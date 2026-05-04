# Sample Snippet: HangerUpdate

Source project: `existingCodes\梁涛插件源代码\4.吊架布置\HangerUpdate\HangerUpdate`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;
using static System.Net.Mime.MediaTypeNames;
using RevitUtils;

namespace HangerUpdate
{
    [Transaction(TransactionMode.Manual)]
    [Serializable]
    public class Command : MarshalByRefObject, IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TaskDialog.Show("rveit", "jdfdf");
            //return Result.Succeeded;

            //TaskDialog.Show("revit", System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            View3D view3d = null;
            if (doc.ActiveView is View3D view3D) view3d = view3D;
            else view3d = ViewUtils.SelectView3D(doc);

            if (view3d == null)
            {
                return Result.Cancelled;
            }

            if (view3d.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).AsInteger() != (int)ViewDetailLevel.Fine)
            {
                using (Transaction t = new Transaction(doc, "三维视图详细程度设置"))
                {
                    t.Start();
                    view3d.get_Parameter(BuiltInParameter.VIEW_DETAIL_LEVEL).Set((int)ViewDetailLevel.Fine);
                    t.Commit();
                }
            }

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }

            var hangerFamiles = Properties.Settings.Default.HangerFamily.Trim(',').Split(',').ToList();
            var hangerSymbols = Properties.Settings.Default.HangerSymbol.Trim(',').Split(',').ToList();
            var r = Properties.Settings.Default.Radius / 304.8;
            var rayDis = Properties.Settings.Default.DownRayScope / 304.8;

            var filterHangers = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_MechanicalEquipment).OfClass(typeof(FamilyInstance))
                .Cast<FamilyInstance>().Where(f => hangerFamiles.Any(hf => f.Symbol.FamilyName.Contains(hf)) && hangerSymbols.Any(hs => f.Symbol.Name.Contains(hs))).ToList();

            var pipes = new FilteredElementCollector(doc, view3d.Id).OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe)).Where(p => p.Name.Contains("喷淋") && p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM) != null && p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - 50 / 304.8 <= 0.0001).Cast<Pipe>().ToList();

            ProgressBarView pbv = new ProgressBarView(commandData);
            pbv.Topmost = true;
            pbv.SetProgressBar(0, filterHangers.Count(), "- 0/1", "吊架更新中...");
            pbv.Show();

            // 记录更新异常的吊架
            List<ElementId> failedIds = new List<ElementId>();

            using (TransactionGroup TG = new TransactionGroup(doc, "吊架更新"))
            {
                TG.Start();

                for (int i = 0; i < filterHangers.Count(); i++)
                {
                    if (pbv.Cancel == true)
                    {
                        if (TG.HasStarted()) TG.RollBack();
                        return Result.Failed;
                    }
                    pbv.SetValue(i, Math.Round((((double)i / filterHangers.Count) * 100)) + "%");
                    pbv.SetNowProgress($"- {i}/{filterHangers.Count}");
                    System.Windows.Forms.Application.DoEvents();
// ... truncated ...
```

## RevitCommand.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace HangerUpdate
{
    [Transaction(TransactionMode.Manual)]
    public abstract class RevitCommand : IExternalCommand
    {
        public abstract void Action();
        public UIDocument Uidoc { get; set; }
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            
            try
            {
                Uidoc = commandData.Application.ActiveUIDocument;
                Action();

                return Result.Succeeded;
            }
            catch(OperationCanceledException ocex)
            {
                TaskDialog.Show("Revit", "已完成");
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

