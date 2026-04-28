using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Forms;

//TODOLIST
//1支管上是变径的情况
//2四通变三通

namespace MEP_SmartMove
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private XYZ _planeNormal;
        private Dictionary<int, Element> _mainDict = new Dictionary<int, Element>();//干管构件
        private Dictionary<int, Element> _branchDict = new Dictionary<int, Element>();//支管构件
        List<Tuple<Connector, Connector>> _toConnect = new List<Tuple<Connector, Connector>>();//待连接的连接件

        private double _distance = 4000 / 304.8;//移动距离

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选择管线
            Reference reference = sel.PickObject(ObjectType.Element,
                new MEPCurveSelectionFilter(), "请选择一根管线进行移动！");
            Element element = doc.GetElement(reference);

            //添加第一个
            _mainDict.Add(element.Id.IntegerValue, element);

            MEPCurve mep = element as MEPCurve;
            Line mepLine = (mep.Location as LocationCurve).Curve as Line;
            _planeNormal = mepLine.Direction.CrossProduct(XYZ.BasisZ).Normalize();

            //绘制模型线判断方向
            ModelCurve modelCurve = null;
            using (Transaction t = new Transaction(doc, "createModelCurve"))
            {
                t.Start();
                modelCurve = Utils.DrawModelCurve(doc, reference.GlobalPoint, reference.GlobalPoint + _planeNormal * 3);
                t.Commit();
            }

            //弹出对话框
            FrmSetting fs = new FrmSetting();
            if (DialogResult.OK != fs.ShowDialog())
            {
                return Result.Cancelled;
            }
            if (fs.Distance < 0)
            {
                _planeNormal *= -1;
            }
            _distance = Math.Abs(fs.Distance);

            //删除模型线
            using (Transaction t = new Transaction(doc, "deleteModelCurve"))
            {
                t.Start();
                doc.Delete(modelCurve.Id);
                t.Commit();
            }

            //递归寻找干管构件、支管管件
            FindConnectTo(element);

            //根据移动距离判断是否需要另外处理
            using (Transaction t = new Transaction(doc, "SmartMove"))
            {
                t.Start();
                foreach (var item in _branchDict)
                {
                    MoveWithFitting(doc, item.Value as MEPCurve);
                }
                //移动
                ElementTransformUtils.MoveElement(doc, element.Id, _planeNormal * _distance);//TODO
                //连接连接件
                foreach (var item in _toConnect)
                {
                    try
                    {
                        item.Item1.ConnectTo(item.Item2);
                    }
                    catch (Exception)
                    {
                        //TODO
                    }
                }
                t.Commit();
            }


            ////选中
            //if (_mainDict.Count > 0)
            //{
            //    List<ElementId> ids = new List<ElementId>();
            //    foreach (var item in _mainDict)
            //    {
            //        ids.Add(new ElementId(item.Key));
            //    }
            //    sel.SetElementIds(ids);
            //}

            //if (_branchDict.Count > 0)
            //{
            //    List<ElementId> ids = new List<ElementId>();
            //    foreach (var item in _branchDict)
            //    {
            //        ids.Add(new ElementId(item.Key));
            //    }
            //    sel.SetElementIds(ids);
            //}

            return Result.Succeeded;
        }

        //递归寻找干管构件、支管管件
        private void FindConnectTo(Element elem)
        {
            ConnectorSet connectors = Utils.GetConSet(elem);
            foreach (Connector conn in connectors)
            {
                ConnectorSet connSet = conn.AllRefs;
                foreach (Connector conn2 in connSet)
                {
                    int id = conn2.Owner.Id.IntegerValue;
                    //找到连接到的构件
                    if (id != elem.Id.IntegerValue
                    && conn2.ConnectorType != ConnectorType.Logical)
                    {
                        //如果是管线
                        if (conn2.Owner is MEPCurve)
                        {
                            Line mepLine = ((conn2.Owner as MEPCurve).Location as LocationCurve).Curve as Line;
                            //如果管线在平面内
                            if (IsOnThePlane(mepLine.Direction))
                            {
                                if (!_mainDict.ContainsKey(id))
                                {
                                    _mainDict.Add(id, conn2.Owner);
                                    //继续找
                                    FindConnectTo(conn2.Owner);
                                }
                            }
                            else
                            {
                                //如果管线不在平面内，则是遇到支管
                                if (!_branchDict.ContainsKey(id))
                                {
                                    _branchDict.Add(id, conn2.Owner);
                                }
                            }
                        }
                        else
                        {
                            if (!_mainDict.ContainsKey(id))
                            {
                                _mainDict.Add(id, conn2.Owner);
                                //继续找
                                FindConnectTo(conn2.Owner);
                            }
                        }
                    }
                }
            }
        }

        //判断向量，是否与当前面共面
        private bool IsOnThePlane(XYZ source)
        {
            if (source.Normalize().IsAlmostEqualTo(XYZ.BasisZ) ||
                source.Normalize().IsAlmostEqualTo(XYZ.BasisZ.Negate()))
            {
                return true;
            }
            XYZ n = source.CrossProduct(XYZ.BasisZ).Normalize();
            if (n.IsAlmostEqualTo(_planeNormal)||
                n.IsAlmostEqualTo(_planeNormal.Negate()))
            {
                return true;
            }
            return false;
        }

        //带配件移动
        //仅支持配件为弯头、三通的情况TODO
        private void MoveWithFitting(Document doc, MEPCurve mep)
        {
            //管道上的配件
            List<Element> fittings = Utils.FindConnectedToList(mep);
            //我们称干管连接支管的配件为主配件
            Element mainFitting = null;
            Element subFitting = null;
            if (fittings.Count == 0)
            {
                return;
            }
            //至少有一个配件为主配件，才能找到支管
            else if (fittings.Count == 1)
            {
                mainFitting = fittings[0];
            }
            else//fittings.Count == 2
            {
                foreach (Element item in fittings)
                {
                    //主配件在干管构件里
                    if (_mainDict.ContainsKey(item.Id.IntegerValue))
                    {
                        mainFitting = item;
                    }
                    else
                    {
                        subFitting = item;
                    }
                }
            }

            //关键定位点
            XYZ mainFittingCenter = (mainFitting.Location as LocationPoint).Point;
            XYZ mepStart;//mep起点
            XYZ mepEnd;//mep终点
            Line line = (mep.Location as LocationCurve).Curve as Line;
            if (line.GetEndPoint(0).DistanceTo(mainFittingCenter) <
                line.GetEndPoint(1).DistanceTo(mainFittingCenter))
            {
                mepStart = line.GetEndPoint(0);
                mepEnd = line.GetEndPoint(1);
            }
            else
            {
                mepStart = line.GetEndPoint(1);
                mepEnd = line.GetEndPoint(0);
            }

            //如果支管方向与移动方向相反，不需要处理
            if ((mepStart + _planeNormal).DistanceTo(mepEnd) > line.Length)
            {
                return;
            }
            else//如果方向相同，但是移动距离小于支管长度，也不需要处理
            {
                if (_distance < line.Length)//TODO 也没什么能够处理的
                {
                    return;
                }
            }
            //其他情况，即同方向，移动距离又大于，才需要处理

            //延伸点
            XYZ extendStart = FindExtendEnd(mainFitting);
            XYZ extendEnd = mepEnd;

            //镜像配件
            Element mainFittingMirrored = MirrorFitting(doc, mainFitting);
            Element subFittingMirrored = null;
            if (null != subFitting)
            {
                extendEnd = FindExtendEnd(subFitting);
                subFittingMirrored = MirrorFitting(doc, subFitting);
            }

            //移动后的起点、终点
            XYZ mepStartMirrored = Transform.CreateReflection(new Plane(_planeNormal, extendStart)).OfPoint(mepStart);
            XYZ newStart = Transform.CreateTranslation(_planeNormal * _distance).OfPoint(mepStartMirrored);
            XYZ newEnd = Transform.CreateReflection(new Plane(_planeNormal, extendEnd)).OfPoint(mepEnd);

            //创建管道
            MEPCurve newCurve = MEPHelper.Create(doc, mep, newStart, newEnd);

            //存储待连接连接件
            Connector con1 = Utils.FindConnector(mainFittingMirrored, mepStartMirrored);
            Connector con2 = Utils.FindConnector(newCurve, newStart);
            _toConnect.Add(new Tuple<Connector, Connector>(con1, con2));
            if (null != subFittingMirrored)
            {
                Connector con3 = Utils.FindConnector(subFittingMirrored, newEnd);
                Connector con4 = Utils.FindConnector(newCurve, newEnd);
                _toConnect.Add(new Tuple<Connector, Connector>(con3, con4));
            }
        }

        //镜像配件
        private Element MirrorFitting(Document doc, Element fitting)
        {
            //如果是镜像变径，交给另外一个方法
            if (IsReducer(fitting))
            {
                return MirrorReducer(doc, fitting);
            }

            //【1】中心点
            XYZ center = (fitting.Location as LocationPoint).Point;//TODO LocationPoint 不在中心的情况！

            //【2】镜像配件
            Element fittingMirrored = MyMirrorElement(doc, fitting, new Plane(_planeNormal, center));

            //【3】镜像后的配件要重新连接上配件原先连接的管道
            Dictionary<XYZ, Connector> fittingConnectedToDict
                = new Dictionary<XYZ, Connector>();
            foreach (var item in Utils.GetConList(fitting))
            {
                //原配件如果有连构件
                var con = Utils.FindConnectedTo(fitting, item.Origin);
                if (null != con)
                {
                    fittingConnectedToDict.Add(item.Origin, con);
                }
            }
            foreach (var con in Utils.GetConList(fittingMirrored))
            {
                foreach (var d in fittingConnectedToDict)
                {
                    if (con.Origin.IsAlmostEqualTo(d.Key))
                    {
                        con.ConnectTo(d.Value);
                    }
                }
            }

            //【4】删除配件
            doc.Delete(fitting.Id);

            return fittingMirrored;
        }

        //判断是否是变径
        private bool IsReducer(Element fitting)
        {
            List<Connector> conList = Utils.GetConList(fitting);
            if (conList.Count == 2)
            {
                if (conList[0].Shape == ConnectorProfileType.Round 
                    && conList[1].Shape == ConnectorProfileType.Round)
                {
                    if (Math.Abs(conList[0].Radius - conList[1].Radius) > 0.001)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        //镜像变径
        private Element MirrorReducer(Document doc, Element reducer)
        {
            //找到变径连接的弯头
            Element elbow = null;
            foreach (var item in Utils.FindConnectedToList(reducer))
            {
                //变径一端连着支管，一段连着弯头
                if (!_branchDict.ContainsKey(item.Id.IntegerValue))
                {
                    if (!(item is MEPCurve))
                    {
                        elbow = item;
                        break;
                    }
                }
            }
            if (null == elbow)
            {
                return null;
            }

            //【1】中心点
            XYZ center = (elbow.Location as LocationPoint).Point;//TODO LocationPoint 不在中心的情况！

            //【2】镜像配件
            IList<ElementId> mirrored = ElementTransformUtils.MirrorElements(
                        doc, new List<ElementId>() { reducer.Id, elbow.Id }, new Plane(_planeNormal, center), true);
            //【3】镜像后的配件
            Element reducerMirrored = null;
            Element elbowMirrored = null;
            foreach (var item in mirrored)
            {
                if (doc.GetElement(item) is Instance)
                {
                    if (IsReducer(doc.GetElement(item)))
                    {
                        reducerMirrored = doc.GetElement(item);
                    }
                    else
                    {
                        elbowMirrored = doc.GetElement(item);
                    }
                }
            }

            //【4】镜像后的配件要重新连接上配件原先连接的管道
            Dictionary<XYZ, Connector> fittingConnectedToDict
                = new Dictionary<XYZ, Connector>();
            foreach (var item in Utils.GetConList(elbow))
            {
                //原配件如果有连构件
                var con = Utils.FindConnectedTo(elbow, item.Origin);
                if (null != con)
                {
                    if (con.Owner.Id.IntegerValue != reducer.Id.IntegerValue)
                    {
                        fittingConnectedToDict.Add(item.Origin, con);
                    }
                }
            }
            foreach (var con in Utils.GetConList(elbowMirrored))
            {
                foreach (var d in fittingConnectedToDict)
                {
                    if (con.Origin.IsAlmostEqualTo(d.Key))
                    {
                        con.ConnectTo(d.Value);
                    }
                }
            }

            //【5】删除配件
            doc.Delete(reducer.Id);
            doc.Delete(elbow.Id);

            return reducerMirrored;
        }

        //找碰撞构件
        private List<Element> FindInterset(Document doc, Element elem)
        {

            return new FilteredElementCollector(doc, doc.ActiveView.Id)
                .WherePasses(new ElementIntersectsElementFilter(elem)).ToElements().ToList();
        }

        //带返回值的镜像
        private Element MyMirrorElement(Document doc, Element elem, Plane plane)
        {
            IList<ElementId> mirrored = ElementTransformUtils.MirrorElements(
                        doc, new List<ElementId>() { elem.Id }, plane, true);
            foreach (var item in mirrored)
            {
                if (null != doc.GetElement(item))
                {
                    if (doc.GetElement(item) is Instance)
                    {
                        return doc.GetElement(item);
                    }
                }
            }
            return null;
        }

        //寻找延伸端点
        private XYZ FindExtendEnd(Element fitting)
        {
            XYZ pt = (fitting.Location as LocationPoint).Point;
            if (IsReducer(fitting))
            {
                foreach (var item in Utils.FindConnectedToList(fitting))
                {
                    if (!(item is MEPCurve))
                    {
                        pt = (item.Location as LocationPoint).Point;
                    }
                } 
            }
            return pt;
        }

    }
}
