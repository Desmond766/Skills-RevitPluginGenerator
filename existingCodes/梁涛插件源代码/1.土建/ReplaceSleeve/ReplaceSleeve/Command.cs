using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Interop;
using Document = Autodesk.Revit.DB.Document;

namespace ReplaceSleeve
{
    // 一键替换空心套柱
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            // 获取项目中所有结构柱类型
            List<Family> columnFamilys = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>()
                .Select(fs => fs.Family).Distinct().Where(f => IsFindFamily(doc, f)).ToList();
            List<string> familyNames = columnFamilys.Select(f => f.Name).Distinct().ToList();
            MainWindow window = new MainWindow();
            window.cbb_old_type.ItemsSource = familyNames;
            window.cbb_new_type.ItemsSource = familyNames;
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            // 一个提供WPF窗体和win32之间互相操作的类，允许开发者获取WPF窗体的hwnd和设置WPF窗体的所有者
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
            windowInteropHelper.Owner = intPtr;
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }

            // 获取视图中的结构柱
            List<FamilyInstance> columns = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>()
                .Where(c => c.Symbol.FamilyName.Equals(window.cbb_old_type.SelectionBoxItem.ToString()) && c.Symbol.LookupParameter("宽度") != null && (c.Symbol.LookupParameter("长度") != null || c.Symbol.LookupParameter("深度") != null)).ToList();

            // 获取空心柱族
            FamilySymbol columnSymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsElementType()
                .Cast<FamilySymbol>().Where(s => s.FamilyName.Equals(window.cbb_new_type.SelectionBoxItem.ToString())).FirstOrDefault();
            if (columnSymbol == null)
            {
                message = "未找到空心柱族";
                return Result.Failed;
            }
            Family columnFamily = columnSymbol.Family;
            if (columnFamily.GetFamilySymbolIds().Count == 0)
            {
                message = "未找到空心柱族类型";
                return Result.Failed;
            }

            ProgressBarView pbv = new ProgressBarView();
            IntPtr revitIntPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper2 = new WindowInteropHelper(pbv);
            windowInteropHelper2.Owner = revitIntPtr;
            pbv.Topmost = true;
            pbv.SetProgressBar(0, columns.Count, "- 1/1", "一键替换柱中...");
            pbv.SetTotalProgress(1, 1);
            pbv.Show();

            //TaskDialog.Show("rebot", columnFamily.Id + "\n" + columnFamily.Name + "\n" + columnFamily.GetFamilySymbolIds().Count);
            using (TransactionGroup tg = new TransactionGroup(doc, "一键替换空心柱"))
            {
                tg.Start();

                foreach (var column in columns)
                {
                    if (pbv.Cancel == true)
                    {
                        pbv.Close();
                        return Result.Cancelled;
                    }
                    pbv.SetValue(columns.IndexOf(column) + 1, columns.Count);
                    pbv.SetNowProgress(columns.IndexOf(column) + 1, columns.Count);
                    System.Windows.Forms.Application.DoEvents();

                    double width = column.Symbol.LookupParameter("宽度").AsDouble();
                    double length = GetSymbolLength(column.Symbol);
                    double mmWidth = Math.Round(width * 304.8, 0, MidpointRounding.AwayFromZero);
                    double mmLength = Math.Round(length * 304.8, 0, MidpointRounding.AwayFromZero);
                    Transaction t = new Transaction(doc, "获取空心柱族类型");
                    t.Start();

                    List<FamilySymbol> familySymbols = columnFamily.GetFamilySymbolIds().Select(id => doc.GetElement(id)).Cast<FamilySymbol>().ToList();
                    FamilySymbol familySymbol = familySymbols.FirstOrDefault(f => Math.Abs(GetSymbolLength(f) - length) < 0.001 && Math.Abs(f.LookupParameter("宽度").AsDouble() - width) < 0.001);
                    if (familySymbol != null)
                    {
                        if (!familySymbol.IsActive) familySymbol.Activate();
                    }
                    else
                    {
                        FamilySymbol templateSymbol = familySymbols.First();
                        string newSymbolName = ProcessWithCustomLogic(templateSymbol.Name, mmLength + "*" + mmWidth);
                        try
                        {
                            familySymbol = templateSymbol.Duplicate(newSymbolName) as FamilySymbol;
                        }
                        catch (Exception ex)
                        {
                            //int count = 0;
                            //var symbolNames = familySymbols.Select(fs => fs.Name).ToList();
                            //while (count < 100)
                            //{
                            //    count++;
                            //    newSymbolName += "(" + count + ")";
                            //    if (!symbolNames.Contains(newSymbolName))
                            //    {
                            //        familySymbol = templateSymbol.Duplicate(newSymbolName) as FamilySymbol;
                            //        break;
                            //    }
                            //}

                            //if (t.HasStarted() && !t.HasEnded()) t.RollBack();
                            //continue;
                            pbv.Close();
                            TaskDialog.Show("ERROR", ex.Message);
                            if (t.HasStarted() && !t.HasEnded()) t.RollBack();
                            if (tg.HasStarted() && !tg.HasEnded()) tg.RollBack();
                            return Result.Failed;
                        }

                        familySymbol.LookupParameter("深度")?.Set(length);
                        familySymbol.LookupParameter("长度")?.Set(length);
                        familySymbol.LookupParameter("宽度").Set(width);
                        if (!familySymbol.IsActive) { familySymbol.Activate(); }
                    }

                    t.Commit();
                    t.Dispose();

                    Transaction t2 = new Transaction(doc, "替换为空心柱");
                    t2.Start();
                    column.Symbol = familySymbol;
                    t2.Commit();
                    t2.Dispose();
                }

                tg.Assimilate();
            }
            pbv.Close();
            //TaskDialog.Show("BIMTRANS", "成功替换空心柱数量：" + columns.Count);
            TaskDialog.Show("BIMTRANS", "完成");

            return Result.Succeeded;
        }
        private bool IsFindFamily(Document doc, Family family)
        {
            bool result = false;

            var symbolIds = family.GetFamilySymbolIds();
            if (symbolIds.Count > 0)
            {
                FamilySymbol familySymbol = doc.GetElement(symbolIds.First()) as FamilySymbol;
                if (familySymbol.LookupParameter("宽度") != null && (familySymbol.LookupParameter("深度") != null || familySymbol.LookupParameter("长度") != null)) result = true;
            }

            return result;
        }
        private string ProcessWithCustomLogic(string input, string appendIfNoMatch)
        {
            if (string.IsNullOrEmpty(input))
                return input + appendIfNoMatch;

            string pattern = @"\d+[*x]\d+";

            // 使用MatchEvaluator进行复杂替换[6](@ref)
            if (Regex.IsMatch(input, pattern))
            {
                // 使用正则表达式替换所有匹配项[2,6](@ref)
                return Regex.Replace(input, pattern, appendIfNoMatch);
            }
            else
            {
                // 不匹配时在末尾添加指定字符
                return input + appendIfNoMatch;
            }
        }
        private double GetSymbolLength(FamilySymbol familySymbol)   
        {
            double length;
            length = familySymbol.LookupParameter("深度")?.AsDouble() ?? familySymbol.LookupParameter("长度").AsDouble();
            return length;
        }
    }
}
