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
    public class CamberLineCmd : IExternalCommand
    {
        double camber = 3/12.0;
        string gsName = "#3 RED - WINDOWS";
        Result IExternalCommand.Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //Reference edgeRef = sel.PickObject(ObjectType.Edge);
            //Edge edge = doc.GetElement(edgeRef).GetGeometryObjectFromReference(edgeRef) as Edge;
            //Curve curve = edge.AsCurve();

            //XYZ pt1 = curve.GetEndPoint(0);
            //XYZ pt2 = curve.GetEndPoint(1);

            CamberLineFrm frm = new CamberLineFrm();
            if (System.Windows.Forms.DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            camber = frm.camber;
            gsName = frm.gsName;

            GraphicsStyle gs = GetGraphicsStyle(doc, gsName);

            if(null == gs)
            {
                TaskDialog.Show("r", "can't find target graphicsStyle, will use default one");
            }

            using (Transaction trans = new Transaction(doc))
            {
                trans.Start("creatCamberLine");

                SetWorkingPlane(doc);

                XYZ pt1 = null;
                XYZ pt2 = null;
                try
                {
                    pt1 = sel.PickPoint();
                    pt2 = sel.PickPoint();
                }
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        return Result.Cancelled;
                    }
                    else
                    {
                        TaskDialog.Show("Revit",
                        ex.Message + "\n" + ex.StackTrace.ToString());
                        return Result.Cancelled;
                    }
                }
                if (Math.Abs(pt1.X - pt2.X) > 0.0001)
                {
                    message = "Can't work in this view!, plese switch to elevation view West/East";
                    return Result.Cancelled;
                }

                pt2 = new XYZ(pt1.X, pt2.Y, pt2.Z);

                XYZ midPt = (pt2 + pt1) / 2;
                XYZ pt3 = new XYZ(midPt.X, midPt.Y, midPt.Z + camber);

                pt3 = new XYZ(pt1.X, pt3.Y, pt3.Z);

                Arc arc = Arc.Create(pt1, pt2, pt3);
                DetailCurve c1 = doc.Create.NewDetailCurve(doc.ActiveView, arc);
                DetailCurve c2 = doc.Create.NewDetailCurve(doc.ActiveView, Line.CreateBound(midPt, pt3));
                if (gs != null)
                {
                    c1.get_Parameter(BuiltInParameter.BUILDING_CURVE_GSTYLE).Set(gs.Id);
                    c2.get_Parameter(BuiltInParameter.BUILDING_CURVE_GSTYLE).Set(gs.Id);
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

        private void SetWorkingPlane(Document doc)
        {
            Plane plane =Plane.CreateByNormalAndOrigin(
                doc.ActiveView.ViewDirection,
                doc.ActiveView.Origin);
            SketchPlane sp = SketchPlane.Create(doc, plane);
            doc.ActiveView.SketchPlane = sp;
        }
    }
}
