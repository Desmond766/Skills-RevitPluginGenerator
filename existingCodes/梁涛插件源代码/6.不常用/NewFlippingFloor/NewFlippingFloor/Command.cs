using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace NewFlippingFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement,new PlanarFaceFilter(doc));
            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            Autodesk.Revit.DB.Transform transform = dwg.GetTransform();
            PlanarFace planarFace = geoObj as PlanarFace;
            CurveArray curveArray = new CurveArray();
            List<CurveArray> curves = new List<CurveArray>();
            List<SolidIInfo> solidInfos = new List<SolidIInfo>();
            bool first = true;
            foreach (var item in planarFace.GetEdgesAsCurveLoops())
            {
                try
                {
                    List<CurveLoop> loops = new List<CurveLoop>() { item };
                    Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200 / 304.8);
                    solid2 = SolidUtils.CreateTransformed(solid2, transform);
                    double area = Math.Abs(solid2.SurfaceArea);
                    SolidIInfo solidInfo = new SolidIInfo() { SurFaceArea = area, Curves = item };
                    solidInfos.Add(solidInfo);
                }
                catch (Exception)
                {
                    continue;

                }
            }
            solidInfos = solidInfos.OrderByDescending(x => x.SurFaceArea).ToList();
            foreach (var item in solidInfos)
            {
                if (first)
                {
                    first = false;
                    foreach (var item2 in item.Curves)
                    {
                        Curve curve = item2.CreateTransformed(transform);
                        curveArray.Append(curve);
                    }
                }
                else
                {
                    CurveArray curveArray1 = new CurveArray();
                    foreach (var item2 in item.Curves)
                    {
                        Curve curve = item2.CreateTransformed(transform);
                        curveArray1.Append(curve);
                    }
                    curves.Add(curveArray1);
                }
            }
            MainWindow mainWindow = new MainWindow();
            List<Level> levels = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().Cast<Level>().ToList();
            List<FloorType> floorTypes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList();
            foreach (var level in levels)
            {
                mainWindow.cb_level.Items.Add(level.Name);
            }
            foreach (var floorType in floorTypes)
            {
                mainWindow.cb_high.Items.Add(floorType.Name);
            }
            mainWindow.ShowDialog();
            if (mainWindow.Cancel)
            {
                return Result.Cancelled;
            }
            string levelName = mainWindow.cb_level.Text;
            string floorTypeName = mainWindow.cb_high.Text;
            double levelOffset = 0;
            try
            {
                levelOffset = Convert.ToDouble(mainWindow.tb_level_offset.Text) / 304.8;
            }
            catch (Exception e)
            {
                TaskDialog.Show("错误", e.Message);
                return Result.Failed;
            }
            Floor floor = null;
            using (Transaction t = new Transaction(doc,"创建楼板"))
            {
                t.Start();
                FloorType floorType;
                Level level;
                if (levelName == "默认")
                {
                    level = doc.ActiveView.GenLevel;
                }
                else
                {
                    level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).WhereElementIsNotElementType().Cast<Level>().ToList().First(x => x.Name == levelName);
                }
                if (floorTypeName == "默认")
                {
                    floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList().First();
                }
                else
                {
                    floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList().First(x => x.Name == floorTypeName);
                }
                floor = doc.Create.NewFloor(curveArray, floorType, level, false);
                foreach (Parameter para in floor.Parameters)
                {
                    if (para.Definition.Name == "自标高的高度偏移")
                    {
                        para.Set(levelOffset);
                        break;
                    }
                }
                t.Commit();
            }
            using (Transaction t = new Transaction(doc, "楼板开洞"))
            {
                t.Start();
                foreach (var item in curves)
                {
                    doc.Create.NewOpening(floor, item, true);
                }
                t.Commit();
            }
            return Result.Succeeded;
        }
    }
    public class PlanarFaceFilter : ISelectionFilter
    {
        public Document doc { get; set; }
        public PlanarFaceFilter(Document doc)
        {
            this.doc = doc;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            if (geoObj is PlanarFace)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    public class SolidIInfo
    {
        public double SurFaceArea { get; set; }
        public CurveLoop Curves { get; set; }
    }
}
