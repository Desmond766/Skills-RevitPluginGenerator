using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeAssignmentOfConduitPath
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            SelWindow window = new SelWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            

            List<Conduit> conduits = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsNotElementType().Cast<Conduit>().ToList();
            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType().Where(x => x.Name.Contains("接线盒")).Cast<FamilyInstance>().ToList();
            //记录在其他回路中的线管，后续遍历中不再进行判断
            List<ElementId> hasCC = new List<ElementId>();
            List<ElementId> hasCF = new List<ElementId>();

            if (window.Import) goto AttributeByExcel;

            Transaction t = new Transaction(doc, "线管通路赋值");
            t.Start();
            foreach (var conduit in conduits)
            {
                //if (conduit.LookupParameter("电气-线管管材").AsString() == null || conduit.LookupParameter("电气系统").AsString() == null || conduit.LookupParameter("导线规格").AsString() == null || conduit.LookupParameter("导线型号").AsString() == null
                //    || conduit.LookupParameter("电气-线管管材").AsString() == "" || conduit.LookupParameter("电气系统").AsString() == "" || conduit.LookupParameter("导线规格").AsString() == "" || conduit.LookupParameter("导线型号").AsString() == ""
                //    || hasCC.Contains(conduit.Id)) continue;

                // 获取文字组内参数不为空的线管
                var paras = conduit.Parameters.Cast<Parameter>();
                paras = paras.Where(p => p.Definition.ParameterGroup == BuiltInParameterGroup.PG_TEXT && p.StorageType == StorageType.String);
                if (paras.Where(p => !string.IsNullOrEmpty(p.AsString())).Count() == 0) continue; 

                List<ElementId> allConELems = new List<ElementId>();
                GetAllConnect(conduit, ref allConELems);
                if (allConELems.Count == 1) continue;
                allConELems.Remove(conduit.Id);
                //获取要给回路赋值各参数的值
                //电气系统
                string para1 = conduit.LookupParameter("电气系统").AsString();
                //电气-线管管材
                string para2 = conduit.LookupParameter("电气-线管管材").AsString();
                //导线规格
                string para3 = conduit.LookupParameter("导线规格").AsString();
                //导线规格1
                string para4 = conduit.LookupParameter("导线规格1").AsString();
                //导线型号
                string para5 = conduit.LookupParameter("导线型号").AsString();
                //导线型号1
                string para6 = conduit.LookupParameter("导线型号1").AsString();
                //工作集
                int para7 = conduit.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger();

                foreach (var id in allConELems)
                {
                    Element elem;
                    try
                    {
                        elem = id.GetElement(doc);
                        if (elem.LookupParameter("电气系统").AsString() != para1) elem.LookupParameter("电气系统").Set(para1);
                        if (elem.LookupParameter("电气-线管管材").AsString() != para2) elem.LookupParameter("电气-线管管材").Set(para2);
                        if (elem.LookupParameter("导线规格").AsString() != para3) elem.LookupParameter("导线规格").Set(para3);
                        if (elem.LookupParameter("导线规格1").AsString() != para4) elem.LookupParameter("导线规格1").Set(para4);
                        if (elem.LookupParameter("导线型号").AsString() != para5) elem.LookupParameter("导线型号").Set(para5);
                        if (elem.LookupParameter("导线型号1").AsString() != para6) elem.LookupParameter("导线型号1").Set(para6);
                        if (elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger() != para7) elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(para7);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (elem is Conduit) hasCC.Add(id);
                    if (elem.Name.Contains("接线盒")) hasCF.Add(id);
                }

            }
            // 接线盒
            foreach (var item in familyInstances)
            {
                if (item.LookupParameter("电气-线管管材").AsString() == null || item.LookupParameter("电气系统").AsString() == null || item.LookupParameter("导线规格").AsString() == null || item.LookupParameter("导线型号").AsString() == null
                    || item.LookupParameter("电气-线管管材").AsString() == "" || item.LookupParameter("电气系统").AsString() == "" || item.LookupParameter("导线规格").AsString() == "" || item.LookupParameter("导线型号").AsString() == ""
                    || hasCF.Contains(item.Id)) continue;
                List<ElementId> allConELems = new List<ElementId>();
                GetAllConnect(item, ref allConELems);
                if (allConELems.Count == 1) continue;
                allConELems.Remove(item.Id);
                //获取要给回路赋值各参数的值
                //电气系统
                string para1 = item.LookupParameter("电气系统").AsString();
                //电气-线管管材
                string para2 = item.LookupParameter("电气-线管管材").AsString();
                //导线规格
                string para3 = item.LookupParameter("导线规格").AsString();
                //导线规格1
                string para4 = item.LookupParameter("导线规格1").AsString();
                //导线型号
                string para5 = item.LookupParameter("导线型号").AsString();
                //导线型号1
                string para6 = item.LookupParameter("导线型号1").AsString();
                //工作集
                int para7 = item.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger();

                foreach (var id in allConELems)
                {
                    Element elem;
                    try
                    {
                        elem = id.GetElement(doc);
                        if (elem.LookupParameter("电气系统").AsString() != para1) elem.LookupParameter("电气系统").Set(para1);
                        if (elem.LookupParameter("电气-线管管材").AsString() != para2) elem.LookupParameter("电气-线管管材").Set(para2);
                        if (elem.LookupParameter("导线规格").AsString() != para3) elem.LookupParameter("导线规格").Set(para3);
                        if (elem.LookupParameter("导线规格1").AsString() != para4) elem.LookupParameter("导线规格1").Set(para4);
                        if (elem.LookupParameter("导线型号").AsString() != para5) elem.LookupParameter("导线型号").Set(para5);
                        if (elem.LookupParameter("导线型号1").AsString() != para6) elem.LookupParameter("导线型号1").Set(para6);
                        if (elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger() != para7) elem.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(para7);
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                    if (elem.Name.Contains("接线盒")) hasCF.Add(id);
                }
            }
            t.Commit();
            return Result.Succeeded;
        AttributeByExcel:
            int succeed = 0;
            int failed = 0;
            using (Transaction tran = new Transaction(doc, "线管通路赋值"))
            {
                tran.Start();
                foreach (var item in conduits)
                {
                    string conduitName = item.Name;
                    var tableRows = window.DataTable.Rows.Cast<DataRow>();
                    if (tableRows.Select(r => r["弱电"].ToString()).Any(x => !string.IsNullOrEmpty(x) && conduitName.Contains(x)))
                    {
                        var tableRow = tableRows.FirstOrDefault(r => !string.IsNullOrEmpty(r["弱电"].ToString()) && conduitName.Contains(r["弱电"].ToString()));
                        //TaskDialog.Show("revit", tableRow["导线型号"].ToString() + "\n" + tableRow["回路标注"].ToString() + "\n" + tableRow["弱电"].ToString() + "\n" + conduitName + "\n" + tableRow["线管材质"].ToString());
                        try
                        {
                            var para1 = item.LookupParameter("电气系统");
                            var para2 = item.LookupParameter("电气-线管管材");
                            var para3 = item.LookupParameter("导线规格");
                            var para4 = item.LookupParameter("导线规格1");
                            var para5 = item.LookupParameter("导线型号");
                            var para6 = item.LookupParameter("导线型号1");
                            var para7 = item.LookupParameter("路由");
                            var para8 = item.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM);
                            //var para8 = item.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM);
                            //var para7 = item.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger();
                            //if (para1 != null) para1.Set(tableRow[""].ToString());

                            if (para5 != null)
                            {
                                // 若关联全局参数则先取消关联后再进行赋值
                                para5.DissociateFromGlobalParameter();
                                para5.Set(tableRow["导线型号"].ToString());
                            }
                            if (para6 != null)
                            {
                                para6.DissociateFromGlobalParameter();
                                para6.Set(tableRow["导线型号1"].ToString());
                            }
                            if (para7 != null) para7.Set(tableRow["回路标注"].ToString());
                            if (para8 != null && Math.Abs(para8.AsDouble() - Convert.ToDouble(tableRow["线管尺寸"].ToString()) / 304.8) > 0.01) para8.Set(Convert.ToDouble(tableRow["线管尺寸"].ToString()) / 304.8);
                            //if (para8 != null) para8.Set(Convert.ToDouble(tableRow["线管尺寸"].ToString()) / 304.8);
                            succeed++;
                        }
                        catch (Exception)
                        {
                            failed++;
                            continue;
                        }
                    }
                }

                tran.Commit();
            }
            //TaskDialog.Show("re", succeed + "\n" + failed);
            return Result.Succeeded;
        }
        /// <summary>
        /// 获取管道/管件通路上所有元素ID
        /// </summary>
        /// <param name="element"></param>
        /// <param name="ids"></param>
        /// <returns></returns>
        private List<ElementId> GetAllConnect(Element element, ref List<ElementId> ids)
        {
            List<ElementId> result = new List<ElementId>();
            if (element is FamilyInstance familyInstance)
            {
                if (element.Category.Id.IntegerValue == -2001040)
                {
                    return ids;
                }
                if (!ids.Contains(familyInstance.Id)) ids.Add(familyInstance.Id);
                foreach (Connector item in familyInstance.MEPModel.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (!ids.Contains(conRef.Owner.Id))
                            {
                                ids.Add(conRef.Owner.Id);
                                //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                GetAllConnect(conRef.Owner, ref ids);
                            }
                        }
                    }
                }
            }
            else if (element is Conduit conduit)
            {
                if (!ids.Contains(conduit.Id)) ids.Add(conduit.Id);
                foreach (Connector item in conduit.ConnectorManager.Connectors)
                {
                    if (item.ConnectorType == ConnectorType.End && item.IsConnected)
                    {
                        foreach (Connector conRef in item.AllRefs)
                        {
                            if (conRef.Owner.Id != item.Owner.Id)
                            {
                                if (!ids.Contains(conRef.Owner.Id))
                                {
                                    ids.Add(conRef.Owner.Id);
                                    //ids.AddRange(GetAllConnect(conRef.Owner, ids));
                                    GetAllConnect(conRef.Owner, ref ids);
                                }
                            }
                        }
                    }
                }
            }


            return ids;
        }
    }
    public static class Extension
    {
        public static Element GetElement(this ElementId elementId, Document doc)
        {
            return doc.GetElement(elementId);
        }
        public static Element GetElement(this Reference reference, Document doc)
        {
            return doc.GetElement(reference);
        }
    }
}
