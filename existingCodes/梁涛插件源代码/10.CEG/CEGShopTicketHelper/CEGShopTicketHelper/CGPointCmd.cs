using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class CGPointCmd : IExternalCommand
    {
        string gsName = "#3 RED - WINDOWS";
        //string cgFamilyName = "CG SYMBOL GENERIC";
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            if (doc.ActiveView is View3D)
            {
                message = "please run in plan/elevation view!";
                return Result.Cancelled;
            }

            Reference reference = sel.PickObject(ObjectType.Element,
                new StructuralFramingFilter(),
                "select a structural framing to calculate CG point");
            Element elem = doc.GetElement(reference);
            GraphicsStyle myStyle = GetGraphicsStyle(doc, gsName);

            using (Transaction trans = new Transaction(doc, "1"))
            {
                trans.Start();
                List<Solid> solids = Utils.GetElementInstanceSolids(elem);
                if (solids.Count > 0)
                {
                    XYZ centeroid = solids[0].ComputeCentroid();

                    //create modelline in 3d view
                    XYZ pt1 = centeroid + XYZ.BasisX / 6.0;
                    XYZ pt2 = centeroid - XYZ.BasisX / 6.0;
                    XYZ pt3 = centeroid + XYZ.BasisY / 6.0;
                    XYZ pt4 = centeroid - XYZ.BasisY / 6.0;
                    XYZ pt5 = centeroid + XYZ.BasisZ / 6.0;
                    XYZ pt6 = centeroid - XYZ.BasisZ / 6.0;
                    var c1= Utils.CreateModelLine(doc, pt1, pt2);
                    var c2 = Utils.CreateModelLine(doc, pt3, pt4);
                    var c3 = Utils.CreateModelLine(doc, pt5, pt6);
                    if (null != myStyle)
                    {
                        c1.LineStyle = myStyle;
                        c2.LineStyle = myStyle;
                        c3.LineStyle = myStyle;
                    }

                    //create detail line in active view
                    XYZ pt7 = centeroid + doc.ActiveView.UpDirection / 6.0;
                    XYZ pt8 = centeroid - doc.ActiveView.UpDirection / 6.0;
                    XYZ pt9 = centeroid + doc.ActiveView.RightDirection / 6.0;
                    XYZ pt10 = centeroid - doc.ActiveView.RightDirection / 6.0;
                    Line line1 = Line.CreateBound(pt7, pt8);
                    Line line2 = Line.CreateBound(pt9, pt10);
                    var dc1 = doc.Create.NewDetailCurve(doc.ActiveView, line1);
                    var dc2 = doc.Create.NewDetailCurve(doc.ActiveView, line2);
                    if (null != myStyle)
                    {
                        dc1.LineStyle = myStyle;
                        dc2.LineStyle = myStyle;
                    }
                }
                else
                {
                    message = "not supported!";
                    return Result.Cancelled;
                }

                trans.Commit();

            }

            return Result.Succeeded;
        }

        private GraphicsStyle GetGraphicsStyle(Document doc, string name)
        {
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            var result1 = collector.OfClass(typeof(GraphicsStyle)).ToElements();
            if (result1.Count == 0)
            {
                return null;
            }
            var result2 = result1.Where(u => u.Name == name);
            if (result2.Count() == 0)
            {
                return null;
            }
            return result2.First() as GraphicsStyle;
        }
    }

    internal class StructuralFramingFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            return (elem is FamilyInstance)
                && elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return true;
        }
    }
}
