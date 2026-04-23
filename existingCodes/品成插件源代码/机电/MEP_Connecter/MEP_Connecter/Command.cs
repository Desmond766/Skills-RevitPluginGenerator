using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.IO;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;

namespace MEP_Connecter
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //Reference r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "请选择要旋转的三通");
            //FamilyInstance familyinstance = doc.GetElement(r0) as FamilyInstance;
            //Location location = familyinstance.Location;
            //LocationPoint locationPoint = location as LocationPoint;
            //XYZ familyinstancePoint = locationPoint.Point;

            Reference r1 = sel.PickObject(ObjectType.Element, "请选择要与三通连接的支管");
            MEPCurve mepCurve1 = doc.GetElement(r1) as MEPCurve;
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            XYZ r1point0 = mepLine1.GetEndPoint(0);
            XYZ r1point1 = mepLine1.GetEndPoint(1);
            Line line1 = Line.CreateBound(r1point0, r1point1);

            Reference r2 = sel.PickObject(ObjectType.Element, "请选择要与三通连接的支管");
            MEPCurve mepCurve2 = doc.GetElement(r2) as MEPCurve;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
            XYZ r2point0 = mepLine2.GetEndPoint(0);
            XYZ r2point1 = mepLine2.GetEndPoint(1);
            Line line2 = Line.CreateBound(r2point0, r2point1);

            Curve curve1 = line1 as Curve;
            Curve curve2 = line1 as Curve;
            curve1.MakeUnbound();//unbound绑定
            curve2.MakeUnbound();
            XYZ xyz = null;
            xyz = IntersectionPoint(line1, line2);
            TaskDialog.Show("a", xyz.ToString());

            //var ductList = GetMainDuct(mepCurve1, mepCurve2);
            //MEPCurve MainDuct = ductList[0];//the main Pipe
            //MEPCurve LessDuct = ductList[1];// the minor Pipe
            //MEPCurve duct3 = null;//the main pipe
            //MEPCurve duct4 = null;//the main pipe
            IntersectionResultArray intersectPoint = new IntersectionResultArray();
            var x = curve1.Intersect(curve2, out intersectPoint);
            if (x == SetComparisonResult.Overlap)
            {
                using (Transaction tran = new Transaction(doc))
                {
                    tran.Start("1033067630");

                    var OrginPoint = intersectPoint.get_Item(0).XYZPoint;

                    Split(doc, mepCurve1, OrginPoint);

                    //duct3 = doc.GetElement(list[0]) as MEPCurve;
                    //duct4 = doc.GetElement(list[1]) as MEPCurve;
                    tran.Commit();
                }
            }

            //ConnectTwoDuctsWithElbow(doc, duct3, duct4, LessDuct);

            //using (Transaction t = new Transaction(doc, "旋转三通"))
            //{
            //    t.Start();
            //    Utils.DrawModelCurve(doc, xyz, familyinstancePoint);
            //    t.Commit();
            //}


            return Result.Succeeded;
        }



        //取得两条线段的交点，直线延长线上的相交不算。
        public XYZ IntersectionPoint(Line line1, Line line2)
        {
            IntersectionResultArray intersectionR = new IntersectionResultArray();
            SetComparisonResult comparisonR;
            comparisonR = line1.Intersect(line2, out intersectionR);
            XYZ intersectionResult = null;
            if (SetComparisonResult.Disjoint != comparisonR)//Disjoint不交
            {
                if (!intersectionR.IsEmpty)//两条直线如果重复为一条直线，这里也为空
                {
                    intersectionResult = intersectionR.get_Item(0).XYZPoint;
                }
            }
            return intersectionResult;
        }

        //取得两条直线的交点
        public XYZ IntersectionPoint(Curve curve1, Curve curve2)
        {
            IntersectionResultArray intersectionR = new IntersectionResultArray();
            SetComparisonResult comparisonR;
            comparisonR = curve1.Intersect(curve2, out intersectionR);
            XYZ intersectionResult = null;
            if (SetComparisonResult.Disjoint != comparisonR)//Disjoint不交
            {
                //if (!intersectionR.IsEmpty)//两条直线如果重复为一条直线，这里也为空
                //{
                intersectionResult = intersectionR.get_Item(0).XYZPoint;
                //}
            }
            return intersectionResult;
        }

        /// <summary>
        /// 区分主要管道与次要管道
        /// </summary>
        /// <param name="duct1"></param>
        /// <param name="duct2"></param>
        /// <returns></returns>
        public static List<MEPCurve> GetMainDuct(MEPCurve duct1, MEPCurve duct2)
        {
            List<MEPCurve> mEPCurves = new List<MEPCurve>();

            Curve curve1 = (duct1.Location as LocationCurve).Curve;
            Curve curve2 = (duct2.Location as LocationCurve).Curve;

            List<double> disList = new List<double>();
            double dis = double.MaxValue;
            XYZ pointA1 = curve1.GetEndPoint(0);
            XYZ pointA2 = curve1.GetEndPoint(1);
            XYZ pointB1 = curve2.GetEndPoint(0);
            XYZ pointB2 = curve2.GetEndPoint(1);

            var distance1 = curve2.Distance(pointA1);
            var distance2 = curve2.Distance(pointA2);
            var distance3 = curve1.Distance(pointB1);
            var distance4 = curve1.Distance(pointB2);

            disList.Add(distance1);
            disList.Add(distance2);
            disList.Add(distance3);
            disList.Add(distance4);

            dis = disList.Min();
            var x = disList.IndexOf(dis);

            if (x < 2)
            {
                mEPCurves.Add(duct2);
                mEPCurves.Add(duct1);
                return mEPCurves;
            }
            else
            {
                mEPCurves.Add(duct1);
                mEPCurves.Add(duct2);
                return mEPCurves;
            }

        }

        #region 智能打断
        /// <summary>
        /// 智能打断
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="elem"></param>
        /// <param name="splitPoint"></param>
        public static void Split(Document doc, MEPCurve elem, XYZ splitPoint)
        {
            //List<ElementId> list = new List<ElementId>();
            Line center = (elem.Location as LocationCurve).Curve as Line;
            // 计算关键点
            XYZ startPoint = center.GetEndPoint(0);
            XYZ endPoint = center.GetEndPoint(1);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(elem, startPoint);
            Connector endConn = Utils.FindConnectedTo(elem, endPoint);

            if (elem is Pipe)
            {
                Pipe originalPipe = elem as Pipe;
                // 绘制第一段
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(doc, originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, startConn, splitPoint);
                }
                else
                {
                    startPipe = Pipe.Create(doc, originalPipe.MEPSystem.GetTypeId(), originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, startPoint, splitPoint);
                }
                Utils.CopyParameters(originalPipe, startPipe);
                // 绘制第二段
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(doc, originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, endConn, splitPoint);
                }
                else
                {
                    endPipe = Pipe.Create(doc, originalPipe.MEPSystem.GetTypeId(), originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, endPoint, splitPoint);
                }
                Utils.CopyParameters(originalPipe, endPipe);
                // 删除原管
                doc.Delete(originalPipe.Id);
                //list.Add(startPipe.Id);
                //list.Add(endPipe.Id);
            }
            if (elem is Duct)
            {
                Duct originalDuct = elem as Duct;
                // 绘制第一段
                Duct startDuct = Duct.Create(doc, originalDuct.MEPSystem.GetTypeId(), originalDuct.DuctType.Id, originalDuct.ReferenceLevel.Id, startPoint, splitPoint);
                Utils.CopyParameters(originalDuct, startDuct);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }
                // 绘制第二段
                Duct endDuct = Duct.Create(doc, originalDuct.MEPSystem.GetTypeId(), originalDuct.DuctType.Id, originalDuct.ReferenceLevel.Id, endPoint, splitPoint);
                Utils.CopyParameters(originalDuct, endDuct);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 删除原管
                doc.Delete(originalDuct.Id);
                //list.Add(startDuct.Id);
                //list.Add(endDuct.Id);
            }
            if (elem is CableTray)
            {
                CableTray originalCableTray = elem as CableTray;
                // 绘制第一段
                CableTray startCableTray = CableTray.Create(doc, originalCableTray.GetTypeId(), startPoint, splitPoint, originalCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalCableTray, startCableTray);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startCableTray, startPoint));
                }
                // 绘制第二段
                CableTray endCableTray = CableTray.Create(doc, originalCableTray.GetTypeId(), endPoint, splitPoint, originalCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalCableTray, endCableTray);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endCableTray, endPoint));
                }
                // 删除原管
                doc.Delete(originalCableTray.Id);
                // list.Add(startCableTray.Id);
                // list.Add(endCableTray.Id);
            }
            if (elem is Conduit)
            {
                Conduit originalConduit = elem as Conduit;
                // 绘制第一段
                Conduit startConduit = Conduit.Create(doc, originalConduit.GetTypeId(), startPoint, splitPoint, originalConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalConduit, startConduit);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }
                // 绘制第二段
                Conduit endConduit = Conduit.Create(doc, originalConduit.GetTypeId(), endPoint, splitPoint, originalConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalConduit, endConduit);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 删除原管
                doc.Delete(originalConduit.Id);
                //list.Add(startConduit.Id);
                // list.Add(endConduit.Id);
            }
            //return list;

        }
        #endregion

        /// <summary>
        /// 创建连接
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="duct1">主要管道1</param>
        /// <param name="duct2">主要管道2</param>
        /// <param name="duct3">次要管道</param>
        public static void ConnectTwoDuctsWithElbow(Document doc, MEPCurve duct1, MEPCurve duct2, MEPCurve duct3)
        {
            double minDistance = double.MaxValue;
            Connector connector1, connector2, connector3;
            connector1 = connector2 = connector3 = null;

            foreach (Connector con1 in duct1.ConnectorManager.Connectors)
            {
                foreach (Connector con2 in duct2.ConnectorManager.Connectors)
                {
                    var dis = con1.Origin.DistanceTo(con2.Origin);
                    if (dis < minDistance)
                    {
                        minDistance = dis;
                        connector1 = con1;
                        connector2 = con2;
                    }

                }
            }

            minDistance = double.MaxValue;//重置
            foreach (Connector con3 in duct3.ConnectorManager.Connectors)
            {
                var dis = con3.Origin.DistanceTo(connector1.Origin);
                if (dis < minDistance)
                {
                    minDistance = dis;
                    connector3 = con3;
                }
            }


            if (connector1 != null && connector2 != null && connector3 != null)
            {
                using (Transaction tran = new Transaction(doc))
                {
                    tran.Start("xx");

                    var elbow = doc.Create.NewTeeFitting(connector1, connector2, connector3);

                    tran.Commit();
                }
            }
        }







        class FamilyinstanceSelectionFilter : ISelectionFilter
        {
            public bool AllowElement(Element elem)
            {
                if (elem is FamilyInstance)
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
}
