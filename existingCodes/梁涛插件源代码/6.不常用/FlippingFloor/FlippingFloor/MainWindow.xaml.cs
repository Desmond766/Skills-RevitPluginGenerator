using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;
using Reference = Autodesk.Revit.DB.Reference;

namespace FlippingFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Category> categories = new List<Category>();
        //创建楼板外部事件
        EventCommand handlerCommand = null;
        ExternalEvent handlerEvent = null;
        //隐藏/显示选中CAD图层
        HiddenCADCommand hiddenCADCommand = null;
        ExternalEvent externalEvent = null;
        //批量创建楼板类型
        CreateFloorTypeCommand createFloorTypeCommand = null;
        ExternalEvent createExternalEventCommand = null;
        //添加填充图层映射
        AddDataCommand addDataCommand = null;
        ExternalEvent addDataEventCommand = null;
        //添加文字注释映射
        AddMappingCommand addMappingCommand = null;
        ExternalEvent addMappingEventCommand = null;
        UIDocument uidoc { get; set; }
        Document doc { get; set; }
        public bool cancel { get; set; } = true;
        private bool first = true;
        private Reference reference = null;
        public HashSet<string> floorThickness = new HashSet<string>();
        List<FloorType> floorTypes;
        public MainWindow(Document doc, UIDocument uidoc)
        {
            InitializeComponent();
            handlerCommand = new EventCommand();
            handlerEvent = ExternalEvent.Create(handlerCommand);
            hiddenCADCommand = new HiddenCADCommand();
            externalEvent = ExternalEvent.Create(hiddenCADCommand);
            createFloorTypeCommand = new CreateFloorTypeCommand();
            createExternalEventCommand = ExternalEvent.Create(createFloorTypeCommand);
            addDataCommand = new AddDataCommand();
            addDataEventCommand = ExternalEvent.Create(addDataCommand);
            addMappingCommand = new AddMappingCommand();
            addMappingEventCommand = ExternalEvent.Create(addMappingCommand);
            this.uidoc = uidoc;
            this.doc = doc;
            projectName.Content += doc.Title;
            floorTypes = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(FloorType)).Cast<FloorType>().ToList().OrderBy(y => Regex.Replace(y.Name, @"[^0-9]+", "")).ToList();
            cbft.ItemsSource = floorTypes.Select(x => x.Name);
            cbft.SelectedIndex = 0;

            List<TNMappingInfo> tNMappingInfos = new List<TNMappingInfo>();
            //创建一个连接到指定数据库
            using (SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))//没有数据库则自动创建
            {
                m_dbConnection.Open();
                string projectName = doc.Title;
                string sql = "create table if not exists `" + doc.Title + "` (layer_name  varchar(225), level varchar(225), high double)";
                //string sql = $"DELETE FROM '{doc.Title}'";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "create table if not exists `" + doc.Title + "_textnote` (textnote  varchar(225), high double)";
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
                //将填充图层的板厚加入到下拉框
                sql = $"select * from `{projectName}` order by layer_name desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            floorThickness.Add(reader["high"].ToString() + "mm");
                        }
                    }
                }
                m_dbConnection.Close();
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
                floorThickness.Add(info);
            }
            floorThickness = floorThickness.OrderBy(x => Convert.ToInt32(Regex.Replace(x, @"[^0-9]+", ""))).ToHashSet();
            thickness.ItemsSource = floorThickness;
            thickness.SelectedIndex = 0;


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
            ftn.ItemsSource = names.OrderBy(x => x);

            List<string> results = new List<string>();
            List<string> results2 = new List<string>();
            //初始化cb_mapping数据
            //数据库连接
            //创建一个连接到指定数据库
            using (SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source=MyDatabase.db;Version=3;"))//没有数据库则自动创建
            {
                m_dbConnection.Open();
                
                string sql = "create table if not exists '" + doc.Title + "' (layer_name  varchar(225), level varchar(225), high double)";
                //string sql = $"DELETE FROM '{doc.Title}'";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "select * from '" + doc.Title + "' order by 'layer_name' desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            results.Add(reader["layer_name"] + "-" + reader["level"] + "-" + reader["high"]);
                    }
                }
                sql = "create table if not exists `" + doc.Title + "_textnote` (textnote  varchar(225), high double)";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    command.ExecuteNonQuery();
                }
                sql = "select * from `" + doc.Title + "_textnote` order by textnote desc";
                using (SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection))
                {
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                            results2.Add(reader["textnote"] + "-" + reader["high"]);
                    }
                }
                m_dbConnection.Close();
            }
            cb_mapping.ItemsSource = results;
            cb_tn_mapping.ItemsSource = results2;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            // 连接到 Revit
            // 请确保已经引用了 Revit API 的程序集

            try
            {
                // 在 Revit 中选择元素
                Reference selectedElement = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, new CADFilter(doc), "请选择一个图层");
                ImportInstance dwg = doc.GetElement(selectedElement) as ImportInstance;
                var geoObj = (dwg as Element).GetGeometryObjectFromReference(selectedElement);
                Category category = (doc.GetElement(geoObj.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory;
                //if(geoObj is Line)
                //{
                //    TaskDialog.Show("sd", "line");
                //}
                //else if (category != null)
                //{
                //    TaskDialog.Show("As", category.Name);
                //}
                categories.Add(category);
                hiddenCADCommand.category = category;
                if (first)
                {
                    first = false;
                    reference = selectedElement;
                }
                string layerName = Command.GetLayerName(doc, selectedElement);
                // 在文本框中显示用户选择的元素名称
                if (tb.Text == "")
                {
                    tb.Text = layerName;
                }
                else/* if (!tb.Text.Contains(layerName))*/
                {
                    tb.Text += "," + layerName;
                }
            }
            catch (Exception ex)
            {
                //TaskDialog.Show("sds", ex.Message);
            }
            hiddenCADCommand.hide = true;
            if (hiddenCADCommand.category != null)
            {
                externalEvent.Raise();
            }
            this.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            hasTextNote.IsChecked = true;
            this.cancel = false;
            // 要分割的字符串
            string input = tb.Text;

            // 使用逗号字符 ',' 作为分隔符
            string[] parts = input.Split(',');

            // 将分割后的字符串数组转换为List
            List<string> CADNames = new List<string>(parts);
            handlerCommand.CADNames = CADNames;
            handlerCommand.reference = reference;
            if (null == ftn.SelectedItem)
            {
                this.Hide();
                TaskDialog.Show("提示", "请选择一个楼板类型作为翻模模板！");
                this.Show();
                return;
            }
            handlerCommand.FloorTypeName = ftn.SelectedItem + "???mm";
            if ((handlerCommand.CADNames == null || handlerCommand.reference == null) && hasTextNote.IsChecked == true)
            {
                hiddenCADCommand.hide = false;
                hiddenCADCommand.categories = categories;
                externalEvent.Raise();
                this.Close();
            }
            else
            {
                handlerEvent.Raise();
                hiddenCADCommand.hide = false;
                hiddenCADCommand.categories = categories;
                externalEvent.Raise();
                this.Close();
            }
            
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            hiddenCADCommand.hide = false;
            hiddenCADCommand.categories = categories;
            externalEvent.Raise();
            this.Close();
        }

        private void btcreate_Click(object sender, RoutedEventArgs e)
        {
            createFloorTypeCommand.Front = tbfn.Text;
            createFloorTypeCommand.After = floorThickness;
            createFloorTypeCommand.FloorType = floorTypes.Where(x => x.Name.Equals(cbft.SelectedItem.ToString())).FirstOrDefault();
            createExternalEventCommand.Raise();
        }

        private void thickness_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Hide();
            try
            {
                // 在 Revit 中选择元素
                Reference selectedElement = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.PointOnElement, new PlanarFaceFilter(doc), "请选择一个图层");
                ImportInstance dwg = doc.GetElement(selectedElement) as ImportInstance;
                var geoObj = (dwg as Element).GetGeometryObjectFromReference(selectedElement);
                Category category = (doc.GetElement(geoObj.GraphicsStyleId) as GraphicsStyle).GraphicsStyleCategory;
                categories.Add(category);
                hiddenCADCommand.category = category;
                //if (first)
                //{
                //    first = false;
                //    reference = selectedElement;
                //}
                string layerName = Command.GetLayerName(doc, selectedElement);
                // 在文本框中显示用户选择的元素名称
                if (fillTB.Text == "")
                {
                    fillTB.Text = layerName;
                }
                else
                {
                    fillTB.Text += "," + layerName;
                }
            }
            catch (Exception)
            {
            }
            hiddenCADCommand.hide = true;
            if (hiddenCADCommand.category != null)
            {
                externalEvent.Raise();
            }
            this.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            this.cancel = false;
            // 要分割的字符串
            string input = tb.Text;
            // 使用逗号字符 ',' 作为分隔符
            string[] parts = input.Split(',');
            // 将分割后的字符串数组转换为List
            List<string> CADNames = new List<string>(parts);
            // 要分割的字符串
            string fillInput = fillTB.Text;
            // 使用逗号字符 ',' 作为分隔符
            string[] fillParts = fillInput.Split(',');
            // 将分割后的字符串数组转换为List
            List<string> fillCADNames = new List<string>(fillParts);
            handlerCommand.CADNames = CADNames;
            handlerCommand.reference = reference;
            handlerCommand.FillCADNames = fillCADNames;
            if (null == ftn.SelectedItem /*&& hasTextNote.IsChecked == true*/)
            {
                this.Hide();
                TaskDialog.Show("提示", "请选择一个楼板类型作为翻模模板！");
                this.Show();
                return;
            }
            if (hasTextNote.IsChecked == false && fillTB.Text == "")
            {
                this.Hide();
                TaskDialog.Show("提示", "不使用文字注释翻模时需至少选择一个填充图层");
                this.Show();
                return;
            }
            handlerCommand.FloorTypeName = ftn.SelectedItem + "???mm";
            if ((handlerCommand.CADNames == null || handlerCommand.reference == null) && hasTextNote.IsChecked == true)
            {
                hiddenCADCommand.hide = false;
                hiddenCADCommand.categories = categories;
                externalEvent.Raise();
                this.Close();
            }
            else
            {
                handlerEvent.Raise();
                hiddenCADCommand.hide = false;
                hiddenCADCommand.categories = categories;
                externalEvent.Raise();
                this.Close();
            }
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            hiddenCADCommand.hide = false;
            hiddenCADCommand.categories = categories;
            externalEvent.Raise();
            this.Close();
        }

        private void fillTB_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            hiddenCADCommand.hide = false;
            hiddenCADCommand.categories = categories;
            externalEvent.Raise();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            if (tb_layername.Text == "")
            {
                this.Hide();
                TaskDialog.Show("提示","填充图层的值不能为空");
                this.Show();
                return;
            }
            else if (tb_level.Text == "" && tb_high.Text == "")
            {
                this.Hide();
                TaskDialog.Show("提示", "标高和板厚需要至少有一个值不为空");
                this.Show();
                return;
            }
            if (tb_high.Text == "")
            {
                addDataCommand.High = 0;
            }
            else
            {
                addDataCommand.High = Convert.ToDouble(tb_high.Text);
            }
            addDataCommand.LayerName = tb_layername.Text;
            addDataCommand.Level = tb_level.Text;
            addDataEventCommand.Raise();
            tb_high.Text = "";
            tb_level.Text = "";
            tb_layername.Text = "";
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // 只允许输入数字和小数点
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            if (tb_tn_name.Text == "" || tb_tn_high.Text == "")
            {
                this.Hide();
                TaskDialog.Show("提示", "不能出现空值，请重新输入");
                this.Show();
                return;
            }
            else if (Convert.ToDouble(tb_tn_high.Text) <= 0)
            {
                this.Hide();
                TaskDialog.Show("提示", "请输入正确的板厚");
                this.Show();
                return;
            }
            addMappingCommand.TextNote = tb_tn_name.Text;
            addMappingCommand.High = Convert.ToDouble(tb_tn_high.Text);
            addMappingEventCommand.Raise();
            tb_tn_name.Text = "";
            tb_tn_high.Text = "";

        }

        private void NumericTextBox_PreviewTextInput2(object sender, TextCompositionEventArgs e)
        {
            // 只允许输入数字和小数点
            Regex regex = new Regex("[^0-9.]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
    public class CADFilter : ISelectionFilter
    {
        public Document doc { get; set; }
        public CADFilter(Document document)
        {
            this.doc = document;
        }
        public bool AllowElement(Element elem)
        {
            return true;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            ImportInstance dwg = doc.GetElement(reference) as ImportInstance;
            var geoObj = (dwg as Element).GetGeometryObjectFromReference(reference);
            if (geoObj is Line || geoObj is PolyLine)
            {
                return true;
            }
            return false;
            //GeometryElement geometryElement = dwg.get_Geometry(new Options());
            //foreach (var item in geometryElement)
            //{
            //    if (item is GeometryInstance geometryInstance)
            //    {
            //        GeometryElement geometryElement1 = geometryInstance.GetInstanceGeometry();
            //        //int count = 0;
            //        foreach (var item1 in geometryElement1)
            //        {
            //            if (item1 is Line || item1 is PolyLine)
            //            {
            //                return true;
            //            }
            //        }
            //    }
            //}
        }
    }
}
