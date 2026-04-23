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

namespace CreateFakeConnectBridge
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            Reference refer1;
            Reference refer2;
            try
            {
                refer1 = sel.PickObject(ObjectType.Element, new CabletrayFilter(), "选择第一条桥架");
                refer2 = sel.PickObject(ObjectType.Element, new CabletrayFilter(), "选择第二条桥架");
            }
            catch (Exception)
            {
                TaskDialog.Show("Revit", "结束布置");
                return Result.Succeeded;
            }

            Element elem1 = doc.GetElement(refer1);
            Element elem2 = doc.GetElement(refer2);
            var points1 = (elem1.Location as LocationCurve).Curve.Tessellate();
            var points2 = (elem2.Location as LocationCurve).Curve.Tessellate();

            double minValue = double.MaxValue;
            XYZ point1 = XYZ.Zero;
            XYZ point2 = XYZ.Zero;

            foreach (var p1 in points1)
            {
                foreach (var p2 in points2)
                {
                    if (p1.DistanceTo(p2) < minValue)
                    {
                        point1 = p1;
                        point2 = p2;
                        minValue = p1.DistanceTo(p2);
                    }
                }
            }
            using (Transaction t = new Transaction(doc, "生成连接桥架"))
            {
                t.Start();
                var id = ElementTransformUtils.CopyElement(doc, elem1.Id, new XYZ()).First();
                Element newElem = doc.GetElement(id);
                Line line = Line.CreateBound(point1, point2);
                (newElem.Location as LocationCurve).Curve = line;
                t.Commit();
            }


            return Result.Succeeded;
        }
    }

    public class CabletrayFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is CableTray)
            {
                return true;
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
