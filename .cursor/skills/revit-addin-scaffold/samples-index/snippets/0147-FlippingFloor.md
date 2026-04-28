# Sample Snippet: FlippingFloor

Source project: `existingCodes\梁涛插件源代码\6.不常用\FlippingFloor\FlippingFloor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## AddDataCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace FlippingFloor
{
    //添加填充图层映射
    public class AddDataCommand : IExternalEventHandler
    {
        public string LayerName { get; set; }
        public string Level { get; set; }
        public double High { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;

            try
            {
                //数据库连接
                SQLiteConnection m_dbConnection;
                //创建一个连接到指定数据库
                using (m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))//没有数据库则自动创建
                {
                    m_dbConnection.Open();
                    string projectName = doc.Title;
                    string sql = "create table if not exists '" + projectName + "' (layer_name  varchar(225), level varchar(225), high double)";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    sql = $"SELECT COUNT(*) FROM '{projectName}' WHERE layer_name = '{LayerName}'";
                    int count;
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        count = Convert.ToInt32(command.ExecuteScalar());
                    }
                    if (count > 0)
                    {
                        sql = $"UPDATE '{projectName}' SET level = '{Level}', high = {High} WHERE layer_name = '{LayerName}'";
                        using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                        {
                            command.ExecuteNonQuery();
                        }
                        GlobalResources.MainWindow1.Hide();
                        TaskDialog.Show("提示", "修改成功");
                        GlobalResources.MainWindow1.Show();
                    }
                    else
                    {
                        sql = "insert into '" + projectName + $"' (layer_name, level, high) values ('{LayerName}', '{Level}', {High})";
                        using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                        {
                            command.ExecuteNonQuery();
                        }
                        GlobalResources.MainWindow1.Hide();
                        TaskDialog.Show("提示", "添加成功");
                        GlobalResources.MainWindow1.Show();
                    }

                    List<string> results = new List<string>();
                    //使用sql查询语句显示结果
                    sql = "select * from `" + projectName + "` order by layer_name desc";
                    //string tableName = "data_revit";
                    //sql = $"SELECT name FROM sqlite_master WHERE type='table' AND name LIKE '{tableName}'";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                                //TaskDialog.Show("111", "layer_name: " + reader["layer_name"] + "\nlevel: " + reader["level"] + "\nhigh: " + reader["high"]);
                                results.Add(reader["layer_name"] + "-" + reader["level"] + "-" + reader["high"]);

                        }
                    }
                    HashSet<string> mappingInfos = new HashSet<string>();
                    //更新板厚下拉框数据
                    //将填充图层的板厚加入到下拉框
                    sql = $"select * from `{doc.Title}` order by layer_name desc";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
// ... truncated ...
```

## AddMappingCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace FlippingFloor
{
    //添加文字注释映射
    public class AddMappingCommand : IExternalEventHandler
    {
        public string TextNote { get; set; }
        public double High { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            //数据库连接
            SQLiteConnection m_dbConnection;
            //创建一个连接到指定数据库
            using (m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))//没有数据库则自动创建
            {
                m_dbConnection.Open();
                string projectName = doc.Title + "_textnote";
                string sql = "create table if not exists `" + projectName + "` (textnote  varchar(225), high double)";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
                }
                sql = $"SELECT COUNT(*) FROM '{projectName}' WHERE textnote = '{TextNote}'";
                int count;
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    count = Convert.ToInt32(command.ExecuteScalar());
                }
                if (count > 0)
                {
                    sql = $"UPDATE '{projectName}' SET high = {High} WHERE textnote = '{TextNote}'";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    GlobalResources.MainWindow1.Hide();
                    TaskDialog.Show("提示", "修改成功");
                    GlobalResources.MainWindow1.Show();
                }
                else
                {
                    sql = "insert into `" + projectName + $"` (textnote, high) values ('{TextNote}', {High})";
                    using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                    {
                        command.ExecuteNonQuery();
                    }
                    GlobalResources.MainWindow1.Hide();
                    TaskDialog.Show("提示", "添加成功");
                    GlobalResources.MainWindow1.Show();
                }

                List<string> results = new List<string>();
                List<TNMappingInfo> tNMappingInfos = new List<TNMappingInfo>();
                HashSet<string> mappingInfos = new HashSet<string>();
                //使用sql查询语句显示结果
                sql = "select * from `" + projectName + "` order by textnote desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            results.Add(reader["textnote"] + "-" + reader["high"]);
                            TNMappingInfo tNMappingInfo = new TNMappingInfo() { TextNote = reader["textnote"].ToString(), High = Convert.ToDouble(reader["high"]) };
                            tNMappingInfos.Add(tNMappingInfo);
                        }
                    }
                }
                //将填充图层的板厚加入到下拉框
                sql = $"select * from `{doc.Title}` order by layer_name desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            mappingInfos.Add(reader["high"].ToString() + "mm");
                        }
                    }
// ... truncated ...
```

## Command.cs

```csharp
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
// ... truncated ...
```

