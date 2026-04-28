# Sample Snippet: NewTextNoteForSlope

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\NewTextNoteForSlope\NewTextNoteForSlope`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NewTextNoteForSlope
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            //MainWindow mainWindow = new MainWindow();
            //PreviewControl previewControl = new PreviewControl(doc, uIDoc.ActiveGraphicalView.Id);
            //mainWindow.main_grid.Children.Add(previewControl);
            //mainWindow.ShowDialog();
            //return Result.Succeeded;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

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

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

        //using (Transaction t = new Transaction(doc, "ds"))
        //{
        //    t.Start();
        //    uIDoc.RefreshActiveView();
        //    doc.Regenerate();
        //    t.Commit();
        //}
        SelectPipeLine:
            XYZ p1 = null;
            XYZ p2 = null;
            XYZ p3 = null;
            try
            {
                p1 = sel.PickPoint();
                p2 = sel.PickPoint();
                p3 = sel.PickPoint();
            }
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

namespace NewTextNoteForSlope
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

