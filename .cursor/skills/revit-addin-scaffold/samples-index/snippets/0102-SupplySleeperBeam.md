# Sample Snippet: SupplySleeperBeam

Source project: `existingCodes\梁涛插件源代码\1.土建\SupplySleeperBeam\SupplySleeperBeam`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

// 补充大样/垫梁
namespace SupplySleeperBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //var r1 = sel.PickObject(ObjectType.Edge);
            //var r2 = sel.PickObject(ObjectType.Edge);
            //Edge line = doc.GetElement(r1).GetGeometryObjectFromReference(r1) as Edge;
            //Edge line2 = doc.GetElement(r2).GetGeometryObjectFromReference(r2) as Edge;

            ////TaskDialog.Show("revit", (line == null).ToString() + "\n" + (line2 == null));
            //bool res = AreLinesParallel(line.AsCurve() as Line, line2.AsCurve() as Line, 0.18);
            //TaskDialog.Show("revit", res.ToString());

            //return Result.Succeeded;

            var levels = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).Cast<Level>().OrderBy(l => l.Elevation);

        Next:
            Element highElement;
            Element lowElement;
            try
            {
                highElement = doc.GetElement(sel.PickObject(ObjectType.Element, new FloorAndBeamFilter(), "选择第一个楼板或梁"));
                lowElement = doc.GetElement(sel.PickObject(ObjectType.Element, new FloorAndBeamFilter(highElement.Id), "选择第二个楼板或梁"));

                if (lowElement.get_BoundingBox(null).Max.Z > highElement.get_BoundingBox(null).Max.Z)
                {
                    Element tempElem = highElement;
                    highElement = lowElement;
                    lowElement = tempElem;
                }
            }
            catch (OperationCanceledException)
            {
                return Result.Succeeded;
            }
            try
            {
                if (highElement is Floor highFloor)
                {
                    if (lowElement is Floor lowFloor)
                    {
                        SupplyBetweenTwoFloor(doc, highFloor, lowFloor);
                    }
                    else if (lowElement is FamilyInstance instance && instance.StructuralType == Autodesk.Revit.DB.Structure.StructuralType.Beam)
                    {
                        SupplyBetweenFloorAndBeam(doc, highFloor, instance);
                    }
                }
                else
                {
                    SupplyBetweenBeamAndFloor(doc, highElement as FamilyInstance, lowElement as Floor);
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("ERROR", ex.Message);
                return Result.Succeeded;
            }
            goto Next;

            return Result.Succeeded;
        }
        private void SupplyBetweenBeamAndFloor(Document doc, FamilyInstance beam, Floor lowFloor)
        {
            var botfaceRefer = HostObjectUtils.GetBottomFaces(lowFloor).First();
            PlanarFace botFace = lowFloor.GetGeometryObjectFromReference(botfaceRefer) as PlanarFace;

            List<Line> lowLines = new List<Line>();
            foreach (var curve in botFace.GetEdgesAsCurveLoops().First()) { if (curve is Line line) { lowLines.Add(line); } }
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
[assembly: AssemblyTitle("SupplySleeperBeam")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("SupplySleeperBeam")]
[assembly: AssemblyCopyright("Copyright ©  2026")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("4e9bea61-d93a-443f-ab5c-7451310ccd1c")]

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

