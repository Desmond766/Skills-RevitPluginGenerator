using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalWaterPipeIdentify
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            #region SQL语句测试
            //string mysqlCon = "server=192.168.11.202;database=bimquantitycalculation;user=fjpc;password=fjpc123456";
            //MySqlConnection con = new MySqlConnection(mysqlCon);
            //con.Open();

            ////string sql = "select * from conduit";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteReader();
            ////    while (countt.Read())
            ////    {
            ////        TaskDialog.Show("revit", countt.GetString("length"));
            ////    }
            ////}
            ////string sql = "insert into conduit (`conduit_id`,`project_id`,`remake`) values (2,3,'test')";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteNonQuery();
            ////    TaskDialog.Show("revit", countt.ToString());
            ////}
            ////string sql = "update conduit set remake='abc'";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteNonQuery();
            ////    TaskDialog.Show("revit", countt.ToString());
            ////}
            ////string sql = "delete from conduit where conduit_id=1 or conduit_id=3";
            ////using (MySqlCommand cmd = new MySqlCommand(sql, con))
            ////{
            ////    var countt = cmd.ExecuteNonQuery();
            ////    TaskDialog.Show("revit", countt.ToString());
            ////}

            //// 参数化查询，防止sql注入
            //int uname = 3;
            //int upwd = 2;
            //string sql2 = "select * from conduit where `conduit_id`=@name and `project_id`=@pwd";
            //using (MySqlCommand cmd = new MySqlCommand(sql2, con))
            //{
            //    cmd.Parameters.Add(new MySqlParameter("@name", uname));
            //    cmd.Parameters.Add(new MySqlParameter("@pwd", upwd));
            //    var reader = cmd.ExecuteReader();
            //    while (reader.Read())
            //    {
            //        if (!reader.IsDBNull(9)) TaskDialog.Show("revit", reader.GetString("remake"));
            //    }
            //}
            ////TaskDialog.Show("revit", "连接成功");

            //con.Close();


            //return Result.Succeeded;
            #endregion

            var pipes = new FilteredElementCollector(doc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_PipeCurves).Where(e => e is Pipe).Cast<Pipe>().ToList();

            var filterPipes1 = pipes.Where(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - (100 / 304.8) >= -0.001 /*&& (p.PipeType.Name.Contains("无压") || p.PipeType.Name.Contains("排水管"))*/);
            var filterPipes2 = pipes.Where(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() - (50 / 304.8) >= -0.001 && (p.PipeType.Name.Contains("冷凝水") || p.PipeType.Name.Contains("燃气")));

            filterPipes1 = filterPipes1.Where(f => !HasTeeFittingConnect(f) && f.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() - (2500 / 304.8) >= -0.001 ||
            HasTeeFittingConnect(f) && Math.Abs(GetLine(f).GetEndPoint(0).Z - GetLine(f).GetEndPoint(1).Z) - (2500 / 304.8) >= -0.001).ToList();
            filterPipes2 = filterPipes2.Where(f => !HasTeeFittingConnect(f) && f.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() - (2500 / 304.8) >= -0.001 ||
            HasTeeFittingConnect(f) && Math.Abs(GetLine(f).GetEndPoint(0).Z - GetLine(f).GetEndPoint(1).Z) - (2500 / 304.8) >= -0.001).ToList();
            //var filterPipes = new List<Pipe>();
            //filterPipes.AddRange(filterPipes1);
            //filterPipes.AddRange(filterPipes2);

            //int filterCount = filterPipes.Count();
            int count = 0;

            List<ElementId> ids = new List<ElementId>();
            ids.AddRange(filterPipes1.Select(p => p.Id).ToList());
            ids.AddRange(filterPipes2.Select(p => p.Id).ToList());
            ids = ids.Distinct().ToList();
            //TaskDialog.Show("revit",filterPipes1.Count()+"\n" + filterPipes2.Count()+"\n"+ ids.Count);

            //sel.SetElementIds(filterPipes.Select(p => p.Id).ToList());
            //return Result.Succeeded;

            using (Transaction t = new Transaction(doc, "排水立管标识"))
            {
                t.Start();

                foreach (var id in ids)
                {
                    Element f = doc.GetElement(id);
                    try
                    {
                        f.LookupParameter("安装方式").Set("立管");
                        count++;
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }

                t.Commit();
            }

            TaskDialog.Show("提示", "运行结束！\n符合条件的排水立管数量：" + ids.Count + "\n成功填写'安装方式'参数的排水立管数量：" + count + "\n未成功填写'安装方式'参数的排水立管数量：" + (ids.Count - count));

            return Result.Succeeded;
        }
        private bool HasTeeFittingConnect(MEPCurve mEPCurve)
        {
            bool result = false;

            var cons = mEPCurve.ConnectorManager.Connectors.Cast<Connector>().Where(c => c.IsConnected).ToList();
            foreach (var con in cons)
            {
                var allRefs = con.AllRefs;
                foreach (Connector conRef in allRefs)
                {
                    if (conRef.Owner.Id != mEPCurve.Id && conRef.Owner is FamilyInstance familyInstance && familyInstance.MEPModel.ConnectorManager != null)
                    {
                        if (familyInstance.MEPModel.ConnectorManager.Connectors.Cast<Connector>().Count(c => c.ConnectorType == ConnectorType.End) == 3)
                        {
                            result = true;
                            return result;
                        }
                    }
                }
            }

            return result;
        }

        private Line GetLine(MEPCurve mEPCurve)
        {
            return (mEPCurve.Location as LocationCurve).Curve as Line;
        }
    }
}
