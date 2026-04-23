using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper.ClientStandard
{
    [Transaction(TransactionMode.Manual)]
    public class TindallBOM : IExternalCommand
    {
        List<AssemblyInstance> selectedAssemblyList = new List<AssemblyInstance>();
        List<ViewSchedule> assemblySecheuleList = new List<ViewSchedule>();
        //public string symbol = "*";
        //public string code = "800";
        //public string projNum = "85417";
        //public string revision = "1";
        public string assemblyName;
        
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //show dialog
            TindallBOMFrm frm = new TindallBOMFrm(doc);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            selectedAssemblyList = frm._selectedAssemblyList;
            //symbol = frm._symbol;
            //code = frm._code;
            //projNum = frm._projNum;

            if (selectedAssemblyList.Count == 0)
            {
                message = "couldn't find any seleted assembly in the project!";
                return Result.Cancelled;
            }

            FilteredElementCollector scheduleCol = new FilteredElementCollector(doc);
            assemblySecheuleList = scheduleCol.OfClass(typeof(ViewSchedule))
                .ToElements().Cast<ViewSchedule>()
                .Where(u => u.IsAssemblyView && !u.IsTemplate)
                .ToList();

            //export
            using (Transaction t = new Transaction(doc, "TindallBOM"))
            {
                t.Start();
                foreach (AssemblyInstance aInst in selectedAssemblyList)
                {
                    ExtractInfo(doc, aInst);
                }
                t.Commit();
            }

            return Result.Succeeded;
        }

        public void ExtractInfo(Document doc, AssemblyInstance aInst)
        {
            //update current assemblyName
            assemblyName = aInst.Name;

            //resultList
            List<string> resultList = new List<string>();

            //get associated schedules
            List<ViewSchedule> assemblySecheules = assemblySecheuleList
                .Where(u => doc.GetElement(u.AssociatedAssemblyInstanceId).Name == aInst.Name)
                .ToList();

            //key
            DataTable dt = null;
            string weight = "NA";
            string length = "NA";
            string width = "NA";
            int index = 1;

            //search the schedules
            foreach (ViewSchedule vs in assemblySecheules)
            {
                if (vs.Name.Contains("WEIGHT"))
                {
                    dt = Utils.ScheduleToDataTable(vs);
                    if (dt.Rows.Count == 1 && dt.Columns.Count == 1)
                    {
                        weight = dt.Rows[0][0].ToString();
                    }
                    resultList.Insert(0, TindallDataFormat1("WEIGHT", weight));
                    break;
                }
            }
            foreach (ViewSchedule vs in assemblySecheules)
            {
                if (vs.Name.Contains("LENGTH & WIDTH"))
                {
                    dt = Utils.ScheduleToDataTable(vs);
                    if (dt.Rows.Count == 1 && dt.Columns.Count == 2)
                    {
                        length = dt.Rows[0][0].ToString();
                        width = dt.Rows[0][1].ToString();
                    }
                    resultList.Add(TindallDataFormat1("LENGTH", length));
                    resultList.Add(TindallDataFormat1("WIDTH", width));
                    break;
                }
            }
            ExtractDataFormat2(assemblySecheules, "PLATE", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "BENTBAR", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "STRBAR", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "STRAND", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "TIF", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "BIF", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "MESH", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "INSUL.", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "SIX101", ref index, resultList);
            ExtractDataFormat2(assemblySecheules, "SIX102", ref index, resultList);

            string resultInfo = string.Join("\n", resultList);
            File.WriteAllText(
                Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                string.Format("{0}{1}.txt", GlobalValue.TindallBOM_projNum, assemblyName)), resultInfo);
        }

        

        public string TindallDataFormat1(string k, string v)
        {
            //85417AFIP-011,1,WEIGHT,62402
            return string.Format("{0}{1},{2},{3},{4}",
                GlobalValue.TindallBOM_projNum, assemblyName, 
                GlobalValue.TindallBOM_revision, k, v);
        }

        public string TindallDataFormat2(string order, string k, string v)
        {
            //85417AFIP-011,1,10,IND030,8,*,526
            return string.Format("{0}{1},{2},{3},{4},{5},{6},{7}",
                GlobalValue.TindallBOM_projNum, assemblyName, 
                GlobalValue.TindallBOM_revision, order, k, v, 
                GlobalValue.TindallBOM_symbol, GlobalValue.TindallBOM_code);
        }

        public void ExtractDataFormat2(
            List<ViewSchedule> assemblySecheules,
            string scheduleNameContain,
            ref int index,
            List<string> resultList)
        {
            DataTable dt = null;
            foreach (ViewSchedule vs in assemblySecheules)
            {
                if (vs.Name.Contains(scheduleNameContain))
                {
                    dt = Utils.ScheduleToDataTable(vs);
                    if (dt.Rows.Count >= 1 && dt.Columns.Count == 2)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            string k = dt.Rows[i][0].ToString();
                            k = k.Replace("(TIF)", "").Replace("(BIF)", "").Replace(" SF", "").Trim();
                            //special plate
                            if (k.StartsWith("S"))
                            {
                                k = GlobalValue.TindallBOM_projNum + k;
                            }

                            string v = dt.Rows[i][1].ToString();
                            if (!string.IsNullOrEmpty(k) || !string.IsNullOrEmpty(v))
                            {
                                resultList.Add(TindallDataFormat2((index * 10).ToString(), k, v));
                                index++;
                            }
                        }
                    }
                    break;
                }
            }
        }

    }
}
