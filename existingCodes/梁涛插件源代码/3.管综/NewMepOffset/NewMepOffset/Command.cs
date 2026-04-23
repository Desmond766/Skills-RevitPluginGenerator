using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 成排管线翻弯点对齐
namespace NewMepOffset
{
    // 框选管线进行批量翻弯
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //var reference = sel.PickObject(ObjectType.Element, new MEPCurveFilter());
            //var selres = doc.GetElement(reference) as MEPCurve;
            //Line line1 = (selres.Location as LocationCurve).Curve as Line;
            //XYZ sel1 = sel.PickPoint();
            //sel1 = line1.Project(sel1).XYZPoint;
            
            //XYZ sel2 = sel.PickPoint();
            //sel2 = line1.Project(sel2).XYZPoint;
            //using (Transaction t = new Transaction(doc, "Create"))
            //{
            //    t.Start();

            //    BreakMEPCurves(doc, selres, sel1, sel2);

            //    t.Commit();
            //}
            //return Result.Succeeded;

            KeyBoardEvent keyBoardEvent = new KeyBoardEvent();
            keyBoardEvent.startListen();

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                keyBoardEvent.stopListen();
                return Result.Cancelled;
            }

            double offset = mainWindow.Dis; // 偏移高度
            double angle = Properties.Settings.Default.Angle; // 弯通角度
            bool upDown = Properties.Settings.Default.UpDown; // 升降偏移
            bool singleSide = Properties.Settings.Default.SingleSide; // 单侧两侧
            XYZ upDir;


        Next:
            List<Reference> references;
            XYZ point1;
            XYZ point2;
            try
            {
                references = sel.PickObjects(ObjectType.Element, new MEPCurveFilter(), "框选管线(按下空格键以完成框选)").ToList();
                point1 = sel.PickPoint("选择翻弯点");
                point2 = sel.PickPoint(singleSide == true ? "选择翻弯方向" : "选择翻弯点2");
            }
            catch (Exception)
            {
                keyBoardEvent.stopListen();
                TaskDialog.Show("Revit", "结束布置");
                return Result.Succeeded;
            }
            List<MEPCurve> mEPCurves = references.Select(x => doc.GetElement(x) as MEPCurve).ToList();
            using (Transaction t = new Transaction(doc, "管线避让"))
            {
                t.Start();

                foreach (var mep in mEPCurves)
                {

                    Line mepLine = mep.GetLine();
                    Line ubMepLine = mepLine.Clone() as Line;
                    ubMepLine.MakeUnbound();

                    // 获取选择的管道的方向
                    XYZ newPoint1 = mepLine.Project(point1).XYZPoint;
                    XYZ dir = (ubMepLine.Project(point2).XYZPoint - mepLine.Project(point1).XYZPoint).Normalize();
                    // 获取管道升降/偏移的方向
                    if (upDown)
                    {
                        upDir = XYZ.BasisZ;
                    }
                    else
                    {
                        upDir = dir.CrossProduct(XYZ.BasisZ).Normalize();
                    }

                    if (!singleSide)
                    {
                        XYZ newPoint2 = mepLine.Project(point2).XYZPoint;
                        BreakMEPCurves(doc, mep, newPoint1, newPoint2, out MEPCurve centerCurve, out MEPCurve otherCurve);

                        XYZ verMove = upDir * offset;
                        XYZ horMove = dir * (Math.Abs(offset) / Math.Tan(Math.PI * angle / 180));
                        centerCurve.Location.Move(verMove);
                        if (angle != 90)
                        {
                            centerCurve.Location.Move(horMove);
                            if (centerCurve.GetLine().Direction.IsAlmostEqualTo(dir))
                            {
                                (centerCurve.Location as LocationCurve).Curve = Line.CreateBound(centerCurve.GetLine().GetEndPoint(0), centerCurve.GetLine().GetEndPoint(1) - horMove * 2);
                            }
                            else if (centerCurve.GetLine().Direction.IsAlmostEqualTo(dir.Negate()))
                            {
                                (centerCurve.Location as LocationCurve).Curve = Line.CreateBound(centerCurve.GetLine().GetEndPoint(0) - horMove * 2, centerCurve.GetLine().GetEndPoint(1));
                            }
                        }
                        Element verElem1 = doc.GetElement(ElementTransformUtils.CopyElement(doc, mep.Id, XYZ.Zero).First());
                        Element verElem2 = doc.GetElement(ElementTransformUtils.CopyElement(doc, mep.Id, XYZ.Zero).First());
                        (verElem1.Location as LocationCurve).Curve = Line.CreateBound(centerCurve.GetLine().GetEndPoint(0), mep.GetLine().GetEndPoint(1));
                        (verElem2.Location as LocationCurve).Curve = Line.CreateBound(otherCurve.GetLine().GetEndPoint(0), centerCurve.GetLine().GetEndPoint(1));
                        // 连接
                        try
                        {
                            doc.Create.NewElbowFitting(verElem1.GetConnector(0), centerCurve.GetConnector(0));
                            doc.Create.NewElbowFitting(verElem1.GetConnector(1), mep.GetConnector(1));
                            doc.Create.NewElbowFitting(verElem2.GetConnector(0), otherCurve.GetConnector(0));
                            doc.Create.NewElbowFitting(verElem2.GetConnector(1), centerCurve.GetConnector(1));
                        }
                        catch (Exception ex)
                        {
                            TaskDialog.Show("Error", ex.Message);
                            if (t.HasStarted()) t.RollBack();
                            break;
                        }
                        
                    }
                    else
                    {
                        // 获取升降/偏移后的新坐标点
                        XYZ newPoint2 = GetCreatePoint(newPoint1, offset, upDir, angle, dir);
                        // 获取升降/偏移后的两条新Line
                        GetNewLines(offset, dir, mepLine, newPoint1, newPoint2, offset * upDir, out Line line, out Line offsetLine, out int changeConId);
                        Line centerLine = Line.CreateBound(newPoint1, newPoint2);
                        //TaskDialog.Show("revit", changeConId.ToString() + "\n" + dir);
                        List<ElementId> ids = new List<ElementId>();
                        GetAllConnect(mep, ref ids, changeConId);

                        ids.Remove(mep.Id);
                        if (ids.Count > 0 && angle != 90) ElementTransformUtils.MoveElements(doc, ids, offset * upDir + dir * (Math.Abs(offset) / Math.Tan(Math.PI * angle / 180)));
                        if (ids.Count > 0 && angle == 90) ElementTransformUtils.MoveElements(doc, ids, offset * upDir);

                        // 先创建对应新管线再连接弯通
                        var id1 = ElementTransformUtils.CopyElement(doc, mep.Id, XYZ.Zero).First();
                        var id2 = ElementTransformUtils.CopyElement(doc, mep.Id, XYZ.Zero).First();
                        MEPCurve newoffsetMep1 = doc.GetElement(id1) as MEPCurve;
                        MEPCurve newcenterMep2 = doc.GetElement(id2) as MEPCurve;

                        Element conElem0;
                        Element conElem1;
                        int? i0;
                        int? i1;
                        // 判断原线管是否与其他元素连接，若连接则先取消连接，后续与新线管重新连接
                        if (mep.IsConnect(0, out conElem0, out i0) /*&& unChangeId != 0*/) conElem0.GetConnector(i0).DisconnectFrom(mep.GetConnector(0));
                        if (mep.IsConnect(1, out conElem1, out i1) /*&& unChangeId != 1*/) conElem1.GetConnector(i1).DisconnectFrom(mep.GetConnector(1));

                        (mep.Location as LocationCurve).Curve = line;
                        (newoffsetMep1.Location as LocationCurve).Curve = offsetLine;
                        (newcenterMep2.Location as LocationCurve).Curve = centerLine;
                        //break;
                        var fit1 = doc.Create.NewElbowFitting(newcenterMep2.GetConnector(0), mep.GetConnector(0));
                        var fit2 = doc.Create.NewElbowFitting(newcenterMep2.GetConnector(1), newoffsetMep1.GetConnector(0));

                        if (conElem0 != null /*&& unChangeId != 0*/)
                        {
                            MEPCurve conMep = conElem0.GetConnector(i0).Origin.GetNearMep(mep, newoffsetMep1);
                            Connector nearCon = conElem0.GetConnector(i0).GetNearUnConConnector(conMep);
                            if (nearCon == null) continue;
                            //conElem0.GetConnector(i0).ConnectTo(nearCon);
                            nearCon.ConnectTo(conElem0.GetConnector(i0));
                        }

                        if (conElem1 != null /*&& unChangeId != 1*/)
                        {
                            MEPCurve conMep = conElem1.GetConnector(i1).Origin.GetNearMep(mep, newoffsetMep1);
                            Connector nearCon = conElem1.GetConnector(i1).GetNearUnConConnector(conMep);
                            if (nearCon == null) continue;
                            //conElem1.GetConnector(i1).ConnectTo(nearCon);
                            nearCon.ConnectTo(conElem1.GetConnector(i1));
                        }

                        ElementTransformUtils.MoveElement(doc, mep.Id, XYZ.BasisX);
                        ElementTransformUtils.MoveElement(doc, mep.Id, XYZ.BasisX.Negate());
                        ElementTransformUtils.MoveElement(doc, newoffsetMep1.Id, XYZ.BasisX);
                        ElementTransformUtils.MoveElement(doc, newoffsetMep1.Id, XYZ.BasisX.Negate());
                    }
                    
                }
                if (!t.HasEnded()) t.Commit();
            }
            goto Next;
        }

        /// <summary>
        /// 两个点 打断
        /// </summary>
        public bool BreakMEPCurves(Document doc, MEPCurve mepCurve1, XYZ breakPoint1, XYZ breakPoint2, out MEPCurve centerCurve, out MEPCurve otherCurve)
        {
            centerCurve = null;
            otherCurve = null;

            Line mepLine = (mepCurve1.Location as LocationCurve).Curve as Line;
            XYZ p0 = mepLine.GetEndPoint(0);
            XYZ p1 = mepLine.GetEndPoint(1);

            XYZ nearP;
            XYZ farP;
            if (p0.DistanceTo(breakPoint1) < p0.DistanceTo(breakPoint2))
            {
                nearP = breakPoint1;
                farP = breakPoint2;
            }
            else
            {
                nearP = breakPoint2;
                farP = breakPoint1;
            }

            ElementId id1 = ElementTransformUtils.CopyElement(doc, mepCurve1.Id, XYZ.Zero).First();
            ElementId id2 = ElementTransformUtils.CopyElement(doc, mepCurve1.Id, XYZ.Zero).First();

            Connector conToConnect = null;
            foreach (var con in mepCurve1.ConnectorManager.Connectors.Cast<Connector>())
            {
                if (con.Id == 1 && con.IsConnected)
                {
                    foreach (Connector conRef in con.AllRefs)
                    {
                        if (conRef.Owner.Id != con.Owner.Id)
                        {
                            con.DisconnectFrom(conRef);
                            doc.Regenerate();
                            conToConnect = conRef;
                            break;
                        }
                    }
                }
            }
            //if (conToConnect == null) return false;
            (mepCurve1.Location as LocationCurve).Curve = Line.CreateBound(p0, nearP);

            MEPCurve mEPCurve2 = doc.GetElement(id1) as MEPCurve;
            (mEPCurve2.Location as LocationCurve).Curve = Line.CreateBound(farP, p1);
            if (conToConnect != null) mEPCurve2.GetConnector(1).ConnectTo(conToConnect);

            MEPCurve mEPCurve3 = doc.GetElement(id2) as MEPCurve;
            (mEPCurve3.Location as LocationCurve).Curve = Line.CreateBound(nearP, farP);

            centerCurve = mEPCurve3;
            otherCurve = mEPCurve2;
            return true;
        }

        /// <summary>
        /// 获取翻弯后的两条Line
        /// </summary>
        /// <param name="mepLine">初始Line</param>
        /// <param name="newPoint1">新创建点1</param>
        /// <param name="newPoint2">新创建点2</param>
        /// <param name="moveDis">移动的距离+方向</param>
        /// <param name="line">变化后的初始管线的Line</param>
        /// <param name="offsetLine">爬升后的管线的Line</param>
        /// <param name="changeConId">坐标点改变的连接器ID</param>
        /// <exception cref="NotImplementedException"></exception>
        private void GetNewLines(double offset, XYZ dir, Line mepLine, XYZ newPoint1, XYZ newPoint2, XYZ moveDis, out Line line, out Line offsetLine, out int changeConId)
        {
            XYZ mep0 = mepLine.GetEndPoint(0);
            XYZ mep1 = mepLine.GetEndPoint(1);

            XYZ newPP2 = mepLine.Project(newPoint2).XYZPoint;
            if (moveDis.Normalize().IsAlmostEqualTo(XYZ.BasisZ) || moveDis.Normalize().IsAlmostEqualTo(XYZ.BasisZ.Negate()))
            {
                if (offset > 0)
                {
                    if (dir.IsAlmostEqualTo(mepLine.Direction))
                    {
                        offsetLine = Line.CreateBound(newPoint2, mep1 + moveDis);
                        line = Line.CreateBound(newPoint1, mep0);
                        changeConId = 1;
                    }
                    else
                    {
                        offsetLine = Line.CreateBound(newPoint2, mep0 + moveDis);
                        line = Line.CreateBound(newPoint1, mep1);
                        changeConId = 0;
                    }
                }
                else
                {
                    if (dir.IsAlmostEqualTo(mepLine.Direction))
                    {
                        offsetLine = Line.CreateBound(newPoint2, mep1 + moveDis);
                        line = Line.CreateBound(newPoint1, mep0);
                        changeConId = 1;
                    }
                    else
                    {
                        offsetLine = Line.CreateBound(newPoint2, mep0 + moveDis);
                        line = Line.CreateBound(newPoint1, mep1);
                        changeConId = 0;
                    }
                }
            }
            else if (newPP2.DistanceTo(mep0) < newPoint1.DistanceTo(mep0))
            {
                offsetLine = Line.CreateBound(newPoint2, mep0 + moveDis);
                line = Line.CreateBound(newPoint1, mep1);
                changeConId = 0;
            }
            else
            {
                offsetLine = Line.CreateBound(newPoint2, mep1 + moveDis);
                line = Line.CreateBound(newPoint1, mep0);
                changeConId = 1;
            }
        }

        /// <summary>
        /// 获取爬升/偏移坐标点
        /// </summary>
        /// <param name="startPoint">起始坐标点</param>
        /// <param name="offset">爬升/偏移长度</param>
        /// <param name="dir">爬升/偏移方向</param>
        /// <param name="angle">爬升/偏移的角度</param>
        /// <param name="moveDir">爬升/偏移移动方向</param>
        /// <returns></returns>
        private XYZ GetCreatePoint(XYZ startPoint, double offset, XYZ dir, double angle, XYZ moveDir)
        {
            XYZ point;
            if (angle == 90)
            {
                point = startPoint + offset * dir;
            }
            else
            {
                point = startPoint + offset * dir + moveDir * (Math.Abs(offset) / Math.Tan(Math.PI * angle / 180));
            }
            return point;
        }
        /// <summary>
        /// 获取单边连接器通路上所有元素ID
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private List<ElementId> GetAllConnect(Element element, ref List<ElementId> ids, int? conId = null)
        {
            List<ElementId> result = new List<ElementId>();
            if (element is FamilyInstance familyInstance)
            {
                if (!ids.Contains(familyInstance.Id)) ids.Add(familyInstance.Id);
                foreach (Connector item in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (!ids.Contains(conRef.Owner.Id))
                            {
                                ids.Add(conRef.Owner.Id);
                                //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                GetAllConnect(conRef.Owner, ref ids);
                            }
                        }
                    }
                }
            }
            else if (element is MEPCurve mEPCurve)
            {
                if (!ids.Contains(mEPCurve.Id)) ids.Add(mEPCurve.Id);
                foreach (Connector item in mEPCurve.ConnectorManager.Connectors)
                {
                    if (conId != null && conId != item.Id) continue;
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (conRef.Owner.Id != item.Owner.Id)
                            {
                                if (!ids.Contains(conRef.Owner.Id))
                                {
                                    ids.Add(conRef.Owner.Id);
                                    //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                    GetAllConnect(conRef.Owner, ref ids);
                                }
                            }
                        }
                    }
                }
            }
            return ids;
        }
    }
    public class MEPCurveFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is MEPCurve curve && (curve.Location as LocationCurve).Curve is Line)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
