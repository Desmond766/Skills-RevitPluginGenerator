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
                }
                //更新板厚下拉框数据
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
                mappingInfos = mappingInfos.OrderBy(x => Convert.ToInt32(Regex.Replace(x, @"[^0-9]+", ""))).ToHashSet();
                GlobalResources.MainWindow1.thickness.ItemsSource = mappingInfos;
                GlobalResources.MainWindow1.thickness.SelectedIndex = 0;
                m_dbConnection.Close();
                GlobalResources.MainWindow1.cb_tn_mapping.ItemsSource = results;
            }
        }

        public string GetName()
        {
            return "AddMappingCommand";
        }
    }
}
