using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// 将有设备编号参数的族实例的族类型赋值给该参数
namespace AddParaBySymbol
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            int meCount = 0;
            int daCount = 0;
            int paCount = 0;
            var elemFilters = new List<ElementFilter>()
            {
                new ElementCategoryFilter(BuiltInCategory.OST_MechanicalEquipment),
                new ElementCategoryFilter(BuiltInCategory.OST_DuctAccessory),
                new ElementCategoryFilter(BuiltInCategory.OST_PipeAccessory),
            };
            LogicalOrFilter orFilter = new LogicalOrFilter(elemFilters);
            var collect = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().WherePasses(orFilter).Where(x => x is FamilyInstance).Cast<FamilyInstance>();
            using (Transaction t = new Transaction(doc, "补充设备编号参数"))
            {
                t.Start();
                foreach (var item in collect)
                {
                    var para = item.LookupParameter("设备编号");
                    if (para != null)
                    {
                        // 该参数取消关联全局参数
                        para.DissociateFromGlobalParameter();
                        para.Set(item.Symbol.Name);
                        switch (item.Category.Id.IntegerValue)
                        {
                            case (int)BuiltInCategory.OST_MechanicalEquipment:
                                meCount++;
                                break;
                            case (int)BuiltInCategory.OST_DuctAccessory:
                                daCount++;
                                break;
                            case (int)BuiltInCategory.OST_PipeAccessory:
                                paCount++;
                                break;
                            default:
                                break;
                        }
                    }
                }

                t.Commit();
            }
            TaskDialog.Show("提示", $"运行结束！\n成功补充设备编号参数的族实例个数：\n机械设备：{meCount}\n风管附件：{daCount}\n管道附件：{paCount}");


            return Result.Succeeded;
        }
    }
}
