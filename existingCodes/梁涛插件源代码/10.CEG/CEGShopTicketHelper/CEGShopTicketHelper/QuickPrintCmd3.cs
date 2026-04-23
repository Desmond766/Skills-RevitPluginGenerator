using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class QuickPrintCmd3 : IExternalCommand
    {
        public ViewSet selectedSheetSet = new ViewSet();
        public PrintSetting selectedPrintSetting = null;
        public string selectedPrinter = null;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            QuickPrintCmd3Frm frm = new QuickPrintCmd3Frm(doc);
            frm.ShowDialog();
            selectedSheetSet = frm.selectedSheetSet;
            selectedPrintSetting = frm.selectedPrintSetting;
            selectedPrinter = frm.selectedPrinter;
            
            if (selectedSheetSet.Size == 0)
            {
                return Result.Cancelled;
            }


            //https://blog.csdn.net/lushibi/article/details/44922281
            //打印机设置
            PrintManager pm = doc.PrintManager;

            //默认地址
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shtprtflenm = path + "\\" + doc.Title
                + "(" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + ").pdf";
            if (File.Exists(shtprtflenm))
            {
                try
                {
                    File.Delete(shtprtflenm);
                }
                catch (Exception ex)
                {
                    message = ex.Message;
                    return Result.Cancelled;
                }
            }

            using (Transaction trans = new Transaction(doc, "CEG Quick Print"))
            {
                trans.Start();

                //设置打印哪些图纸
                pm.PrintRange = PrintRange.Select;
                var vss = pm.ViewSheetSetting;

                //其他设置
                pm.PrintToFileName = shtprtflenm;
                pm.CombinedFile = true;
                pm.PrintToFile = true;
                pm.PrintSetup.CurrentPrintSetting = selectedPrintSetting;
                pm.Apply();

                ////如果设置的是同样的视图，会报错
                //if (!SameSheets(vss.InSession.Views, selectedSheetSet))
                //{
                //    vss.InSession.Views = selectedSheetSet;
                //}
                //pm.SubmitPrint();

                //bool needToCreateNewSet = true;
                FilteredElementCollector filteredElementCollectorSets = new FilteredElementCollector(doc);
                filteredElementCollectorSets.OfClass(typeof(ViewSheetSet));
                //foreach (Element e in filteredElementCollectorSets)
                //{
                //    if (e is ViewSheetSet)
                //    {
                //        ViewSheetSet vSet = (ViewSheetSet)e;
                //        if (vSet.Name == "Quick Print")
                //        {
                //            vSet.Views = selectedSheetSet;
                //            vss.CurrentViewSheetSet = vSet;

                //            vss.CurrentViewSheetSet.Views = vSet.Views;

                //            try
                //            {
                //                vss.Save();
                //                pm.Apply();
                //                needToCreateNewSet = false;
                //            }
                //            catch { }
                //        }
                //    }
                //}
                //if (needToCreateNewSet == true)
                //{
                //    vss.CurrentViewSheetSet.Views = selectedSheetSet;
                //    try
                //    {
                //        vss.SaveAs("Quick Print");
                //        pm.Apply();
                //    }
                //    catch 
                //    {
                //        vss.SaveAs("Quick Print" + "_" + Utils.GetTimeStamp());
                //        pm.Apply();
                //    }
                    
                //    //needToCreateNewSet = false;
                //}


                string timeStamp = Utils.GetTimeStamp();
                vss.CurrentViewSheetSet.Views = selectedSheetSet;
                vss.SaveAs("Quick Print" + "_" + timeStamp);
                pm.Apply();

                pm.SubmitPrint();

                var delVSS = filteredElementCollectorSets.Where(e => e is ViewSheetSet)
                    .FirstOrDefault(e => e.Name == "Quick Print" + "_" + timeStamp);
                if (delVSS != null) doc.Delete(delVSS.Id);

                trans.Commit();
            }


            return Result.Succeeded;
        }

        private ViewSet GetAllSheets(Document doc, string assemblyName)
        {
            ViewSet sheetSet = new ViewSet();
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(Autodesk.Revit.DB.View));
            foreach (ElementId id in collector.ToElementIds())
            {
                ViewSheet sheet = (doc.GetElement(id) as ViewSheet);
                if (null != sheet)
                {
                    if (sheet.IsAssemblyView)
                    {
                        if (doc.GetElement(sheet.AssociatedAssemblyInstanceId).Name == assemblyName)
                        //if (sheet.SheetNumber.Contains(assemblyName))//W-61 W-61X
                        {
                            sheetSet.Insert(sheet);
                        }
                    }
                }
            }
            return sheetSet;
        }

        private bool SameSheets(ViewSet set1, ViewSet set2)
        {
            if (set1.Size != set2.Size)
            {
                return false;
            }

            foreach (View item in set1)
            {
                if (!set2.Contains(item))
                {
                    return false;
                }
            }
            return true;
        }

    }
}
