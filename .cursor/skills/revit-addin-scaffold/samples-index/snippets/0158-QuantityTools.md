# Sample Snippet: QuantityTools

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\QuantityTools\QuantityTools`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## RevitCommand.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace QuantityTools
{
    public abstract class RevitCommand : IExternalCommand
    {
        public abstract void Action();
        public UIApplication uiapp { get; private set; }
        public UIDocument uidoc { get; private set; }
        public Application app { get; private set; }
        public Document doc { get; private set; }
        public Selection sel { get; private set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            

            try
            {
                uiapp = commandData.Application;
                uidoc = uiapp.ActiveUIDocument;
                app = uiapp.Application;
                doc = uidoc.Document;
                sel = uidoc.Selection;

                Action();

                return Result.Succeeded;
            }
            catch (OperationCanceledException)
            {
                return Result.Succeeded;
            }
            catch (Exception ex)
            {
                message = ex.Message; 
                return Result.Failed;
            }
        }
    }
}

```

## AttributeAssignmentOfConduitPathCmd\Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using QuantityTools.AttributeAssignmentOfConduitPathCmd;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
// HACK: 25.10.10 修改线管管径时报错（已解决）
// 创建弱电电线信息
namespace AttributeAssignmentOfConduitPath
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            //using (Transaction ts = new Transaction(doc, "ss"))
            //{
            //    ts.Start();
            //    var refff = uIDoc.Selection.PickObject(ObjectType.Element);
            //    Element element = doc.GetElement(refff);
            //    element.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(10 / 304.8);
            //    ts.Commit();
            //}
            //return Result.Succeeded;

            SelWindow window = new SelWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }


            List<Conduit> conduits = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsNotElementType().Cast<Conduit>().ToList();
            List<FamilyInstance> fits = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ConduitFitting).Cast<FamilyInstance>().ToList();
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType().Where(x => x.Name.Contains("接线盒")).Cast<FamilyInstance>().ToList();
            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(new ElementCategoryFilter(BuiltInCategory.OST_Conduit), new ElementCategoryFilter(BuiltInCategory.OST_ConduitFitting));
            List<Element> conduitsAndFitsAndBoxs = new FilteredElementCollector(doc, doc.ActiveView.Id).WhereElementIsNotElementType().WherePasses(logicalOrFilter).ToList();
            conduitsAndFitsAndBoxs.AddRange(familyInstances);
            conduitsAndFitsAndBoxs = conduitsAndFitsAndBoxs.Where(x => x.LookupParameter("电气系统") != null).ToList();
            // 记录在其他回路中的线管，后续遍历中不再进行判断
            List<ElementId> hasCC = new List<ElementId>();
            // 记录在其他回路中的接线盒，后续遍历中不再进行判断
            List<ElementId> hasCF = new List<ElementId>();
            // 记录在其他回路中的线管配件，后续遍历中不再进行判断
            List<ElementId> hasCFit = new List<ElementId>();

            if (window.Import) goto AttributeByExcel;

            Transaction t = new Transaction(doc, "线管通路赋值");
            t.Start();
            foreach (var conduit in conduits)
            {
                //if (conduit.LookupParameter("电气-线管管材").AsString() == null || conduit.LookupParameter("电气系统").AsString() == null || conduit.LookupParameter("导线规格").AsString() == null || conduit.LookupParameter("导线型号").AsString() == null
                //    || conduit.LookupParameter("电气-线管管材").AsString() == "" || conduit.LookupParameter("电气系统").AsString() == "" || conduit.LookupParameter("导线规格").AsString() == "" || conduit.LookupParameter("导线型号").AsString() == ""
                //    || hasCC.Contains(conduit.Id)) continue;

                if (conduit.LookupParameter("电气-线管管材").AsString() == null || conduit.LookupParameter("电气系统").AsString() == null
                    || conduit.LookupParameter("电气-线管管材").AsString() == "" || conduit.LookupParameter("电气系统").AsString() == ""
                    || hasCC.Contains(conduit.Id)) continue;

                // TODO: 25.3.7若电气系统中包含"照明"，则线管属性刷多刷一个"路由"参数
                // TODO: 25.4.3照明系统的线管不需要进去特殊处理，且赋值时只需对参数为空值的情况赋值，不用覆盖
                //bool contiansLight = false;
                //if (conduit.LookupParameter("电气系统").AsString().Contains("照明")) contiansLight = true;
                //if (contiansLight) if (conduit.LookupParameter("路由") == null || string.IsNullOrEmpty(conduit.LookupParameter("路由").AsString())) continue;

                //// 获取文字组内参数不为空的线管
                //var paras = conduit.Parameters.Cast<Parameter>();
                //paras = paras.Where(p => p.Definition.ParameterGroup == BuiltInParameterGroup.PG_TEXT && p.StorageType == StorageType.String);
                //if (paras.Where(p => !string.IsNullOrEmpty(p.AsString())).Count() == 0) continue;

                List<ElementId> allConELems = new List<ElementId>();
                GetAllConnect(conduit, ref allConELems);
                if (allConELems.Count == 1) continue;
                allConELems.Remove(conduit.Id);
                /* //获取要给回路赋值各参数的值
                //电气系统
                string para1 = conduit.LookupParameter("电气系统").AsString();
// ... truncated ...
```

