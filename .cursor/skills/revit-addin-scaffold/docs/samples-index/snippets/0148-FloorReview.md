# Sample Snippet: FloorReview

Source project: `existingCodes\梁涛插件源代码\6.不常用\FloorReview\FloorReview`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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

namespace FloorReview
{
    public class DelEventCommand : IExternalEventHandler
    {
        public bool IsTextNote { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;

            if (IsTextNote)
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
using System.Threading.Tasks;

namespace FloorReview
{
    public class EventCommand : IExternalEventHandler
    {
        public ElementId FloorId { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            try
            {
                uIDoc.ShowElements(FloorId);
                uIDoc.Selection.SetElementIds(new List<ElementId>() { FloorId });
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}

```

