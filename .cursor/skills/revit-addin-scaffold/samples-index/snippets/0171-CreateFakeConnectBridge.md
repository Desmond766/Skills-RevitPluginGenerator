# Sample Snippet: CreateFakeConnectBridge

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CreateFakeConnectBridge\CreateFakeConnectBridge`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateFakeConnectBridge
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            Reference refer1;
            Reference refer2;
            try
            {
                refer1 = sel.PickObject(ObjectType.Element, new CabletrayFilter(), "选择第一条桥架");
                refer2 = sel.PickObject(ObjectType.Element, new CabletrayFilter(), "选择第二条桥架");
            }
            catch (Exception)
            {
                TaskDialog.Show("Revit", "结束布置");
                return Result.Succeeded;
            }

            Element elem1 = doc.GetElement(refer1);
            Element elem2 = doc.GetElement(refer2);
            var points1 = (elem1.Location as LocationCurve).Curve.Tessellate();
            var points2 = (elem2.Location as LocationCurve).Curve.Tessellate();

            double minValue = double.MaxValue;
            XYZ point1 = XYZ.Zero;
            XYZ point2 = XYZ.Zero;

            foreach (var p1 in points1)
            {
                foreach (var p2 in points2)
                {
                    if (p1.DistanceTo(p2) < minValue)
                    {
                        point1 = p1;
                        point2 = p2;
                        minValue = p1.DistanceTo(p2);
                    }
                }
            }
            using (Transaction t = new Transaction(doc, "生成连接桥架"))
            {
                t.Start();
                var id = ElementTransformUtils.CopyElement(doc, elem1.Id, new XYZ()).First();
                Element newElem = doc.GetElement(id);
                Line line = Line.CreateBound(point1, point2);
                (newElem.Location as LocationCurve).Curve = line;
                t.Commit();
            }


            return Result.Succeeded;
        }
    }

    public class CabletrayFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is CableTray)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
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
[assembly: AssemblyTitle("CreateFakeConnectBridge")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("CreateFakeConnectBridge")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("556e534e-0086-4663-af04-696aeae5ab8c")]

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

