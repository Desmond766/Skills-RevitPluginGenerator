# Sample Snippet: ColoringOfStructuralPlates

Source project: `existingCodes\梁涛插件源代码\1.土建\ColoringOfStructuralPlates\ColoringOfStructuralPlates`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using Color = Autodesk.Revit.DB.Color;
using Document = Autodesk.Revit.DB.Document;
using Autodesk.Revit.ApplicationServices;
using Application = Autodesk.Revit.ApplicationServices.Application;
using Autodesk.Revit.UI.Events;
using System.ComponentModel;
using Autodesk.Revit.UI.Selection;
using System.Threading;

//楼板按标高/板厚赋色
namespace ColoringOfStructuralPlates
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Document doc = null;
        public static List<ColorInfo> ColorInfos = null;
        public static bool IsHigh;
        public static bool IsCeiling;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Application app = commandData.Application.Application;
            doc = uIDoc.Document;

            //var testRef = sel.PickObject(ObjectType.Element);
            //var testElem = doc.GetElement(testRef);
            //TaskDialog.Show("revit", GetElementColorInCurrentView(doc, testElem).Red.ToString());
            //return Result.Succeeded;

            var basePoint = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectBasePoint).WhereElementIsNotElementType().First();
            var elevation = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsValueString();
            int intElevation = Convert.ToInt32(elevation);

            List<Group> allGroup = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_IOSModelGroups).OfClass(typeof(Group)).Cast<Group>().ToList();
            // 获取所有楼板
            List<Element> floors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor))
                .WhereElementIsNotElementType()/*.Cast<Floor>()*/.ToList();
            // 获取所有组中的楼板
            List<Element> floorInGroup = new List<Element>();
            foreach (var group in allGroup)
            {
                foreach (var id in group.GetMemberIds())
                {
                    Element e = doc.GetElement(id);
                    if (e is Floor) floorInGroup.Add(e);
                }
            }
            //floors.AddRange(floorInGroup); // 不需要通过组添加

            // 获取所有天花板
            List<Element> ceilings = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Ceilings).OfClass(typeof(Ceiling))
                .WhereElementIsNotElementType()/*.Cast<Ceiling>()*/.ToList();
            // 获取所有组中的天花板
            List<Element> ceilingInGroup = new List<Element>();
            foreach (var group in allGroup)
            {
                foreach (var id in group.GetMemberIds())
                {
                    Element e = doc.GetElement(id);
                    if (e is Ceiling) ceilingInGroup.Add(e);
                }
            }
            //ceilings.AddRange(ceilingInGroup);

            var floorOrCeilings = new List<Element>();

            //获取填充方式（实体填充）
            FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
            fillPatternElementFilter.OfClass(typeof(FillPatternElement));
            FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
            .GetFillPattern().IsSolidFill) as FillPatternElement;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
// ... truncated ...
```

## KeyUtils.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ColoringOfStructuralPlates
{
    public class KeyUtils
    {
        [DllImport("user32.dll", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, UIntPtr dwExtraInfo);

        // ESC键的虚拟键码
        private const byte VK_ESCAPE = 0x1B;

        // 按键标志
        private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;
        private const uint KEYEVENTF_KEYUP = 0x0002;
        /// <summary>
        /// 使用Windows API模拟ESC键
        /// </summary>
        public static void SimulateEscapePress()
        {
            try
            {
                // 按下ESC键
                keybd_event(VK_ESCAPE, 0, KEYEVENTF_EXTENDEDKEY, UIntPtr.Zero);

                // 等待10毫秒
                System.Threading.Thread.Sleep(10);

                // 释放ESC键
                keybd_event(VK_ESCAPE, 0, KEYEVENTF_KEYUP, UIntPtr.Zero);
            }
            catch (Exception ex)
            {
                throw new Exception($"模拟ESC键失败: {ex.Message}");
            }
        }
    }
}

```

## ChangeFloorColor.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = Autodesk.Revit.DB.Color;

namespace ColoringOfStructuralPlates
{
    public class ChangeFloorColor : IExternalEventHandler
    {
        public List<ElementId> ElemIds { get; set; } = new List<ElementId>();
        public Element FloorOrCeiling { get; set; }
        public Color Color { get; set; }
        public List<ChangeColorInfo> ChangeColorInfos { get; set; } = new List<ChangeColorInfo>();
        public void Execute(UIApplication app)
        {
            if (ElemIds.Count == 0) goto Next;
            try
            {
                Document doc = app.ActiveUIDocument.Document;

                //获取填充方式（实体填充）
                FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
                fillPatternElementFilter.OfClass(typeof(FillPatternElement));
                FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
                .GetFillPattern().IsSolidFill) as FillPatternElement;

                if (FloorOrCeiling != null) ElemIds.Add(FloorOrCeiling.Id);
                Transaction t = new Transaction(doc, "更改楼板颜色");
                t.Start();
                foreach (var id in ElemIds)
                {
                    //OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(FloorOrCeiling.Id);
                    OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(id);
                    overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);//前景填充图案
                    overrideGraphicSettings.SetSurfaceForegroundPatternColor(Color);//前景填充颜色
                    overrideGraphicSettings.SetSurfaceTransparency(0);//设置透明度(0：不透明；1：透明)

                    overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
                    overrideGraphicSettings.SetCutForegroundPatternColor(Color);
                    overrideGraphicSettings.SetCutForegroundPatternVisible(true);
                    //将设置应用到视图
                    doc.ActiveView.SetElementOverrides(id, overrideGraphicSettings);
                }
                t.Commit();
            }
            catch (Exception e)
            {
                //TaskDialog.Show("revit", e.ToString());
            }
        Next:
            if (ChangeColorInfos.Count == 0) return;
            try
            {
                Document doc = app.ActiveUIDocument.Document;

                //获取填充方式（实体填充）
                FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
                fillPatternElementFilter.OfClass(typeof(FillPatternElement));
                FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
                .GetFillPattern().IsSolidFill) as FillPatternElement;

                Transaction t = new Transaction(doc, "更改楼板颜色");
                t.Start();
                foreach (var info in ChangeColorInfos)
                {
                    //OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(FloorOrCeiling.Id);
                    OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(info.ElementId);
                    overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);//前景填充图案
                    overrideGraphicSettings.SetSurfaceForegroundPatternColor(info.Color);//前景填充颜色
                    overrideGraphicSettings.SetSurfaceTransparency(0);//设置透明度(0：不透明；1：透明)

                    overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
                    overrideGraphicSettings.SetCutForegroundPatternColor(info.Color);
                    overrideGraphicSettings.SetCutForegroundPatternVisible(true);
                    //将设置应用到视图
                    doc.ActiveView.SetElementOverrides(info.ElementId, overrideGraphicSettings);
                    //TaskDialog.Show("rvi", info.Color.Red + "," + info.Color.Green + "," + info.Color.Blue);
                }
                t.Commit();
            }
            catch (Exception)
// ... truncated ...
```

