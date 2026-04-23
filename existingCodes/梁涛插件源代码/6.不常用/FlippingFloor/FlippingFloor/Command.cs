using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;
using Reference = Autodesk.Revit.DB.Reference;
using Transform = Autodesk.Revit.DB.Transform;

namespace FlippingFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;


            MainWindow mainWindow = new MainWindow(doc, uIDoc);
            GlobalResources.MainWindow1 = mainWindow;
            mainWindow.Show();
            Application app = commandData.Application.Application;
            app.DocumentChanged += OnDocumentChanged;
            return Result.Succeeded;
        }
        private void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            Document doc = e.GetDocument();
            List<FloorType> familySymbols = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(FloorType)).Cast<FloorType>().ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            HashSet<string> names = new HashSet<string>();
            foreach (var item in familySymbols)
            {
                string input = item.Name;
                string pattern = @"\d+(?=mm)";
                Match match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    string symbolName = item.Name.Replace(match.Value, "");
                    symbolName = symbolName.Replace("mm", "");
                    names.Add(symbolName);
                }    
            }
            GlobalResources.MainWindow1.ftn.ItemsSource = names.OrderBy(x => x);
        }
        //获取选中图层名称
        public static string GetLayerName(Document doc, Reference reference)
        {
            string name = null;
            Element element = doc.GetElement(reference);
            GeometryElement geoElem = element.get_Geometry(new Options());//几何图元
            GeometryObject geoObj = element.GetGeometryObjectFromReference(reference);//几何对象
            Category targetCategory = null;
            ElementId graphicsStyleId = null;
            if (geoObj.GraphicsStyleId != ElementId.InvalidElementId)
            {
                graphicsStyleId = geoObj.GraphicsStyleId;
                GraphicsStyle gs = doc.GetElement(geoObj.GraphicsStyleId) as GraphicsStyle;//获得所选对象图形样式
                if (gs != null)
                {
                    targetCategory = gs.GraphicsStyleCategory;//图层
                    name = gs.GraphicsStyleCategory.Name;//图层名字                           
                }
            }
            return name;
        }
        //获取两直线相交点
        public static XYZ GetIntersectionPoint(Line line1, Line line2)
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
        public bool IsPointInsidePolygon(List<Line> polygon, XYZ point)
        {
            int count = 0;

            // 创建一条从点到轮廓外部的远处的射线
            Line ray = Line.CreateBound(point, new XYZ(point.X + 10000, point.Y, point.Z));

            // 遍历每条轮廓线段
            for (int i = 0; i < polygon.Count; i++)
            {
                // 获取当前线段和下一线段
                Line line1 = polygon[i];

                // 检查射线与当前线段是否相交
                IntersectionResultArray results;
                SetComparisonResult result = ray.Intersect(line1, out results);

                // 如果相交
                if (result == SetComparisonResult.Overlap)
                {
                    count++;
                }
            }
            
            // 如果交点数为奇数，则点在轮廓内部
            return count % 2 == 1;
        }
    }
    public static class GlobalResources
    {
        public static MainWindow MainWindow1 { get; set; }
    }
    public class TextNoteInfo
    {
        public List<Line> Lines { get; set; }
        public TextNote TextNote { get; set; }
    }
    //创建楼板需要的相关信息
    public class FloorInfo
    {
        public CurveArray CurveArray { get; set; }
        public string SymbolName { get; set; }
        public TextNote TextNote { get; set; }
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
}
