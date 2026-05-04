# Sample Snippet: AlignmentOfPipelineBends

Source project: `existingCodes\梁涛插件源代码\3.管综\AlignmentOfPipelineBends\AlignmentOfPipelineBends`

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

namespace AlignmentOfPipelineBends
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            listenUtils.startListen();

        Next:
            List<Reference> references;
            Reference mainRe;
            Reference pipeLineRe;
            try
            {
                references = sel.PickObjects(ObjectType.Element, new FittingFilter(), "框选需要对齐的管线弯头（按空格键完成框选，ESC键取消）").ToList();
                mainRe = sel.PickObject(ObjectType.Element, new FittingFilter(), "选择一个弯头作为对齐点（按空格键完成框选，ESC键取消）");
                //pipeLineRe = sel.PickObject(ObjectType.Element, new MepFilter(), "选择一条管线作为对齐的方向");
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                TaskDialog.Show("提示", "已完成对齐");
                return Result.Succeeded;
            }

            List<FamilyInstance> familyInstances = references.Select(r => doc.GetElement(r)).Cast<FamilyInstance>().ToList();
            FamilyInstance mainInstance = doc.GetElement(mainRe) as FamilyInstance;

            bool isVer = false; // 判断是否翻弯（升降）
            List<Connector> cons = mainInstance.MEPModel.ConnectorManager.Connectors.Cast<Connector>().ToList();
            if (cons.Count == 2)
            {
                if (Math.Abs(cons[0].Origin.Z - cons[1].Origin.Z) > 0.0001) isVer = true;
            }

            Line line;
            if (isVer)
            {
                XYZ p0 = cons[0].Origin;
                p0 = new XYZ(p0.X, p0.Y, 0);
                XYZ p1 = cons[1].Origin;
                p1 = new XYZ(p1.X, p1.Y, 0);
                line = Line.CreateBound(p0, p1);
            }
            else
            {
                try
                {
                    pipeLineRe = sel.PickObject(ObjectType.Element, new MepFilter(), "选择一条管线作为对齐的方向");
                    line = (doc.GetElement(pipeLineRe).Location as LocationCurve).Curve as Line;
                }
                catch (Exception)
                {
                    TaskDialog.Show("提示", "已完成对齐");
                    return Result.Succeeded;
                }
            }

            line.MakeUnbound();
            XYZ mainPoint = line.Project((mainInstance.Location as LocationPoint).Point).XYZPoint;
            using (Transaction t = new Transaction(doc, "管线弯通对齐"))
            {
                t.Start();

                foreach (var elem in familyInstances)
                {
                    XYZ point = (elem.Location as LocationPoint).Point;
                    XYZ pp = line.Project(point).XYZPoint;
                    double dis = pp.DistanceTo(mainPoint);
                    XYZ moveDir = (mainPoint - pp).Normalize();

                    ElementTransformUtils.MoveElement(doc, elem.Id, moveDir * dis);
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
[assembly: AssemblyTitle("AlignmentOfPipelineBends")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("AlignmentOfPipelineBends")]
[assembly: AssemblyCopyright("Copyright ©  2025")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("d5b9bf5b-afff-4f8a-8d7f-d6f675d07f47")]

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

