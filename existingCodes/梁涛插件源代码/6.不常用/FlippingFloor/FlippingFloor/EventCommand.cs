using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Markup;
using System.Windows.Shapes;
using System.Xml.Linq;
using Line = Autodesk.Revit.DB.Line;
using Reference = Autodesk.Revit.DB.Reference;

namespace FlippingFloor
{
    //创建楼板
    public class EventCommand : IExternalEventHandler
    {
        public List<string> CADNames {  get; set; }
        public Reference reference { get; set; }
        public string FloorTypeName { get; set; }
        public List<string> FillCADNames { get; set; } = new List<string>();
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            ImportInstance dwg;
            if (reference == null)
            {
                dwg = new FilteredElementCollector(doc,doc.ActiveView.Id).OfClass(typeof(ImportInstance)).Cast<ImportInstance>().FirstOrDefault();
            }
            else
            {
                dwg = doc.GetElement(reference) as ImportInstance;
            }
            Transform transform = dwg.GetTransform();
            //var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            //获取选中线段所在图层所有的线段
            List<Line> lines = new List<Line>();
            //获取选中所在图层中所有的多段线
            List<PolyLine> polyLines = new List<PolyLine>();
            GeometryElement geometryElement = dwg.get_Geometry(new Options());
            foreach (var item in geometryElement)
            {
                if (item is GeometryInstance geometryInstance)
                {
                    GeometryElement geometryElement1 = geometryInstance.GetInstanceGeometry();
                    //int count = 0;
                    foreach (var item1 in geometryElement1)
                    {
                        if (item1 is Line line && CADNames.Contains((doc.GetElement(line.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name))
                        {
                            //line = Line.CreateBound(new XYZ(line.GetEndPoint(0).X, line.GetEndPoint(0).Y, 0), new XYZ(line.GetEndPoint(1).X, line.GetEndPoint(1).Y, 0));
                            if (line.GetEndPoint(0).Z == line.GetEndPoint(1).Z && line.Length > 1)
                            {
                                lines.Add(line);
                            }
                        }
                        else if (item1 is PolyLine polyLine && CADNames.Contains((doc.GetElement(polyLine.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name)/* && !((doc.GetElement(polyLine.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name).Equals("S-00-DK-上区-B1-柱$0$室内墙1")*/)
                        {
                            polyLines.Add(polyLine);
                        }
                    }
                }
            }
            foreach (var item in polyLines)
            {
                IList<XYZ> points = item.GetCoordinates();
                if (points.Count < 2) continue;
                for (int i = 0; i < points.Count - 1; i++)
                {
                    try
                    {
                        //Line line = Line.CreateBound(points[i], points[i + 1]);
                        Line line = Line.CreateBound(new XYZ(points[i].X, points[i].Y, 0), new XYZ(points[i + 1].X, points[i + 1].Y, 0));
                        if (new XYZ(points[i].X, points[i].Y, 0).DistanceTo(new XYZ(points[i + 1].X, points[i + 1].Y, 0)) > 1) lines.Add(line);
                        
                    }
                    catch (Exception e)
                    {
                        //TaskDialog.Show("ds", e.Message);
                    }
                }
            }

            //获取楼板和文字注释对板厚和标高的映射
            //存放映射数据
            List<MappingInfo> mappingInfos = new List<MappingInfo>();
            List<TNMappingInfo> tNMappingInfos = new List<TNMappingInfo>();
            //数据库连接
            SQLiteConnection m_dbConnection;
            //创建一个连接到指定数据库
            using (m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))//没有数据库则自动创建
            {
                m_dbConnection.Open();
                string projectName = doc.Title;
                string sql = "select * from `" + projectName + "` order by layer_name desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            MappingInfo mappingInfo = new MappingInfo() { LayerName = reader["layer_name"].ToString(), LevelName = reader["level"].ToString(), High = Convert.ToDouble(reader["high"]) };
                            mappingInfos.Add(mappingInfo);
                        }
                    }
                }
                sql = "select * from `" + projectName + "_textnote` order by textnote desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TNMappingInfo tNMappingInfo = new TNMappingInfo() { TextNote = reader["textnote"].ToString(), High = Convert.ToDouble(reader["high"]) };
                            tNMappingInfos.Add(tNMappingInfo);
                        }
                    }
                }
                m_dbConnection.Close();
            }
            
            List<ElementId> ids = new List<ElementId>();
            TransactionGroup tGroup = new TransactionGroup(doc, "楼板翻模");
            tGroup.Start();
            using (Transaction t = new Transaction(doc, "创建模型线"))
            {
                t.Start();
                foreach (var item in lines)
                {
                    bool first = true;
                    SketchPlane sketchPlane = null;
                    if (first)
                    {
                        first = false;
                        Plane plane = Plane.CreateByNormalAndOrigin(XYZ.BasisZ, item.GetEndPoint(0));
                        sketchPlane = SketchPlane.Create(doc, plane);
                    }
                    Line line = Line.CreateBound(item.GetEndPoint(0) - item.Direction * (300 / 304.8), item.GetEndPoint(1) + item.Direction * (300 / 304.8));
                    ModelCurve modelCurve = doc.Create.NewModelCurve(line, sketchPlane);
                    ids.Add(modelCurve.Id);
                }
                t.Commit();
            }
            //TaskDialog.Show("ww",lines.First().GetEndPoint(0).ToString());
            //uIDoc.Selection.SetElementIds(ids);
            //uIDoc.ShowElements(ids);
            //return;
            //当前视图所有文本注释或指定图层下的文字注释
            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
            using (Transaction t = new Transaction(doc, "文字注释位置调整"))
            {
                t.Start();
                foreach (var item in textNotes)
                {
                    //item.Coord = new XYZ(item.Coord.X, item.Coord.Y, 100 / 304.8);
                    item.Coord = new XYZ(item.Coord.X, item.Coord.Y, 0);
                }
                t.Commit();
            }
            List<FillTextNote> fillTextNotes = new List<FillTextNote>();
            List<SolidInfo> solidInfos = new List<SolidInfo>();
            List<PlanarFaceInfo> planarFaceInfos = new List<PlanarFaceInfo>();
            //用户有选择填充图层
            try
            {
                if (FillCADNames.Count != 0)
                {
                    foreach (string name in FillCADNames)
                    {
                        //该图层的所有线段
                        List<Line> lines2 = new List<Line>();
                        ////获取该图层所有的planarFace
                        List<PlanarFace> planarFaces = new List<PlanarFace>();
                        GeometryElement geometryElement1 = dwg.get_Geometry(new Options());
                        foreach (var item in geometryElement1)
                        {
                            if (item is GeometryInstance geometryInstance)
                            {
                                GeometryElement geometryElement2 = geometryInstance.GetInstanceGeometry();
                                //int count = 0;
                                foreach (var item1 in geometryElement2)
                                {
                                    if (item1 is Solid solid)
                                    {
                                        foreach (PlanarFace item2 in solid.Faces)
                                        {
                                            
                                            if ((doc.GetElement(item2.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory.Name == name)
                                            {
                                                CurveLoop loop = new CurveLoop();
                                                List<CurveLoop> curves = new List<CurveLoop>();
                                                
                                                
                                                List<SolidIInfo> solidInfos1 = new List<SolidIInfo>();
                                                foreach (var item3 in item2.GetEdgesAsCurveLoops())
                                                {
                                                    foreach (var item4 in item3)
                                                    {
                                                        if (item4 is Line line)
                                                        {
                                                            lines2.Add(line);
                                                        }
                                                    }
                                                    try
                                                    {
                                                        List<CurveLoop> loops = new List<CurveLoop>() { item3 };
                                                        Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200 / 304.8);
                                                        solid2 = SolidUtils.CreateTransformed(solid2, transform);
                                                        double area = Math.Abs(solid2.SurfaceArea);
                                                        SolidIInfo solidInfo = new SolidIInfo() { SurFaceArea = area, Curves = item3 };
                                                        solidInfos1.Add(solidInfo);
                                                    }
                                                    catch (Exception)
                                                    {
                                                        continue;
                                                        
                                                    }
                                                }
                                                solidInfos1 = solidInfos1.OrderByDescending(x => x.SurFaceArea).ToList();
                                                if (solidInfos1.Count > 0)
                                                {
                                                    loop = solidInfos1.First().Curves;
                                                    curves = solidInfos1.Select(y => y.Curves).ToList();
                                                    curves.Remove(loop);
                                                    PlanarFaceInfo planarFaceInfo = new PlanarFaceInfo() { CurveLoop = loop, CurveLoops = curves, Name = name };
                                                    planarFaceInfos.Add(planarFaceInfo);
                                                }
                                                
                                                //planarFaces.Add(item2);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        ////将planarFace变为solid
                        //List<Solid> solids = new List<Solid>();
                        //List<Line> lines2 = new List<Line>();
                        //foreach (var item in planarFaces)
                        //{
                        //    IList<CurveLoop> curves = new List<CurveLoop>();
                        //    curves = item.GetEdgesAsCurveLoops();
                        //    foreach (CurveLoop curveLoop in curves)
                        //    {
                        //        try
                        //        {
                        //            List<CurveLoop> loops = new List<CurveLoop>() { curveLoop };
                        //            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200 / 304.8);
                        //            solid = SolidUtils.CreateTransformed(solid, transform);
                        //            solids.Add(solid);
                        //        }
                        //        catch (Exception)
                        //        {
                        //            continue;
                        //        }
                        //    }
                        //}
                        //solids = solids.OrderByDescending(x => Math.Abs(x.SurfaceArea)).ToList();
                        ////将solids转换为与图层范围相同的solid
                        //List<Solid> solids2 = new List<Solid>(new Solid[100]);
                        //List<Solid> solidsCopy = new List<Solid>();
                        ////int coun = 0;
                        //foreach (Solid solid in solids)
                        //{
                        //    solids2.Add(solid);
                        //    solidsCopy.Add(solid);
                        //}
                        //for (int i = 0; i < solids.Count - 1; i++)
                        //{
                        //    for (int j = i + 1; j < solids.Count; j++)
                        //    {
                        //        Solid solid1 = BooleanOperationsUtils.ExecuteBooleanOperation(solids[i], solids[j], BooleanOperationsType.Intersect);
                        //        if (solid1 == null || solid1.Faces.Size == 0) continue;
                        //        Solid solid = BooleanOperationsUtils.ExecuteBooleanOperation(solids[i], solids[j], BooleanOperationsType.Difference);
                        //        solids[i] = solid;
                        //        solids2[i] = solid;
                        //        if (solids2.Contains(solidsCopy[i])) solids2.Remove(solidsCopy[i]);
                        //        if (solids2.Contains(solidsCopy[j])) solids2.Remove(solidsCopy[j]);
                        //        //coun++;
                        //    }
                        //}
                        //solids2 = solids2.Where(x => x != null).ToList();
                        //SolidInfo solidInfo = new SolidInfo() { Name = name, Solids = solids2 };
                        //solidInfos.Add(solidInfo);
                        ////TaskDialog.Show("Sd", "planarface数：" + planarFaces.Count.ToString() + "\n原始solid数：" + solids.Count() + "\n过滤后：" + solids2.Count() + "\n有差集：" + coun);
                        //foreach (Solid item in solids2)
                        //{
                        //    foreach (Edge item1 in item.Edges)
                        //    {
                        //        Line line = item1.AsCurve() as Line;
                        //        lines2.Add(line);
                        //    }
                        //}
                        //获取在该图层范围内的所有文字注释
                        List<TextNote> textNotes2 = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                        List<TextNote> filterTextNotes = new List<TextNote>();
                        
                        foreach (var item in textNotes2)
                        {
                            //bool isInside = IsPointInsidePolygon(lines2, transform.OfPoint(item.Coord));
                            bool isInside = IsPointInsidePolygon(lines2, item.Coord);
                            if (isInside) filterTextNotes.Add(item);
                        }
                        FillTextNote fillTextNote = new FillTextNote() { FillCADName = name, TextNotes = filterTextNotes };
                        fillTextNotes.Add(fillTextNote);
                        //TaskDialog.Show("dss", fillTextNotes.First().TextNotes.Count.ToString() +"\n"+ textNotes2.Count() +"\n"+ lines2.Count());
                    }
                }
            }
            catch (Exception e)
            {

                TaskDialog.Show("error", e.Message);
            }
            //文本注释与其距离最近的line
            List<TextNoteInfo> textNoteInfos = new List<TextNoteInfo>();
            //创建楼板相关信息
            List<FloorInfo> floorInfos = new List<FloorInfo>();
            // 获取当前活动的视图
            View previousView = uIDoc.ActiveView;
            // 获取默认的三维视图的视图 ID
            ElementId default3DViewId = new FilteredElementCollector(doc)
                .OfClass(typeof(View3D))
                .FirstOrDefault(v => v.Name == "{三维}")?.Id;

            if (default3DViewId != null)
            {
                // 激活默认的三维视图
                uIDoc.ActiveView = doc.GetElement(default3DViewId) as View;
            }
            uIDoc.ActiveView = previousView;
            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).ToList().FirstOrDefault(x => x.Name == "{三维}" || x.Name == "{3D}") as View3D;
            if (view3D == null)
            {
                TaskDialog.Show("error", "未找到该项目默认的三维视图");
                return;
            }
            //ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Lines);
            //ElementClassFilter classFilter = new ElementClassFilter(typeof(ModelCurve));
            //LogicalAndFilter andFilter = new LogicalAndFilter(categoryFilter, classFilter);
            ReferenceIntersector refIntersector = new ReferenceIntersector(new ElementIsCurveDrivenFilter(), FindReferenceTarget.All, view3D);
            //ReferenceIntersector refIntersector = new ReferenceIntersector(andFilter, FindReferenceTarget.All, view3D);

            foreach (var item in textNotes)
            {
                XYZ p = item.Coord;
                p = new XYZ(p.X, p.Y, 0);
                List<Line> lines1 = new List<Line>();

                for (int i = 1; i <= 366; i += 35)
                {
                    XYZ dir = RotateVector(XYZ.BasisX, i, p);
                    ReferenceWithContext referenceWithContext = refIntersector.FindNearest(p, dir);
                    if (referenceWithContext != null)
                    {
                        if (!(doc.GetElement(referenceWithContext.GetReference()) is ModelCurve)) continue;
                        Line line = ((doc.GetElement(referenceWithContext.GetReference()) as ModelLine).Location as LocationCurve).Curve as Line;
                        if (line != null && !lines1.Contains(line)) lines1.Add(line);
                    }
                }
                List<Line> newLines = new List<Line>();
                bool finalInsert = false;
                bool hasInsert = false;
                for (int i = 0; i < lines1.Count - 1; i++)
                {
                    bool insert = false;
                    if (i == 0 && DetermineOverlappingLines(lines1[0], lines1[lines1.Count - 1]))
                    {
                        hasInsert = true;
                        insert = true;
                        finalInsert = true;
                        List<XYZ> points = new List<XYZ>() { lines1[0].GetEndPoint(0), lines1[0].GetEndPoint(1), lines1[lines1.Count - 1].GetEndPoint(0), lines1[lines1.Count - 1].GetEndPoint(1) };
                        double maxDis = double.MinValue;
                        XYZ maxPoint1 = null;
                        XYZ maxPoint2 = null;
                        for (int j = 0; j < points.Count; j++)
                        {
                            for (int k = 0; k < points.Count; k++)
                            {
                                double dis = points[j].DistanceTo(points[k]);
                                if (dis > maxDis)
                                {
                                    maxDis = dis;
                                    maxPoint1 = points[j];
                                    maxPoint2 = points[k];
                                }
                            }
                        }
                        newLines.Add(Line.CreateBound(maxPoint1, maxPoint2));
                    }
                    if (DetermineOverlappingLines(lines1[i], lines1[i + 1]))
                    {
                        hasInsert = true;
                        List<XYZ> points = new List<XYZ>() { lines1[i].GetEndPoint(0), lines1[i].GetEndPoint(1), lines1[i + 1].GetEndPoint(0), lines1[i + 1].GetEndPoint(1) };
                        double maxDis = double.MinValue;
                        XYZ maxPoint1 = null;
                        XYZ maxPoint2 = null;
                        for (int j = 0; j < points.Count; j++)
                        {
                            for (int k = 0; k < points.Count; k++)
                            {
                                double dis = points[j].DistanceTo(points[k]);
                                if (dis > maxDis)
                                {
                                    maxDis = dis;
                                    maxPoint1 = points[j];
                                    maxPoint2 = points[k];
                                }
                            }
                        }
                        newLines.Add(Line.CreateBound(maxPoint1, maxPoint2));
                    }
                    else if (!insert && i == 0)
                    {
                        newLines.Add(lines1[i]);
                    }
                    else if (i != 0)
                    {
                        newLines.Add(lines1[i]);
                    }
                    if (i == lines1.Count - 2 && !DetermineOverlappingLines(lines1[i], lines1[i + 1]) && finalInsert)
                    {
                        newLines.Add(lines1[i + 1]);
                    }
                }
                if (hasInsert)
                {
                    TextNoteInfo textNoteInfo = new TextNoteInfo() { TextNote = item, Lines = newLines };
                    textNoteInfos.Add(textNoteInfo);
                }
                else
                {
                    TextNoteInfo textNoteInfo = new TextNoteInfo() { TextNote = item, Lines = lines1 };
                    textNoteInfos.Add(textNoteInfo);
                }
                //TextNoteInfo textNoteInfo = new TextNoteInfo() { TextNote = item, Lines = lines1 };
                //textNoteInfos.Add(textNoteInfo);
            }
            //foreach (var item in textNotes)
            //{
            //    XYZ p = item.Coord;
            //    p = new XYZ(p.X, p.Y, 0);
            //    List<Line> lines1 = new List<Line>();
            //    for (int i = 1; i <= 366; i+= 35)
            //    {
            //        XYZ dir = RotateVector(XYZ.BasisX, i, p);
            //        ReferenceWithContext referenceWithContext = refIntersector.FindNearest(p, dir);
            //        if (referenceWithContext != null)
            //        {
            //            Line line = ((doc.GetElement(referenceWithContext.GetReference()) as ModelLine).Location as LocationCurve).Curve as Line;
            //            if (line != null && !lines1.Contains(line)) lines1.Add(line);
            //        }
            //    }
            //    List<Line> newLines = new List<Line>();
            //    bool finalInsert = false;
            //    bool hasInsert = false;
            //    for (int i = 0; i < lines1.Count - 1; i++)
            //    {
            //        bool insert = false;
            //        if (i == 0 && DetermineOverlappingLines(lines1[0], lines1[lines1.Count - 1]))
            //        {
            //            hasInsert = true;
            //            insert = true;
            //            finalInsert = true;
            //            List<XYZ> points = new List<XYZ>() { lines1[0].GetEndPoint(0), lines1[0].GetEndPoint(1), lines1[lines1.Count - 1].GetEndPoint(0), lines1[lines1.Count - 1].GetEndPoint(1) };
            //            double maxDis = double.MinValue;
            //            XYZ maxPoint1 = null;
            //            XYZ maxPoint2 = null;
            //            for (int j = 0; j < points.Count; j++)
            //            {
            //                for (int k = 0; k < points.Count; k++)
            //                {
            //                    double dis = points[j].DistanceTo(points[k]);
            //                    if (dis > maxDis)
            //                    {
            //                        maxDis = dis;
            //                        maxPoint1 = points[j];
            //                        maxPoint2 = points[k];
            //                    }
            //                }
            //            }
            //            newLines.Add(Line.CreateBound(maxPoint1, maxPoint2));
            //        }
            //        if (DetermineOverlappingLines(lines1[i], lines1[i + 1]))
            //        {
            //            hasInsert = true;
            //            List<XYZ> points = new List<XYZ>() { lines1[i].GetEndPoint(0), lines1[i].GetEndPoint(1), lines1[i + 1].GetEndPoint(0), lines1[i + 1].GetEndPoint(1) };
            //            double maxDis = double.MinValue;
            //            XYZ maxPoint1 = null;
            //            XYZ maxPoint2 = null;
            //            for (int j = 0; j < points.Count; j++)
            //            {
            //                for (int k = 0; k < points.Count; k++)
            //                {
            //                    double dis = points[j].DistanceTo(points[k]);
            //                    if (dis > maxDis)
            //                    {
            //                        maxDis = dis;
            //                        maxPoint1 = points[j];
            //                        maxPoint2 = points[k];
            //                    }
            //                }
            //            }
            //            newLines.Add(Line.CreateBound(maxPoint1, maxPoint2));
            //        }
            //        else if (!insert && i == 0)
            //        {
            //            newLines.Add(lines1[i]);
            //        }
            //        else if (i != 0)
            //        {
            //            newLines.Add(lines1[i]);
            //        }
            //        if (i == lines1.Count - 2 && !DetermineOverlappingLines(lines1[i], lines1[i + 1]) && finalInsert)
            //        {
            //            newLines.Add(lines1[i + 1]);
            //        }
            //    }
            //    if (hasInsert)
            //    {
            //        TextNoteInfo textNoteInfo = new TextNoteInfo() { TextNote = item, Lines = newLines };
            //        textNoteInfos.Add(textNoteInfo);
            //    }
            //    else
            //    {
            //        TextNoteInfo textNoteInfo = new TextNoteInfo() { TextNote = item, Lines = lines1 };
            //        textNoteInfos.Add(textNoteInfo);
            //    }
            //    //TextNoteInfo textNoteInfo = new TextNoteInfo() { TextNote = item, Lines = lines1 };
            //    //textNoteInfos.Add(textNoteInfo);
            //}
            foreach (var item in textNoteInfos)
            {
                List<Line> lines1 = item.Lines;
                //File.AppendAllText(@"C:\Users\Administrator\Desktop\11.txt", item.Lines.Count + "\n");
                CurveArray curveArray = new CurveArray();
                if (item.Lines.Count < 3) continue;
                for (int i = 0; i < lines1.Count; i++)
                {
                    XYZ cP = lines1[i].GetEndPoint(0).Add(lines1[i].GetEndPoint(1)) / 2;
                    lines1[i] = Line.CreateBound(cP - lines1[i].Direction * (30000 / 304.8), cP + lines1[i].Direction * (30000 / 304.8));
                }
                bool hasNull = false;
                int count = 0;
                for (int i = 0; i < lines1.Count - 1; i++)
                {
                    XYZ p = Command.GetIntersectionPoint(lines1[i], lines1[i + 1]);
                    if (p == null)
                    {
                        hasNull = true;
                        break;
                    }
                    if (i == 0)
                    {
                        count++;
                        XYZ newP = p.DistanceTo(lines1[i].GetEndPoint(0)) > p.DistanceTo(lines1[i].GetEndPoint(1)) ? lines1[i].GetEndPoint(0) : lines1[i].GetEndPoint(1);
                        XYZ newP2 = p.DistanceTo(lines1[i + 1].GetEndPoint(0)) > p.DistanceTo(lines1[i + 1].GetEndPoint(1)) ? lines1[i + 1].GetEndPoint(0) : lines1[i + 1].GetEndPoint(1);
                        if (p.DistanceTo(newP) < 0.001 || p.DistanceTo(newP2) < 0.001)
                        {
                            hasNull = true;
                            break;
                        }
                        lines1[i] = Line.CreateBound(p, newP);
                        lines1[i + 1] = Line.CreateBound(p, newP2);
                    }
                    else if (i != lines1.Count - 1)
                    {
                        count++;
                        XYZ newP = p.DistanceTo(lines1[i].GetEndPoint(0)) < p.DistanceTo(lines1[i].GetEndPoint(1)) ? lines1[i].GetEndPoint(0) : lines1[i].GetEndPoint(1);
                        XYZ newP2 = p.DistanceTo(lines1[i + 1].GetEndPoint(0)) > p.DistanceTo(lines1[i + 1].GetEndPoint(1)) ? lines1[i + 1].GetEndPoint(0) : lines1[i + 1].GetEndPoint(1);
                        if (p.DistanceTo(newP) < 0.001 || p.DistanceTo(newP2) < 0.001)
                        {
                            hasNull = true;
                            break;
                        }
                        lines1[i] = Line.CreateBound(p, newP);
                        lines1[i + 1] = Line.CreateBound(p, newP2);
                    }

                    if (i == lines1.Count - 2)
                    {
                        count++;
                        XYZ pF = Command.GetIntersectionPoint(lines1[i + 1], lines1[0]);
                        if (pF == null)
                        {
                            hasNull = true;
                            break;
                        }
                        XYZ newPF = pF.DistanceTo(lines1[i + 1].GetEndPoint(0)) < pF.DistanceTo(lines1[i + 1].GetEndPoint(1)) ? lines1[i + 1].GetEndPoint(0) : lines1[i + 1].GetEndPoint(1);
                        XYZ newPF2 = pF.DistanceTo(lines1[0].GetEndPoint(0)) < pF.DistanceTo(lines1[0].GetEndPoint(1)) ? lines1[0].GetEndPoint(0) : lines1[0].GetEndPoint(1);
                        if (pF.DistanceTo(newPF) < 0.001 || pF.DistanceTo(newPF2) < 0.001)
                        {
                            hasNull = true;
                            break;
                        }
                        lines1[i + 1] = Line.CreateBound(pF, newPF);
                        lines1[0] = Line.CreateBound(pF, newPF2);
                    }
                }
                for (int i = 0; i < lines1.Count; i++)
                {
                    Line line = lines1[i == lines1.Count - 1 ? 0 : i + 1];
                    if (lines1[i].GetEndPoint(0).DistanceTo(line.GetEndPoint(0)) < 0.001 || lines1[i].GetEndPoint(0).DistanceTo((line.GetEndPoint(1))) < 0.001)
                    {
                        lines1[i] = Line.CreateBound(lines1[i].GetEndPoint(1), lines1[i].GetEndPoint(0));
                        
                    }
                    if (i == lines1.Count - 1)
                    {
                        if (lines1[i].GetEndPoint(0) == lines1[0].GetEndPoint(0) || lines1[i].GetEndPoint(0) == lines1[0].GetEndPoint(1))
                        {
                            lines1[i] = Line.CreateBound(lines1[i].GetEndPoint(1), lines1[i].GetEndPoint(0));                          
                        }
                    }

                }
                foreach (var l in lines1) if (!hasNull) curveArray.Append(l);
                string symbolName = item.TextNote.Text;
                //symbolName = symbolName.Replace("(", "");
                //symbolName = symbolName.Replace(")", "");
                symbolName = symbolName.Replace("\r", "");
                symbolName = symbolName.Replace("\n", "");
                symbolName = symbolName.Replace("\t", "");
                if (tNMappingInfos.Select(x => x.TextNote).Contains(symbolName))
                {
                    symbolName = tNMappingInfos.First(y => y.TextNote == symbolName).High.ToString();
                }
                else
                {
                    symbolName = Regex.Replace(symbolName, @"[^0-9]+", "");
                }
                symbolName += "mm";
                if (curveArray.Size >= 3 && !hasNull)
                {
                    FloorInfo floorInfo = new FloorInfo() { CurveArray = curveArray, SymbolName = symbolName, TextNote = item.TextNote };
                    floorInfos.Add(floorInfo);
                }
            }
            //TaskDialog.Show("sds", floorInfos.Count.ToString() + "===");
            if (GlobalResources.MainWindow1.hasTextNote.IsChecked == true)//有文字注释
            {
                using (Transaction t = new Transaction(doc, "创建楼板"))
                {
                    t.Start();
                    foreach (var item in floorInfos)
                    {
                        FloorType familySymbol = null;
                        string symbolName = item.SymbolName;
                        List<FloorType> floorTypes = null;
                        string fullName = FloorTypeName.Replace("???mm", symbolName);
                        floorTypes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().Where(x => x.Name.Equals(fullName)).ToList();

                        if (floorTypes.Count > 0)
                        {
                            familySymbol = floorTypes.First();
                        }
                        else
                        {
                            familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList().First();
                        }
                        //if (!familySymbol.IsActive)
                        //{
                        //    familySymbol.Activate();
                        //}
                        try
                        {
                            Floor floor = doc.Create.NewFloor(item.CurveArray, familySymbol, doc.ActiveView.GenLevel, false);
                            foreach (Parameter para in floor.Parameters)
                            {
                                if (para.Definition.Name == "自标高的高度偏移")
                                {
                                    para.Set(0);
                                    break;
                                }
                            }
                            //修改楼板的标高（有填充图层）
                            if (FillCADNames.Count != 0)
                            {
                                foreach (FillTextNote fillText in fillTextNotes)
                                {
                                    //TaskDialog.Show("sds", fillText.TextNotes.First().Text + "||" +item.TextNote.Text );
                                    //return;
                                    Level level = null;
                                    List<ElementId> textNoteIds = new List<ElementId>();
                                    textNoteIds = fillText.TextNotes.Select(x => x.Id).ToList();
                                    if (textNoteIds.Contains(item.TextNote.Id))
                                    {
                                        //填充图层名称
                                        string name = fillText.FillCADName;
                                        if (mappingInfos.Select(x => x.LayerName).Contains(name))
                                        {
                                            level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).Cast<Level>().ToList().FirstOrDefault(x => x.Name.Equals(mappingInfos.First(y => y.LayerName == name).LevelName));
                                        }
                                        if (level != null) floor.get_Parameter(BuiltInParameter.LEVEL_PARAM).Set(level.Id);
                                        break;
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {

                            //TaskDialog.Show("ds", e.Message);
                            continue;
                        }
                    }
                    t.Commit();
                }
                    
            }
            else//无文字注释 有填充图层
            {
                //TaskDialog.Show("Sd", solidInfos.First().Solids.Count.ToString());
                //foreach (var item in solidInfos)
                //{
                //    string name = item.Name;
                //    string levelName;
                //    double high;
                //    if(mappingInfos.Select(x => x.LayerName).ToList().Contains(name))
                //    {
                //        levelName = mappingInfos.First(x => x.LayerName == name).LevelName;
                //        high = mappingInfos.First(x => x.LayerName == name).High;
                //    }
                //    else
                //    {
                //        levelName = "?????";
                //        high = 0;
                //    }
                //    foreach (var item2 in item.Solids)
                //    {
                //        foreach (PlanarFace item3 in item2.Faces)
                //        {
                //            if (item3.FaceNormal.Z == -1)
                //            {
                //                Floor floor = null;
                //                IList<CurveLoop> curves = item3.GetEdgesAsCurveLoops();
                //                //TaskDialog.Show("Sd555", curves.Count.ToString());
                //                for (int i = 0; i < curves.Count; i++)
                //                {

                //                    CurveArray curveArray = new CurveArray();
                //                    // 遍历 CurveLoop 中的每条曲线，并将其添加到 CurveArray 中
                //                    foreach (Curve curve in curves[i])
                //                    {
                //                        curveArray.Append(curve);
                //                    }
                //                    using (Transaction t = new Transaction(doc, "创建楼板"))
                //                    {
                //                        t.Start();
                //                        FloorType floorType;
                //                        //Level level = doc.ActiveView.GenLevel;
                //                        Level level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).Cast<Level>().FirstOrDefault(x => x.Name.Equals(levelName));
                //                        floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().Where(x => x.Name.Contains(high.ToString())).ToList().FirstOrDefault();
                //                        if (levelName == "?????" || floorType == null)
                //                        {
                //                            floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList().First();
                //                        }
                //                        if (levelName == "?????" || level == null)
                //                        {
                //                            level = doc.ActiveView.GenLevel;
                //                        }
                //                        floor = doc.Create.NewFloor(curveArray, floorType, level, false);
                //                        t.Commit();
                //                    }
                //                    break;
                //                }
                //                using (Transaction t = new Transaction(doc, "楼板开洞"))
                //                {
                //                    t.Start();
                //                    for (int i = 0; i < curves.Count; i++)
                //                    {
                //                        CurveArray curveArray = new CurveArray();
                //                        // 遍历CurveLoop中的每条曲线，并将其添加到CurveArray中
                //                        foreach (Curve curve in curves[i])
                //                        {
                //                            curveArray.Append(curve);
                //                        }
                //                        if (i != 0) doc.Create.NewOpening(floor, curveArray, true);
                //                    }
                //                    t.Commit();
                //                }
                //            }
                //        }
                //    }
                //}
                foreach (var item in planarFaceInfos)
                {
                    string name = item.Name;
                    string levelName;
                    double high;
                    if(mappingInfos.Select(x => x.LayerName).ToList().Contains(name))
                    {
                        levelName = mappingInfos.First(x => x.LayerName == name).LevelName;
                        high = mappingInfos.First(x => x.LayerName == name).High;
                    }
                    else
                    {
                        levelName = "?????";
                        high = 0;
                    }
                    string fullName = FloorTypeName.Replace("???", high.ToString());
                    Floor floor = null;
                    CurveLoop curve = item.CurveLoop;
                    //TaskDialog.Show("Sd555", fullName);

                    CurveArray curveArray = new CurveArray();
                    // 遍历 CurveLoop 中的每条曲线，并将其添加到 CurveArray 中
                    foreach (Curve curve1 in curve)
                    {
                        curveArray.Append(curve1);
                    }
                    using (Transaction t = new Transaction(doc, "创建楼板"))
                    {
                        t.Start();
                        FloorType floorType;
                        //Level level = doc.ActiveView.GenLevel;
                        Level level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).Cast<Level>().FirstOrDefault(x => x.Name.Equals(levelName));
                        floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().Where(x => x.Name.Equals(fullName)).ToList().FirstOrDefault();
                        if (levelName == "?????" || floorType == null)
                        {
                            floorType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList().First();
                        }
                        if (levelName == "?????" || level == null)
                        {
                            level = doc.ActiveView.GenLevel;
                        }
                        floor = doc.Create.NewFloor(curveArray, floorType, level, false);
                        foreach (Parameter para in floor.Parameters)
                        {
                            if (para.Definition.Name == "自标高的高度偏移")
                            {
                                para.Set(0);
                                break;
                            }
                        }
                        t.Commit();
                    }
                    using (Transaction t = new Transaction(doc, "楼板开洞"))
                    {
                        t.Start();
                        foreach (var curve2 in item.CurveLoops)
                        {
                            CurveArray curveArray2 = new CurveArray();
                            // 遍历CurveLoop中的每条曲线，并将其添加到CurveArray中
                            foreach (Curve curve3 in curve2)
                            {
                                curveArray2.Append(curve3);
                            }
                            doc.Create.NewOpening(floor, curveArray2, true);
                            //doc.Create.NewFloor(curveArray2, new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).WhereElementIsElementType().Cast<FloorType>().ToList().First(), doc.ActiveView.GenLevel, false);
                        }
                        t.Commit();
                    }
                }
            }
            using (Transaction t = new Transaction(doc, "删除模型线"))
            {
                t.Start();
                doc.Delete(ids);
                t.Commit();
            }
            tGroup.Assimilate();
        }

        public string GetName()
        {
            return "EventCommand";
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="originalVector">初始向量</param>
        /// <param name="degrees">旋转角度</param>
        /// <param name="point">旋转起点</param>
        /// <returns></returns>
        public XYZ RotateVector(XYZ originalVector, double degrees,XYZ point)
        {
            // 将旋转角度从度转换为弧度
            double radians = degrees * (Math.PI / 180);

            // 创建一个绕Z轴旋转的变换，注意Revit中顺时针旋转角度为负
            Transform rotation = Transform.CreateRotationAtPoint(XYZ.BasisZ, -radians, point);

            // 应用旋转变换到原始向量
            XYZ rotatedVector = rotation.OfVector(originalVector);

            return rotatedVector;
        }
        public bool DetermineOverlappingLines(Line line1, Line line2)
        {
            // 判断两条直线是否在同一直线上
            SetComparisonResult result = line1.Intersect(line2, out IntersectionResultArray intersectionResult);

            if (result == SetComparisonResult.Equal)
            {
                return true;
            }
            else
            {
                return false;
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
    public class FillTextNote
    {
        //填充图层CAD名称
        public string FillCADName { get; set; }
        //在填充图层内的文字注释
        public List<TextNote> TextNotes { get; set; }
    }
    public class SolidInfo
    {
        public List<Solid> Solids { get; set; }
        public Level Level { get; set; }
        public string Name { get; set; }
    }
    //填充图层映射信息
    public class MappingInfo
    {
        public string LayerName { get; set; }
        public string LevelName{ get; set; }
        public double High { get; set; }
    }
    //文字注释映射信息
    public class TNMappingInfo
    {
        public string TextNote { get; set; }
        public double High { get; set; }
    }
    public class PlanarFaceInfo
    {
        //图层名称
        public string Name { get; set; }
        //主板
        public CurveLoop CurveLoop { get; set; }
        //主板上需要开的洞
        public List<CurveLoop> CurveLoops { get; set; }
    }
    public class SolidIInfo
    {
        public double SurFaceArea { get; set; }
        public CurveLoop Curves { get; set; }
    }
}
