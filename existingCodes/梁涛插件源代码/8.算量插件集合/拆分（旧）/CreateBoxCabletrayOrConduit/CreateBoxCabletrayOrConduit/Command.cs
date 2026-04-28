using AddInfoBetweenPointLocation;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateBoxCabletrayOrConduit
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            if (!(doc.ActiveView is View3D))
            {
                TaskDialog.Show("revit", "请在三维视图中运行插件");
                return Result.Cancelled;
            }
            else
            {
                view3D = doc.ActiveView as View3D;
            }

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }


            List<FamilyInstance> boxs;
            ElementId symbolId;
            string elemName;
            double high = -1;
            DataTable dataTable = new DataTable();

            if (window.rb_import.IsChecked == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Excel Files|*.xls;*.xlsx;*.csv";
                string path = "";
                if (openFileDialog.ShowDialog() == true)
                {
                    path = openFileDialog.FileName;
                }
                else
                {
                    return Result.Cancelled;
                }
                dataTable = ExcelUtils.ReadExcelFile2(path);
                dataTable.TableName = "配电箱设备表";
            }

            if (window.rb_scope.IsChecked == true)
            {
                boxs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).WhereElementIsNotElementType().Cast<FamilyInstance>()/*.Where(x => x.Symbol.Family.Name.Contains("配电"))*/.ToList();
            }
            else if (window.rb_sel.IsChecked == true)
            {
                boxs = sel.PickObjects(ObjectType.Element, new BoxFilter(), "框选配电箱").Select(x => doc.GetElement(x)).Cast<FamilyInstance>().ToList();
            }
            else
            {
                boxs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_ElectricalEquipment).WhereElementIsNotElementType()
                    .Where(x => x.LookupParameter("编号") != null && !string.IsNullOrEmpty(x.LookupParameter("编号").AsString()))
                    .Cast<FamilyInstance>()/*.Where(x => x.Symbol.Family.Name.Contains("配电"))*/.ToList();
            }

            if (window.rb_symbol.IsChecked == true)
            {
                symbolId = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsElementType().First().Id;
                elemName = "桥架";
            }
            else
            {
                symbolId = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsElementType().First().Id;
                elemName = "线管";
            }

            if (window.rb_high.IsChecked == false)
            {
                try
                {
                    high = Convert.ToDouble(window.tb_high.Text) / 304.8;
                    if (high <= 0)
                    {
                        TaskDialog.Show("Error", "输入的数值需大于0");
                        return Result.Cancelled;
                    }
                }
                catch (Exception e)
                {
                    TaskDialog.Show("Error", e.Message);
                    return Result.Failed;
                }
            }

            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            var cableTrays = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_CableTray).OfClass(typeof(CableTray)).Cast<CableTray>().Where(x => !(x.GetDirection().IsAlmostEqualTo(XYZ.BasisZ) || x.GetDirection().IsAlmostEqualTo(XYZ.BasisZ.Negate())));

            if (window.rb_import.IsChecked == true) goto ImportExcel;

            TransactionGroup TG = new TransactionGroup(doc, $"创建竖向{elemName}");
            TG.Start();
            foreach (var box in boxs)
            {
                XYZ boxPoint = (box.Location as LocationPoint).Point;
                CableTray cableTray = cableTrays.OrderBy(x => x.GetLine().Project(boxPoint).XYZPoint.DistanceTo(boxPoint)).First();
                double downLevel = cableTray.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble();
                Level level = doc.GetElement(cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId()) as Level;
                downLevel += level.ProjectElevation;
                if (window.rb_symbol.IsChecked == true)
                {
                    foreach (Connector con in box.MEPModel.ConnectorManager.Connectors)
                    {
                        if (con.Shape == ConnectorProfileType.Rectangular && !con.IsConnected && con.ConnectorType == ConnectorType.End)
                        {
                            XYZ conPoint = con.Origin;
                            XYZ conPoint2;
                            if (high == -1) conPoint2 = new XYZ(conPoint.X, conPoint.Y, downLevel);
                            else conPoint2 = conPoint + XYZ.BasisZ * high;
                            ElementId levelId = cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
                            symbolId = cableTray.GetTypeId();
                            using (Transaction t = new Transaction(doc, "创建竖向桥架"))
                            {
                                t.Start();
                                //CableTray newCableTray = CableTray.Create(doc, symbolId, conPoint, conPoint2, levelId);
                                //newCableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(cableTray.Width);
                                //newCableTray.get_Parameter(BuiltInParameter.)
                                Line line = Line.CreateBound(conPoint, conPoint2);
                                ElementId newCableTrayId = ElementTransformUtils.CopyElement(doc, cableTray.Id, new XYZ()).First();
                                CableTray newCableTray = doc.GetElement(newCableTrayId) as CableTray;
                                (newCableTray.Location as LocationCurve).Curve = line;
                                Connector cableCon = newCableTray.GetConnector(0);

                                double angle = cableCon.CoordinateSystem.BasisY.Negate().AngleTo(box.FacingOrientation);
                                ElementTransformUtils.RotateElement(doc, newCableTrayId, line, angle);

                                con.ConnectTo(cableCon);
                                t.Commit();
                            }
                        }
                    }
                }
                else
                {
                    foreach (Connector con in box.MEPModel.ConnectorManager.Connectors)
                    {
                        if (con.Shape == ConnectorProfileType.Round && !con.IsConnected && con.ConnectorType == ConnectorType.End)
                        {
                            XYZ conPoint = con.Origin;
                            XYZ conPoint2;
                            if (high == -1) conPoint2 = new XYZ(conPoint.X, conPoint.Y, downLevel);
                            else conPoint2 = conPoint + XYZ.BasisZ * high;
                            ElementId levelId = cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
                            using (Transaction t = new Transaction(doc, "创建竖向线管"))
                            {
                                t.Start();
                                Conduit newConduit = Conduit.Create(doc, symbolId, conPoint, conPoint2, levelId);
                                Connector conduitCon = newConduit.GetConnector(0);
                                con.ConnectTo(conduitCon);
                                t.Commit();
                            }
                        }
                    }
                }
            }
            TG.Assimilate();
            // 恢复视图中楼板的可见性
            HiddenFloor(doc, view3D, openIds, isHidden);
            return Result.Succeeded;
        ImportExcel:
            using (TransactionGroup newTG = new TransactionGroup(doc, $"创建竖向{elemName}"))
            {
                newTG.Start();
                foreach (var box in boxs)
                {
                    string boxName = box.LookupParameter("编号").AsString();
                    foreach (DataRow dr in dataTable.Rows)
                    {
                        if (!string.IsNullOrEmpty(dr["用电名称"].ToString()))
                        {
                            string name = dr["用电名称"].ToString();
                            if (!string.IsNullOrEmpty(dr["连接材料"].ToString()))
                            {
                                string info = dr["连接材料"].ToString();
                                string eng = Regex.Replace(info, "[^A-Za-z]", "").Trim();
                                string num = Regex.Replace(info, "[^0-9]", "").Trim();


                                if (boxName == name)
                                {
                                    var type = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Conduit).WhereElementIsElementType().FirstOrDefault(t => t.Name.Contains(eng));
                                    if (type == null) goto Next;
                                    symbolId = type.Id;

                                    XYZ boxPoint = (box.Location as LocationPoint).Point;
                                    CableTray cableTray = cableTrays.OrderBy(x => x.GetLine().Project(boxPoint).XYZPoint.DistanceTo(boxPoint)).First();
                                    double downLevel = cableTray.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble();
                                    Level level = doc.GetElement(cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId()) as Level;
                                    downLevel += level.ProjectElevation;

                                    foreach (Connector con in box.MEPModel.ConnectorManager.Connectors)
                                    {
                                        if (con.Shape == ConnectorProfileType.Round && con.ConnectorType == ConnectorType.End && !con.IsConnected)
                                        {
                                            XYZ conPoint = con.Origin;
                                            XYZ conPoint2;
                                            // TODO:需添加判断条件：最近桥架高度小于连接器z轴时不创建，或在寻找最近桥架时过滤掉高度低于连接器Z轴的连接器再进行寻找
                                            if (high == -1) conPoint2 = new XYZ(conPoint.X, conPoint.Y, downLevel);
                                            else conPoint2 = conPoint + XYZ.BasisZ * high;
                                            ElementId levelId = cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();
                                            using (Transaction t = new Transaction(doc, "创建竖向线管"))
                                            {
                                                t.Start();
                                                Conduit newConduit = Conduit.Create(doc, symbolId, conPoint, conPoint2, levelId);
                                                if (Math.Abs(newConduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).AsDouble() - Convert.ToInt32(num) / 304.8) > 0.01)
                                                    newConduit.get_Parameter(BuiltInParameter.RBS_CONDUIT_DIAMETER_PARAM).Set(Convert.ToInt32(num) / 304.8);
                                                Connector conduitCon = newConduit.GetConnector(0);
                                                con.ConnectTo(conduitCon);
                                                t.Commit();
                                            }
                                        }
                                    }

                                    break;
                                }

                            }
                        }
                    }
                Next:;
                }



                newTG.Assimilate();
            }

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
    }
}
