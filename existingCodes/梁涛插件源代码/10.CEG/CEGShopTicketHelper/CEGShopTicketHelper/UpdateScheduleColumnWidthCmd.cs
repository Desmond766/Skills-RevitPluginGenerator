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
    public class UpdateScheduleColumnWidthCmd : IExternalCommand
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

            if (sel.GetElementIds().Count != 1)
            {
                message = "select 1 schedule with template before running this tool";
                return Result.Cancelled;
            }
            ScheduleSheetInstance scheduleInst = doc.GetElement(sel.GetElementIds().First()) 
                as ScheduleSheetInstance;
            if (null == scheduleInst)
            {
                message = "select 1 schedule with template before running this tool";
                return Result.Cancelled;
            }
            ViewSchedule vs = doc.GetElement(scheduleInst.ScheduleId) as ViewSchedule;
            if (null == vs.ViewTemplateId)
            {
                message = "select 1 schedule with template before running this tool";
                return Result.Cancelled;
            }
            ViewSchedule template = doc.GetElement(vs.ViewTemplateId) as ViewSchedule;
            Dictionary<string, double> columnWidthDict = new Dictionary<string, double>();
            for (int i = 0; i < vs.Definition.GetFieldCount(); i++)
            {
                ScheduleField _field = vs.Definition.GetField(i);
                if (!columnWidthDict.ContainsKey(_field.GetName()))
                {
                    columnWidthDict.Add(_field.GetName(), _field.GridColumnWidth);
                }
            }
            //TaskDialog.Show("r", template.Name);
            //MessageBox.Show(string.Join(",",columnWidthDict.Keys)
            //    +"\n"+ string.Join(",", columnWidthDict.Values));

            //遍历所有的视图
            List<ViewSchedule> schedules = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewSchedule))
                .WhereElementIsNotElementType()
                .ToElements().Cast<ViewSchedule>().ToList();
            //TaskDialog.Show("r", schedules.Count.ToString());

            //List<ViewSchedule> collectVS = new List<ViewSchedule>();
            using (Transaction trans = new Transaction(doc, "CopyScheduleColumnWidth"))
            {
                trans.Start();
                foreach (ViewSchedule schedule in schedules)
                {
                    ElementId tempId = schedule.ViewTemplateId;
                    if (null != tempId)
                    {
                        if (tempId.IntegerValue == template.Id.IntegerValue)
                        {
                            //here
                            for (int i = 0; i < schedule.Definition.GetFieldCount(); i++)
                            {
                                ScheduleField _field = schedule.Definition.GetField(i);
                                if (columnWidthDict.ContainsKey(_field.GetName()))
                                {
                                    _field.GridColumnWidth = columnWidthDict[_field.GetName()];
                                }
                            }
                            //collectVS.Add(schedule);
                        }
                    }
                }
                //TaskDialog.Show("r", collectVS.Count.ToString());
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }
}
