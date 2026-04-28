# Sample Snippet: CorrectionOfCasingAngle

Source project: `existingCodes\梁涛插件源代码\10.CEG\CorrectionOfCasingAngle\CorrectionOfCasingAngle`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;

namespace CorrectionOfCasingAngle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            ElementCategoryFilter elementCategoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_PipeFitting);
            ElementCategoryFilter elementCategoryFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment);
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(elementCategoryFilter2, elementCategoryFilter);
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(logicalOrFilter).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Contains("HW-普通钢套管-水平") || x.Name.Equals("钢套管") || x.Name.Equals("HW-普通钢套管")).Cast<FamilyInstance>().ToList();
            //List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(logicalOrFilter).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Equals("钢套管")).Cast<FamilyInstance>().ToList();
            //HashSet<string> names = new HashSet<string>();
            //string info = "";
            //foreach (FamilyInstance familyInstance in familyInstances)
            //{
            //    names.Add(familyInstance.Name);
            //}
            //foreach (string item in names)
            //{
            //    info += item + "\n";
            //}
            //TaskDialog.Show("sd", info);
            int count = 0;
            int notFind = 0;
            int rightDir = 0;
            using (Transaction t = new Transaction(doc,"修正套筒角度"))
            {
                t.Start();
                foreach (FamilyInstance familyInstance in familyInstances)
                {
                    ElementIntersectsElementFilter elementFilter = new ElementIntersectsElementFilter(familyInstance);
                    FilteredElementCollector pipes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe));
                    FilteredElementCollector cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray));
                    List<Pipe> pipes1 = pipes.WherePasses(elementFilter).Cast<Pipe>().ToList();
                    List<CableTray> cableTrays1 = cableTrays.WherePasses(elementFilter).Cast<CableTray>().ToList();
                    if (pipes1.Count == 0 && cableTrays1.Count == 0)
                    {
                        notFind++;
                        continue;
                    }
                    //if (pipes1.Count == 0) continue;
                    //Pipe pipe = pipes1.First();
                    Pipe pipe = null;
                    if (pipes1.Count == 1)
                    {
                        XYZ dir = ((pipes1.First().Location as LocationCurve).Curve as Line).Direction.Normalize();
                        if (dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate())) continue;
                        pipe = pipes1.First();
                    }
                    if (pipes1.Count > 1)
                    {
                        foreach (Pipe item in pipes1)
                        {
                            XYZ dir = ((item.Location as LocationCurve).Curve as Line).Direction.Normalize();
                            if (!(dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))) pipe = item;
                        }
                    }
                    CableTray cableTray = null;
                    if (cableTrays1.Count == 1)
                    {
                        XYZ dir = ((cableTrays1.First().Location as LocationCurve).Curve as Line).Direction.Normalize();
                        if (dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate())) continue;
                        cableTray = cableTrays1.First();
                    }
                    if (cableTrays1.Count > 1)
                    {
                        foreach (CableTray item in cableTrays1)
                        {
                            XYZ dir = ((item.Location as LocationCurve).Curve as Line).Direction.Normalize();
                            if (!(dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))) cableTray = item;
                        }
                    }
                    Transform transform = familyInstance.GetTransform();
                    XYZ pipeLineDir;
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
[assembly: AssemblyTitle("CorrectionOfCasingAngle")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CorrectionOfCasingAngle")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("232ac969-4cde-4fb5-b03f-51eae82af957")]

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

