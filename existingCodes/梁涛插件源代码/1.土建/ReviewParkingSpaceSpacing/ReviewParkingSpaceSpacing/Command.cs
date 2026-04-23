using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace ReviewParkingSpaceSpacing
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;

            MainWindow window = new MainWindow();
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(window);
            windowInteropHelper.Owner = intPtr;
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            Document linkDoc = null;

            if (window.ElementInLink)
            {
                Reference linkReference;
                try
                {
                    linkReference = sel.PickObject(ObjectType.LinkedElement, "选择链接墙、柱所在链接模型");
                }
                catch (OperationCanceledException)
                {
                    TaskDialog.Show("BIMTRANS", "已取消操作");
                    return Result.Cancelled;
                }
                RevitLinkInstance linkInstance = doc.GetElement(linkReference) as RevitLinkInstance;
                linkDoc = linkInstance.GetLinkDocument();
            }
            Document linkOrLocalDoc = linkDoc ?? doc;

            List<ParkingSpaceInfo> infos = new List<ParkingSpaceInfo>();

            // 获取视图中所有停车位
            List<FamilyInstance> parkingSpaces = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).OfClass(typeof(FamilyInstance))
                .Cast<FamilyInstance>().Where(f => f.Symbol.FamilyName.Contains("停车位")).ToList();

            foreach (var ps in parkingSpaces)
            {
                Transform transform = ps.GetTransform();
                XYZ point = (ps.Location as LocationPoint).Point;
                XYZ xDir = transform.OfVector(XYZ.BasisX);
                XYZ yDir = transform.OfVector(XYZ.BasisY);
                double width = ps.Symbol.LookupParameter("车位宽").AsDouble();
                double length = ps.Symbol.LookupParameter("车位长").AsDouble();
                // UPDATE:26.2.5新增1mm误差
                double halfWidth = (width / 2) + (299 / 304.8);
                double halfLength = (length / 2) - (1500 / 304.8);
                //halfLength = length;
                var solidFilter = CreateSolidFilter(point, halfWidth, halfLength, xDir, yDir);

                XYZ min = ps.get_BoundingBox(null).Min;
                XYZ max = ps.get_BoundingBox(null).Max;
                min = min - XYZ.BasisX * (1000 / 304.8) - XYZ.BasisY * (1000 / 304.8);
                max = max + XYZ.BasisX * (1000 / 304.8) + XYZ.BasisY * (1000 / 304.8);
                var boxFilter = new BoundingBoxIntersectsFilter(new Outline(min, max));
                var orFilter = new LogicalOrFilter(new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns), new ElementCategoryFilter(BuiltInCategory.OST_Walls));


                using (FilteredElementCollector columnAndWallCol = new FilteredElementCollector(linkOrLocalDoc).WherePasses(orFilter))
                {
                    columnAndWallCol.WherePasses(boxFilter).WherePasses(solidFilter);

                    var filterElems = columnAndWallCol.ToList();
                    filterElems = filterElems.Where(e => !GetFamilyName(e).Contains("停车位")).ToList();
                    if (filterElems.Count > 0)
                    {
                        infos.Add(new ParkingSpaceInfo() { Id = ps.Id, Name = ps.Name, Point = point });
                    }

                    //// 测试用
                    //if (ps.Id.IntegerValue == 5771008 && false)
                    //{

                    //    //TaskDialog.Show("revit", linkElems.Count().ToString());
                    //    //int c = linkCol.Count();
                    //    //TaskDialog.Show("revit", c.ToString());
                    //    //TaskDialog.Show("revit", c.ToString());
                    //    //TODO:26.1.21不加tolist会报错
                    //    var elems = columnAndWallCol.GetEnumerator();
                    //    while (elems.MoveNext())
                    //    {
                    //        TaskDialog.Show("revit2", elems.Current.Id + "\n" + elems.Current.Category.Name);
                    //    }
                    //    foreach (var item in columnAndWallCol)
                    //    //foreach (var item in linkCol.ToList())
                    //    //foreach (var item in linkElems)
                    //    {
                    //        //TaskDialog.Show("revit", item.Id + "\n" + item.Category.Name + "\n" + linkElems.Count());
                    //        TaskDialog.Show("revit", item.Id + "\n" + item.Category.Name);
                    //        //TaskDialog.Show("revit", linkCol.ToList().Count().ToString());
                    //    }
                    //    break;
                    //}
                }
            }

            ResultWPF resultWPF = new ResultWPF(uidoc, infos);
            resultWPF.Title = "(" + infos.Count + "/" + parkingSpaces.Count + ")" + resultWPF.Title;
            WindowInteropHelper windowInteropHelper2 = new WindowInteropHelper(resultWPF);
            windowInteropHelper2.Owner = intPtr;
            resultWPF.Show();

            return Result.Succeeded;
        }
        private string GetFamilyName(Element element)
        {
            string result = null;
            if (element is FamilyInstance familyInstance && element.Category.Id.IntegerValue == -2001330)
            {
                result = familyInstance.Symbol.FamilyName;
            }
            else if (element is Wall wall)
            {
                result = wall.WallType.FamilyName;
            }
            return result;
        }
        private ElementIntersectsSolidFilter CreateSolidFilter(XYZ point, double halfWidth, double halfLength, XYZ xDir, XYZ yDir)
        {
            XYZ p1 = point - xDir * halfWidth - yDir * halfLength;
            XYZ p2 = point + xDir * halfWidth - yDir * halfLength;
            XYZ p3 = point + xDir * halfWidth + yDir * halfLength;
            XYZ p4 = point - xDir * halfWidth + yDir * halfLength;
            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, XYZ.BasisZ, 2000 / 304.8);
            ElementIntersectsSolidFilter filter = new ElementIntersectsSolidFilter(solid);

            return filter;
        }
    }
    public class ParkingSpaceInfo
    {
        public ElementId Id { get; set; }
        public string Name { get; set; }
        public XYZ Point { get; set; }
    }
}
