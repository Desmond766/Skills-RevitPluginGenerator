using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModifyingASchedule
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;


            List<Element> elements1 = new List<Element>();
            ViewSheet view = doc.ActiveView as ViewSheet;
            ElementClassFilter classFilter = new ElementClassFilter(typeof(FamilyInstance));
            List<ElementId> ids = (doc.GetElement(view.AssociatedAssemblyInstanceId) as AssemblyInstance).GetDependentElements(null).ToList();
            foreach (var item in ids)
            {
                try
                {
                    Element element = doc.GetElement(item);
                    if (element.Category.Id.IntegerValue == -2001350)
                    {
                        elements1.Add(element);
                    }
                }
                catch (Exception)
                {

                    continue;
                }
            }
            string name = doc.GetElement(view.AssociatedAssemblyInstanceId).Name;
            name = GetStringUntilFirstSpace(name);
            //TaskDialog.Show("dd", name);
            int cou = -1;
            foreach (var item in elements1)
            {
                foreach (Parameter para in item.Parameters)
                {
                    try
                    {
                        if (para.Definition.Name == "CONTROL_MARK" && para.AsString().Contains("MK"))
                        {
                            string nameP = para.AsString();
                            nameP = nameP.Replace("MK", "");
                            int couP = Convert.ToInt32(nameP);
                            if (couP > cou)
                            {
                                cou = couP;
                            }
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }
                }
            }

            List<Element> _Ø = new List<Element>();
            foreach (var item in elements1)
            {
                foreach (Parameter para in item.Parameters)
                {
                    if (para.Definition.Name == "CONTROL_MARK" && para.AsString() != null && para.AsString().Contains("Ø"))
                    {
                        foreach (Parameter para2 in item.Parameters)
                        {
                            try
                            {
                                if (para2.Definition.Name == "全長")
                                {
                                    _Ø.Add(item);
                                }
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                           
                        }
                    }
                }
            }
            _Ø = _Ø.OrderBy(x => x.LookupParameter("CONTROL_MARK").AsString()).ThenBy(y => y.LookupParameter("全長").AsDouble()).ToList();
            HashSet<ViewSchedule> viewSchedules = new HashSet<ViewSchedule>();
            ElementCategoryFilter categoryFilter = new ElementCategoryFilter(new ElementId(-2000570));
            foreach (var item in view.GetDependentElements(categoryFilter))
            {
                ScheduleSheetInstance scheduleSheetInstance = doc.GetElement(item) as ScheduleSheetInstance;
                ViewSchedule viewSchedule = doc.GetElement(scheduleSheetInstance.ScheduleId) as ViewSchedule;
                viewSchedules.Add(viewSchedule);
            }
            List<Tuple<ViewSchedule, List<double>>> scheduleList = new List<Tuple<ViewSchedule, List<double>>>();
            foreach (var item in viewSchedules)
            {
                List<double> nums = new List<double>();
                nums = item.GetWidth();
                scheduleList.Add(new Tuple<ViewSchedule, List<double>>(item, nums));
            }
            Transaction t = new Transaction(doc, "修改参数");
            t.Start();
            foreach (var item in elements1)
            {
                string cM = "";
                foreach (Parameter para in item.Parameters)
                {
                    try
                    {
                        if (para.Definition.Name == "CONTROL_MARK" && para.AsString().Contains("MK"))
                        {
                            cM = para.AsString();
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        continue;
                    }
                    
                }
                if (cM != "")
                {
                    foreach (Parameter para in item.Parameters)
                    {
                        if (para.Definition.Name == "CONTROL_MARK_GENE")
                        {
                            string newName = "";
                            if (cM.Length > 3)
                            {
                               newName = cM.Replace("MK", name);
                            }
                            else
                            {
                                newName = cM.Replace("MK", name + "0");
                            }
                             
                            para.Set(newName);
                            break;
                        }
                    }
                }
            }
            cou++;
            string nName = name + cou;
            if (cou <= 9)
            {
                nName = name + "0" + cou;
            }
            for (int i = 0; i < _Ø.Count(); i++)
            {
                _Ø[i].LookupParameter("CONTROL_MARK_GENE").Set(nName);
                if (i <= _Ø.Count() - 2)
                {
                    string p1 = _Ø[i].LookupParameter("CONTROL_MARK").AsString();
                    p1 = p1.Replace("Ø", "");
                    int np1 = Convert.ToInt32(p1);
                    double d1 = _Ø[i].LookupParameter("全長").AsDouble();
                    string p2 = _Ø[i + 1].LookupParameter("CONTROL_MARK").AsString();
                    p2 = p2.Replace("Ø", "");
                    int np2 = Convert.ToInt32(p2);
                    double d2 = _Ø[i + 1].LookupParameter("全長").AsDouble();
                    if (np1 < np2 || Math.Abs(d1 - d2) > 0.0001)
                    {
                        cou++;
                        if (cou <= 9)
                        {
                            nName = name + "0" + cou;
                        }
                        else
                        {
                            nName = name + cou;
                        }
                        
                    }
                }
            }
            //在这修改明细表列宽
            foreach (Tuple<ViewSchedule, List<double>> item in scheduleList)
            {
                for (int i = 0; i < item.Item1.Definition.GetFieldCount(); i++)
                {
                    ScheduleField _field = item.Item1.Definition.GetField(i);
                    _field.GridColumnWidth = item.Item2[i];
                }
            }
            t.Commit();
            return Result.Succeeded;
        }
        public  string GetStringUntilFirstSpace(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            int index = input.IndexOf(' ');

            if (index == -1)  // 如果没有找到空格
            {
                return input;  // 返回整个字符串
            }

            return input.Substring(0, index);
        }

    }
    public static class Utils
    {
        public static List<double> GetWidth(this ViewSchedule viewSchedule)
        {
            List<double> columnWidths = new List<double>();
            for (int i = 0; i < viewSchedule.Definition.GetFieldCount(); i++)
            {
                ScheduleField _field = viewSchedule.Definition.GetField(i);
                columnWidths.Add(_field.GridColumnWidth);
            }
            return columnWidths;
        }
    }
}
