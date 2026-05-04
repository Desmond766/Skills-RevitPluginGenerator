# Sample Snippet: BatchArrangementOfHangersBetweenBeams

Source project: `existingCodes\梁涛插件源代码\11.其他\BatchArrangementOfHangersBetweenBeams\BatchArrangementOfHangersBetweenBeams`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using ArrangeSingleOrMultiplePipeHangersInTheLinkedModel;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

namespace BatchArrangementOfHangersBetweenBeams
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        Document doc = null;
        double floorBottomHeight = 0;
        Level level = null;
        FamilySymbol singleFamilySymbol = null;
        double hangerLength = 0;
        Element pipeLine1 = null;
        Element pipeLine2 = null;
        Line midLine = null;
        string singleLayer = "单层";
        FamilySymbol familySymbol = null;
        bool uprighPole = false;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 支吊架".Equals(view3.Name))
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
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }
            UserControl1 userControl1 = new UserControl1(doc);
            

            userControl1.ShowDialog();
            if (userControl1.cancel)
            {
                return Result.Cancelled;
            }
            string centerPointPosition = userControl1.comboBox.Text;
// ... truncated ...
```

## EventCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchArrangementOfHangersBetweenBeams
{
    public class EventCommand : IExternalEventHandler
    {
        bool check = false;
        public static UserControl1 userControl2 { get; set; } = null;
        public EventCommand()
        {
        }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            if (userControl2.check.IsChecked == true)
            {
                userControl2.tb.Visibility = System.Windows.Visibility.Visible;
                userControl2.lb.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                userControl2.tb.Visibility = System.Windows.Visibility.Hidden;
                userControl2.lb.Visibility = System.Windows.Visibility.Hidden;
            }

        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}

```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrangeSingleOrMultiplePipeHangersInTheLinkedModel
{
    class Utils
    {
        #region 绘制模型线
        /// <summary>
        /// 绘制模型线
        /// </summary>
        /// <param name="p1">点1</param>
        /// <param name="p2">点2</param>
        public static void DrawModelCurve(Document doc, XYZ p1, XYZ p2)
        {
            SketchPlane sketchPlane = SketchPlane.Create(doc, Plane.CreateByNormalAndOrigin((p1 - p2).CrossProduct(p1), p2));
            doc.Create.NewModelCurve(Line.CreateBound(p1, p2), sketchPlane);
        }
        #endregion

        #region 获得向下投影到楼板的点
        public static XYZ GetClearHeightPoint(View3D view, Document doc, XYZ point_Do)
        {
            XYZ point;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            Reference r2 = referenceWithContext.GetReference();
            point = r2.GlobalPoint;
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return point;

        }
        #endregion

        #region 获得管线向下投影的净高 考虑高低板
        public static double GetClearHeight(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());

            Reference r2 = referenceWithContext.GetReference();
            distance = r2.GlobalPoint.DistanceTo(point_Do);
            //DrawModelCurve(doc, point_Do, r2.GlobalPoint);

            return distance;

        }
        #endregion


        #region 获得管线向上投影的净高
        public static double GetClearHeightUp(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
// ... truncated ...
```

