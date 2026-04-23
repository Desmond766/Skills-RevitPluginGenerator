using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConnectConduitByNode
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        FamilySymbol familySymbol = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            TransactionGroup TG2 = new TransactionGroup(doc, "载入族");
            TG2.Start();
            string dllPath = Assembly.GetExecutingAssembly().Location;
            string nodeFamilyPath = dllPath.Replace("ConnectConduitByNode.dll", "品成-拓扑节点.rfa");
            LoadFamily(doc, nodeFamilyPath);
            TG2.Assimilate();

            // 拓扑节点族类型
            familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).WhereElementIsElementType().Where(x => x.Name == "品成-拓扑节点").Cast<FamilySymbol>().FirstOrDefault();
            if (familySymbol == null)
            {
                TaskDialog.Show("Error", "未找到拓扑节点族");
                return Result.Cancelled;
            }

            Conduit conduit1 = doc.GetElement(sel.PickObject(ObjectType.Element, new ConduitFilter(), "选择第一条线管")) as Conduit;
            Conduit conduit2 = doc.GetElement(sel.PickObject(ObjectType.Element, new ConduitFilter(), "选择第二条线管")) as Conduit;
            Line line1 = (conduit1.Location as LocationCurve).Curve as Line;
            Line uLine1 = line1.Clone() as Line;
            uLine1.MakeUnbound();
            Line line2 = (conduit2.Location as LocationCurve).Curve as Line;
            Line uLine2 = line2.Clone() as Line;
            uLine2.MakeUnbound();
            if (uLine1.Intersect(uLine2, out var resultArray) == SetComparisonResult.Overlap)
            {
                using (Transaction t = new Transaction(doc, "延长线管"))
                {
                    t.Start();
                    XYZ point = resultArray.get_Item(0).XYZPoint;
                    int i1 = GetNearPointId(line1, point);
                    if (i1 == 0)
                    {
                        Line newLine1 = Line.CreateBound(point, line1.GetEndPoint(1));
                        (conduit1.Location as LocationCurve).Curve = newLine1;
                    }
                    else
                    {
                        Line newLine1 = Line.CreateBound(line1.GetEndPoint(0), point);
                        (conduit1.Location as LocationCurve).Curve = newLine1;
                    }
                    int i2 = GetNearPointId(line2, point);
                    if (i2 == 0)
                    {
                        Line newLine2 = Line.CreateBound(point, line2.GetEndPoint(1));
                        (conduit2.Location as LocationCurve).Curve = newLine2;
                    }
                    else
                    {
                        Line newLine2 = Line.CreateBound(line2.GetEndPoint(0), point);
                        (conduit2.Location as LocationCurve).Curve = newLine2;
                    }
                    if (!familySymbol.IsActive)
                    {
                        familySymbol.Activate();
                    }
                    FamilyInstance node = doc.Create.NewFamilyInstance(point, familySymbol, StructuralType.NonStructural);

                    t.Commit();
                }
                
            }
            else
            {
                TaskDialog.Show("提示", "所选线管不相交，无法进行延长");
            }

            return Result.Succeeded;
        }

        private int GetNearPointId(Line line, XYZ point)
        {
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            if (p0.DistanceTo(point) > p1.DistanceTo(point))
            {
                return 1;
            }return 0;
        }

        public Family LoadFamily(Document doc, string familyPath)
        {
            Family family = null;
            using (Transaction trans = new Transaction(doc, "载入拓扑族"))
            {
                trans.Start();

                // 尝试载入族文件
                try
                {
                    doc.LoadFamily(familyPath, out family);
                }
                catch (Exception)
                {
                    TaskDialog.Show("Error", "未在指定路径找到拓扑节点族，无法载入");
                }

                trans.Commit();
            }

            return family;
        }
    }
    public class ConduitFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Conduit)
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
