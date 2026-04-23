using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;


namespace MEP_Replaycer
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string type = "标高刷";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Failed;
            }

            try
            {
                while (true)
                {
                    if (type == "标高刷")
                    {
                        ReplaycerForOffset replaycerForOffset = new ReplaycerForOffset(commandData);
                        using (Transaction t = new Transaction(doc, "标高刷"))
                        {
                            t.Start();

                            //选择管线
                            Reference reference = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择一根管线,收集标高");
                            replaycerForOffset.Replaycer(reference);

                            t.Commit();
                        }
                    }
                    else if (type == "系统刷")
                    {
                        RepalycerForSystemType replaycerForSystemType = new RepalycerForSystemType(commandData);
                        using (Transaction t = new Transaction(doc, "系统刷"))
                        {
                            t.Start();

                            //选择管线
                            Reference reference = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择一根管线,收集系统");
                            replaycerForSystemType.Replaycer(reference);

                            t.Commit();
                        }
                    }
                    else
                    {
                        ReplaycerForSize replaycerForSize = new ReplaycerForSize(commandData);
                        using (Transaction t = new Transaction(doc, "管径刷"))
                        {
                            t.Start();

                            //选择管线
                            Reference reference = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "请选择一根管线,收集管径");
                            replaycerForSize.Replaycer(reference);

                            t.Commit();
                        }
                    }
                }
            }
            catch (Exception)
            {

            }


            return Result.Succeeded;
        }
    }
}
