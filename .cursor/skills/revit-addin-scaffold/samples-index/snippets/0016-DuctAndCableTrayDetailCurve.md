# Sample Snippet: DuctAndCableTrayDetailCurve

Source project: `existingCodes\品成插件源代码\机电\DuctAndCableTrayDetailCurve\DuctAndCableTrayDetailCurve`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;

using Autodesk.Revit.DB.Mechanical;
using System.Xml;
using Autodesk.Revit.UI.Events;

namespace DuctAndCableTrayDetailCurve
{
    [Transaction(TransactionMode.Manual)]
    public class Command: IExternalCommand
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
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //框选,选择桥架和风管加入ductOrCableTrayList
            IList<Reference> list = sel.PickObjects(ObjectType.Element);
            List<Element> ductOrCableTrayList = new List<Element>();
            foreach (Reference reference in list)
            {
                Element elem = doc.GetElement(reference);
                if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves
                    || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
                {
                    ductOrCableTrayList.Add(elem);
                }
            }

            Options option = new Options();
            option.View = doc.ActiveView;
            DetailCurve detailCurve;

            //对风管和桥架添加边框
            using (Transaction t = new Transaction(doc, "详图线"))
            {
                t.Start();

                foreach (Element elem in ductOrCableTrayList)
                {
                    GeometryElement geomElement = elem.get_Geometry(option);
                    if (null == geomElement)
                    {
                        continue;
                    }
                    foreach (GeometryObject geomobj in geomElement)
                    {
                        Solid geomSolid = geomobj as Solid;
                        if (null == geomSolid)
                        {
                            continue;
                        }
                        foreach (Face geomFace in geomSolid.Faces)
                        {
                            if (!(geomFace is PlanarFace))
                            {
                                continue;
                            }
                            EdgeArrayArray edgeArrayArray = geomFace.EdgeLoops;
                            EdgeArray edgeArray = edgeArrayArray.get_Item(0) as EdgeArray;
                            for (int i = 0; i < edgeArray.Size; i++)
                            {
                                Line line = edgeArray.get_Item(i).AsCurve() as Line;
                                try//有在该平面中无法画线的情况如：两点在同一个位置
                                {
                                    detailCurve = doc.Create.NewDetailCurve(doc.ActiveView, line);
                                }
                                catch (Exception)
                                {
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
[assembly: AssemblyTitle("DuctAndCableTrayDetailCurve")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("微软中国")]
[assembly: AssemblyProduct("DuctAndCableTrayDetailCurve")]
[assembly: AssemblyCopyright("Copyright © 微软中国 2017")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// 将 ComVisible 设置为 false 使此程序集中的类型
// 对 COM 组件不可见。  如果需要从 COM 访问此程序集中的类型，
// 则将该类型上的 ComVisible 特性设置为 true。
[assembly: ComVisible(false)]

// 如果此项目向 COM 公开，则下列 GUID 用于类型库的 ID
[assembly: Guid("115bacb2-9ca5-42fa-bdea-15d82b88b339")]

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

