# Sample Snippet: ConnectConduitByNode

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\ConnectConduitByNode\ConnectConduitByNode`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConnectConduitByNode
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        FamilySymbol familySymbol = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            TransactionGroup TG2 = new TransactionGroup(doc, "载入族");
            TG2.Start();
            string dllPath = Assembly.GetExecutingAssembly().Location;
            string nodeFamilyPath = dllPath.Replace("ConnectConduitByNode.dll", "品成-拓扑节点.rfa");
            LoadFamily(doc, nodeFamilyPath);
            TG2.Assimilate();

            // 拓扑节点族类型
            familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).WhereElementIsElementType().Where(x => x.Name == "品成-拓扑节点").Cast<FamilySymbol>().FirstOrDefault();
            if (familySymbol == null)
            {
                TaskDialog.Show("Error", "未找到拓扑节点族");
                return Result.Cancelled;
            }

            Conduit conduit1 = doc.GetElement(sel.PickObject(ObjectType.Element, new ConduitFilter(), "选择第一条线管")) as Conduit;
            Conduit conduit2 = doc.GetElement(sel.PickObject(ObjectType.Element, new ConduitFilter(), "选择第二条线管")) as Conduit;
            Line line1 = (conduit1.Location as LocationCurve).Curve as Line;
            Line uLine1 = line1.Clone() as Line;
            uLine1.MakeUnbound();
            Line line2 = (conduit2.Location as LocationCurve).Curve as Line;
            Line uLine2 = line2.Clone() as Line;
            uLine2.MakeUnbound();
            if (uLine1.Intersect(uLine2, out var resultArray) == SetComparisonResult.Overlap)
            {
                using (Transaction t = new Transaction(doc, "延长线管"))
                {
                    t.Start();
                    XYZ point = resultArray.get_Item(0).XYZPoint;
                    int i1 = GetNearPointId(line1, point);
                    if (i1 == 0)
                    {
                        Line newLine1 = Line.CreateBound(point, line1.GetEndPoint(1));
                        (conduit1.Location as LocationCurve).Curve = newLine1;
                    }
                    else
                    {
                        Line newLine1 = Line.CreateBound(line1.GetEndPoint(0), point);
                        (conduit1.Location as LocationCurve).Curve = newLine1;
                    }
                    int i2 = GetNearPointId(line2, point);
                    if (i2 == 0)
                    {
                        Line newLine2 = Line.CreateBound(point, line2.GetEndPoint(1));
                        (conduit2.Location as LocationCurve).Curve = newLine2;
                    }
                    else
                    {
                        Line newLine2 = Line.CreateBound(line2.GetEndPoint(0), point);
                        (conduit2.Location as LocationCurve).Curve = newLine2;
                    }
                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                    FamilyInstance node = doc.Create.NewFamilyInstance(point, familySymbol, StructuralType.NonStructural);

                    t.Commit();
                }
                
            }
            else
            {
                TaskDialog.Show("提示", "所选线管不相交，无法进行延长");
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
[assembly: AssemblyTitle("ConnectConduitByNode")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("ConnectConduitByNode")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("7fd76179-c457-4c01-8b6b-dff28e0cc19a")]

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

