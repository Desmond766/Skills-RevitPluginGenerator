using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Line = Autodesk.Revit.DB.Line;

//板块标注或者基础埋件标注
namespace Demo02
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            IList<Reference> references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, "Frame selection of embedded parts");
            Reference reference2 = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "Select the embedded parts to be marked");
            List<Reference> references1 = new List<Reference>();
            foreach (Reference item in references)
            {
                FamilyInstance familyInstance = doc.GetElement(item) as FamilyInstance;
                FamilyInstance familyInstance2 = doc.GetElement(reference2) as FamilyInstance;
                if (familyInstance != null && familyInstance.Name.Equals(familyInstance2.Name))
                {
                    references1.Add(item);
                }
                if (doc.GetElement(item) is Grid)
                {
                    references1.Add(item);
                }
            }
            // 在立面视图上创建与当前视图平行的工作平面
            using (Transaction transaction = new Transaction(doc, "Create Sketch Plane"))
            {
                transaction.Start();

                // 获取当前视图的方向
                XYZ viewDirection = uIDoc.ActiveView.ViewDirection;

                // 创建平面的位置（这里假设在Z轴方向上移动10个单位）
                XYZ planeLocation = new XYZ(0, 0, 10);

                // 创建平面
                Plane plane = Plane.CreateByNormalAndOrigin(viewDirection, planeLocation);

                // 在文档中创建平面
                SketchPlane sketchPlane = SketchPlane.Create(doc, plane);

                // 将新创建的平面设置为当前视图的工作平面
                uIDoc.ActiveView.SketchPlane = sketchPlane;

                transaction.Commit();
            }


            XYZ point = uIDoc.Selection.PickPoint("Select the location to place the annotation");
            ReferenceArray referenceArray = new ReferenceArray();
            XYZ p1 = null;
            XYZ p2 = null;
            int count = 0;
            foreach (Reference reference in references1)
            {
                if (doc.GetElement(reference) is FamilyInstance)
                {
                    count++;
                    FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
                    if (p1 == null && count == 1)
                    {
                        p1 = (familyInstance.Location as LocationPoint).Point;
                    }
                    if (p2 == null && count == 2)
                    {
                        p2 = (familyInstance.Location as LocationPoint).Point;
                    }
                }
                if (count > 2 )
                {
                    break;
                }
            }
            foreach (Reference reference in references1)
            {
                Reference reference1 = null;
                if (doc.GetElement(reference) is FamilyInstance)
                {
                    FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
                    if (XYZ.BasisX.IsAlmostEqualTo((p1 - p2).Normalize()) || XYZ.BasisX.Negate().IsAlmostEqualTo((p1 - p2).Normalize()) ||
                        XYZ.BasisY.IsAlmostEqualTo((p1 - p2).Normalize()) || XYZ.BasisY.Negate().IsAlmostEqualTo((p1 - p2).Normalize()))
                    {
                        reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                    }
                    if (XYZ.BasisZ.IsAlmostEqualTo((p1 - p2).Normalize()) || XYZ.BasisZ.Negate().IsAlmostEqualTo((p1 - p2).Normalize()))
                    {
                        reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                    }
                    referenceArray.Append(reference1);
                }
                if (doc.GetElement(reference) is Grid)
                {
                    referenceArray.Append(reference);
                }
            }
            //XYZ point = p1;
            Line line = null;
            if (XYZ.BasisX.IsAlmostEqualTo((p1 - p2).Normalize()) || XYZ.BasisX.Negate().IsAlmostEqualTo((p1 - p2).Normalize()))
            {
                line = Line.CreateBound(new XYZ(p1.X, point.Y, point.Z), new XYZ(p2.X, point.Y, point.Z));
            }
            if (XYZ.BasisY.IsAlmostEqualTo((p1 - p2).Normalize()) || XYZ.BasisY.Negate().IsAlmostEqualTo((p1 - p2).Normalize()))
            {
                line = Line.CreateBound(new XYZ(point.X, p1.Y, point.Z), new XYZ(point.X, p2.Y, point.Z));
            }
            if (XYZ.BasisZ.IsAlmostEqualTo((p1 - p2).Normalize()) || XYZ.BasisZ.Negate().IsAlmostEqualTo((p1 - p2).Normalize()))
            {
                line = Line.CreateBound(new XYZ(point.X, point.Y, p1.Z), new XYZ(point.X, point.Y, p2.Z));
            }
            using (Transaction t = new Transaction(doc, "Create Dimensions"))
            {
                t.Start();
                doc.Create.NewDimension(uIDoc.ActiveView, line, referenceArray);
                t.Commit();
            }


            return Result.Succeeded;
        }
    }
}
