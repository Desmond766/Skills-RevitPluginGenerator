using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CopySameParameterValue
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            List<Category> categories = new FilteredElementCollector(doc, doc.ActiveView.Id).Select(e => e.Category)
                .Where(c => c != null).Select(c => c.Id).Distinct().Select(id => Category.GetCategory(doc, id)).Where(c => c != null).ToList();
            //foreach (var item in categories)
            //{
            //    TaskDialog.Show("e", item.Name);
            //}
            //TaskDialog.Show("r", categories.Count.ToString());

            List<CategoryInfo> categoryInfos = new List<CategoryInfo>();
            foreach (Category c in categories)
            {
                categoryInfos.Add(new CategoryInfo() { Category = c, CategoryName = c.Name });
            }
            categoryInfos = categoryInfos.OrderBy(c => c.CategoryName).ToList();

            MainWindow mainWindow = new MainWindow(doc, categoryInfos);
            mainWindow.ShowDialog();

            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            using (Transaction t = new Transaction(doc, "参数复制"))
            {
                t.Start();

                var elems = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(new ElementCategoryFilter(mainWindow.SelCategory.Id));
                foreach (var elem in elems)
                {
                    dynamic value = GetParameterValue(elem, mainWindow.SourcePara, out var storageType);
                    SetParamenterValue(elem, mainWindow.TargetPara, value, storageType);
                }

                t.Commit();
            }

            MessageBox.Show("运行完成！");

            return Result.Succeeded;

            //List<ElementFilter> elementFilters = new List<ElementFilter>()
            //{
            //    new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment),
            //    new ElementCategoryFilter(BuiltInCategory.OST_ElectricalEquipment),
            //    new ElementCategoryFilter(BuiltInCategory.OST_PipeAccessory),
            //    new ElementCategoryFilter(BuiltInCategory.OST_DuctAccessory),
            //};
            //LogicalOrFilter orFilter = new LogicalOrFilter(elementFilters);
            //var elemCol = new FilteredElementCollector(doc).WherePasses(orFilter).WhereElementIsNotElementType();

            //using (Transaction t = new Transaction(doc, "统一相同参数值"))
            //{
            //    t.Start();

            //    foreach (var elem in elemCol)
            //    {
            //        var paras = elem.Parameters.Cast<Parameter>().ToList();
            //        var para1 = paras.FirstOrDefault(p => p.Definition.Name == "设备分类编码" && p.StorageType == StorageType.String && !string.IsNullOrEmpty(p.AsString()));
            //        var para2 = paras.FirstOrDefault(p => p.Definition.Name == "设备编号" && p.StorageType == StorageType.String && !string.IsNullOrEmpty(p.AsString()));
            //        var paras1 = paras.Where(p => p.Definition.Name == "设备分类编码" && !p.IsReadOnly && p.StorageType == StorageType.String && string.IsNullOrEmpty(p.AsString()));
            //        var paras2 = paras.Where(p => p.Definition.Name == "设备编号" && !p.IsReadOnly && p.StorageType == StorageType.String && string.IsNullOrEmpty(p.AsString()));

            //        if (para1 != null)
            //        {
            //            string paraValue1 = para1.AsString();
            //            foreach (var para in paras1)
            //            {
            //                para.Set(paraValue1);
            //            }
            //        }
            //        if (para2 != null)
            //        {
            //            string paraValue2 = para2.AsString();
            //            foreach (var para in paras2)
            //            {
            //                para.Set(paraValue2);
            //            }
            //        }
            //    }

            //    t.Commit();
            //}

            //MessageBox.Show("完成");

            //return Result.Succeeded;
        }

        private void SetParamenterValue(Element elem, Parameter targetPara, dynamic value, StorageType storageType)
        {
            foreach (Parameter para in elem.Parameters)
            {
                if (para.Id == targetPara.Id && para.IsReadOnly == false)
                {
                    // 不同StorageType需进行转换后再填入值
                    try
                    {
                        if (para.StorageType == StorageType.String)
                        {
                            if (storageType == StorageType.Double) para.Set((value * 304.8).ToString());
                            else para.Set(value.ToString());
                        }
                        else if (para.StorageType == StorageType.Integer)
                        {
                            para.Set(Convert.ToInt32(value));
                        }
                        else if (para.StorageType == StorageType.Double)
                        {
                            para.Set(Convert.ToDouble(value));
                        }
                        else
                        {
                            para.Set(value);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    break;
                }
            }
        }

        private dynamic GetParameterValue(Element elem, Parameter sourcePara, out StorageType storageType)
        {
            dynamic result = null;
            storageType = StorageType.None;

            foreach (Parameter para in elem.Parameters)
            {
                if (para.Id == sourcePara.Id)
                {
                    if (para.StorageType == StorageType.Integer)
                    {
                        result = para.AsInteger();
                    }
                    else if (para.StorageType == StorageType.Double)
                    {
                        result = para.AsDouble();
                    }
                    else if (para.StorageType == StorageType.String)
                    {
                        result = para.AsString() ?? para.AsValueString();
                    }
                    else if (para.StorageType == StorageType.ElementId)
                    {
                        result = para.AsElementId();
                    }
                    storageType = para.StorageType;
                    break;
                }
            }


            return result;
        }
    }
    public class ParameterInfo
    {
        public Parameter Parameter { get; set; }
        public string ParaName { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsEnabled { get; set; }
    }
    public class CategoryInfo
    {
        public Category Category { get; set; }
        public string CategoryName { get; set; }
    }
}
