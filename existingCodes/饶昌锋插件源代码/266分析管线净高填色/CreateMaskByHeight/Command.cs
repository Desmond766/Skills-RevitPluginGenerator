using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CreateMaskByHeight
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            CreatMaskWindow window = new CreatMaskWindow();
            window.ShowDialog();
            int index = window.CreateType.SelectedIndex;
            int minValue = int.Parse(window.MinValue.Text);
            int maxValue = int.Parse(window.MaxValue.Text);
            bool flag = window.isSubmit;
            if (flag)
            {
                FilteredElementCollector collector = new FilteredElementCollector(doc, uidoc.ActiveView.Id);
                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
                List<Floor> floorList = new List<Floor>();

                //根据不同选项执行代码
                switch (index)
                {
                    case 0:
                        //车道
                        floorList = collector.OfCategory(BuiltInCategory.OST_Floors).ToElements().OfType<Floor>().Where(x => IsTargetFloor(x, "A-PB-地坪漆")).ToList();
                        CreateMask(uidoc, floorList, minValue, maxValue);
                        break;
                    case 1:
                        //车位
                        floorList = collector.OfCategory(BuiltInCategory.OST_Floors).ToElements().OfType<Floor>().Where(x => IsTargetFloor(x, "A-PB-停车位区域")).ToList();
                        CreateMask(uidoc, floorList, minValue, maxValue);
                        break;
                    case 2:
                        //房间
                        FloorFilter floorFilter = new FloorFilter();
                        floorList = uidoc.Selection.PickObjects(ObjectType.Element, floorFilter).ToFloors(doc);
                        CreateMask(uidoc, floorList, minValue, maxValue);
                        break;
                    default:
                        System.Windows.MessageBox.Show("创建失败");
                        return Result.Cancelled;
                }
                return Result.Succeeded;
            }

            return Result.Failed;
        }
        public void CreateMask(UIDocument uidoc, List<Floor> floorList, int minValue, int maxValue)
        {
            Document doc = uidoc.Document;
            Document linkDoc = null;
            doc.NewTransaction("创建遮罩层", () =>
            {

                foreach (Floor floor in floorList)
                {

                    Dictionary<ElementId, double> minElement = new Dictionary<ElementId, double>();
                    try
                    {
                        minElement = MaskCreat.Creat(uidoc, floor, minValue, maxValue, ref linkDoc);
                    }
                    catch (Exception e)
                    {
                        System.Windows.MessageBox.Show(e.ToString());
                        continue;
                    }
                    if (minElement != null)
                    {
                        if (minElement.Count() != 0)
                        {
                            MEPCurve mEP = linkDoc.GetElement(minElement.First().Key) as MEPCurve;

                            //MessageBox.Show(minElement.First().Key.ToString());
                            Curve curve = (mEP.Location as LocationCurve).Curve;
                            XYZ centerPoint = curve.Evaluate(0.5, true);

                            FilteredElementCollector collector = new FilteredElementCollector(doc);
                            List<FilledRegionType> lstFilledRegionType = collector.OfClass(typeof(FilledRegionType)).Cast<FilledRegionType>().ToList();
                            FilledRegionType filledRegionType = lstFilledRegionType.FirstOrDefault();

                            IList<CurveLoop> loops = new List<CurveLoop>();
                            List<Curve> curveList = new List<Curve>();//5601726
                            XYZ p1 = new XYZ(centerPoint.X - 500 / 304.8, centerPoint.Y + 500 / 304.8, centerPoint.Z);
                            XYZ p2 = new XYZ(centerPoint.X + 500 / 304.8, centerPoint.Y + 500 / 304.8, centerPoint.Z);
                            XYZ p3 = new XYZ(centerPoint.X + 500 / 304.8, centerPoint.Y - 500 / 304.8, centerPoint.Z);
                            XYZ p4 = new XYZ(centerPoint.X - 500 / 304.8, centerPoint.Y - 500 / 304.8, centerPoint.Z);
                            curveList.Add(Line.CreateBound(p1, p2));
                            curveList.Add(Line.CreateBound(p2, p3));
                            curveList.Add(Line.CreateBound(p3, p4));
                            curveList.Add(Line.CreateBound(p4, p1));
                            CurveLoop curveLoop = CurveLoop.Create(curveList);
                            loops.Add(curveLoop);
                            FilledRegion filledRegion = FilledRegion.Create(doc, filledRegionType.Id, uidoc.ActiveView.Id, loops);
                            MessageBox.Show(filledRegion.Id.ToString());//4305937 4306001

                        }
                    }
                    //System.Windows.MessageBox.Show(minElement.Count + "  " + minElement.First().Value);

                }

            });
        }
        public bool IsTargetFloor(Floor floor, string name)
        {
            //if (floor.Name.Contains("A-PB-地坪漆") || floor.Name.Contains("A-PB-停车位区域"))
            //{
            //    return true;
            //}
            if (floor.Name.Contains(name))
            {
                return true;
            }
            return false;
        }
    }
}
