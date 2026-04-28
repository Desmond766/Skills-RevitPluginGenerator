# Sample Snippet: CreateHorizontalProfileFrame

Source project: `existingCodes\饶昌锋插件源代码\107创建平行剖面\CreateHorizontalProfileFrame`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateHorizontalProfileFrame
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            //获取元素
            ElementFilter filter = new ElementFilter();
            Element element;
            try
            {
                element = uidoc.Selection.PickObject(ObjectType.Element, filter).GetElement(doc);
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }
            #region 当element为门时 进行预处理

            FamilyInstance door = null;
            FamilySymbol doorSymbol = null;
            if (element.Category.Id.IntegerValue == ((int)BuiltInCategory.OST_Doors))
            {
                door = element as FamilyInstance;
                doorSymbol = door.Symbol;
            }
            if (door != null)
            {
                element = door.Host;
            }
            #endregion
            //判断元素水平或垂直
            string direction = element.IsHorizontal();
            XYZ centPoint = Utils.GetMEPCurveCentrePoint(element);
            BoundingBoxXYZ boundingBoxXYZ = new BoundingBoxXYZ();
            XYZ minPoint = null;
            XYZ maxPoint = null;
            double height = 0;
            double framing = 0;
            //对不同的元素设置不同的剖面Y轴高度
            if (element is Wall)
            {
                height = element.get_Parameter(BuiltInParameter.WALL_USER_HEIGHT_PARAM).AsDouble();
            }
            else if (element.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
            {
                framing = 1000 / 304.8;
            }
            if (door != null)
            {
                height = doorSymbol.LookupParameter("高度").AsDouble();
                centPoint = (door.Location as LocationPoint).Point;
            }
            double lenght = element.GetElementLength();
            if (door != null)
            {
                lenght = doorSymbol.LookupParameter("宽度").AsDouble();
            }
            if (direction == "horizontal" || direction == null)
            {
                minPoint = new XYZ(centPoint.X - lenght / 2, centPoint.Z - framing, -centPoint.Y - 1000 / 304.8);
                maxPoint = new XYZ(centPoint.X + lenght / 2, centPoint.Z + height, -centPoint.Y + 2000 / 304.8);
            }
            else
            {
                minPoint = new XYZ(centPoint.Y - lenght / 2, centPoint.Z, centPoint.X - 1000 / 304.8);
                maxPoint = new XYZ(centPoint.Y + lenght / 2, centPoint.Z + height, centPoint.X + 2000 / 304.8);
            }
            ViewSection sectionView;
            doc.NewTransaction("创建剖面框", () =>
            {
                // 创建剖面视图
                // 获取剖面类型
                ElementId viewFamilyTypeId = null;
                FilteredElementCollector collector1 = new FilteredElementCollector(doc);
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateHorizontalProfileFrame
{
    public static class Utils
    {
        public static XYZ GetMEPCurveCentrePoint(this Element elem)
        {
            LocationCurve locationCurve = elem.Location as LocationCurve;
            Curve curve = locationCurve.Curve;
            XYZ centerPoint = curve.Evaluate(0.5, true);
            return centerPoint;
        }
        public static double GetElementLength(this Element elem)
        {
            LocationCurve locationCurve = elem.Location as LocationCurve;
            double lenght = locationCurve.Curve.Length;
            return lenght;
        }

        public static Element GetElement(this Reference reference, Document doc)
        {
            Element elem = doc.GetElement(reference);
            return elem;
        }
        public static string IsHorizontal(this Element elem)
        {
            XYZ startPoint = (elem.Location as LocationCurve).Curve.GetEndPoint(0);
            XYZ endPoint = (elem.Location as LocationCurve).Curve.GetEndPoint(1);

            if (Math.Abs(startPoint.X - endPoint.X) < 0.000001)
            {
                return "vertical";
            }
            else if (Math.Abs(startPoint.Y - endPoint.Y) < 0.000001)
            {
                return "horizontal";
            }
            return null;

        }
    }
}

```

