# Sample Snippet: MEP_TagHelperForSlope

Source project: `existingCodes\品成插件源代码\机电\MEP_TagHelperForSlope\MEP_TagHelperForSlope`

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

namespace MEP_TagHelperForSlope
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //#region 判断加密
            ////注册验证
            //string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}
            //#endregion

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

            //JL UPDATE 2021-10-18
            //程序在3D 机电视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 机电，命名规则 3D {当前视图名称}
            View3D view3D = null;
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 机电".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 机电 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

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
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MEP_TagHelperForSlope
{
    class Utils
    {
        #region 判断点p(x,y)在两点p1(x1,y1),p2(x2,y2)的左边还是右边
        public static bool LeftOfLine(XYZ p, XYZ p1, XYZ p2)
        {
            //斜率：(p1.X - p2.X) / (p1.Y - p2.Y)
            //找到点p在通过点p2且与p1和p2形成的直线平行的直线上的投影点的横坐标。类似line.Project(point).XYZPoint
            double tmpx = (p1.X - p2.X) / (p1.Y - p2.Y) * (p.Y - p2.Y) + p2.X;

            if (tmpx > p.X)//当tmpx>p.X的时候，说明点在线的左边，小于在右边，等于则在线上。
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 判断点p(x,y)在两点p1(x1,y1),p2(x2,y2)的左边还是右边
        public static bool YLeftOfLine(XYZ p, XYZ p1, XYZ p2)
        {
            double tmpx = (p1.Y - p2.Y) / (p1.X - p2.X) * (p.X - p2.X) + p2.Y;

            if (tmpx > p.Y)//当tmpx>p.X的时候，说明点在线的左边，小于在右边，等于则在线上。
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

// ... truncated ...
```

