# Sample Snippet: ViewScaling

Source project: `existingCodes\梁涛插件源代码\10.CEG\ViewScaling\ViewScaling`

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
using System.Text;
using System.Threading.Tasks;
using ViewScaling.Properties;
using Settings = ViewScaling.Properties.Settings;

namespace ViewScaling
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            View view = doc.ActiveView;

            MainWindow mainWindow = new MainWindow(doc);
            mainWindow.ShowDialog();
            if (mainWindow.Cancel)
            {
                return Result.Cancelled;
            }
            //double scaling = doc.ActiveView.Scale / Settings.Default.scale;
            double scaling = 1 - Settings.Default.scale / doc.ActiveView.Scale;

            List<Dimension> dimensions = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Dimensions).WhereElementIsNotElementType().Cast<Dimension>().ToList();

            List<DetailLine> detailLines = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory((BuiltInCategory)(-2000051)).WhereElementIsCurveDriven().Where(x => x is DetailLine && x.GroupId.IntegerValue == -1).Cast<DetailLine>().ToList();
            //TaskDialog.Show("revit", detailLines.Count.ToString());
            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).WhereElementIsNotElementType().Cast<TextNote>().ToList();

            FamilyInstance familyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().Cast<FamilyInstance>().ToList().FirstOrDefault();

            AssemblyInstance assemblyInstance = new FilteredElementCollector(doc,doc.ActiveView.Id).OfCategoryId(new ElementId(-2000267)).WhereElementIsNotElementType().Cast<AssemblyInstance>().ToList().FirstOrDefault();

            XYZ max = assemblyInstance.get_BoundingBox(doc.ActiveView).Max;
            XYZ min = assemblyInstance.get_BoundingBox(doc.ActiveView).Min;
            if (familyInstance == null || assemblyInstance == null)
            {
                TaskDialog.Show("错误", "未能找到该视图的结构框架或部件");
                return Result.Cancelled;
            }

            XYZ famPoint = (familyInstance.Location as LocationPoint).Point;

            Transform transform = familyInstance.GetTransform();

            Options options = new Options();
            options.ComputeReferences = true;
            options.DetailLevel = ViewDetailLevel.Medium;
            GeometryElement geometryElement = familyInstance.get_Geometry(options);

            TransactionGroup TG = new TransactionGroup(doc, "View Scaling");
            TG.Start();
            // 1.移动尺寸标注
            Transaction t1 = new Transaction(doc, "Move Dim");
            t1.Start();
            foreach (var item in dimensions)
            {
                //Line line = ((item.Location as LocationCurve).Curve as Line);
                Line line = item.Curve as Line;
                XYZ lineDir = line.Direction;
                XYZ p = line.Origin;
                if (lineDir.IsAlmostEqualTo(view.UpDirection) || lineDir.IsAlmostEqualTo(view.UpDirection.Negate()))
                {

                    XYZ pp = p.GetProjectionPoint(view.RightDirection);
                    XYZ fampp = famPoint.GetProjectionPoint(view.RightDirection);
                    if ((pp - fampp).Normalize().IsAlmostEqualTo(view.RightDirection))
                    {
                        //XYZ nearP = GetNearestPoint(geometryElement, transform, view.RightDirection, p);
                        XYZ nearP = null;
                        if ((max.GetProjectionPoint(view.RightDirection) - min.GetProjectionPoint(view.RightDirection)).Normalize().IsAlmostEqualTo(view.RightDirection))
                        {
                            nearP = max.GetProjectionPoint(view.RightDirection);
                        }
                        else
                        {
                            nearP = min.GetProjectionPoint(view.RightDirection);
                        }
// ... truncated ...
```

## Command02.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;
using Settings = ViewScaling.Properties.Settings;

namespace ViewScaling
{
    [Transaction(TransactionMode.Manual)]
    public class Command02 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Document doc = uIDoc.Document;

            //Dimension dimension = sel.PickObject(ObjectType.Element).GetElement(doc) as Dimension;
            //DetailLine detailLine = sel.PickObject(ObjectType.Element).GetElement(doc) as DetailLine;
            //Line dimLine = (dimension.Curve as Line);
            ////dimLine.MakeUnbound();
            //Line deLine = (detailLine.Location as LocationCurve).Curve as Line;
            ////deLine.MakeUnbound();
            //SetComparisonResult result = dimLine.Intersect(deLine);
            //if (result == SetComparisonResult.Superset)
            //{
            //    TaskDialog.Show("revit", GetPlanePoint(doc, deLine.GetEndPoint(0)).DistanceTo(GetPlanePoint(doc, dimLine.Origin)) + "\n" + deLine.Origin.DistanceTo(dimLine.Origin + dimLine.Direction * dimension.get_Parameter(BuiltInParameter.DIM_TOTAL_LENGTH).AsDouble() * 304.8));
            //}
            //return Result.Succeeded;

            //Dimension element = sel.PickObject(ObjectType.Element).GetElement(doc) as Dimension;
            //foreach (DimensionSegment segment in element.Segments)
            //{
            //    XYZ leader = segment.LeaderEndPosition;
            //    XYZ ori = segment.Origin;
            //    XYZ text = segment.TextPosition;
            //    TaskDialog.Show("revit", ori.DistanceTo(text) + "\n" + ori.DistanceTo(leader) + "\n" + segment.ValueString);
            //}
            //return Result.Succeeded;

            View view = doc.ActiveView;

            MainWindow mainWindow = new MainWindow(doc);
            mainWindow.ShowDialog();
            if (mainWindow.Cancel)
            {
                return Result.Cancelled;
            }

            double scaling = 1 - Settings.Default.scale / doc.ActiveView.Scale;

            List<Dimension> dimensions = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Dimensions).WhereElementIsNotElementType().Cast<Dimension>().ToList();

            List<DetailLine> detailLines = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Lines).WhereElementIsCurveDriven().Where(x => x is DetailLine && x.GroupId.IntegerValue == -1).Cast<DetailLine>().ToList();

            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).WhereElementIsNotElementType().Cast<TextNote>().ToList();

            List<IndependentTag> tags = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategoryId(new ElementId(-2005014)).WhereElementIsNotElementType().Cast<IndependentTag>().ToList();

            FamilyInstance familyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().Cast<FamilyInstance>().ToList().FirstOrDefault();

            AssemblyInstance assemblyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategoryId(new ElementId(-2000267)).WhereElementIsNotElementType().Cast<AssemblyInstance>().ToList().FirstOrDefault();


            if (familyInstance == null || assemblyInstance == null)
            {
                TaskDialog.Show("错误", "未能找到该视图的结构框架或部件");
                return Result.Cancelled;
            }
            XYZ assMax = assemblyInstance.get_BoundingBox(doc.ActiveView).Max;
            XYZ assMin = assemblyInstance.get_BoundingBox(doc.ActiveView).Min;
            XYZ famMax = familyInstance.get_BoundingBox(doc.ActiveView).Max;
            XYZ famMin = familyInstance.get_BoundingBox(doc.ActiveView).Min;
            TransactionGroup TG = new TransactionGroup(doc, "View Scaling");
            TG.Start();
            // 1.Move Dim assinstance
            using (Transaction t1 = new Transaction(doc, "Move Dim"))
            {
                double moveLength = 0;
                foreach (var item in dimensions)
                {
                    XYZ dimDir = (item.Curve as Line).Direction;
// ... truncated ...
```

