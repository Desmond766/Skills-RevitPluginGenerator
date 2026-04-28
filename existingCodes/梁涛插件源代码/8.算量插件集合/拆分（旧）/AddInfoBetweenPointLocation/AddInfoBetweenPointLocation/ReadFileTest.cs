using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace AddInfoBetweenPointLocation
{
    [Transaction(TransactionMode.Manual)]
    public class ReadFileTest : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
            //openFileDialog.Filter = "Excel Files|*.csv";
            string path = "";
            if (openFileDialog.ShowDialog() == true)
            {
                string filePath = openFileDialog.FileName;
                //TaskDialog.Show("revit", ExcelUtils.ReadExcelFile(filePath));
                
                
                path = openFileDialog.FileName;
            }
            var m_dt = new DataTable();
            m_dt = ExcelUtils.ReadExcelFile2(path);
            m_dt.TableName = "回路表";


            LogicalOrFilter orFilter = new LogicalOrFilter(new ElementCategoryFilter(BuiltInCategory.OST_ElectricalEquipment), new ElementCategoryFilter(BuiltInCategory.OST_ElectricalFixtures));
            var elemCol = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(orFilter).Where(e => e.LookupParameter("编号") != null && !string.IsNullOrEmpty(e.LookupParameter("编号").AsString()));

            int count = 0;
            int succeed = 0;
            TaskDialog.Show("test", m_dt.Rows.Count + "\n" + elemCol.Count());
            DateTime time1 = DateTime.Now;
            foreach (Element item in elemCol)
            {
                string itemName = item.LookupParameter("编号").AsString();
                foreach (DataRow dr in m_dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["用电名称"].ToString()))
                    {
                        string name = dr["用电名称"].ToString();
                        if (!string.IsNullOrEmpty(dr["连接材料"].ToString()))
                        {
                            count++;
                            string info = dr["连接材料"].ToString();
                            string eng = Regex.Replace(info, "[^A-Za-z]", "").Trim();
                            string num = Regex.Replace(info, "[^0-9]", "").Trim();


                            if (itemName == name)
                            {
                                succeed++;
                                break;
                            }

                        }
                    }
                }
            }
            DateTime time2 = DateTime.Now;
            TaskDialog.Show("revit", count + "\n" + succeed + "\n" + time2.Subtract(time1));
            return Result.Succeeded;
            using (Transaction t = new Transaction(doc, "读取csv创建竖向线管"))
            {
                t.Start();

                foreach (DataRow dr in m_dt.Rows)
                {
                    if (!string.IsNullOrEmpty(dr["用电名称"].ToString()))
                    {
                        string name = dr["用电名称"].ToString();
                        if (!string.IsNullOrEmpty(dr["连接材料"].ToString()))
                        {
                            count++;
                            string info = dr["连接材料"].ToString();
                            string eng = Regex.Replace(info, "[^A-Za-z]", "").Trim();
                            string num = Regex.Replace(info, "[^0-9]", "").Trim();

                            var elem = elemCol.FirstOrDefault(x => x.LookupParameter("编号").AsString() == name);
                            //var ielems = elemCol.GetEnumerator();
                            //while (ielems.MoveNext())
                            //{
                            //    var el = ielems.Current;
                            //    if (el.LookupParameter("编号").AsString() == name)
                            //    {
                            //        break;
                            //    }
                            //}

                            if (elem == null) continue;

                            var bbox = elem.get_BoundingBox(null);
                            XYZ point = bbox.Max.Add(bbox.Min) / 2;
                            double z = bbox.Max.Z;
                            point = new XYZ(point.X, point.Y, z - 10 / 304.8);

                            ElementId conduitType = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsElementType()
                                .Where(x => x.Name.Contains(eng)).Select(x => x.Id).FirstOrDefault();
                            if (conduitType == null) continue;
                            ElementId levelId = elem.LevelId;
                            Conduit conduit = Conduit.Create(doc, conduitType, point, point + XYZ.BasisZ * 1000 / 304.8, levelId);
                            conduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(Convert.ToInt32(num) / 304.8);
                            var para = conduit.LookupParameter("电气-线管管材");
                            if (para != null) para.Set(eng);
                            succeed++;
                        }
                    }
                }

                t.Commit();
            }
            TaskDialog.Show("revit", count + "\n" + succeed);

            return Result.Succeeded;
        }

        
    }


}
