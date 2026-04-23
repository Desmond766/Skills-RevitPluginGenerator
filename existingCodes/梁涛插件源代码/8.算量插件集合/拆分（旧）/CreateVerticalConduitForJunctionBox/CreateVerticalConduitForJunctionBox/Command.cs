using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace CreateVerticalConduitForJunctionBox
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;

            int successCount = 0;
            List<ElementId> ids = new List<ElementId>();

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }

            DataTable m_dt;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                m_dt = ReadExcelFile(filePath);

            }
            else
            {
                TaskDialog.Show("提示", "未导入Excel文件");
                return Result.Cancelled;
            }
            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ElectricalFixtures).WhereElementIsNotElementType()
                .Where(x => x.Name.Contains("接线盒") && x.Name.Contains("墙内")).Cast<FamilyInstance>().ToList();

            ConduitType defaultType = new FilteredElementCollector(doc).OfClass(typeof(ConduitType)).Cast<ConduitType>().First();

            Transaction t = new Transaction(doc, "墙内接线盒创建竖向线管");
            t.Start();
            foreach (var item in familyInstances)
            {

                // 判断点位是否在弱电线管规格表中
                var dataRows = m_dt.Rows.Cast<DataRow>().Where(dr => !string.IsNullOrEmpty(dr["用电名称"].ToString()) && dr["用电名称"].ToString() == item.LookupParameter("").AsString());
                if (dataRows.Count() == 0) continue;
                var dataRow = dataRows.First();
                var lineStand = dataRow["导线规格"].ToString();
                var routNum = dataRow["回路编号"].ToString();
                item.LookupParameter("回路编号").Set(routNum);
                item.LookupParameter("导线规格").Set(lineStand);
                //foreach (DataRow dr in m_dt.Rows)
                //{
                //    if (!string.IsNullOrEmpty(dr["用电名称"].ToString()))
                //    {
                //        string name = dr["用电名称"].ToString();
                //        if (!string.IsNullOrEmpty(dr["连接材料"].ToString()))
                //        {
                //            string info = dr["连接材料"].ToString();
                //            string eng = Regex.Replace(info, "[^A-Za-z]", "").Trim();
                //            string num = Regex.Replace(info, "[^0-9]", "").Trim();
                //            if (item.Name == name)
                //            {
                                
                //                break;
                //            }

                //        }
                //    }
                //}
                bool create = false;
                foreach (Connector con in item.MEPModel.ConnectorManager.Connectors)
                {
                    if (!con.CoordinateSystem.BasisZ.IsAlmostEqualTo(XYZ.BasisZ) || con.ConnectorType != ConnectorType.End || con.IsConnected) continue;
                    double height = GetHeightToFloor(view3D, con.Origin);
                    if (height == -1) continue;
                    XYZ refPoint = con.Origin + XYZ.BasisZ * height;

                    string sysName = item.LookupParameter("电气系统").AsString();
                    if (sysName == "") sysName = "线线线";

                    ConduitType conduitType = new FilteredElementCollector(doc).OfClass(typeof(ConduitType)).Cast<ConduitType>().Where(x => x.Name.Contains(sysName)).FirstOrDefault();
                    if (conduitType == null) conduitType = defaultType;

                    Conduit conduit = Conduit.Create(doc, conduitType.Id, con.Origin, refPoint, item.LevelId);
                    ids.Add(conduit.Id);
                    conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(20 / 304.8);

                    if (item.LookupParameter("电气系统").AsString() != "")
                    {
                        conduit.LookupParameter("电气系统").Set(item.LookupParameter("电气系统").AsString());
                        conduit.LookupParameter("导线规格").Set(item.LookupParameter("导线规格").AsString());
                        conduit.LookupParameter("导线规格1").Set(item.LookupParameter("导线规格1").AsString());
                        conduit.LookupParameter("导线型号").Set(item.LookupParameter("导线型号").AsString());
                        conduit.LookupParameter("导线型号1").Set(item.LookupParameter("导线型号1").AsString());
                        conduit.LookupParameter("电气-线管管材").Set(item.LookupParameter("电气-线管管材").AsString());
                        conduit.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).Set(item.get_Parameter(BuiltInParameter.ELEM_PARTITION_PARAM).AsInteger());
                    }

                    Connector conduitCon = conduit.GetConnector(0);
                    conduitCon.ConnectTo(con);
                    create = true;
                }
                if (create) successCount++;
            }

            t.Commit();
            TaskDialog.Show("Revit", $"接线盒（墙内）个数：{familyInstances.Count}\n成功创建线管的接线盒（墙内）个数：{successCount}");

            List<ElementId> finalIds = familyInstances.Select(x => x.Id).ToList();
            finalIds.AddRange(ids);
            sel.SetElementIds(finalIds);

            // 恢复视图中楼板的可见性
            HiddenFloor(doc, view3D, openIds, isHidden);

            return Result.Succeeded;
        }
        private void HiddenFloor(Document doc, View3D view3D, List<ElementId> openIds, bool isHidden)
        {
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();
                try
                {
                    foreach (var id in openIds)
                    {
                        view3D.SetFilterVisibility(id, false);
                    }
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), true);
                }
                catch (Exception)
                {
                    t.RollBack();
                    return;
                }

                t.Commit();
            }
        }

        private List<ElementId> DisplayFloor(Document doc, View view3D, out bool isHidden)
        {
            var closeIds = new List<ElementId>();
            var filterIds = view3D.GetFilters();
            using (Transaction t = new Transaction(doc, "可见性设置"))
            {
                t.Start();

                try
                {
                    foreach (var id in filterIds)
                    {
                        var filter = doc.GetElement(id);
                        if (filter.Name.Contains("结构板") || filter.Name.Contains("楼板"))
                        {
                            if (view3D.GetFilterVisibility(id)) continue;
                            view3D.SetFilterVisibility(id, true);
                            closeIds.Add(id);
                        }
                    }
                    //TaskDialog.Show("revit", view3D.GetCategoryHidden(new ElementId(-2000032)).ToString());
                    isHidden = view3D.GetCategoryHidden(new ElementId(-2000032));
                    if (isHidden) view3D.SetCategoryHidden(new ElementId(-2000032), false);
                }
                catch (Exception)
                {
                    isHidden = false;
                    closeIds = new List<ElementId>();
                    t.RollBack();
                    return closeIds;
                }

                t.Commit();
            }
            return closeIds;
        }

        public static DataTable ReadExcelFile(string filePath)
        {
            DataTable dt = new DataTable();


            Application excelApp = new Application();
            Workbook workbook = excelApp.Workbooks.Open(filePath);
            Worksheet worksheet = workbook.Sheets[1];

            Range usedRange = worksheet.UsedRange;

            int unknown = 0;
            for (int col = 1; col < usedRange.Columns.Count + 1; col++)
            {
                var value = (usedRange.Cells[1, col] as Range)?.Value2;
                if (value != null)
                {
                    DataColumn dc = new DataColumn(value.ToString().Trim());
                    dt.Columns.Add(dc);
                }
                else
                {
                    unknown++;
                    DataColumn dc = new DataColumn($"未知{unknown}");
                    dt.Columns.Add(dc);
                }
            }
            for (int row = 2; row <= usedRange.Rows.Count; row++) // 从第二行开始，假设第一行为标题
            {
                DataRow dr = dt.NewRow();
                for (int col = 1; col < usedRange.Columns.Count + 1; col++)
                {
                    var value = (usedRange.Cells[row, col] as Range)?.Value2;
                    if (value != null)
                    {
                        dr[col - 1] = value.ToString();
                    }
                }
                dt.Rows.Add(dr);
            }

            workbook.Close(false);
            excelApp.Quit();

            return dt;
        }

        public double GetHeightToFloor(View3D view3D, XYZ point)
        {
            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.Element, view3D);
            referenceIntersector.FindReferencesInRevitLinks = true;
            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point, XYZ.BasisZ);

            if (referenceWithContext != null)
            {
                double height = referenceWithContext.GetReference().GlobalPoint.DistanceTo(point);
                return height;
            }

            return -1;
        }
    }
}
