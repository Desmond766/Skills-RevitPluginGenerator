using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;

namespace ColumnCornerProtectorDirectionAdjustment
{
    // 柱套护角方向调整（中海空心柱族）
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public List<ElementId> LinkLaneIds { get; set; } = new List<ElementId>();
        double FindLength = 0;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow mainWindow = new MainWindow();
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            FindLength = Properties.Settings.Default.MaxDis / 304.8;

            //// 用该方法可以在不关闭Revit的情况下更新插件，但无法通过快捷键使用对应插件
            //var assembly = Assembly.LoadFrom(@"C:\Program Files\BIMTRANS\NewBTStore\ColoringOfStructuralPlates.dll");
            //var type = assembly.GetType("ColoringOfStructuralPlates.Command");
            //var realCommand = Activator.CreateInstance(type) as IExternalCommand;

            //return realCommand.Execute(commandData, ref message, elements);

            //return Result.Succeeded;

            //Wall wall = (Wall)doc.GetElement(sel.PickObject(ObjectType.Element, "选择幕墙"));
            //Mullion mullion = (Mullion)doc.GetElement(sel.PickObject(ObjectType.Element, "选择竖梃"));
            //var uLines = wall.CurtainGrid.GetUGridLineIds();
            //var vLines = wall.CurtainGrid.GetVGridLineIds();
            ////TaskDialog.Show("revit", uLines.Count + "\n" + vLines.Count);
            //CurtainGrid grid = wall.CurtainGrid;
            //Transaction transaction = new Transaction(doc, "添加网格");
            //transaction.Start();

            //foreach (var item in grid.GetVGridLineIds())
            //{
            //    CurtainGridLine gridLine = (CurtainGridLine)doc.GetElement(item);
            //    gridLine.AddMullions(gridLine.AllSegmentCurves.get_Item(2), mullion.MullionType, false);
            //}
            
            //transaction.Commit();
            //return Result.Succeeded;

            //// 修改楼板边界
            //Reference ref1 = sel.PickObject(ObjectType.Element, "Please pick a floor to edit");
            //Floor floor = doc.GetElement(ref1) as Floor;

            //Transaction transTemp = new Transaction(doc);
            //transTemp.Start("tempDelete");
            //ICollection<ElementId> ids = doc.Delete(floor.Id);
            //transTemp.RollBack();

            //List<ModelLine> mLines = new List<ModelLine>();
            //foreach (ElementId id in ids)
            //{
            //    Element ele = doc.GetElement(id);
            //    if (ele is ModelLine)
            //    {
            //        mLines.Add(ele as ModelLine);
            //    }
            //}
            //Transaction trans = new Transaction(doc);
            //trans.Start("ChangeFloor");
            //foreach (ModelLine mline in mLines)
            //{
            //    LocationCurve lCurve = mline.Location as LocationCurve;
            //    Line c = lCurve.Curve as Line;
            //    XYZ pt1 = c.GetEndPoint(0);
            //    XYZ pt2 = c.GetEndPoint(1);
            //    Transform transform = Transform.CreateTranslation(new XYZ(-1, -1.5, 0)); //move the line.
            //    XYZ pt1New = transform.OfPoint(pt1);
            //    XYZ pt2New = transform.OfPoint(pt2);
            //    Line newLine = Line.CreateBound(pt1New, pt2New);
            //    lCurve.Curve = newLine;
            //    break;
            //}
            //trans.Commit();
            //return Result.Succeeded;

            //ModelPath modelPath = ModelPathUtils.ConvertUserVisiblePathToModelPath(@"E:\插件问题模型\26.1.28一键替换柱\中海广州亚运城B2项目-土建-B2.rvt");
            //UIDocument newUiDoc = commandData.Application.OpenAndActivateDocument(modelPath,new OpenOptions(),false);
            //commandData.Application.OpenAndActivateDocument(@"E:\插件问题模型\26.1.28一键替换柱\中海广州亚运城B2项目-土建-B2.rvt");
            //return Result.Succeeded;

            //if (!(doc.ActiveView is ViewPlan))
            //{
            //    message = "请在平面运行插件";
            //    return Result.Failed;
            //}
            RevitLinkInstance revitLinkInstance = doc.GetElement(sel.PickObject(ObjectType.LinkedElement, "选择车道边界线所在链接模型")) as RevitLinkInstance;
            Document linkDoc = revitLinkInstance.GetLinkDocument();

            using (FilteredElementCollector linkCol = new FilteredElementCollector(linkDoc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_Floors))
            {
                var linkElems = linkCol.ToList();
                linkElems = linkElems.Where(le => le is Floor linkFloor && linkFloor.FloorType.Name.Contains("车道边界线")).ToList();
                LinkLaneIds = linkElems.Select(le => le.Id).ToList();
            }
            if (LinkLaneIds.Count == 0)
            {
                message = "未找链接模型中的车道边界线";
                return Result.Failed;
            }

            List<FamilyInstance> familyInstances = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).Cast<FamilyInstance>()
                .Where(f => f.Symbol.FamilyName.Contains("车库空心柱-实例参数（中海）")).ToList();

            //TaskDialog.Show("revi", familyInstances.Count.ToString());
            //using (Transaction t = new Transaction(doc, "清空"))
            //{
            //    t.Start();
            //    foreach (var item in familyInstances)
            //    {
            //        item.LookupParameter("宽右下")?.Set(0);
            //        item.LookupParameter("宽右上")?.Set(0);
            //        item.LookupParameter("宽左下")?.Set(0);
            //        item.LookupParameter("宽左上")?.Set(0);
            //    }
            //    t.Commit();
            //}
            //return Result.Succeeded;
            using (TransactionGroup TG = new TransactionGroup(doc, "套柱护角调整"))
            {
                TG.Start();
                foreach (var familyInstance in familyInstances)
                {
                    double halfLength = familyInstance.Symbol.LookupParameter("深度").AsDouble() / 2;
                    double halfWidth = familyInstance.Symbol.LookupParameter("宽度").AsDouble() / 2;

                    XYZ centerPoint = (familyInstance.Location as LocationPoint).Point;
                    centerPoint = new XYZ(centerPoint.X, centerPoint.Y, familyInstance.get_BoundingBox(null).Max.Z);
                    XYZ pointFaceDir = familyInstance.GetTransform().OfVector(XYZ.BasisY.Negate());

                    XYZ dirX = familyInstance.GetTransform().OfVector(XYZ.BasisX);
                    XYZ dirY = familyInstance.GetTransform().OfVector(XYZ.BasisY);
                    XYZ dirXN = familyInstance.GetTransform().OfVector(XYZ.BasisX.Negate());

                    ColumnCornerProtectorAdjustment(doc, linkDoc, familyInstance, centerPoint, pointFaceDir, dirY, dirX, dirXN, halfWidth, halfLength);
                }
                TG.Assimilate();
            }
            TaskDialog.Show("BIMTRANS", "完成");
            return Result.Succeeded;
        }
        private void ColumnCornerProtectorAdjustment(Document doc, Document linkDoc, FamilyInstance familyInstance, XYZ centerPoint, XYZ pointFaceDir, XYZ dirY, XYZ dirX, XYZ dirXN, double halfWidth, double halfLength)
        {
            using (Transaction t = new Transaction(doc, "套柱护角调整"))
            {
                t.Start();

                // 宽右下
                if (IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, dirX, halfWidth, pointFaceDir, halfLength) || IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, pointFaceDir, halfLength, dirX, halfWidth))
                {
                    familyInstance.LookupParameter("宽右下")?.Set(1);
                }
                // 宽右上
                if (IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, dirX, halfWidth, dirY, halfLength) || IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, dirY, halfLength, dirX, halfWidth))
                {
                    familyInstance.LookupParameter("宽右上")?.Set(1);
                }
                // 宽左下
                if (IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, dirXN, halfWidth, pointFaceDir, halfLength) || IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, pointFaceDir, halfLength, dirXN, halfWidth))
                {
                    familyInstance.LookupParameter("宽左下")?.Set(1);
                }
                // 宽左上
                if (IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, dirXN, halfWidth, dirY, halfLength) || IsColumnCornerGuardFacingTheLane(linkDoc, centerPoint, dirY, halfLength, dirXN, halfWidth))
                {
                    familyInstance.LookupParameter("宽左上")?.Set(1);
                }

                t.Commit();
            }
        }

        private bool IsColumnCornerGuardFacingTheLane(Document linkDoc, XYZ point, XYZ verDir, double verLength, XYZ findDir, double addLength/*, double findLength = (1500 / 304.8)*/)
        {
            bool result = false;
            point = point + verDir * verLength;
            double findLength = FindLength;

            LogicalAndFilter andFilter = CreateMixFilter(point, findDir, addLength + findLength, verDir, verLength, 100);
            using (FilteredElementCollector linkCol = new FilteredElementCollector(linkDoc, LinkLaneIds).WherePasses(andFilter))
            {
                if (linkCol.Count() > 0)
                {
                    return true;
                }
            }

            return result;
        }
        private LogicalAndFilter CreateMixFilter(XYZ p, XYZ lengthDir, double length, XYZ widthDir, double width, double height)
        {
            List<ElementFilter> elementFilters = new List<ElementFilter>();

            ElementIntersectsSolidFilter solidFilter = GetSolidFilter(p, lengthDir, length, widthDir, width, out var solid, height);
            elementFilters.Add(solidFilter);
            var box = solid.GetBoundingBox();
            XYZ min = box.Min + p + lengthDir * (length / 2.0);
            var max = box.Max + p + lengthDir * (length / 2.0);

            ////需在事务中进行
            //DirectShape shape = DirectShape.CreateElement(Doc, new ElementId(BuiltInCategory.OST_StructuralFoundation));
            //shape.AppendShape(new List<GeometryObject>() { solid });
            //TaskDialog.Show("revit", min + "\n" + max + "\n" + p +"\n"  + lengthDir + "\n" + length);

            Outline outline = new Outline(min, max);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(outline);
            elementFilters.Add(intersectsFilter);

            return new LogicalAndFilter(elementFilters);
        }
        private ElementIntersectsSolidFilter GetSolidFilter(XYZ p, XYZ lengthDir, double length, XYZ widthDir, double width, out Solid solid, double height = (1000 / 304.8))
        {
            XYZ upDir = XYZ.BasisZ;
            XYZ downP = p - upDir * height;
            XYZ p1 = downP + widthDir * (width / 2);
            XYZ p2 = downP + widthDir * (width / 2) + lengthDir * length;
            XYZ p3 = downP - widthDir * (width / 2) + lengthDir * length;
            XYZ p4 = downP - widthDir * (width / 2);
            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, upDir, height * 2);
            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);

            return solidFilter;
        }
    }
}
