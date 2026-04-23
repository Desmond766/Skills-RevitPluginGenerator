using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class ScheduleViewPopulatorCmd : IExternalCommand
    {
        public List<ElementId> selectedSheetList = new List<ElementId>();
        public List<ScheduleInfo> scheduleInfoList = new List<ScheduleInfo>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // select
            if (sel.GetElementIds().Count == 0)
            {
                message = "Select Schedule First!";
                return Result.Cancelled;
            }

            // collect info
            List<int> scheduleIds = new List<int>();
            foreach (ElementId id in sel.GetElementIds())
            {
                Element elem = doc.GetElement(id);
                if (elem is ScheduleSheetInstance)
                {
                    //2024.3.16 只收集不重复的
                    int sId = (elem as ScheduleSheetInstance).ScheduleId.IntegerValue;
                    if (!scheduleIds.Contains(sId))
                    {
                        ScheduleInfo sInfo = new ScheduleInfo(elem);
                        scheduleInfoList.Add(sInfo);
                        scheduleIds.Add(sId);
                    }
                }
            }
            if (scheduleInfoList.Count == 0)
            {
                message = "No Schedule Slected!";
                return Result.Cancelled;
            }

            //show dialog
            AssemblySheetFrm frm = new AssemblySheetFrm(doc);
            frm.ShowDialog();
            selectedSheetList = frm.selectedSheetList;

            //创建元组集合收集明细表
            //等循环结束后再修改明细表列宽
            List<Tuple<ViewSchedule, List<double>>> scheduleList = new List<Tuple<ViewSchedule, List<double>>>();

            using (Transaction tran = new Transaction(doc, "Schedule"))
            {
                tran.Start();
                foreach (ElementId id in selectedSheetList)
                {
                    try
                    {
                        ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                        ElementId assemblyInstanceId = sheet.AssociatedAssemblyInstanceId;
                        if (null != sheet)
                        {
                            foreach (ScheduleInfo sInfo in scheduleInfoList)
                            {
                                //create schedule
                                ViewSchedule schedule = AssemblyViewUtils.CreateSingleCategorySchedule
                                    (doc, assemblyInstanceId,
                                    new ElementId(sInfo.Category), sInfo.TemplateId, true);
                                schedule.Name = sInfo.Name;
                                //add to sheet
                                var newSch = ScheduleSheetInstance.Create(doc, sheet.Id, schedule.Id, sInfo.Position);
                                //split is new function in 2023api

                                //添加到元组集合中
                                scheduleList.Add(new Tuple<ViewSchedule, List<double>>(schedule, sInfo.ColumnWidths));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //TaskDialog.Show("r", ex.Message + ex.StackTrace);
                        continue;
                    }
                }

                tran.Commit();
            }

            using (Transaction tran = new Transaction(doc, "Schedule2"))
            {
                tran.Start();
                //在这修改明细表列宽
                foreach (Tuple<ViewSchedule, List<double>> item in scheduleList)
                {
                    TaskDialog.Show("r", item.Item1.Definition.GetFieldCount().ToString()
                        + ";" + item.Item2.Count.ToString());
                    for (int i = 0; i < item.Item1.Definition.GetFieldCount(); i++)
                    {
                        ScheduleField _field = item.Item1.Definition.GetField(i);
                        //set GridColumnWidth
                        _field.GridColumnWidth = item.Item2[i];
                        //set SheetColumnWidth
                        //_field.SheetColumnWidth =
                    }
                }
                tran.Commit();
            }
            

            return Result.Succeeded;
        }
    }
}
