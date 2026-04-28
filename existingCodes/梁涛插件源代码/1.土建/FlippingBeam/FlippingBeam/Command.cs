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
                }
            }
            //foreach (var item in polyLines)
            //{
            //    if (item.NumberOfCoordinates==3)
            //    {
            //        TaskDialog.Show("sd", "dayu3");
            //        break;
            //    }
            //}
            //return Result.Succeeded;
            //FamilySymbol familySymbol = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).Where(x => x.Name.Equals("S-KL-200×400mm")).Cast<FamilySymbol>().First();
            //FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Where(x => x.Name.Equals("QI45")).Cast<FamilySymbol>().First();
            List<Line> linesCopy = new List<Line>();
            foreach (var item in lines)
            {
                linesCopy.Add(item);
            }
            List<Line> newLines = new List<Line>();
            foreach(var item in lines)
            {
                foreach (var item1 in linesCopy)
                {
                    if (item.GetEndPoint(0).DistanceTo(item1.GetEndPoint(0)) < 0.0001) continue;
                    XYZ cp1 = item.GetEndPoint(0).Add(item.GetEndPoint(1)) / 2;
                    XYZ cp2 = item1.GetEndPoint(0).Add(item1.GetEndPoint(1)) / 2;
                    if (cp1.DistanceTo(cp2) < 1500 / 304.8)
                    {
                        XYZ newp1 = (cp1 + cp2) / 2 + item.Direction * (item.Length / 2);
                        XYZ newp2 = (cp1 + cp2) / 2 - item.Direction * (item.Length / 2);
                        Line line = Line.CreateBound(newp1, newp2);
                        newLines.Add(line);
                        linesCopy.Remove(item1);
                        linesCopy.Remove(item);
                        break;
                    }

                }
            }
            //TaskDialog.Show("ds",lines.Count + "\n" + linesCopy.Count);
            //return Result.Succeeded;
            //using (Transaction t = new Transaction(doc, "创建梁"))
            //{
            //    t.Start();
            //    foreach (var item in lines)
            //    {
            //        foreach (var item1 in linesCopy)
            //        {
            //            //if (item.GetEndPoint(0) == item1.GetEndPoint(0)) continue;
            //            if (item.GetEndPoint(0).DistanceTo(item1.GetEndPoint(0)) < 0.0001) continue;
            //            XYZ cp1 = item.GetEndPoint(0).Add(item.GetEndPoint(1)) / 2;
            //            XYZ cp2 = item1.GetEndPoint(0).Add(item1.GetEndPoint(1)) / 2;
            //            if (cp1.DistanceTo(cp2) < 600 / 304.8)
            //            {
            //                XYZ newp1 = (cp1 + cp2) / 2 + item.Direction * (item.Length / 2);
            //                XYZ newp2 = (cp1 + cp2) / 2 - item.Direction * (item.Length / 2);
            //                Line line = Line.CreateBound(newp1, newp2);
            //                if (!familySymbol.IsActive)
            //                {
            //                    familySymbol.Activate();
            //                }
            //                doc.Create.NewFamilyInstance(line, familySymbol, doc.ActiveView.GenLevel, Autodesk.Revit.DB.Structure.StructuralType.Beam);
            //                //lines.Remove(item);
            //                linesCopy.Remove(item1);
            //                linesCopy.Remove(item);
            //                break;
            //            }
            //        }
            //    }
            //    t.Commit();
            //}
            //TaskDialog.Show("sd", "sdsdsd" + lines.Count());
            //return Result.Succeeded;
            //获取当前视图所有文字注释
            List<TextNote> textNotes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
            //获取选中图层的所有文字信息
            Class2 class2 = new Class2();
            Element element = doc.GetElement(referenceText);
            CADLinkType cADLinkType = doc.GetElement(element.GetTypeId()) as CADLinkType;
            List<CADTextModel> cADTextModels = class2.GetCADTextInfo(Class2.GetCADPath(cADLinkType.Id, doc));
            //List<CADTextModel> cADTextModels = class2.GetCADTextInfo(@"C:\Users\Administrator\Desktop\梁翻模\(已绑定)S-00-DK-上区-B1-梁中线(1).dwg");
            List<CADTextModel> cADTexts = new List<CADTextModel>();
            foreach (var item in cADTextModels)
            {
                if (item.Layer == GetLayerName(doc,referenceText))
                {
                    cADTexts.Add(item);
                }
            }
            int i2 = 0;
            bool j = true;
            using (Transaction t = new Transaction(doc, "创建梁"))
            {
                t.Start();
                foreach (var item in newLines)
                {
                    XYZ cP = item.GetEndPoint(0).Add(item.GetEndPoint(1)) / 2;
                    //foreach (var item2 in cADTexts)
                    //{
                    //    if (cP.DistanceTo(item2.Location) < 2000 / 304.8)
                    //    {
                    //        string text = item2.Text.Replace("*", " x ");
                    //        FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Where(x => x.Name.Equals(text)).Cast<FamilySymbol>().First();
                    //        if (!familySymbol.IsActive)
                    //        {
                    //            familySymbol.Activate();
                    //        }
                    //        doc.Create.NewFamilyInstance(item, familySymbol, doc.ActiveView.GenLevel, Autodesk.Revit.DB.Structure.StructuralType.Beam);
                    //        cADTexts.Remove(item2);
                    //        break;
                    //    }
                    //}
                    foreach (var item2 in cADTextModels)
                    {

                        //if (item.GetEndPoint(0).DistanceTo(item2.Coord) > 1000 / 304.8 && item.GetEndPoint(1).DistanceTo(item2.Coord) > 1000 / 304.8) continue;
                        XYZ transP = transform.OfPoint(item2.Location);
                        if (cP.DistanceTo(transP) > 20000 / 304.8) continue;
                        string text = item2.Text.Replace("\r", "");
                        text = text.Replace("*", " x ");
                        //text = Regex.Replace(text, @"[^A-Za-z0-9]+", "");
                        //char x1 = 'x';
                        //text = text.Replace(x1.ToString(), " " + x1 + " ");
                        text = Regex.Replace(text.Replace("(", "(").Replace(")", ")"), @"[\(]∗", "");
                        if (j && text == "400 x 700")
                        {
                            j = false;
                            TaskDialog.Show("sds", text + 1111);
                        }
                        List<Element> elements1 = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilySymbol)).Where(x => x.Name.Equals(text)).ToList();
                        if (i2 < 1)
                        {
                            i2 += 1;
                            TaskDialog.Show("sd", text + elements1.Count().ToString() + doc.ActiveView.GenLevel.Name);
                        }
                        FamilySymbol familySymbol = elements1.Cast<FamilySymbol>().FirstOrDefault();
                        if (familySymbol != null && !familySymbol.IsActive)
                        {
                            familySymbol.Activate();
                        }
                        if (familySymbol != null)
                        {
                            doc.Create.NewFamilyInstance(item, familySymbol, doc.ActiveView.GenLevel, Autodesk.Revit.DB.Structure.StructuralType.Beam);
                            i2 += 1;
                            break;
                        }
                    }
                }
                t.Commit();
            }
            //TaskDialog.Show("ds", i.ToString());
            //TaskDialog.Show("ds", lines.Count + "\n" + linesCopy.Count);
            //TaskDialog.Show("revit", lines.Count().ToString() + "\n" + polyLines.Count() + "\n" + geometryObjects.Count());
            //TaskDialog.Show("revit", GetLayerName(doc,reference));
            //if (geoObj is Line)
            //{
            //    Line l = geoObj as Line;
            //    p1 = l.GetEndPoint(0);
            //    p2 = l.GetEndPoint(1);
            //    //p2 = transform.OfPoint(p2);
            //    TaskDialog.Show("revit", p2.X.ToString());
            //}
            return Result.Succeeded;
        }
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
    }
}
