# Sample Snippet: AddPipelineInformation

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AddPipelineInformation\AddPipelineInformation`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.ApplicationServices;

namespace AddPipelineInformation // 埋地管道参数填写+房间构件安装位置赋值 合并
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            List<Room> rooms = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Rooms).WhereElementIsNotElementType().Cast<Room>().ToList();

            List<Pipe> pipes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsNotElementType().Cast<Pipe>().ToList();

            TransactionGroup TG = new TransactionGroup(doc, "埋地管道参数填写+房间构件安装位置赋值");
            TG.Start();
            foreach (Room room in rooms)
            {
                XYZ min = null;
                XYZ max = null;

                GeometryElement geometryElement = room.ClosedShell;
                Solid solid = null;
                foreach (var item in geometryElement)
                {
                    if (item is Solid solidRoom)
                    {
                        solid = solidRoom;
                        BoundingBoxXYZ boundingBox = solid.GetBoundingBox();
                        min = boundingBox.Transform.OfPoint(boundingBox.Min);
                        max = boundingBox.Transform.OfPoint(boundingBox.Max);
                        break;
                    }
                }

                ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
                Outline outline = new Outline(min, max);
                BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
                List<Pipe> pipes2 = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).WhereElementIsNotElementType().WherePasses(intersectsFilter).WherePasses(solidFilter).Cast<Pipe>().ToList();
                string roomName = room.Name;

                using (Transaction t = new Transaction(doc, "构件安装位置赋值"))
                {
                    t.Start();
                    foreach (var pipe in pipes2)
                    {
                        try
                        {
                            var para = pipe.LookupParameter("安装位置");
                            para.DissociateFromGlobalParameter();
                            para.Set(roomName);
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    t.Commit();
                }
            }



            using (Transaction t = new Transaction(doc, "埋地管道参数赋值"))
            {
                t.Start();
                foreach (var pipe in pipes)
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
[assembly: AssemblyTitle("AddPipelineInformation")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AddPipelineInformation")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("133f6081-bec7-421e-9603-0fccc8e03c28")]

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

