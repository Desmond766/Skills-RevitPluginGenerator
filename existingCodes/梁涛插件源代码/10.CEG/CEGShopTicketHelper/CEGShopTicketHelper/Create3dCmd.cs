using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class Create3dCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //viewTemplate
            FilteredElementCollector col3 = new FilteredElementCollector(doc);
            List<View3D> assembly3dTemplates = col3.OfClass(typeof(View3D))
                .Cast<View3D>()
                .Where(u => u.IsTemplate)
                .ToList();
            Create3dFrm frm = new Create3dFrm(assembly3dTemplates);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            ElementId templateId = frm._templateId;
            List<string> assemblyNameContains = frm._assemblyNameContains;

            //assembly
            FilteredElementCollector col = new FilteredElementCollector(doc);
            List<AssemblyInstance> assemblyList = col.OfClass(typeof(AssemblyInstance))
                .Cast<AssemblyInstance>()
                .Where(u => assemblyNameContains.Any(v => u.Name.Contains(v)))
                .ToList();

            //assembly3d
            FilteredElementCollector col2 = new FilteredElementCollector(doc);
            List<View3D> assembly3dViews = col2.OfClass(typeof(View3D))
                .Cast<View3D>()
                .Where(u => u.IsAssemblyView && !u.IsTemplate && u.Name.Contains("3D"))
                .ToList();

            //exist3dAssemblyList
            List<int> exist3dAssemblyList = assembly3dViews
                .Where(u => u.ViewTemplateId.IntegerValue == templateId.IntegerValue)
                .Select(u => doc.GetElement(u.AssociatedAssemblyInstanceId).Id.IntegerValue).ToList();
            //needTemplate3dAssemblyList
            List<int> needTemplate3dAssemblyList = assembly3dViews
                .Where(u => u.ViewTemplateId.IntegerValue != templateId.IntegerValue)
                .Select(u => doc.GetElement(u.AssociatedAssemblyInstanceId).Id.IntegerValue).ToList();

            using (Transaction trans = new Transaction(doc, "Create 3D"))
            {
                trans.Start();
                foreach (AssemblyInstance aInst in assemblyList)
                {
                    if (!exist3dAssemblyList.Contains(aInst.Id.IntegerValue))
                    {
                        if (needTemplate3dAssemblyList.Contains(aInst.Id.IntegerValue))
                        {
                            View3D v = AssemblyViewUtils.Create3DOrthographic(
                                doc, aInst.Id, templateId, true);
                        }
                        else
                        {
                            View3D v = AssemblyViewUtils.Create3DOrthographic(
                                doc, aInst.Id, templateId, true);
                        }
                    }
                }
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
