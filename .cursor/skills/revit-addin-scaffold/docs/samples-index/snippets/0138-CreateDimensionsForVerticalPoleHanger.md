# Sample Snippet: CreateDimensionsForVerticalPoleHanger

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\CreateDimensionsForVerticalPoleHanger\CreateDimensionsForVerticalPoleHanger`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace CreateDimensionsForVerticalPoleHanger
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance)).Where(x => x.Name.Equals("PM-多拉杆槽钢吊架（一层）")).Cast<FamilyInstance>().ToList();

            using (Transaction t = new Transaction(doc, "创建尺寸标注"))
            {
                t.Start();
                foreach (var item in familyInstances)
                {
                    Transform transform = item.GetTransform();
                    XYZ direction = transform.OfVector(XYZ.BasisX);
                    XYZ p = (item.Location as LocationPoint).Point;
                    //XYZ verticesEnd0 = p - direction * 20;
                    //XYZ verticesEnd1 = p + direction * 20;
                    //XYZ vertical1 = verticesEnd0.CrossProduct(verticesEnd1);
                    //XYZ verticalVector = new XYZ(vertical1.X, vertical1.Y, direction.Z).Normalize();
                    XYZ verticalVector = GetPerpendicularVector(direction);
                    p = p + verticalVector * (1000 / 304.8);
                    Line line = Line.CreateBound(p + direction * 2, p - direction * 2);
                    ReferenceArray referenceArray = new ReferenceArray();
                    int para1 = item.LookupParameter("水平端板1").AsInteger();
                    int para2 = item.LookupParameter("水平端板2").AsInteger();
                    int para3 = item.LookupParameter("水平端板3").AsInteger();
                    List<Reference> references = new List<Reference>();
                    references = item.GetReferences(FamilyInstanceReferenceType.WeakReference).ToList();
                    referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":482:SURFACE"));
                    referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":483:SURFACE"));
                    if (para1 == 1)
                    {
                        referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":488:SURFACE"));
                    }
                    if (para2 == 1)
                    {
                        referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":491:SURFACE"));
                    }
                    if (para3 == 1)
                    {
                        referenceArray.Append(references.First(x => x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 12) == ":492:SURFACE"));
                    }
                    doc.Create.NewDimension(uIDoc.ActiveView, line, referenceArray);
                }
                t.Commit();
            }
            return Result.Succeeded;
        }
        // 获取垂直向量
        private XYZ GetPerpendicularVector(XYZ direction)
        {
            // 计算垂直向量，这里简单地使用直线方向向量的法向量
            XYZ perpendicularVector = new XYZ(-direction.Y, direction.X, 0);
            return perpendicularVector;
        }
    }
}

```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的一般信息由以下
// 控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("CreateDimensionsForVerticalPoleHanger")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CreateDimensionsForVerticalPoleHanger")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("ac9574c8-a08c-4ac9-89b9-f8bb2a0d09ea")]

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

