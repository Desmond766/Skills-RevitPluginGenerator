using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;
using System.IO;

namespace MEP_SmartSplitTwo
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            Reference r1;
            Reference r2;
            MEPCurve e1;
            MEPCurve e2;
            XYZ splitPoint1;
            XYZ splitPoint2;
            while (true)
            {
                try
                {
                    // 拾取构件
                    r1 = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    e1 = doc.GetElement(r1) as MEPCurve;
                    splitPoint1 = Utils.GetProjectivePoint((e1.Location as LocationCurve).Curve as Line, r1.GlobalPoint);

                    r2 = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    e2 = doc.GetElement(r2) as MEPCurve;
                    splitPoint2 = Utils.GetProjectivePoint((e2.Location as LocationCurve).Curve as Line, r2.GlobalPoint);
                    // Split
                    using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartSplit"))
                    {
                        t.Start();
                        Split(doc, e1, splitPoint1, splitPoint2);
                        t.Commit();
                    }
                }
                catch
                {
                    break;
                }
            }



            return Result.Succeeded;
        }

        #region 智能打断
        /// <summary>
        /// 智能打断
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="elem"></param>
        /// <param name="splitPoint"></param>
        public static void Split(Document doc, MEPCurve elem, XYZ splitPoint1, XYZ splitPoint2)
        {
            Line center = (elem.Location as LocationCurve).Curve as Line;
            // 计算关键点
            XYZ startPoint = center.GetEndPoint(0);
            XYZ endPoint = center.GetEndPoint(1);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(elem, startPoint);
            Connector endConn = Utils.FindConnectedTo(elem, endPoint);

            XYZ splitPoint11;
            XYZ splitPoint22;
            double distance1 = splitPoint1.DistanceTo(startPoint);
            double distance2 = splitPoint2.DistanceTo(startPoint);
            if (distance1 < distance2)
            {
                splitPoint11 = splitPoint1;
                splitPoint22 = splitPoint2;
            }
            else
            {
                splitPoint11 = splitPoint2;
                splitPoint22 = splitPoint1;
            }

            if (elem is Pipe)
            {
                Pipe originalPipe = elem as Pipe;
                // 绘制第一段
                Pipe startPipe = null;
                if (null != startConn)
                {
                    startPipe = Pipe.Create(doc, originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, startConn, splitPoint11);
                }
                else
                {
                    startPipe = Pipe.Create(doc, originalPipe.MEPSystem.GetTypeId(), originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, startPoint, splitPoint11);
                }
                Utils.CopyParameters(originalPipe, startPipe);
                // 绘制第二段
                Pipe endPipe = null;
                if (null != endConn)
                {
                    endPipe = Pipe.Create(doc, originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, endConn, splitPoint22);
                }
                else
                {
                    endPipe = Pipe.Create(doc, originalPipe.MEPSystem.GetTypeId(), originalPipe.PipeType.Id, originalPipe.ReferenceLevel.Id, endPoint, splitPoint22);
                }
                Utils.CopyParameters(originalPipe, endPipe);
                // 删除原管
                doc.Delete(originalPipe.Id);
            }
            if (elem is Duct)
            {
                Duct originalDuct = elem as Duct;
                // 绘制第一段
                Duct startDuct = Duct.Create(doc, originalDuct.MEPSystem.GetTypeId(), originalDuct.DuctType.Id, originalDuct.ReferenceLevel.Id, startPoint, splitPoint11);
                Utils.CopyParameters(originalDuct, startDuct);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startDuct, startPoint));
                }
                // 绘制第二段
                Duct endDuct = Duct.Create(doc, originalDuct.MEPSystem.GetTypeId(), originalDuct.DuctType.Id, originalDuct.ReferenceLevel.Id, endPoint, splitPoint22);
                Utils.CopyParameters(originalDuct, endDuct);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endDuct, endPoint));
                }
                // 删除原管
                doc.Delete(originalDuct.Id);
            }
            if (elem is CableTray)
            {
                CableTray originalCableTray = elem as CableTray;
                // 绘制第一段
                CableTray startCableTray = CableTray.Create(doc, originalCableTray.GetTypeId(), startPoint, splitPoint11, originalCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalCableTray, startCableTray);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startCableTray, startPoint));
                }
                // 绘制第二段
                CableTray endCableTray = CableTray.Create(doc, originalCableTray.GetTypeId(), endPoint, splitPoint22, originalCableTray.ReferenceLevel.Id);
                Utils.CopyParameters(originalCableTray, endCableTray);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endCableTray, endPoint));
                }
                // 删除原管
                doc.Delete(originalCableTray.Id);
            }
            if (elem is Conduit)
            {
                Conduit originalConduit = elem as Conduit;
                // 绘制第一段
                Conduit startConduit = Conduit.Create(doc, originalConduit.GetTypeId(), startPoint, splitPoint11, originalConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalConduit, startConduit);
                if (null != startConn)
                {
                    startConn.ConnectTo(Utils.FindConnector(startConduit, startPoint));
                }
                // 绘制第二段
                Conduit endConduit = Conduit.Create(doc, originalConduit.GetTypeId(), endPoint, splitPoint22, originalConduit.ReferenceLevel.Id);
                Utils.CopyParameters(originalConduit, endConduit);
                if (null != endConn)
                {
                    endConn.ConnectTo(Utils.FindConnector(endConduit, endPoint));
                }
                // 删除原管
                doc.Delete(originalConduit.Id);
            }
        }

        #endregion
    }
    #region MEPSelectionFilter
    public class MEPSelectionFilter : ISelectionFilter
    {
        public bool AllowElement(Element element)
        {
            if (element is Pipe || element is Duct || element is CableTray || element is Conduit)
            {
                return true;
            }
            return false;
        }
        public bool AllowReference(Reference refer, XYZ point)
        {
            return false;
        }
    }
    #endregion
}
