# Sample Snippet: CreateIrregularColumns

Source project: `existingCodes\梁涛插件源代码\1.土建\CreateIrregularColumns\CreateIrregularColumns`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document = Autodesk.Revit.DB.Document;

namespace CreateIrregularColumns
{
    [Journaling(JournalingMode.NoCommandData)]
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Application app = commandData.Application.Application;
            Document doc = uIDoc.Document;


            View view = doc.ActiveView;
            if (!(view is ViewPlan))
            {
                TaskDialog.Show("提示", "请在平面视图运行插件");
                return Result.Cancelled;
            }
            SketchPlane sketchPlane1 = view.SketchPlane;
            if (sketchPlane1 == null)
            {
                TaskDialog.Show("提示", "未在该视图找到草图平面");
                return Result.Cancelled;
            }
            string rftPath = @"C:\ProgramData\Autodesk\RVT 2020\Family Templates\Chinese\公制结构柱.rft";
            //if 手动添加路径

            if (rftPath == null)
            {
                TaskDialog.Show("提示", "请检查公制结构柱族样板路径是否正确");
                return Result.Cancelled;
            }
            CurveArrArray curveArrArray = new CurveArrArray();

            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, new PlanarFaceFilter(doc));

            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);

            Autodesk.Revit.DB.Transform transform1 = dwg.GetTransform();

            List<Level> levels = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().Cast<Level>().ToList();
            levels = levels.OrderBy(x => x.ProjectElevation).ToList();
            Level level = doc.ActiveView.GenLevel;
            int j = levels.Select(x => x.Name).ToList().IndexOf(level.Name);
            double projectElevation = 0;
            double projectElevation1 = 0;
            double distance = 1;
            if (j != -1 && j != levels.Count - 1)
            {
                projectElevation = levels[j].ProjectElevation;
                projectElevation1 = levels[j + 1].ProjectElevation;
                distance = projectElevation1 - projectElevation;
            }
            //CurveLoop curves = new CurveLoop();
            PolyLine polyLine = geoObj as PolyLine;
            Outline outline = polyLine.GetOutline();
            XYZ center_globle = (outline.MaximumPoint + outline.MinimumPoint) / 2;
            Transform transform = Transform.Identity;
            transform.Origin = center_globle;
            //XYZ point = uIDoc.Selection.PickPoint();
            //TaskDialog.Show("ds", center_globle + "\n" + geoObj.GetHashCode() + "\n" + point + "\n" + reference.GlobalPoint);
            //return Result.Succeeded;
            IList<XYZ> points = polyLine.GetCoordinates();
            CurveArray curveArray = new CurveArray();
            // 用于比较重叠的线
            List<Line> compareLines = new List<Line>();
            for (int i = 0; i < polyLine.NumberOfCoordinates - 1; i++)
            {
                Line line = Line.CreateBound(transform.Inverse.OfPoint(points[i]), transform.Inverse.OfPoint(points[i + 1]));
                if (compareLines.FirstOrDefault(l => IsSameLine(l, line)) == null)
                {
                    curveArray.Append(line);
                    compareLines.Add(line);
                }
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
[assembly: AssemblyTitle("CreateIrregularColumns")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CreateIrregularColumns")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("5c447423-6019-4cfc-9bb6-43834c0d3a49")]

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

