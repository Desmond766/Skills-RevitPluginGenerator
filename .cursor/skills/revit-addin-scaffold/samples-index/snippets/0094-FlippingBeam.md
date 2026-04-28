# Sample Snippet: FlippingBeam

Source project: `existingCodes\梁涛插件源代码\1.土建\FlippingBeam\FlippingBeam`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FlippingBeam
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        //static string dll = @"C:\ProgramData\Autodesk\Revit\Addins\2020\Teigha_Net64\TD_Mgd.dll";//引用位置
        //Assembly a = Assembly.UnsafeLoadFrom(dll);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Assembly.UnsafeLoadFrom(@"C:\ProgramData\Autodesk\Revit\Addins\2020\Teigha_Net64\TD_Mgd.dll");
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            //MainWindow mainWindow = new MainWindow(doc, uIDoc);
            //mainWindow.ShowDialog();
            //return Result.Succeeded;
            //IndependentTag independentTag = doc.GetElement(uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element)) as IndependentTag;
            //string text2 = independentTag.TagText;
            //text2 = Regex.Replace(text2, @"[^0-9]+", "");
            //text2 = text2.Replace("0", "");
            //TaskDialog.Show("sds", text2);
            //return Result.Succeeded;
            ProgressBar progressBar = new ProgressBar();

            progressBar.Show();
            return Result.Succeeded;


            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement,"选择梁中线图层");
            Reference referenceText = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement,"选择文字信息图层");
            //TaskDialog.Show("dsda", GetLayerName(doc, referenceText));
            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            Transform transform = dwg.GetTransform();
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            //TaskDialog.Show("revit", geoObj.GetType().ToString());
            //Transform transf = null;
            XYZ p1 = null;
            XYZ p2 = null;
            //获取选中线段所在图层所有的线段
            List<Line> lines = new List<Line>();
            List<PolyLine> polyLines = new List<PolyLine>();
            List<GeometryObject> geometryObjects = new List<GeometryObject>();
            GeometryElement geometryElement = dwg.get_Geometry(new Options());
            foreach (var item in geometryElement)
            {
                if (item is GeometryInstance geometryInstance)
                {
                    GeometryElement geometryElement1 = geometryInstance.GetInstanceGeometry();
                    //int count = 0;
                    foreach (var item1 in geometryElement1)
                    {
                        //if (item1 is Line line1 && count==0)
                        //{
                        //    count++;
                        //    TaskDialog.Show("ds", GetLayerName(doc, reference) + "\n" + (doc.GetElement(line1.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name);
                        //}
                        if (item1 is Line line && GetLayerName(doc, reference) == (doc.GetElement(line.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name)
                        {
                            //Line line = item1 as Line;
                            lines.Add(line);
                        }else if (item1 is PolyLine polyLine && GetLayerName(doc, reference) == (doc.GetElement(polyLine.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name)
                        {
                            //PolyLine polyLine = item1 as PolyLine;
                            polyLines.Add(polyLine);
                        }
                    }
                }
            }
            if (polyLines.Count > 0)
            {
                foreach (var item in polyLines)
                {
                    IList<XYZ> points = item.GetCoordinates();
                    for (int i = 0; i < points.Count - 1; i++)
                    {
                        Line line = Line.CreateBound(points[i], points[i+1]);
                        lines.Add(line);
                    }
// ... truncated ...
```

## DelEventCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingBeam
{
    public class DelEventCommand : IExternalEventHandler
    {
        public bool isTextNote { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;

            if (isTextNote)
            {
                List<ElementId> textNoteIds = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Select(x => x.Id).ToList();
                using (Transaction t = new Transaction(doc, "删除所有文字注释"))
                {
                    t.Start();
                    foreach (var item in textNoteIds)
                    {
                        doc.Delete(item);
                    }
                    t.Commit();
                }
            }
            else
            {
                List<ElementId> tagIds = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFramingTags).OfClass(typeof(IndependentTag)).Cast<IndependentTag>().Select(x => x.Id).ToList();
                using (Transaction t = new Transaction(doc, "删除所有梁标记"))
                {
                    t.Start();
                    foreach (var item in tagIds)
                    {
                        doc.Delete(item);
                    }
                    t.Commit();
                }
            }
        }

        public string GetName()
        {
            return "DelEventCommand";
        }
    }
}

```

## EventCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FlippingBeam
{
    public class EventCommand : IExternalEventHandler
    {
        public ElementId beamId { get; set; }
        public string beamName { get; set; }
        public string correct { get; set; }
        public string noteText { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            //string newBeamName = Regex.Replace(doc.GetElement(beamId).Name, @"[^0-9]+", "");
            //if (noteText == "未找到")
            //{
            //    Position.correct = "未知";
            //}
            //else if (newBeamName == noteText )
            //{
            //    Position.correct = "是";
            //}
            //else
            //{
            //    Position.correct = "否";
            //}
            try
            {
                uIDoc.ShowElements(beamId);
                uIDoc.Selection.SetElementIds(new List<ElementId>() { beamId });
            }
            catch (Exception)
            {

                throw;
            }
            

            ////放样
            //double radius = 1000 / 304.8;
            //Curve circle1 = Arc.Create(point, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
            //Curve circle2 = Arc.Create(point, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
            //List<CurveLoop> loops = new List<CurveLoop>();
            //List<Curve> curveList = new List<Curve> { circle1, circle2 };
            //CurveLoop curveLoop = CurveLoop.Create(curveList);
            //loops.Add(curveLoop);
            ////拉伸
            //Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200);
            //ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
            //List<FamilyInstance> beams = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance)).WherePasses(filter).Cast<FamilyInstance>().Where(x => x.Symbol.FamilyName.Contains("梁")).ToList();
            //if (beams.Count == 0)
            //{
            //    uIDoc.ShowElements(noteId);
            //    uIDoc.Selection.SetElementIds(new List<ElementId>() { noteId });
            //}
            //else if (beams.Count == 1)
            //{
            //    Line line = (beams.First().Location as LocationCurve).Curve as Line;
            //    double angle1 = line.Direction.AngleTo(XYZ.BasisX);
            //    double angle2 = line.Direction.AngleTo(XYZ.BasisX.Negate());

            //    uIDoc.ShowElements(beams.First().Id);
            //    uIDoc.Selection.SetElementIds(new List<ElementId>() { beams.First().Id });
            //}
            //else
            //{
            //    double minDistance = double.MaxValue;
            //    FamilyInstance minBeam = null;
            //    foreach (var item in beams)
// ... truncated ...
```

