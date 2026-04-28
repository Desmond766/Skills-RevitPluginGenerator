# Sample Snippet: MEP_TagHelper

Source project: `existingCodes\品成插件源代码\机电\MEP_TagHelper\MEP_TagHelper`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;

namespace MEP_TagHelper
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

    //        #region 判断加密
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }
    //        #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //【1】判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            while (true)
            {

                //【2】选择三点————————————————————————————————————————————————————————————————————————————————————————————————————————————————
                XYZ pt1 = XYZ.Zero;
                XYZ pt2 = XYZ.Zero;
                XYZ pt3 = XYZ.Zero;
                try
                {
                    pt1 = sel.PickPoint();
                    pt2 = sel.PickPoint();
                    pt3 = sel.PickPoint();
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "结束布置");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }

                //根据三点创建拉伸Solid
                Solid solid = null;
                try
                {
                    pt1 = new XYZ(pt1.X, pt1.Y, -20000 / 304.8);
                    pt2 = new XYZ(pt2.X, pt2.Y, -20000 / 304.8);
                    pt3 = new XYZ(pt3.X, pt3.Y, -20000 / 304.8);
                    XYZ pt4 = pt2 + (pt3 - pt2).Normalize() * 10 / 304.8;

                    Curve c1 = Line.CreateBound(pt1, pt2);
                    Curve c2 = Line.CreateBound(pt2, pt4);
                    Curve c3 = Line.CreateBound(pt4, pt1);
                    List<Curve> curveList = new List<Curve>() { c1, c2, c3 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    List<CurveLoop> curveLoopList = new List<CurveLoop>() { curveLoop };
                    //向上拉伸5000
                    solid = GeometryCreationUtilities.CreateExtrusionGeometry(curveLoopList, XYZ.BasisZ, 500000.0 / 304.8);
                }
                catch
                {
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MEP_TagHelper
{
    class Utils
    {
        #region 判断点p(x,y)在两点p1(x1,y1),p2(x2,y2)的左边还是右边
        public static bool LeftOfLine(XYZ p, XYZ p1, XYZ p2)
        {
            double tmpx = (p1.X - p2.X) / (p1.Y - p2.Y) * (p.Y - p2.Y) + p2.X;

            if (tmpx > p.X)//当tmpx>p.X的时候，说明点在线的左边，小于在右边，等于则在线上。
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion


        #region 根据族名称找族下某类型名称ID

        public static ElementId FindTypeIdByFamilyName(Document doc, string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

        }

        #endregion

        #region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        public static XYZ GetProjectivePoint(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        {
            XYZ pLine = new XYZ();
            double k = (standardEndPoint.Y - standardStartPoint.Y) / (standardEndPoint.X - standardStartPoint.X);
            if (Math.Abs(k) < 0.1) //if (k == 0)
            {
                pLine = new XYZ(modifyStartPoint.X, standardStartPoint.Y, modifyStartPoint.Z);

            }
            else if (Math.Abs(standardEndPoint.X - standardStartPoint.X) < 0.1)
            {
                pLine = new XYZ(standardEndPoint.X, modifyStartPoint.Y, modifyStartPoint.Z);
            }
            else
            {
                double x = (k * (standardStartPoint.X) + ((modifyStartPoint.X) / k) + modifyStartPoint.Y - standardStartPoint.Y) / (1 / k + k);
                double y = -1 / k * (x - modifyStartPoint.X) + modifyStartPoint.Y;
                pLine = new XYZ(x, y, modifyStartPoint.Z);

            }
            return pLine;
        }

        #endregion
// ... truncated ...
```

