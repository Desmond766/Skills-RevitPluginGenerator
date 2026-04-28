# Sample Snippet: ReplaceParkingPlace

Source project: `existingCodes\梁涛插件源代码\2.机电建模及算量\ReplaceParkingPlace\ReplaceParkingPlace`

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

namespace ReplaceParkingPlace
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            var refer = sel.PickObject(ObjectType.LinkedElement, "选择链接模型");
            //var refer = sel.PickObject(ObjectType.PointOnElement, "选择链接模型");
            var linkInstance = doc.GetElement(refer) as RevitLinkInstance;
            Transform linkTransform = linkInstance.GetTransform();
            Document linkDoc = linkInstance.GetLinkDocument();

            //FamilyInstance familyInstance1 = linkDoc.GetElement(refer.LinkedElementId) as FamilyInstance;
            //GeometryObject geo = familyInstance1.GetGeometryObjectFromReference(refer.CreateReferenceInLink());
            //if (geo is PlanarFace planarFace)
            //{
            //    TaskDialog.Show("revit", planarFace.FaceNormal.ToString());
            //};
            //FamilySymbol familySymbol2 = null;
            //using (var symbolCol = new FilteredElementCollector(doc).WhereElementIsElementType())
            //{
            //    familySymbol2 = symbolCol.OfCategory(BuiltInCategory.OST_GenericModel)
            //        .Where(e => e is FamilySymbol).Cast<FamilySymbol>()
            //        .FirstOrDefault(s => s.Name.Contains("代替车位族"));
            //}
            //ReplaceElement(doc, linkDoc.GetElement(refer.LinkedElementId) as FamilyInstance, linkTransform, familySymbol2);
            //return Result.Succeeded;

            //FamilyInstance linkelem = linkDoc.GetElement(refer.LinkedElementId) as FamilyInstance;
            //TaskDialog.Show("e", (linkelem.GetTransform().Multiply(linkTransform).OfVector(XYZ.BasisY.Negate()).AngleTo(XYZ.BasisY) % Math.PI).ToString());
            //return Result.Succeeded;

            List<FamilyInstance> linkElems = new List<FamilyInstance>();

            using (FilteredElementCollector linkElemCol = new FilteredElementCollector(linkDoc))
            {
                //LogicalOrFilter orFilter = new LogicalOrFilter(new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns), new ElementCategoryFilter(BuiltInCategory.OST_GenericModel));
                var linkParkingPlaces = linkElemCol.WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_StructuralColumns)
                    .Where(le => le is FamilyInstance).Cast<FamilyInstance>().Where(e => e.Symbol.FamilyName.Contains("停车位"));

                linkElems.AddRange(linkParkingPlaces);
            }

            FamilySymbol familySymbol = null;
            using (var symbolCol = new FilteredElementCollector(doc).WhereElementIsElementType())
            {
                familySymbol = symbolCol.OfCategory(BuiltInCategory.OST_GenericModel)
                    .Where(e => e is FamilySymbol).Cast<FamilySymbol>()
                    .FirstOrDefault(s => s.Name.Contains("代替车位族"));
            }
            if (familySymbol == null)
            {
                TaskDialog.Show("提示", "未找代替车位族类型");
                return Result.Cancelled;
            }

            using (Transaction t = new Transaction(doc, "车位族实例替换"))
            {
                t.Start();

                // 激活车位族类型
                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }

                foreach (var elem in linkElems)
                {
                    if (elem.Location == null || !(elem.Location is LocationPoint)) continue;

                    XYZ point = (elem.Location as LocationPoint).Point;
                    point = linkTransform.OfPoint(point);
                    //point = point + XYZ.BasisZ * 100;

                    double width = (double)(elem.Symbol.LookupParameter("车位宽")?.AsDouble() ?? elem.Symbol.LookupParameter("车位宽度")?.AsDouble());
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ReplaceParkingPlace")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ReplaceParkingPlace")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("7a39d80b-b69a-428c-aa86-28a2838b6b2a")]

// 程序集的版本信息由下列四个值组成: 
//
//      主版本
//      次版本
//      生成号
//      修订号
//
//可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值
//通过使用 "*"，如下所示:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

