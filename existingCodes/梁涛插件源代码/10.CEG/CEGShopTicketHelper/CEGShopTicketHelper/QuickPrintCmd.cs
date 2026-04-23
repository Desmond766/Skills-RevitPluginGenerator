using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.IO;
using Autodesk.Revit.DB.Visual;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class QuickPrintCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            if (!doc.ActiveView.IsAssemblyView)
            {
                message = "Quick Print only work for shopticket/assembly sheet";
                return Result.Cancelled;
            }
            ViewSheet currentSheet = doc.ActiveView as ViewSheet;
            if (null == currentSheet)
            {
                message = "Quick Print only work for shopticket/assembly sheet";
                return Result.Cancelled;
            }
            string currentAssemblyName = doc.GetElement(currentSheet.AssociatedAssemblyInstanceId).Name;

            //https://blog.csdn.net/lushibi/article/details/44922281
            //打印机设置
            PrintManager pm = doc.PrintManager;
            
            //默认地址
            String path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string shtprtflenm = path + "\\" + currentAssemblyName
                + "(" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd") + ").pdf";
            if (currentAssemblyName.Contains("/"))
            {
                message = "Assembly name contain '/' can not print";
                return Result.Cancelled;
            }
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
                ViewSet sheetSet = GetAllSheets(doc, currentAssemblyName);

                //其他设置
                pm.PrintToFileName = shtprtflenm;
                pm.CombinedFile = true;
                pm.PrintToFile = true;
                //pm.PrintSetup.CurrentPrintSetting = ticketSetting;
                //SetPrintSettings(doc, pm, sheetSet);
                pm.Apply();

                ////如果设置的是同样的视图，会报错
                //if (!SameSheets(vss.InSession.Views, sheetSet))
                //{
                //    //vss.InSession.Views = sheetSet;
                //    //bug report 2025-8-1 设置InSession会导致默认的图纸集的设置修改
                //    vss.CurrentViewSheetSet.Views = sheetSet;
                //    vss.SaveAs("Quick Print");
                //}

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
                //            vSet.Views = sheetSet;
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
                //    vss.CurrentViewSheetSet.Views = sheetSet;
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
                //}

                string timeStamp = Utils.GetTimeStamp();
                vss.CurrentViewSheetSet.Views = sheetSet;
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

        //根据图框选择打印设置
        private void SetPrintSettings(Document doc, PrintManager pm, ViewSet sheetSet)
        {
            PrintSetting ticketSetting;
            PrintSetting hardWareSetting;

            var settingIds = doc.GetPrintSettingIds();
            ticketSetting = doc.GetElement(settingIds.Where(u => doc.GetElement(u).Name == "11 X17").FirstOrDefault())
                            as PrintSetting;
            hardWareSetting = doc.GetElement(settingIds.Where(u => doc.GetElement(u).Name == "8.5X11").FirstOrDefault())
                            as PrintSetting;

            foreach (ViewSheet sheet in sheetSet)
            {
                FamilyInstance titleBlock = Utils.GetTitleInstanceOnSheet(sheet.Document, sheet);

                ////读取图框宽度高度
                //double sheetWidth = titleBlock.get_Parameter(BuiltInParameter.SHEET_WIDTH).AsDouble();
                //double sheetHeight = titleBlock.get_Parameter(BuiltInParameter.SHEET_HEIGHT).AsDouble();

                if (titleBlock.Name.Contains("8.5X11"))
                {
                    pm.PrintSetup.CurrentPrintSetting = hardWareSetting;
                }
                if (titleBlock.Name.Contains("11X17"))
                {
                    pm.PrintSetup.CurrentPrintSetting = ticketSetting;
                }
                return;
            }
        }

    }
}
