using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewCreatVerticalCableTray
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));
            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图 ：3D 机电");
                return Result.Cancelled;
            }

            Reference reference;
        SelCableTray:
            try
            {
                reference = sel.PickObject(ObjectType.Element, new CableTrayFilter(), "选择桥架上的一个坐标点");
            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "结束布置");
                return Result.Succeeded;
            }

            CableTray cableTray = reference.GetElement(doc) as CableTray;
            XYZ dir = ((cableTray.Location as LocationCurve).Curve as Line).Direction;
            XYZ point = reference.GlobalPoint;
            ElementId level = cableTray.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsElementId();

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
                Element elem = referenceWithContext.GetReference().GetElement(doc);
                RevitLinkInstance revitLinkInstance = elem as RevitLinkInstance;
                Document linkDoc = revitLinkInstance.GetLinkDocument();
                Floor floor = referenceWithContext.GetReference().LinkedElementId.GetElement(linkDoc) as Floor;
                double height = referenceWithContext.GetReference().GlobalPoint.DistanceTo(point);
                height += floor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble();

                Transaction t = new Transaction(doc, "创建竖向桥架");
                t.Start();
                CableTray newCableTray = CableTray.Create(doc, cableTray.GetTypeId(), point, point + XYZ.BasisZ * height, level);
                newCableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).Set(cableTray.Width);
                newCableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).Set(cableTray.Height);
                Connector con = newCableTray.GetConnector(1);
                XYZ newDir = con.CoordinateSystem.BasisX;
                if (Math.Abs(newDir.AngleTo(dir) - Math.PI / 2) > 0.0001)
                {
                    XYZ verDir = con.CoordinateSystem.BasisY;
                    double angle = verDir.AngleTo(dir);
                    Line newLine = (newCableTray.Location as LocationCurve).Curve as Line;
                    Line line = Line.CreateBound(newLine.GetEndPoint(1), newLine.GetEndPoint(0));
                    ElementTransformUtils.RotateElement(doc, newCableTray.Id, newLine, angle);
                    if (Math.Abs(con.CoordinateSystem.BasisX.AngleTo(dir) - Math.PI / 2) > 0.0001)
                    {
                        ElementTransformUtils.RotateElement(doc, newCableTray.Id, line, angle * 2);
                    }
                }
                t.Commit();
            }
            else
            {
                TaskDialog.Show("提示", "未在指定点上方找到楼板,请重试");
            }

            goto SelCableTray;

            //return Result.Succeeded;

        }
    }
}
