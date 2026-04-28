using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FloorReview
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Application app = commandData.Application.Application;
            Document doc = uIDoc.Document;

            //string input = "S-PB-B1-200mm";
            //// 正则表达式解释：\d+ 匹配一个或多个数字，(?=m) 是正向前瞻，表示其前面的表达式匹配的内容后面必须紧跟着 'm'
            //string pattern = @"\d+(?=mm)";

            //Match match = Regex.Match(input, pattern);
            //if (match.Success)
            //{
            //    TaskDialog.Show("sd", match.Value);
            //}
            //else
            //{
            //    TaskDialog.Show("11","未找到符合条件的数字。");
            //}
            //return Result.Succeeded;

            List<TextNote> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
            ObservableCollection<TextNoteInfo> textNoteInfos = new ObservableCollection<TextNoteInfo>();
            GetFloorsByLofting(textNotes, textNoteInfos, doc);

            MainWindow mainWindow = new MainWindow(textNoteInfos, doc, uIDoc, app);
            GlobalResources.MainWindow1 = mainWindow;
            mainWindow.Show();
            


            return Result.Succeeded;
        }
        public void GetFloorsByLofting(List<TextNote> textNotes, ObservableCollection<TextNoteInfo> textNoteInfos, Document doc)
        {
            List<TNMappingInfo> tNMappingInfos = new List<TNMappingInfo>();
            //创建一个连接到指定数据库
            using (SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))//没有数据库则自动创建
            { 
                m_dbConnection.Open();
                string projectName = doc.Title;
                string sql = "create table if not exists `" + doc.Title + "_textnote` (textnote  varchar(225), high double)";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
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
            foreach (var item in textNotes)
            {
                XYZ point = item.Coord;
                double Z = (doc.GetElement(doc.ActiveView.GenLevel.FindAssociatedPlanViewId()) as ViewPlan).SketchPlane.GetPlane().Origin.Z;
                Z = Z - 100;
                point = new XYZ(point.X, point.Y, Z);
                //放样
                double radius = 25 / 304.8;
                Curve circle1 = Arc.Create(point, radius, 0, Math.PI, XYZ.BasisX, XYZ.BasisY);
                Curve circle2 = Arc.Create(point, radius, Math.PI, 2 * Math.PI, XYZ.BasisX, XYZ.BasisY);
                List<CurveLoop> loops = new List<CurveLoop>();
                List<Curve> curveList = new List<Curve> { circle1, circle2 };
                CurveLoop curveLoop = CurveLoop.Create(curveList);
                loops.Add(curveLoop);
                //拉伸
                Solid solid1 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ.Negate(), 200);
                Solid solid2 = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 200);
                ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid1);
                ElementIntersectsSolidFilter filter2 = new ElementIntersectsSolidFilter(solid2);
                List<Floor> filterFloors = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).WherePasses(filter2).Cast<Floor>().ToList();
                //if (filterFloors.Count == 0) filterFloors = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor)).WherePasses(filter2).Cast<Floor>().ToList();
                string noteText = item.Text;
                noteText = noteText.Replace("\r", "");
                noteText = noteText.Replace("\n", "");
                noteText = noteText.Replace("\t", "");
                if (tNMappingInfos.Select(x => x.TextNote).Contains(noteText))
                {
                    noteText = tNMappingInfos.First(y => y.TextNote == noteText).High.ToString();
                }
                else
                {
                    noteText = Regex.Replace(noteText, @"[^0-9]+", "");
                }
                noteText += "mm";
                if (1 != filterFloors.Count)
                {
                    //string noteText = Regex.Replace(item.Text, @"[^0-9]+", "");
                    //noteText += "mm";
                    TextNoteInfo textNoteInfo = new TextNoteInfo() { Floor = null, FloorID = new ElementId(1111111), FloorName = "未找到", NoteText = noteText, NoteID = item.Id, Correct = "未知", IsBold = true, TextColor = "yellow", Level = null, LevelName = ""};
                    textNoteInfos.Add(textNoteInfo);
                }
                else
                {
                    Floor floor = filterFloors.First();
                    string input = floor.Name;
                    string pattern = @"\d+(?=mm)";
                    Match match = Regex.Match(input, pattern);
                    string floorName = match.Value + "mm";                    
                    //string noteText = Regex.Replace(item.Text, @"[^0-9]+", "");
                    //noteText += "mm";
                    if (floorName == noteText)
                    {
                        TextNoteInfo textNoteInfo = new TextNoteInfo() { Floor = floor, FloorID = floor.Id, FloorName = floorName, NoteText = noteText, NoteID = item.Id, Correct = "是", IsBold = false, TextColor = "black", Level = doc.GetElement(floor.LevelId) as Level, LevelName = (doc.GetElement(floor.LevelId) as Level).Name };
                        textNoteInfos.Add(textNoteInfo);
                    }
                    else
                    {
                        TextNoteInfo textNoteInfo = new TextNoteInfo() { Floor = floor, FloorID = floor.Id, FloorName = floorName, NoteText = noteText, NoteID = item.Id, Correct = "否", IsBold = true, TextColor = "red", Level = doc.GetElement(floor.LevelId) as Level, LevelName = (doc.GetElement(floor.LevelId) as Level).Name };
                        textNoteInfos.Add(textNoteInfo);
                    }
                }
            }
        }
        
    }
    public static class GlobalResources
    {
        public static MainWindow MainWindow1 { get; set; }
    }
    public class TextNoteInfo
    {
        //文字注释对应的楼板
        public Floor Floor { get; set; }
        //楼板ID
        public ElementId FloorID { get; set; }
        //楼板名称
        public string FloorName { get; set; }
        //文字注释信息
        public string NoteText { get; set; }
        //文字注释ID
        public ElementId NoteID { get; set; }
        //楼板标记与文字注释是否一致
        public string Correct { get; set; }
        //字体颜色
        public string TextColor { get; set; }
        //字体粗细
        public bool IsBold { get; set; }
        //楼板标高
        public Level Level { get; set; }
        //楼板标高名称
        public string LevelName { get; set; }
    }
    //文字注释映射信息
    public class TNMappingInfo
    {
        public string TextNote { get; set; }
        public double High { get; set; }
    }
}
