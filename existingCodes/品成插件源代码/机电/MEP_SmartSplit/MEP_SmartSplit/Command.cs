//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
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

namespace MEP_SmartSplit
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion
        

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            Reference r;
            MEPCurve e;
            XYZ splitPoint;
            while (true)
            {
                try
                {
                    // 拾取构件
                    r = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    e = doc.GetElement(r) as MEPCurve;
                    splitPoint = Utils.GetProjectivePoint((e.Location as LocationCurve).Curve as Line, r.GlobalPoint);
                    // Split
                    using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartSplit"))
                    {
                        t.Start();
                        Split(doc, e, splitPoint);
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
        public static void Split(Document doc, MEPCurve elem, XYZ splitPoint)
        {
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
            }
        }
        #endregion

        #region 找到不同盘符的共享盘
        /// <summary>
        /// 找到不同盘符的共享盘
        /// </summary>
        /// <param name="specifiedPath">指定的路径</param>
        /// <returns>大家电脑上可以识别到的路径</returns>
        public static string SharedPath(string path)
        {
            //列出用户共享盘可能的盘符
            List<string> strList = new List<string>()
        {
            "A", "B", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            for (int i = 0; i < strList.Count; i++)
            {
                string SharePath = path.Replace("X", strList[i]);
                if (Directory.Exists(SharePath))
                {
                    path = SharePath;
                    break;
                }
            }
            return path;
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