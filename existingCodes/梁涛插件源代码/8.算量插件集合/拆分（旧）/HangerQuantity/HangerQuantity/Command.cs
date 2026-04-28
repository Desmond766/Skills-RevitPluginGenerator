using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Visual;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using Application = Microsoft.Office.Interop.Excel.Application;
using MessageBox = System.Windows.MessageBox;
using View = Autodesk.Revit.DB.View;

namespace HangerQuantity
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false || (mainWindow.WaterCheck == false && mainWindow.HVACCheck == false))
            {
                return Result.Cancelled;
            }

            var views = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType().Cast<View>();
            View waterView = null;
            View HVACView = null;
            if (mainWindow.WaterCheck == true)
            {
                waterView = views.FirstOrDefault(v => v.Name.Equals("水电抗震吊架出图"));
                if (waterView == null)
                {
                    message = "未找到视图：水电抗震吊架出图";
                    return Result.Cancelled;
                }
            }
            if (mainWindow.HVACCheck == true)
            {
                HVACView = views.FirstOrDefault(v => v.Name.Equals("暖通抗震吊架出图"));
                if (HVACView == null)
                {
                    message = "未找到视图：暖通抗震吊架出图";
                    return Result.Cancelled;
                }
            }
            List<TextNote> distinctTextNotes = new List<TextNote>();
            if (mainWindow.WaterCheck == true && mainWindow.HVACCheck == true)
            {
                var waterTextNotes = new FilteredElementCollector(doc, waterView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                var HVACTextNotes = new FilteredElementCollector(doc, HVACView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                distinctTextNotes = DistinctTextNotes(waterTextNotes, HVACTextNotes);
            }
            else if (mainWindow.WaterCheck == true)
            {
                var waterTextNotes = new FilteredElementCollector(doc, waterView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                distinctTextNotes = waterTextNotes;
            }else if (mainWindow.HVACCheck == true)
            {
                var HVACTextNotes = new FilteredElementCollector(doc, HVACView.Id).OfCategory(BuiltInCategory.OST_TextNotes).OfClass(typeof(TextNote)).Cast<TextNote>().ToList();
                distinctTextNotes = HVACTextNotes;
            }
            var textNoteGroup = distinctTextNotes.GroupBy(dtn => dtn.Text).ToList();
            ExportExcel(textNoteGroup);

            return Result.Succeeded;
        }
        // 去除两个集合中文字相同且坐标相似的文字注释，避免重复计算算量
        private List<TextNote> DistinctTextNotes(List<TextNote> textNotes1, List<TextNote> textNotes2)
        {
            List<TextNote> result = new List<TextNote>();

            foreach (TextNote textNote in textNotes1)
            {
                var filterNotes = textNotes2.Where(t => t.Text.Equals(textNote.Text) && t.Coord.DistanceTo(textNote.Coord) < 0.001).ToList();
                filterNotes.ForEach(ft => textNotes2.Remove(ft));
            }
            result.AddRange(textNotes1);
            result.AddRange(textNotes2);

            return result;
        }

        public void ExportExcel(List<IGrouping<string, TextNote>> group)
        {
            Application excelApp = new Application();
            Workbook excelDoc = excelApp.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);

            Worksheet excelSheet = (Worksheet)excelDoc.Worksheets[1];

            excelSheet.Cells[1, 1].Value = "文字注释";
            excelSheet.Cells[1, 2].Value = "数量";
            excelSheet.Cells[1, 3].Value = "类型";

            int i = 2;
            foreach (var info in group)
            {
                excelSheet.Cells[i, 1].Value = info.Key;
                excelSheet.Cells[i, 2].Value = info.ToList().Count;
                if (info.Key.StartsWith("Q") || info.Key.StartsWith("S"))
                {
                    excelSheet.Cells[i, 3].Value = "水电抗震吊架";
                }
                else if (info.Key.StartsWith("F"))
                {
                    excelSheet.Cells[i, 3].Value = "风管抗震吊架";
                }
                i++;
            }
            DateTime dateTime = DateTime.Now;
            string savePath = $@"C:\Users\Administrator\Desktop\抗震吊架算量{dateTime:yyyy-MM-dd HHmmss}.xlsx";
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel File|*.xlsx;*.xlx;*.csv|All Files|*.*";   // 设置文件类型为文本文件
                saveFileDialog.DefaultExt = ".xlsx";   // 默认文件的拓展名
                saveFileDialog.Title = "保存文件";
                saveFileDialog.FileName = $"抗震吊架算量{dateTime:yyyy-MM-dd HHmmss}.xlsx";   // 文件默认名

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    savePath = saveFileDialog.FileName;
                    excelDoc.SaveAs(savePath);
                    MessageBox.Show($"导出成功，文件路径：{savePath}");
                }
            }
            catch (Exception ex)
            {
                TaskDialog.Show("error", ex.Message);
                excelDoc.Close(false);
                excelApp.Quit();
                excelDoc = null;
                excelApp = null;
                return;
            }
            excelDoc.Close(false);
            excelApp.Quit();
            excelDoc = null;
            excelApp = null;

        }
    }
}
