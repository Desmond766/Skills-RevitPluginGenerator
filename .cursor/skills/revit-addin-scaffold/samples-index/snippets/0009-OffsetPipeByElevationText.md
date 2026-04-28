# Sample Snippet: OffsetPipeByElevationText

Source project: `existingCodes\品成插件源代码\土建\OffsetPipeByElevationText\OffsetPipeByElevationText`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;

namespace OffsetPipeByElevationText
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        double startOffset = 100.0 / 304.8;
        double endOffset = -100 / 304.8;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            PipeType pipeType = collector.OfClass(typeof(PipeType)).First() as PipeType;

            //first pick mepcurve
            Reference reference1 = sel.PickObject(ObjectType.Element);
            Element element1 = doc.GetElement(reference1);
            //second pick startText
            Reference reference2 = sel.PickObject(ObjectType.Element);
            Element element2 = doc.GetElement(reference2);
            //3rd pick endText
            Reference reference3 = sel.PickObject(ObjectType.Element);
            Element element3 = doc.GetElement(reference3);
            if (!(element1 is MEPCurve) || !(element2 is TextNote) || !(element3 is TextNote))
            {
                message = "首先选择管道起点，再选择起点标高文字，最后选择终点标高文字";
                return Result.Cancelled;
            }

            // mepCurve
            MEPCurve mepCurve = element1 as MEPCurve;
            Curve curve = (mepCurve.Location as LocationCurve).Curve;
            XYZ startPoint = curve.GetEndPoint(0);
            XYZ endPoint = curve.GetEndPoint(1);
            XYZ splitPoint = GetProjectivePoint(startPoint, endPoint, reference1.GlobalPoint);
            if (splitPoint.DistanceTo(startPoint) > splitPoint.DistanceTo(endPoint))
            {
                startPoint = curve.GetEndPoint(1);
                startPoint = curve.GetEndPoint(0);
            }
            double diameter = mepCurve.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
            // startText & endText
            TextNote startText = element2 as TextNote;
            TextNote endText = element3 as TextNote;
            try
            {
                startOffset = double.Parse(startText.Text) / 0.3048 + diameter / 2.0;
                endOffset = double.Parse(endText.Text) / 0.3048 + diameter / 2.0;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return Result.Cancelled;
            }
            startPoint = new XYZ(startPoint.X, startPoint.Y, startOffset);
            endPoint = new XYZ(endPoint.X, endPoint.Y, endOffset);

            Transaction trans = new Transaction(doc, "SlopePipe");
            trans.Start();
            //create new Pipe
            Pipe newPipe = Pipe.Create(doc,
                mepCurve.MEPSystem.GetTypeId(),
                mepCurve.GetTypeId(),
                mepCurve.ReferenceLevel.Id,
                startPoint, endPoint);
            //copy parameters
            CopyParameters(mepCurve as Pipe, newPipe);
            //delete old pipe
            doc.Delete(mepCurve.Id);
            trans.Commit();


            return Result.Succeeded;
        }

        #region 获得点在直线上的投影点坐标
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
[assembly: AssemblyTitle("OffsetPipeByElevationText")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("OffsetPipeByElevationText")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2020")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 会使此程序集中的类型
//对 COM 组件不可见。如果需要从 COM 访问此程序集中的类型
//请将此类型的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("0eec1d31-51b5-4eae-bb4c-2537f3b06eb1")]

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

