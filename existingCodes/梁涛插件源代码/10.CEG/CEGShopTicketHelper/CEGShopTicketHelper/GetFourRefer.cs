using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class GetFourRefer : IExternalCommand
    {
        UIDocument uIDoc = null;
        Document doc = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;

            //SelectFace:
            //try
            //{
            //    Reference reference = uIDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Face);
            //    Element element = doc.GetElement(reference);
            //    PlanarFace planarFace = element.GetGeometryObjectFromReference(reference) as PlanarFace;
            //    if (doc.ActiveView.UpDirection.Negate().IsAlmostEqualTo(planarFace.FaceNormal))
            //    {
            //        TaskDialog.Show("lp", planarFace.GetFaceCenter().
            //            GetProjectionPoint(doc.ActiveView.UpDirection.Negate()).GetLength().ToString() + "\n" +
            //            planarFace.GetFaceCenter() + "\n" +
            //            planarFace.GetFaceCenter().GetProjectionPoint(doc.ActiveView.UpDirection.Negate()
            //            ) + "\n" + planarFace.FaceNormal);
            //    }
            //}
            //catch (Exception)
            //{
            //    return Result.Succeeded;
            //}
            //goto SelectFace;


            FamilyInstance familyInstance = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming)
                .WhereElementIsNotElementType().Cast<FamilyInstance>().ToList().First();
            Transform transform = familyInstance.GetTransform();
            ElementId tnID = new FilteredElementCollector(doc).OfClass(typeof(TextNoteType))
                .Cast<TextNoteType>().ToList().First().Id;
            GeometryElement geometryElement = familyInstance.get_Geometry(new Options());
            Transaction t = new Transaction(doc, "创建文字注释");
            t.Start();
            //TaskDialog.Show("revit", GetFaces(geometryElement, doc).Count.ToString());
            foreach (PlanarFace item in GetFaces(geometryElement, doc, transform))
            {
                XYZ p = GetFaceCenter(item);
                TextNote textNote = TextNote.Create(doc, doc.ActiveView.Id, p, "aa", tnID);
                uIDoc.Selection.SetElementIds(new ElementId[] { textNote.Id });
            }


            t.Commit();

            return Result.Succeeded;
        }
        private XYZ GetFaceCenter(PlanarFace face)
        {
            // 计算平面面的中心点
            // 获取平面面的边界框
            BoundingBoxUV boundingBox = face.GetBoundingBox();
            UV min = boundingBox.Min;
            UV max = boundingBox.Max;

            // 计算中心点
            UV centerUV = new UV((min.U + max.U) / 2, (min.V + max.V) / 2);
            XYZ center = face.Evaluate(centerUV);

            return center;
        }
        public List<Face> GetFaces(GeometryElement geometryElement, Document doc, Transform transform)
        {
            View currentView = doc.ActiveView;
            List<Face> faces = new List<Face>();
            Solid solid = null;
            foreach (var item in geometryElement)
            {
                if (item is GeometryInstance geometryInstance && geometryInstance.GetSymbolGeometry() != null)
                {
                    GeometryElement geoE = geometryInstance.GetSymbolGeometry();
                    foreach (GeometryObject obj in geoE)
                    {
                        if (obj is Solid solid1 && solid1.Volume > 0)
                        {
                            solid = solid1;
                            break;
                        }
                    }
                }
                else if (item is Solid solid1 && solid1.Volume > 0)
                {
                    solid = solid1;
                    break;
                }
            }
            if (solid == null) return faces;
            solid = SolidUtils.CreateTransformed(solid, transform);
            PlanarFace planarFaceA = GetFace(currentView.UpDirection, solid.Faces);
            if (planarFaceA != null) faces.Add(planarFaceA);
            PlanarFace planarFaceB = GetFace(currentView.UpDirection.Negate(), solid.Faces);
            if (planarFaceB != null) faces.Add(planarFaceB);
            PlanarFace planarFace1 = GetFace(currentView.RightDirection.Negate(), solid.Faces);
            if (planarFace1 != null) faces.Add(planarFace1);
            PlanarFace planarFace2 = GetFace(currentView.RightDirection, solid.Faces);
            if (planarFace2 != null) faces.Add(planarFace2);

            return faces;
        }

        private PlanarFace GetFace(XYZ viewDir, FaceArray faces)
        {
            PlanarFace planarFace = null;
            List<PlanarFace> planarFaces = new List<PlanarFace>();
            foreach (Face face in faces)
            {
                if (face is PlanarFace planarFace1 && planarFace1.FaceNormal.IsAlmostEqualTo(viewDir))
                {
                    planarFaces.Add(planarFace1);
                }
            }
            if (planarFaces.Count == 1) return planarFaces.First();
            if (planarFaces.Count == 0) return planarFace;
            //planarFaces = planarFaces.OrderByDescending(f => f.GetFaceCenter().GetProjectionPoint(viewDir).GetLength()).ToList();
            List<PlanarFace> samePPDirFaces = new List<PlanarFace>();
            List<PlanarFace> nePPDirFaces = new List<PlanarFace>();
            foreach (var item in planarFaces)
            {
                XYZ projectDir = item.GetFaceCenter().GetProjectionPoint(viewDir).Normalize();
                if (viewDir.IsAlmostEqualTo(projectDir))
                {
                    samePPDirFaces.Add(item);
                }
                else if (viewDir.Negate().IsAlmostEqualTo(projectDir))
                {
                    nePPDirFaces.Add(item);
                }
            }
            samePPDirFaces = samePPDirFaces.OrderByDescending(f => f.GetFaceCenter().GetProjectionPoint(viewDir).GetLength()).ToList();
            nePPDirFaces = nePPDirFaces.OrderBy(f => f.GetFaceCenter().GetProjectionPoint(viewDir).GetLength()).ToList();
            if (samePPDirFaces.Count > 0)
            {
                planarFace = samePPDirFaces.First();
            }
            else if (nePPDirFaces.Count > 0)
            {
                planarFace = nePPDirFaces.First();
            }
            return planarFace;
        }
    }
    public static class Extension
    {
        //获取坐标点在向量上的投影点
        public static XYZ GetProjectionPoint(this XYZ point, XYZ direction)
        {
            // 定义点P和向量v
            XYZ pointP = point;
            XYZ vectorV = direction;

            // 计算点P到原点的向量OP
            XYZ vectorOP = pointP;

            // 计算点P在向量v上的投影
            double dotProduct = vectorOP.DotProduct(vectorV);
            double magnitudeSquared = vectorV.DotProduct(vectorV);
            double projectionCoefficient = dotProduct / magnitudeSquared;

            XYZ projection = projectionCoefficient * vectorV;

            return projection;
        }
        public static XYZ GetFaceCenter(this PlanarFace face)
        {
            // 计算平面面的中心点
            // 获取平面面的边界框
            BoundingBoxUV boundingBox = face.GetBoundingBox();
            UV min = boundingBox.Min;
            UV max = boundingBox.Max;

            // 计算中心点
            UV centerUV = new UV((min.U + max.U) / 2, (min.V + max.V) / 2);
            //XYZ center = face.Project(new XYZ(centerUV.U, centerUV.V, 0)).XYZPoint;
            XYZ center = face.Evaluate(centerUV);

            return center;
        }
    }
}
