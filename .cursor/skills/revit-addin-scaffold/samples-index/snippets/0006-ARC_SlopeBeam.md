# Sample Snippet: ARC_SlopeBeam

Source project: `existingCodes\品成插件源代码\土建\ARC_SlopeBeam\ARC_SlopeBeam`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Structure;
using System.Diagnostics;

namespace ARC_SlopeBeam
{
     [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;

            // 判断是否存在三维视图
            View3D view =Get3DView(doc);
            if (null == view)
            {
                message = "错误1：未找到｛三维｝视图！";
                return Result.Failed;
            }
            // 梁过滤器
            FilteredElementCollector beamCollector;
            // 柱过滤器
            FilteredElementCollector columnCollector;
            if (selection.GetElementIds().Count == 0)
            {
                beamCollector = new FilteredElementCollector(doc);
                columnCollector = new FilteredElementCollector(doc);
            }
            else
            {
                beamCollector = new FilteredElementCollector(doc, selection.GetElementIds());
                columnCollector = new FilteredElementCollector(doc, selection.GetElementIds());
            }
            beamCollector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance));
            columnCollector.OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance));

            // 开始
            int num_Done = 0;
            int num_Pass = 0;
            using (Transaction t = new Transaction(doc, "SlopeBeam"))
            {
                t.Start();
                foreach (FamilyInstance familyInstance in beamCollector)
                {
                    try
                    {
                        XYZ zOffset = new XYZ(0, 0, familyInstance.get_Parameter(BuiltInParameter.Z_OFFSET_VALUE).AsDouble());
                        Curve curve = (familyInstance.Location as LocationCurve).Curve;
                        // 原来的偏移量
                        double end0_Base_Offset = familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).AsDouble();
                        double end1_Base_Offset = familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION).AsDouble();
                        // 计算得到的需要偏移的量
                        double end0_Offset = GetDistance(view, curve.GetEndPoint(0) + zOffset);
                        double end1_Offset = GetDistance(view, curve.GetEndPoint(1) + zOffset);
                        if (end0_Offset > 0.00001)
                        {
                            familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END0_ELEVATION).Set(end0_Base_Offset + end0_Offset);
                        }
                        if (end1_Offset > 0.00001)
                        {
                            familyInstance.get_Parameter(BuiltInParameter.STRUCTURAL_BEAM_END1_ELEVATION).Set(end1_Base_Offset + end1_Offset);
                        }
                        num_Done += 1;
                    }
                    catch
                    {
                        num_Pass += 1;
                        continue;
                    }
                }
                foreach (FamilyInstance familyInstance in columnCollector)
// ... truncated ...
```

## Properties\AssemblyInfo.cs

```csharp
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// 有关程序集的常规信息通过以下
// 特性集控制。更改这些特性值可修改
// 与程序集关联的信息。
[assembly: AssemblyTitle("ARC_SlopeBeam")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyProduct("ARC_SlopeBeam")]
[assembly: AssemblyCopyright("Copyright © Microsoft 2019")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("5765a470-f23f-4504-bbf1-b11c2dddf229")]

// 程序集的版本信息由下面四个值组成: 
//
//      主版本
//      次版本 
//      生成号
//      修订号
//
// 可以指定所有这些值，也可以使用“生成号”和“修订号”的默认值，
// 方法是按如下所示使用“*”: 
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("1.0.0.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]

```

