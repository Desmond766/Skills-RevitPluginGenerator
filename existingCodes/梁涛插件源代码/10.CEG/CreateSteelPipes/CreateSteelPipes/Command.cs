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
            int count = 0;
            //两正
            if (intersectionPoint != null)
            {
                count++;
                length1 = startPoint1.DistanceTo(intersectionPoint);
                length2 = startPoint2.DistanceTo(intersectionPoint);
                setLength1 = length1 - famLength + insertionLength;
                setLength2 = length2 - famLength + insertionLength;
            }
            //一正一反
            if (intersectionPoint == null)
            {
                Line line3 = Line.CreateBound(startPoint1, endPoint1);
                Line line4 = Line.CreateBound(newStartPoint2, startPoint2);
                intersectionPoint = GetIntersectionPoint(line3, line4);
            }
            if (intersectionPoint != null && count == 0)
            {
                count++;
                length1 = startPoint1.DistanceTo(intersectionPoint);
                length2 = startPoint2.DistanceTo(intersectionPoint);
                setLength1 = length1 - famLength + insertionLength;
                setLength2 = length2 + insertionLength;
            }
            //一反一正
            if (intersectionPoint == null)
            {
                Line line3 = Line.CreateBound(newStartPoint1, startPoint1);
                Line line4 = Line.CreateBound(startPoint2, endPoint2);
                intersectionPoint = GetIntersectionPoint(line3, line4);
            }
            if (intersectionPoint != null && count == 0)
            {
                count++;
                length1 = startPoint1.DistanceTo(intersectionPoint);
                length2 = startPoint2.DistanceTo(intersectionPoint);
                setLength1 = length1 + insertionLength;
                setLength2 = length2 - famLength + insertionLength;
            }
            //两反
            if (intersectionPoint == null)
            {
                Line line3 = Line.CreateBound(newStartPoint1, startPoint1);
                Line line4 = Line.CreateBound(newStartPoint2, startPoint2);
                intersectionPoint = GetIntersectionPoint(line3, line4);
            }
            if (intersectionPoint != null && count == 0)
            {
                length1 = startPoint1.DistanceTo(intersectionPoint);
                length2 = startPoint2.DistanceTo(intersectionPoint);
                setLength1 = length1 + insertionLength;
                setLength2 = length2 + insertionLength;
            }
            //两套筒反方向平行
            if ((intersectionPoint == null) && (line1.Direction.IsAlmostEqualTo(line2.Direction.Negate())))
            {
                if (startPoint1.DistanceTo(startPoint2) > sleeveEndPoint1.DistanceTo(sleeveEndPoint2))
                {
                    intersectionPoint = sleeveEndPoint1 - direction * insertionLength;
                    straightSteelBars = true;
                    setLength = sleeveEndPoint1.DistanceTo(sleeveEndPoint2) + insertionLength * 2;
                }
                else
                {
                    intersectionPoint = startPoint1 + direction * insertionLength; ; /*(startPoint1 + sleeveEndPoint2) / 2;*/
                    straightSteelBars = true;
                    setLength = startPoint1.DistanceTo(startPoint2) + insertionLength * 2;
                }
            }
            //两套筒平行
            if (intersectionPoint == null && line1.Direction.IsAlmostEqualTo(line2.Direction))
            {
                if (startPoint1.DistanceTo(sleeveEndPoint2) > sleeveEndPoint1.DistanceTo(startPoint2))
                {
                    intersectionPoint = sleeveEndPoint1 - direction * insertionLength;
                    straightSteelBars = true;
                    setLength = sleeveEndPoint1.DistanceTo(startPoint2) + insertionLength * 2;
                }
                else
                {
                    intersectionPoint = startPoint1 + direction * insertionLength;
                    straightSteelBars = true;
                    setLength = startPoint1.DistanceTo(sleeveEndPoint2) + insertionLength * 2;
                }
            }
            if (intersectionPoint == null)
            {
                TaskDialog.Show("tips", "Intersection Not Found");
                return Result.Failed;
            }

            //FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_SpecialityEquipment).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().Where(x => x.FamilyName == "BAR_L" && x.Name == "D29").ToList().First();
            //double angle = 0;
            //ElementIntersectsElementFilter elementIntersectsElementFilter = new ElementIntersectsElementFilter(familyInstance1);
            //ElementIntersectsElementFilter elementIntersectsElementFilter2 = new ElementIntersectsElementFilter(familyInstance2);


            using (Transaction trans = new Transaction(doc, "Create Steel Pipe"))
            {
                trans.Start();
                //Level level = doc.GetElement(familyInstance3.LookupParameter("标高").AsElementId()) as Level;
                FamilyInstance familyInstance = doc.Create.NewFamilyInstance(intersectionPoint, familySymbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                Line axis = Line.CreateBound(intersectionPoint, new XYZ(intersectionPoint.X, intersectionPoint.Y, 0));
                if (straightSteelBars == false)
                {
                    familyInstance.LookupParameter("BAR_LENGTH_B").Set(setLength1);
                    familyInstance.LookupParameter("BAR_LENGTH_C").Set(setLength2);
                }
                else if (straightSteelBars)
                {
                    familyInstance.LookupParameter("DIM_LENGTH").Set(setLength);
                }
                //ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, (-90 / 180) * Math.PI);
                trans.Commit();
            }

            return Result.Succeeded;
        }

        private XYZ GetIntersectionPoint(Line line1, Line line2)
        {
            // 判断两条直线是否相交
            SetComparisonResult result = line1.Intersect(line2, out IntersectionResultArray intersectionResult);

            // 如果相交，获取交点坐标
            if (result == SetComparisonResult.Overlap)
            {
                XYZ intersectionPoint = intersectionResult.get_Item(0).XYZPoint;
                return intersectionPoint;
            }
            else
            {
                // 如果不相交，返回null或者抛出异常
                return null;
            }
        }
    }
}
