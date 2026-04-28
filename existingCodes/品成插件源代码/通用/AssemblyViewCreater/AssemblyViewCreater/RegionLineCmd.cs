using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyViewCreater
{
    [Transaction(TransactionMode.Manual)]
    class RegionLineCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            Reference reference = sel.PickObject(ObjectType.Element);
            var e = doc.GetElement(reference);
            var bb = e.get_BoundingBox(doc.ActiveView);
            XYZ pt1 = bb.Max;
            XYZ pt2 = bb.Min;
            XYZ ct = (pt1+pt2)/2.0;

            //根据名称找标签族
            var familyName = "CEG-DIAGONAL";
            ElementId familyId = null;

            familyId = Utils.FindTypeIdByFamilyName(doc, familyName);
            FamilySymbol symbol = doc.GetElement(Utils.FindTypeIdByFamilyName(doc, familyName)) as FamilySymbol;
            View view = doc.ActiveView;
            if (!symbol.IsActive)
            {
                symbol.Activate();
            }

            using (Transaction trans = new Transaction(doc))
            {
                trans.Start("RegionLine");
                FamilyInstance familyline = doc.Create.NewFamilyInstance(Line.CreateBound(pt1, pt2), symbol, view);
                ElementTransformUtils.MirrorElement(doc, familyline.Id, Plane.CreateByNormalAndOrigin(XYZ.BasisX, ct));
                //doc.Create.NewDetailCurve(doc.ActiveView, Line.CreateBound(pt1, pt2));
                trans.Commit();
            }

            return Result.Succeeded;
        }
    }




}
