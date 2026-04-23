using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace AlignmentOfPipelineBends
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            listenUtils.startListen();

        Next:
            List<Reference> references;
            Reference mainRe;
            Reference pipeLineRe;
            try
            {
                references = sel.PickObjects(ObjectType.Element, new FittingFilter(), "框选需要对齐的管线弯头（按空格键完成框选，ESC键取消）").ToList();
                mainRe = sel.PickObject(ObjectType.Element, new FittingFilter(), "选择一个弯头作为对齐点（按空格键完成框选，ESC键取消）");
                //pipeLineRe = sel.PickObject(ObjectType.Element, new MepFilter(), "选择一条管线作为对齐的方向");
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                TaskDialog.Show("提示", "已完成对齐");
                return Result.Succeeded;
            }

            List<FamilyInstance> familyInstances = references.Select(r => doc.GetElement(r)).Cast<FamilyInstance>().ToList();
            FamilyInstance mainInstance = doc.GetElement(mainRe) as FamilyInstance;

            bool isVer = false; // 判断是否翻弯（升降）
            List<Connector> cons = mainInstance.MEPModel.ConnectorManager.Connectors.Cast<Connector>().ToList();
            if (cons.Count == 2)
            {
                if (Math.Abs(cons[0].Origin.Z - cons[1].Origin.Z) > 0.0001) isVer = true;
            }

            Line line;
            if (isVer)
            {
                XYZ p0 = cons[0].Origin;
                p0 = new XYZ(p0.X, p0.Y, 0);
                XYZ p1 = cons[1].Origin;
                p1 = new XYZ(p1.X, p1.Y, 0);
                line = Line.CreateBound(p0, p1);
            }
            else
            {
                try
                {
                    pipeLineRe = sel.PickObject(ObjectType.Element, new MepFilter(), "选择一条管线作为对齐的方向");
                    line = (doc.GetElement(pipeLineRe).Location as LocationCurve).Curve as Line;
                }
                catch (Exception)
                {
                    TaskDialog.Show("提示", "已完成对齐");
                    return Result.Succeeded;
                }
            }

            line.MakeUnbound();
            XYZ mainPoint = line.Project((mainInstance.Location as LocationPoint).Point).XYZPoint;
            using (Transaction t = new Transaction(doc, "管线弯通对齐"))
            {
                t.Start();

                foreach (var elem in familyInstances)
                {
                    XYZ point = (elem.Location as LocationPoint).Point;
                    XYZ pp = line.Project(point).XYZPoint;
                    double dis = pp.DistanceTo(mainPoint);
                    XYZ moveDir = (mainPoint - pp).Normalize();

                    ElementTransformUtils.MoveElement(doc, elem.Id, moveDir * dis);
                }

                t.Commit();
            }

            goto Next;


            return Result.Succeeded;
        }
    }
    public class FittingFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeFitting || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTrayFitting
                || elem.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctFitting)
            {
                if (elem.Location != null && elem.Location is LocationPoint) return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
    public class MepFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is MEPCurve && elem.Location != null && elem.Location is LocationCurve locationCurve && locationCurve.Curve is Line)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
