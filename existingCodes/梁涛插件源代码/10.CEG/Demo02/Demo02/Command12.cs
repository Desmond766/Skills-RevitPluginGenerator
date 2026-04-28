using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command12 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            Reference reference = uIDoc.Selection.PickObject(ObjectType.Element, new SpecializedEquipmentFilter(), "Select a steel bar");
            Reference reference1 = uIDoc.Selection.PickObject(ObjectType.Face, "Pick a face");

            UserControl07 userControl07 = new UserControl07();
            userControl07.ShowDialog();
            if (userControl07.cancel)
            {
                return Result.Cancelled;
            }
            double extensionLength = Convert.ToInt32(userControl07.tb.Text) / 304.8;

            FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            FamilyInstance familyInstance1 = doc.GetElement(reference1) as FamilyInstance;

            bool rebar;
            try
            {
                rebar = familyInstance.LookupParameter("DIM_LENGTH").IsReadOnly;
            }
            catch (Exception)
            {
                TaskDialog.Show("tip", "This steel bar does not have the parameter \"DIM_LENGTH\".");
                return Result.Failed;
            }
            if (rebar)
            {
                GeometryObject geometryObject = familyInstance1.GetGeometryObjectFromReference(reference1);
                Face face = geometryObject as Face;
                XYZ point = (familyInstance.Location as LocationPoint).Point;
                Transform transform = familyInstance.GetTransform();
                XYZ dirB = transform.OfVector(XYZ.BasisY).Normalize();
                XYZ dirC = transform.OfVector(XYZ.BasisX).Normalize();
                double distance = face.Project(point).Distance;
                IntersectionResult BResult = face.Project((point + dirB * distance));
                IntersectionResult CResult = face.Project((point + dirC * distance));

                using (Transaction t = new Transaction(doc, "Modify the length of steel bars"))
                {
                    t.Start();
                    if (BResult != null && CResult != null)
                    {
                       bool bc = BResult.Distance < CResult.Distance ? familyInstance.LookupParameter("BAR_LENGTH_B").Set(distance + extensionLength) : familyInstance.LookupParameter("BAR_LENGTH_C").Set(distance + extensionLength);
                    }
                    else if (BResult != null && CResult == null)
                    {
                        familyInstance.LookupParameter("BAR_LENGTH_B").Set(distance + extensionLength);
                    }
                    else if (CResult != null && BResult == null)
                    {
                        familyInstance.LookupParameter("BAR_LENGTH_C").Set(distance + extensionLength);
                    }
                    t.Commit();
                }
            }
            else
            {
                Transform transform = familyInstance.GetTransform();
                XYZ direction = transform.OfVector(XYZ.BasisY.Negate()).Normalize();
                XYZ startPoint = (familyInstance.Location as LocationPoint).Point;
                XYZ endPoint = startPoint + direction * familyInstance.LookupParameter("DIM_LENGTH").AsDouble();
                GeometryObject geometryObject = familyInstance1.GetGeometryObjectFromReference(reference1);
                PlanarFace face = geometryObject as PlanarFace;

                XYZ faceP = face.Origin;
                //Transform transform1 = null;
                //Options options = new Options();
                //options.ComputeReferences = true;
                //GeometryElement geometryElement = familyInstance1.get_Geometry(options);
                //foreach (var item in geometryElement)
                //{
                //    if (item is GeometryInstance geometryInstance)
                //    {
                //        transform1 = geometryInstance.Transform;
                //    }
                //}
                ////faceP = transform1.OfPoint(faceP);
                //double distance = startPoint.DistanceTo(faceP);
                //double distance2 = endPoint.DistanceTo(faceP);
                double distance = face.Project(startPoint).Distance;
                double distance2 = face.Project(endPoint).Distance;

                using (Transaction t = new Transaction(doc, "Modify the length of steel bars"))
                {
                    t.Start();
                    if (distance > distance2)
                    {
                        familyInstance.LookupParameter("DIM_LENGTH").Set(distance + extensionLength);
                    }
                    //doc.Create.NewFamilyInstance(faceP, familyInstance.Symbol, Autodesk.Revit.DB.Structure.StructuralType.NonStructural);
                    if (distance2 > distance)
                    {
                        familyInstance.LookupParameter("DIM_LENGTH").Set(distance2 + extensionLength);
                        //ElementTransformUtils.MoveElement(doc, familyInstance.Id, direction * extensionLength);
                        ElementTransformUtils.MoveElement(doc, familyInstance.Id, direction * (distance - extensionLength));
                    }
                    t.Commit();
                }
            }





            return Result.Succeeded;
        }
    }
}
