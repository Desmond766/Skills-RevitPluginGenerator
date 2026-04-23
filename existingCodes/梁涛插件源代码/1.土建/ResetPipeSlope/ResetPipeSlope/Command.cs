using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitTemplate1.Https;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

// 批量重置管道坡度（变为0）
namespace ResetPipeSlope
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            HttpHelper.SendLog(doc.Title, "重置管道坡度", 129, 1);
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();

        Next:

            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                references = sel.PickObjects(ObjectType.Element, new PipeAndConduitFilter(), "框选要重置的管道/线管(空格完成选择 ESC结束)");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Succeeded;
            }

            try
            {
                using (Transaction t = new Transaction(doc, "批量重置管道坡度"))
                {
                    t.Start();
                    foreach (var refer in references)
                    {
                        Element element = doc.GetElement(refer);
                        Curve elemCurve = (element.Location as LocationCurve).Curve;
                        XYZ newEnd0 = elemCurve.GetEndPoint(0);
                        XYZ newEnd1 = elemCurve.GetEndPoint(1);
                        newEnd1 = new XYZ(newEnd1.X, newEnd1.Y, newEnd0.Z);
                        Curve newCurve = Line.CreateBound(newEnd0, newEnd1);
                        (element.Location as LocationCurve).Curve = newCurve;
                    }
                    t.Commit();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //return Result.Succeeded;
            }
            

            goto Next;
        }
    }
    public class PipeAndConduitFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Pipe || elem is Conduit)
            {
                Curve curve = (elem.Location as LocationCurve).Curve;
                XYZ e0 = curve.GetEndPoint(0);
                XYZ e1 = curve.GetEndPoint(1);
                e0 = new XYZ(e0.X, e0.Y, 0);
                e1 = new XYZ(e1.X, e1.Y, 0);
                if (e0.DistanceTo(e1) > 0.001)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
