# Sample Snippet: AutomaticallyGenerateDimensions

Source project: `existingCodes\梁涛插件源代码\10.CEG\AutomaticallyGenerateDimensions\AutomaticallyGenerateDimensions`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticallyGenerateDimensions
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            View view = doc.ActiveView;
            //TaskDialog.Show("sd", view.UpDirection.ToString() + "\n");
            //return Result.Succeeded;
            XYZ upDir = view.UpDirection;
            XYZ rightDir = view.RightDirection;
            XYZ viewDir = view.ViewDirection;
            Element elem= new FilteredElementCollector(doc,doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType().FirstOrDefault();
            FamilyInstance familyInstance = elem as FamilyInstance;
            ReferenceArray referenceArray = new ReferenceArray();
            XYZ max = elem.get_BoundingBox(null).Max;
            XYZ min = elem.get_BoundingBox(null).Min;
            Options options = new Options();
            options.ComputeReferences = true;
            GeometryElement geometryElement = elem.get_Geometry(options);
            foreach (var item in geometryElement)
            {
                if (item is Solid solid && solid.Volume > 0)
                {
                    double minVal1 = double.MaxValue;
                    double minVal2 = double.MaxValue;
                    Reference upReference = null;
                    Reference downReference = null;
                    foreach (var face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                        { 
                            if (planarFace.Origin.Z - min.Z < minVal1)
                            {
                                
                                minVal1 = planarFace.Origin.Z - min.Z;
                                downReference = planarFace.Reference;
                            }
                        }
                    }
                    foreach (var face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ))
                        {
                            if (max.Z - planarFace.Origin.Z < minVal2)
                            {
                                minVal2 = max.Z - planarFace.Origin.Z;
                                upReference = planarFace.Reference;
                            }
                        }
                    }
                    referenceArray.Append(upReference); 
                    referenceArray.Append(downReference);
                }
            }

            Options options2 = new Options();
            options2.ComputeReferences = true;
            GeometryElement geometryElement2 = elem.get_Geometry(options2);
            ReferenceArray referenceArray2 = new ReferenceArray();
            referenceArray2 = GetReferences(geometryElement2, max, min, view);

            
            XYZ pA = max.Add(new XYZ(max.X, max.Y, min.Z)) / 2;
            pA = pA + upDir * 1 + rightDir.Negate() * 2;
            XYZ pB = min.Add(new XYZ(min.X, min.Y, max.Z)) / 2;
            pB = pB + upDir.Negate() * 0.2 + rightDir.Negate() * 2;
            XYZ p1 = max.Add(new XYZ(min.X, min.Y, max.Z)) / 2;
            p1 = p1 + rightDir.Negate() * 2;
            XYZ p2 = min.Add(new XYZ(max.X, max.Y, min.Z)) / 2;
            //Line axis1 = Line.CreateBound(p1 - viewDir * 2, p1 + viewDir * 2);
            //Line axis2 = Line.CreateBound(p2 - viewDir * 2, p2 + viewDir * 2);

            double rota = (90 / 180) * Math.PI;
            List<ReferenceArray> upRefs = new List<ReferenceArray>();
            List<ReferenceArray> leftRefs = new List<ReferenceArray>();
            upRefs.Add(referenceArray);
            leftRefs.Add(referenceArray2);
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
[assembly: AssemblyTitle("AutomaticallyGenerateDimensions")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AutomaticallyGenerateDimensions")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("0889e4d5-fe63-4795-ac89-6bef536fa701")]

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

