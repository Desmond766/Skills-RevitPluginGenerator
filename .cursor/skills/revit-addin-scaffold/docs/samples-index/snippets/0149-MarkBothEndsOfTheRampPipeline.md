# Sample Snippet: MarkBothEndsOfTheRampPipeline

Source project: `existingCodes\梁涛插件源代码\6.不常用\MarkBothEndsOfTheRampPipeline\MarkBothEndsOfTheRampPipeline`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarkBothEndsOfTheRampPipeline
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            while (true)
            {
                Reference reference;
                XYZ point1;
                XYZ point2;
                try
                {
                    reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new PipeFilter(), "选择一根管道");
                    point1 = reference.GlobalPoint;
                    point2 = uIDoc.Selection.PickPoint("选择布置方向");
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "结束布置");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }                
                //Pipe pipe = doc.GetElement(reference) as Pipe;
                Element element = doc.GetElement(reference);
                Line line = (element.Location as LocationCurve).Curve as Line;
                XYZ sP = line.GetEndPoint(0);
                XYZ eP = line.GetEndPoint(1);


                //判断引线方向
                XYZ crossDirection = line.Direction.CrossProduct(XYZ.BasisZ);
                if ((point2 + crossDirection * 1.0).DistanceTo(point1) < point2.DistanceTo(point1))
                {
                    crossDirection = crossDirection.Negate();
                }

                //根据名称找标签族
                //水管
                var tagFamilyName_RightAlign_ST = "PC_水管标记_右对齐_起点";
                var tagFamilyName_LeftAlign_ST = "PC_水管标记_左对齐_起点";
                ElementId tagTypeId_RightAlign_ST = null;
                ElementId tagTypeId_LeftAlign_ST = null;
                var tagFamilyName_RightAlign_ET = "PC_水管标记_右对齐_端点";
                var tagFamilyName_LeftAlign_ET = "PC_水管标记_左对齐_端点";
                ElementId tagTypeId_RightAlign_ET = null;
                ElementId tagTypeId_LeftAlign_ET = null;

                //燃气管
                var tagFamilyName_RightAlign_RST = "PC_燃气管标记_右对齐_起点";
                var tagFamilyName_LeftAlign_RST = "PC_燃气管标记_左对齐_起点";
                ElementId tagTypeId_RightAlign_RST = null;
                ElementId tagTypeId_LeftAlign_RST = null;
                var tagFamilyName_RightAlign_RET = "PC_燃气管标记_右对齐_端点";
                var tagFamilyName_LeftAlign_RET = "PC_燃气管标记_左对齐_端点";
                ElementId tagTypeId_RightAlign_RET = null;
                ElementId tagTypeId_LeftAlign_RET = null;

                //线管
                //var tagFamilyName_RightAlign_XST = "PC_水管标记_右对齐_起点";
                var tagFamilyName_LeftAlign_XST = "PC_线管标记_左对齐_起点";
                //ElementId tagTypeId_RightAlign_XST = null;
                ElementId tagTypeId_LeftAlign_XST = null;
                //var tagFamilyName_RightAlign_XET = "PC_水管标记_右对齐_端点";
                var tagFamilyName_LeftAlign_XET = "PC_线管标记_左对齐_端点";
                //ElementId tagTypeId_RightAlign_XET = null;
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
[assembly: AssemblyTitle("MarkBothEndsOfTheRampPipeline")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MarkBothEndsOfTheRampPipeline")]
[assembly: AssemblyCopyright("Copyright ©  2024")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("82e178b7-cef7-4427-9999-bf8b2ea0ab11")]

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

