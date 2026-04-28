using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Application = Microsoft.Office.Interop.Excel.Application;
using CheckBox = System.Windows.Controls.CheckBox;
using DataTable = System.Data.DataTable;
using Window = System.Windows.Window;

namespace CorrectionOfJunctionBoxHeight
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        // 电气点位高度表
        public DataTable DataTable { get; set; }
        public bool Import { get; private set; } = false;
        public bool Cancel { get; private set; } = true;
        public List<CheckBox> CheckBoxes { get; private set; } = new List<CheckBox>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AllSel_Checked(object sender, RoutedEventArgs e)
        {
            
        }

        private void AllSel_Click(object sender, RoutedEventArgs e)
        {
            if (AllSel.IsChecked == true)
            {
                D1.IsChecked = true;
                D2.IsChecked = true;
                D3.IsChecked = true;
                D4.IsChecked = true;
                D5.IsChecked = true;
                D6.IsChecked = true;
                D7.IsChecked = true;
                D8.IsChecked = true;
            }
            if (AllSel.IsChecked == false || AllSel.IsChecked == null)
            {
                D1.IsChecked = false;
                D2.IsChecked = false;
                D3.IsChecked = false;
                D4.IsChecked = false;
                D5.IsChecked = false;
                D6.IsChecked = false;
                D7.IsChecked = false;
                D8.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Cancel = false;
            List<CheckBox> checkBoxes = new List<CheckBox>() { D1, D2, D3, D4, D5, D6, D7, D8 };
            if (checkBoxes.Where(x => x.IsChecked == true).Count() == 0)
            {
                WindowState = WindowState.Minimized;
                TaskDialog.Show("Revit", "请选择至少一个类型", TaskDialogCommonButtons.Ok);
                WindowState = WindowState.Normal;
                Cancel = true;
                return;
            }
            CheckBoxes.AddRange(checkBoxes);

            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void D1_Click(object sender, RoutedEventArgs e)
        {
            if (D1.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D2_Click(object sender, RoutedEventArgs e)
        {
            if (D2.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D3_Click(object sender, RoutedEventArgs e)
        {
            if (D3.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D4_Click(object sender, RoutedEventArgs e)
        {
            if (D4.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D5_Click(object sender, RoutedEventArgs e)
        {
            if (D5.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D6_Click(object sender, RoutedEventArgs e)
        {
            if (D6.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D7_Click(object sender, RoutedEventArgs e)
        {
            if (D7.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void D8_Click(object sender, RoutedEventArgs e)
        {
            if (D8.IsChecked == false && AllSel.IsChecked == true)
            {
                AllSel.IsChecked = false;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                var m_dt = ReadExcelFile(filePath);
                m_dt.TableName = "电气点位高度表";
                DataTable = m_dt;
                Cancel = false;
                Import = true;
                bt_import.Content = "已导入";
                bt_import.IsEnabled = false;

                //Close();
            }
        }

        public static DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();


            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range usedRange = worksheet.UsedRange;

            int unknown = 0;
            for (int col = 1; col < usedRange.Columns.Count + 1; col++)
            {
                var value = (usedRange.Cells[1, col] as Range)?.Value2;
                if (value != null)
                {
                    DataColumn dc = new DataColumn(value.ToString().Trim());
                    dt.Columns.Add(dc);
                }
                else
                {
                    unknown++;
                    DataColumn dc = new DataColumn($"未知{unknown}");
                    dt.Columns.Add(dc);
                }
            }
            for (int row = 2; row <= usedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
            {
                DataRow dr = dt.NewRow();
                for (int col = 1; col < usedRange.Columns.Count + 1; col++)
                {
                    var value = (usedRange.Cells[row, col] as Range)?.Value2;
                    if (value != null)
                    {
                        dr[col - 1] = value.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            workbook.Close(false);
            excelApp.Quit();

            return dt;
        }
    }
}
