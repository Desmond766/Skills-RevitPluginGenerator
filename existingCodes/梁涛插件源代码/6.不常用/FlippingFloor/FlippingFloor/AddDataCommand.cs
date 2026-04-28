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
                            {
                                mappingInfos.Add(reader["high"].ToString() + "mm");
                            }
                        }
                    }
                    List<TNMappingInfo> tNMappingInfos = new List<TNMappingInfo>();
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
                    List<string> textNotes = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().Select(x => x.Text).ToList();
                    foreach (var item in textNotes)
                    {
                        string info = item;
                        info = info.Replace("\r", "");
                        info = info.Replace("\n", "");
                        info = info.Replace("\t", "");
                        if (tNMappingInfos.Select(x => x.TextNote).Contains(info))
                        {
                            info = tNMappingInfos.First(y => y.TextNote == info).High.ToString();
                        }
                        else
                        {
                            info = Regex.Replace(info, @"[^0-9]+", "");
                        }
                        info += "mm";
                        mappingInfos.Add(info);
                    }
                    m_dbConnection.Close();
                    mappingInfos = mappingInfos.OrderBy(x => Convert.ToInt32(Regex.Replace(x, @"[^0-9]+", ""))).ToHashSet();
                    GlobalResources.MainWindow1.cb_mapping.ItemsSource = results;
                    GlobalResources.MainWindow1.thickness.ItemsSource = mappingInfos;
                    GlobalResources.MainWindow1.thickness.SelectedIndex = 0;
                }
            }
            catch (Exception e)
            {
                GlobalResources.MainWindow1.Hide();
                TaskDialog.Show("错误提示", e.Message);
                GlobalResources.MainWindow1.Show();
            }
        }

        public string GetName()
        {
            return "AddDataCommand";
        }
    }
}
