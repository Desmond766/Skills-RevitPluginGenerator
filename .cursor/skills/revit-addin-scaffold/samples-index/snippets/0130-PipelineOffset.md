# Sample Snippet: PipelineOffset

Source project: `existingCodes\梁涛插件源代码\3.管综\PipelineOffset（管道偏移）\PipelineOffset`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PipelineOffset
{
    //管道135度偏移
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            double angle = 4.5 / 18 * Math.PI;
            //获取中断点和管道
            Reference reference = uIDoc.Selection.PickObject(ObjectType.Element, new PipelineFilter(), "选择一根管线");
            //获取偏移方向
            XYZ directPoint = uIDoc.Selection.PickPoint();
            Element element = doc.GetElement(reference);
            XYZ oldPoint = reference.GlobalPoint;
            Line pipeLine = (element.Location as LocationCurve).Curve as Line;
            XYZ point = pipeLine.Project(oldPoint).XYZPoint;
            XYZ p1 = pipeLine.GetEndPoint(0);
            XYZ p2 = pipeLine.GetEndPoint(1);
            Line newLine1 = Line.CreateBound(p1, point);
            Line newLine2 = Line.CreateBound(point, p2);
            TransactionGroup group = new TransactionGroup(doc, "管道135度偏移");
            group.Start();
            Transaction t = new Transaction(doc, "打断管道");
            t.Start();
            //1.打断管道
            //if (element is Duct duct)
            //{
            //    ElementId symbolId = duct.GetTypeId();
            //    MEPSystem mEPSystem = duct.MEPSystem;
            //    ElementId systemId = mEPSystem.GetTypeId();
            //    ElementId levelId = duct.ReferenceLevel.Id;
            //    Duct duct1 = Duct.Create(doc, systemId, symbolId, levelId, p1, point);
            //    Duct duct2 = Duct.Create(doc, systemId, symbolId, levelId, point, p2);
            //    connector1 = GetConnector(duct1, point);
            //    connector2 = GetConnector(duct2, point);

            //}
            //else if (element is Pipe pipe)
            //{
            //    //ElementId symbolId = pipe.GetTypeId();
            //    //MEPSystem mEPSystem = pipe.MEPSystem;
            //    //ElementId systemId = mEPSystem.GetTypeId();
            //    //ElementId levelId = pipe.ReferenceLevel.Id;
            //    //Pipe pipe1 = Pipe.Create(doc, systemId, symbolId, levelId, p1, point);
            //    //Pipe pipe2 = Pipe.Create(doc, systemId, symbolId, levelId, point, p2);
            //    ICollection<ElementId> ids = ElementTransformUtils.CopyElement(doc, element.Id, (p1 + p2) / 2);
            //    ElementId copyId = ids.First();
            //    (pipe.Location as LocationCurve).Curve = newLine1;
            //    Pipe pipe1 = pipe;
            //    Pipe pipe2 = doc.GetElement(copyId) as Pipe;
            //    (pipe2.Location as LocationCurve).Curve= newLine2;
            //    connector1 = GetConnector(pipe1, point);
            //    connector2 = GetConnector(pipe2, point);
            //    Line axis = Line.CreateBound(point, point + XYZ.BasisZ * 2);

            //    //ElementTransformUtils.RotateElement(doc, pipe2.Id, axis, 0.7854);
            //    ElementTransformUtils.RotateElement(doc, pipe2.Id, axis, -angle);
            //}
            //else if (element is CableTray cableTray)
            //{
            //    ElementId symbolId = cableTray.GetTypeId();
            //    ElementId levelId = cableTray.ReferenceLevel.Id;
            //    CableTray cableTray1 = CableTray.Create(doc, symbolId, p1, point, levelId);
            //    CableTray cableTray2 = CableTray.Create(doc, symbolId, point, p2, levelId);
            //    connector1 = GetConnector(cableTray1, point);
            //    connector2 = GetConnector(cableTray2, point);
            //}
            //TaskDialog.Show("22", angle.ToString());
            //PlumbingUtils.BreakCurve(doc, element.Id, point);

            //1.打断管道
            ICollection<ElementId> ids = ElementTransformUtils.CopyElement(doc, element.Id, (p1 + p2) / 2);
            ElementId copyId = ids.First();
            (element.Location as LocationCurve).Curve = newLine1;
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
[assembly: AssemblyTitle("PipelineOffset")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PipelineOffset")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("67fa074e-4601-40af-aeee-8aa7029dd131")]

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

