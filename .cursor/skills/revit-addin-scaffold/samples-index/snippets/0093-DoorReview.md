# Sample Snippet: DoorReview

Source project: `existingCodes\梁涛插件源代码\1.土建\DoorReview\DoorReview`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DoorReview
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Assembly assembly = Assembly.UnsafeLoadFrom(@"\\192.168.0.251\在制项目2\品成Revit插件商店\品成Revit插件商店\108楼板翻模\FlippingFloor.dll");

            //Type commandType = assembly.GetTypes().FirstOrDefault(t => typeof(IExternalCommand).IsAssignableFrom(t) && !t.IsAbstract && t.FullName == "FlippingFloor.Command");
            //IExternalCommand exCommand = (IExternalCommand)Activator.CreateInstance(commandType);
            //Result result = exCommand.Execute(commandData, ref message, elements);

            //Type type = assembly.GetType("NewBTStore.UpdateCmd");
            //string info = "";
            //var types = assembly.GetTypes();
            //foreach (var item in types)
            //{
            //    object instance2;

            //    var propInfos = item.GetMethods();
            //    info += item.Name + "\n";
            //    foreach (var item2 in propInfos)
            //    {
            //        info += item2.Name + "||";
            //    }
            //    info += "\n";
            //}

            //TaskDialog.Show("revit", info);
            //var instance = Activator.CreateInstance(type);
            //var method = type.GetMethod("Execute", new Type[] { typeof(ExternalCommandData), typeof(string), typeof(ElementSet) });
            //Result result2 = (Result)(method?.Invoke(instance, new object[] { commandData, message, elements }));




            //return Result.Succeeded;

            ScopeWindow scopeWindow = new ScopeWindow();
            scopeWindow.ShowDialog();
            if (scopeWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            double scope = scopeWindow.Scope / 304.8;
            //TaskDialog.Show("revti", scope.ToString());

            var textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();

            var doors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().ToList();
            List<DoorInfo> doorInfos = new List<DoorInfo>();
            // HACK: 25.10.30 新增完整文本注释与不完整文字注释选项

            if (scopeWindow.Full)
            {
                foreach (var door in doors)
                {
                    // 判断文字注释是否与门方向平行，误差为0.18（10°）
                    //var textNote = textNotes.Where(x => IsParallel(x.BaseDirection, door as FamilyInstance, 0.18)).Where(x => (x.Coord + XYZ.BasisZ.Negate() * x.Coord.Z).DistanceTo((GetPoint(door) + XYZ.BasisZ.Negate() * GetPoint(door).Z)) < 5000 / 304.8).OrderBy(t => t.Coord.DistanceTo(GetPoint(door))).FirstOrDefault(); //判断距离需在同一Z平面上
                    var textNote = textNotes.Where(x => IsParallel(x.BaseDirection, door as FamilyInstance, 0.18)).Where(x => (x.Coord + XYZ.BasisZ.Negate() * x.Coord.Z).DistanceTo((GetPoint(door) + XYZ.BasisZ.Negate() * GetPoint(door).Z)) < scope).OrderBy(t => t.Coord.DistanceTo(GetPoint(door))).FirstOrDefault(); //判断距离需在同一Z平面上
                    if (textNote == null)
                    {
                        doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "未知", IsBold = true, TextColor = "yellow", FamilySymbol = door.Symbol });
                        continue;
                    }
                    string text = textNote.Text;
                    text = text.Replace("\r", "");
                    text = text.Replace("\n", "");
                    string num = Regex.Replace(text, "[^0-9]+", "");
                    if (num.Count() != 4)
                    {
                        doorInfos.Add(new DoorInfo() { Door = door, DoorName = door.Name, DoorId = door.Id, Correct = "未知", NoteText = text, IsBold = true, TextColor = "yellow", FamilySymbol = door.Symbol });
// ... truncated ...
```

## BrushBackColorConverter.cs

```csharp
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace DoorReview
{
    public class BrushBackColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((string)value == "blue")
            {
                return new SolidColorBrush(Color.FromRgb(0, 0, 255));
            }
            else
            {
                return new SolidColorBrush();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

```

## ChangeSymbolEvent.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DoorReview
{
    internal class ChangeSymbolEvent : IExternalEventHandler
    {
        public FamilyInstance Door { get; set; }
        public FamilySymbol DoorSymbol { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document document = app.ActiveUIDocument.Document;
            using (Transaction t = new Transaction(document, "更换门类型"))
            {
                t.Start();
                try
                {
                    Door.ChangeTypeId(DoorSymbol.Id);
                    t.Commit();
                }
                catch (Exception e)
                {
                    if (t.HasStarted()) t.RollBack();
                    MessageBox.Show(e.Message);
                }
                uidoc.Selection.SetElementIds(new ElementId[] { Door.Id });
            }
            
        }

        public string GetName()
        {
            return "ChangeSymbolEvent";
        }
    }
}

```

