using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper.ShopTicketChecking
{
    [Transaction(TransactionMode.Manual)]
    public class QtyChecking : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            //1.get all the assembly control mark
            Dictionary<string, List<ViewSheet>> ticketDict 
                = new Dictionary<string, List<ViewSheet>>();
            List<ViewSheet> sheetList = new List<ViewSheet>();
            List<ViewSheet> sheets = new FilteredElementCollector(doc)
                .OfCategory(BuiltInCategory.OST_Sheets)
                .Cast<ViewSheet>().ToList();
            foreach (ViewSheet s in sheets)
            {
                ElementId id = s.AssociatedAssemblyInstanceId;
                if (null != id)
                {
                    if (null != doc.GetElement(id))
                    {
                        sheetList.Add(s);
                    }
                }
            }
            var ticketGroup = sheetList.GroupBy(s => doc.GetElement(s.AssociatedAssemblyInstanceId).Name);
            foreach (var item in ticketGroup)
            {
                if (!ticketDict.ContainsKey(item.Key))
                {
                    ticketDict.Add(item.Key, item.ToList());
                }
            }

            //2.get qty base on model
            Dictionary<string, List<Element>> controlMarkDict
                = new Dictionary<string, List<Element>>();
            List<Element> elemetList = new List<Element>();
            List<Element> elems = new FilteredElementCollector(doc)
                .OfClass(typeof(FamilyInstance))
                .OfCategory(BuiltInCategory.OST_StructuralFraming)
                .ToElements().ToList();
            foreach (Element e in elems)
            {
                if (!e.Name.Contains("(DO NOT USE)"))
                {
                    if (e.GetParameters("CONTROL_MARK").Count != 0)
                    {
                        elemetList.Add(e);
                    }
                }
            }
            var controlMarkGroups = elemetList.GroupBy(u => Utils.GetParameterByName(u, "CONTROL_MARK"));
            foreach (var item in controlMarkGroups)
            {
                if (null == item.Key) { continue; }
                if (!controlMarkDict.ContainsKey(item.Key))
                {
                    controlMarkDict.Add(item.Key, item.ToList());
                }
            }
            controlMarkDict = controlMarkDict.OrderBy(p => p.Key, new StringComparer(true))
                .ToDictionary(p => p.Key, o => o.Value);

            //3.result List
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "ControlMark";
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "PieceCount";
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "TicketQty";
            dt.Columns.Add(dc3);
            DataColumn dc4 = new DataColumn();
            dc4.ColumnName = "Result";
            dt.Columns.Add(dc4);

            foreach (var item in controlMarkDict)
            {
                string controlMark = item.Key;
                string pieceCount = item.Value.Count.ToString();
                string ticketCount = "-";
                string result = "-";
                if (ticketDict.ContainsKey(item.Key))
                {
                    List<ViewSheet> tickets = ticketDict[item.Key];
                    ticketCount = GetTicketQty(tickets);
                    result = pieceCount == ticketCount ? "Pass" : "Error";
                }

                DataRow dr = dt.NewRow();
                dt.Rows.Add(dr);
                dr[0] = controlMark;
                dr[1] = pieceCount;
                dr[2] = ticketCount;
                dr[3] = result;
            }

            //4.show dialog
            QtyCheckingFrm frm = new QtyCheckingFrm(dt);
            //if (DialogResult.OK != frm.ShowDialog())
            //{
            //    return Result.Cancelled;
            //}
            frm.Show();

            return Result.Succeeded;
        }

        private string GetTicketQty(List<ViewSheet> sheets)
        {
            List<string> result = sheets.Select(u=>Utils.GetParameterByName(u, "Piece_Count"))
                .Distinct().ToList();

            if (result.Count == 0) return "null";
            if (result.Count > 1) return "Varies";
    
            return result[0];
        }
    }
}
