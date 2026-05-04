# Sample Snippet: CreateSteelPipes

Source project: `existingCodes\梁涛插件源代码\10.CEG\CreateSteelPipes\CreateSteelPipes`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.IO;
using Autodesk.Revit.ApplicationServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CreateSteelPipes
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            UIApplication uiApp = commandData.Application;
            Application app = uiApp.Application;
            Document doc = uidoc.Document;

            Selection sel = uidoc.Selection;

            FamilyInstance familyInstance1 = doc.GetElement(sel.PickObject(ObjectType.Element, new SpecializedEquipmentFilter(), "Select The first Family Instance")) as FamilyInstance;
            FamilyInstance familyInstance2 = doc.GetElement( sel.PickObject(ObjectType.Element, new SpecializedEquipmentFilter(), "Select The Second Family Instance")) as FamilyInstance;
            FamilyInstance familyInstance3 = doc.GetElement(sel.PickObject(ObjectType.Element, new SpecializedEquipmentFilter(), "Select The Third Family Instance")) as FamilyInstance;
            FamilySymbol familySymbol = familyInstance3.Symbol;
            double famLength = familyInstance1.Symbol.LookupParameter("Sleeve Length (mm)").AsDouble();

            UserControl1 userControl1 = new UserControl1();

            //string logFilePath = Path.Combine(Path.GetDirectoryName(app.RecordingJournalFilename), "PluginLogNum.txt");
            //string num = "";  
            //if (File.Exists(logFilePath))
            //{
            //    // 读取上一次的值作为wpf窗体文本框的值
            //    num = File.ReadAllText(logFilePath);
            //    userControl1.textBox.Text = num;

            //}
            userControl1.ShowDialog();
            if (userControl1.cancel)
            {
                return Result.Cancelled;
            }                
            //    // 读取上一次的值
            //    num = userControl1.textBox.Text;
            //    //将数值写入文本文件
            //    File.WriteAllText(logFilePath, num);
            ////else
            ////{
            ////    File.Create(logFilePath);
            ////    // 读取上一次的值
            ////    string num = userControl1.textBox.Text;
            ////    //将数值写入文本文件
            ////    File.WriteAllText(logFilePath, num);
            ////}

            double insertionLength = Convert.ToDouble(userControl1.textBox.Text) / 304.8;

            XYZ startPoint1 = (familyInstance1.Location as LocationPoint).Point;
            Transform transform = familyInstance1.GetTransform();
            XYZ direction = transform.OfVector(XYZ.BasisZ);
            XYZ endPoint1 = startPoint1 + direction * 10000 / 304.8;
            XYZ sleeveEndPoint1 = startPoint1 + direction * familyInstance1.Symbol.LookupParameter("Sleeve Length (mm)").AsDouble();
            XYZ newStartPoint1 = startPoint1 - direction * 10000 / 304.8;
            Line line1 = Line.CreateBound(startPoint1, endPoint1);
            Line sleeveLine1 = Line.CreateBound(startPoint1, sleeveEndPoint1);
            
            XYZ startPoint2 = (familyInstance2.Location as LocationPoint).Point;
            Transform transform2 = familyInstance2.GetTransform();
            XYZ direction2 = transform2.OfVector(XYZ.BasisZ);
            XYZ endPoint2 = startPoint2 + direction2 * 10000 / 304.8;
            XYZ sleeveEndPoint2 = startPoint2 + direction2 * familyInstance2.Symbol.LookupParameter("Sleeve Length (mm)").AsDouble();
            XYZ newStartPoint2 = startPoint2 - direction2 * 10000 / 304.8;
            Line line2 = Line.CreateBound(startPoint2, endPoint2);
            Line sleeveLine2 = Line.CreateBound(startPoint2, sleeveEndPoint2);
            XYZ intersectionPoint = GetIntersectionPoint(line1, line2);

            bool straightSteelBars = false;

            double length1;
            double length2;
            double setLength = 0;
            double setLength1 = 0;
            double setLength2 = 0;
// ... truncated ...
```

## SpecializedEquipmentFilter.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateSteelPipes
{
    internal class SpecializedEquipmentFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == -2001350)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            throw new NotImplementedException();
        }
    }
}

```

