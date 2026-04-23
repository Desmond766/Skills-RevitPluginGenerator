using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document = Autodesk.Revit.DB.Document;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CreateDimensions
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        UIDocument uIDoc = null;
        Document doc = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            IList<Reference> references;
            IList<Reference> linkedReference;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new HangerFilter(), "框选要标注的吊架（按空格键完成框选，ESC键取消）");
                listenUtils.startListen();
                linkedReference = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.LinkedElement, new LinkedBeamWallFilter(), "选择梁、墙或柱（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<FamilyInstance> hangers = references.Select(r => doc.GetElement(r) as FamilyInstance).ToList();

            ReferenceArray referenceArray = new ReferenceArray();
            //XYZ p1 = null;
            //XYZ p2 = null;
            //int count = 0;
            //foreach (Reference reference in references)
            //{
            //    string name = null;
            //    if (name == null)
            //    {
            //        name = doc.GetElement(reference).Name;
            //    }
            //    if (doc.GetElement(reference).Name.Equals(name))
            //    {
            //        count++;
            //    }
            //    FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            //    if (p1 == null && count == 1)
            //    {
            //        p1 = (familyInstance.Location as LocationPoint).Point;
            //    }
            //    if (p2 == null && count == 2)
            //    {
            //        p2 = (familyInstance.Location as LocationPoint).Point;
            //    }
            //    if (count > 2)
            //    {
            //        break;
            //    }
            //}
            FamilyInstance firstHanger = doc.GetElement(references.First()) as FamilyInstance;
            XYZ hangerP = (firstHanger.Location as LocationPoint).Point;
            double pZ = (firstHanger.Location as LocationPoint).Point.Z;

            TransactionGroup group = new TransactionGroup(doc, "吊架间创建尺寸标注");
            group.Start();
            using (Transaction t = new Transaction(doc, "创建模型线"))
            {
                t.Start();
                foreach (Reference reference in linkedReference)
                {
                    RevitLinkInstance revitLinkInstance = doc.GetElement(reference.ElementId) as RevitLinkInstance;
                    Transform transform = revitLinkInstance.GetTransform();
                    Document linkDoc = revitLinkInstance.GetLinkDocument();
                    Element wallOrBeam = linkDoc.GetElement(reference.LinkedElementId);
                    ElementType elementType = linkDoc.GetElement(wallOrBeam.GetTypeId()) as ElementType;

                    //double width = elementType.LookupParameter("b")?.AsDouble() ?? elementType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble();

                    if (wallOrBeam.Category.Id.IntegerValue == -2001330)
                    {
                        if (references.Count >= 2)
                        {
                            FamilyInstance familyInstance1 = doc.GetElement(references.First()) as FamilyInstance;
                            FamilyInstance familyInstance2 = doc.GetElement(references.Last()) as FamilyInstance;
                            XYZ p1 = (familyInstance1.Location as LocationPoint).Point;
                            XYZ p2 = (familyInstance2.Location as LocationPoint).Point;
                            //p1 = transform.OfPoint(p1);
                            //p2 = transform.OfPoint(p2);
                            Transform transform1 = familyInstance1.GetTransform();
                            XYZ hangerDir = transform1.OfVector(XYZ.BasisX);
                            XYZ direction = (p1 - p2).Normalize();
                            //XYZ vertical1 = p1.CrossProduct(p2);
                            //XYZ verticalVector = new XYZ(vertical1.X, vertical1.Y, pZ).Normalize();
                            XYZ verticalVector = GetPerpendicularVector(direction);
                            Element column = linkDoc.GetElement(reference.LinkedElementId);
                            XYZ colCPoint = (column.Location as LocationPoint).Point;
                            colCPoint = transform.OfPoint(colCPoint);
                            // 长度边方向
                            XYZ colLnegthDir = transform.OfVector(XYZ.BasisY);
                            XYZ colWidthDir = transform.OfVector(XYZ.BasisX);

                            if (colLnegthDir.IsAlmostEqualTo(direction) || colLnegthDir.IsAlmostEqualTo(direction.Negate()))
                            {
                                double halfLength = elementType.LookupParameter("长度").AsDouble() / 2.0;
                                XYZ sidePoint1 = colCPoint - colLnegthDir * halfLength;
                                XYZ sidePoint2 = colCPoint + colLnegthDir * halfLength;
                                colCPoint = sidePoint1.DistanceTo(p1) < sidePoint2.DistanceTo(p1) ? sidePoint1 : sidePoint2;
                            }
                            else if (colWidthDir.IsAlmostEqualTo(direction) || colWidthDir.IsAlmostEqualTo(direction.Negate()))
                            {
                                double halfWidth = elementType.LookupParameter("宽度").AsDouble() / 2.0;
                                XYZ sidePoint1 = colCPoint - colWidthDir * halfWidth;
                                XYZ sidePoint2 = colCPoint + colWidthDir * halfWidth;
                                colCPoint = sidePoint1.DistanceTo(p1) < sidePoint2.DistanceTo(p1) ? sidePoint1 : sidePoint2;
                            }
                            
                            
                            if (direction.IsAlmostEqualTo(hangerDir) || direction.IsAlmostEqualTo(hangerDir.Negate()))
                            {
                                //TaskDialog.Show("ss", "111");
                                Line modelLine = Line.CreateBound(colCPoint - verticalVector, colCPoint + verticalVector);
                                Plane plane = Plane.CreateByNormalAndOrigin(direction, colCPoint);
                                SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                                ModelCurve modelCurve = doc.Create.NewModelCurve(modelLine, sketchPlane);
                                referenceArray.Append(new Reference(modelCurve));
                            }
                            else if (verticalVector.IsAlmostEqualTo(hangerDir) || verticalVector.IsAlmostEqualTo(hangerDir.Negate()))
                            {
                                //TaskDialog.Show("ss", "222");
                                Line modelLine = Line.CreateBound(colCPoint - verticalVector, colCPoint + verticalVector);
                                Plane plane = Plane.CreateByNormalAndOrigin(direction, colCPoint);
                                SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                                ModelCurve modelCurve = doc.Create.NewModelCurve(modelLine, sketchPlane);
                                referenceArray.Append(new Reference(modelCurve));
                            }

                        }
                    }
                    else
                    {
                        double halfWidth = (elementType.LookupParameter("b")?.AsDouble() ?? elementType.get_Parameter(BuiltInParameter.WALL_ATTR_WIDTH_PARAM).AsDouble()) / 2.0;

                        Line line1 = (wallOrBeam.Location as LocationCurve).Curve as Line;
                        XYZ p11 = line1.GetEndPoint(0);
                        p11 = transform.OfPoint(p11);
                        XYZ p22 = line1.GetEndPoint(1);
                        p22 = transform.OfPoint(p22);
                        
                        XYZ direction = (p11 - p22).Normalize();
                        XYZ verDir = direction.CrossProduct(XYZ.BasisZ).Normalize();

                        XYZ sidePoint1 = p11 - verDir * halfWidth;
                        XYZ sidePoint2 = p11 + verDir * halfWidth;
                        if (sidePoint1.DistanceTo(hangerP) < sidePoint2.DistanceTo(hangerP))
                        {
                            p11 = sidePoint1;
                            p22 = p22 - verDir * halfWidth;
                        }
                        else
                        {
                            p11 = sidePoint2;
                            p22 = p22 + verDir * halfWidth;
                        }
                        Line modelLine = Line.CreateBound(new XYZ(p11.X, p11.Y, pZ), new XYZ(p22.X, p22.Y, pZ));

                        Plane plane = null;
                        if (direction.IsAlmostEqualTo(XYZ.BasisX) || direction.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                        {
                            plane = Plane.CreateByNormalAndOrigin(new XYZ(0, 1, 0), new XYZ(p11.X, p11.Y, pZ));
                        }
                        else if (direction.IsAlmostEqualTo(XYZ.BasisY) || direction.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                        {
                            plane = Plane.CreateByNormalAndOrigin(new XYZ(1, 0, 0), new XYZ(p11.X, p11.Y, pZ));
                        }
                        else
                        {
                            plane = Plane.CreateByThreePoints(p11, p22, p11.Add(p22) / 2 + XYZ.BasisZ);
                        }
                        SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                        ModelCurve modelCurve = doc.Create.NewModelCurve(modelLine, sketchPlane);
                        referenceArray.Append(new Reference(modelCurve));
                    }
                }
                t.Commit();
            }
            Line line = null;
            XYZ point = uIDoc.Selection.PickPoint("选择要放置的位置");
            bool first = true;
            foreach (Reference reference in references)
            {
                Reference reference1 = null;
                FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
                XYZ familyPoint = (familyInstance.Location as LocationPoint).Point;
                double radian = (familyInstance.Location as LocationPoint).Rotation;
                int angle = (int)Math.Round(180 / Math.PI * radian);
                //判断吊架的旋转角度
                if (angle == 0 || angle == 180 || angle == 360)
                {
                    int count = 0;
                    XYZ p1 = null;
                    XYZ p2 = null;
                    //获取选中吊架中任意两个吊架创建点形成的直线的方向
                    foreach (Reference item in references)
                    {
                        count++;
                        FamilyInstance familyInstance2 = doc.GetElement(item) as FamilyInstance;
                        if (p1 == null && count == 1)
                        {
                            p1 = (familyInstance2.Location as LocationPoint).Point;
                        }
                        if (p2 == null && count == 2)
                        {
                            p2 = (familyInstance2.Location as LocationPoint).Point;
                        }
                        if (count == 2)
                        {
                            break;
                        }
                    }
                    if (count > 1)
                    {
                        XYZ direction = (p1 - p2).Normalize();
                        if (direction.IsAlmostEqualTo(XYZ.BasisX) || direction.IsAlmostEqualTo(XYZ.BasisX.Negate()))
                        {
                            if (line == null)
                            {
                                line = Line.CreateBound(new XYZ(familyPoint.X, point.Y, familyPoint.Z), new XYZ(familyPoint.X + 1, point.Y, familyPoint.Z));
                            }
                            reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First();
                            referenceArray.Append(reference1);
                        }
                        else
                        {
                            if (line == null)
                            {
                                line = Line.CreateBound(new XYZ(point.X, familyPoint.Y, familyPoint.Z), new XYZ(point.X, familyPoint.Y + 1, familyPoint.Z));
                            }
                            reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                            referenceArray.Append(reference1);
                        }
                    }
                    else
                    {
                        if (line == null)
                        {
                            line = Line.CreateBound(new XYZ(point.X, familyPoint.Y, familyPoint.Z), new XYZ(point.X, familyPoint.Y + 1, familyPoint.Z));
                        }
                        reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                        referenceArray.Append(reference1);
                    }

                }
                else if (angle == 90 || angle == 270)
                {
                    int count = 0;
                    XYZ p1 = null;
                    XYZ p2 = null;
                    foreach (Reference item in references)
                    {
                        count++;
                        FamilyInstance familyInstance2 = doc.GetElement(item) as FamilyInstance;
                        if (p1 == null && count == 1)
                        {
                            p1 = (familyInstance2.Location as LocationPoint).Point;
                        }
                        if (p2 == null && count == 2)
                        {
                            p2 = (familyInstance2.Location as LocationPoint).Point;
                        }
                        if (count == 2)
                        {
                            break;
                        }
                    }
                    if (count > 1)
                    {
                        XYZ direction = (p1 - p2).Normalize();
                        if (direction.IsAlmostEqualTo(XYZ.BasisY) || direction.IsAlmostEqualTo(XYZ.BasisY.Negate()))
                        {
                            if (line == null)
                            {
                                line = Line.CreateBound(new XYZ(point.X, familyPoint.Y, familyPoint.Z), new XYZ(point.X, familyPoint.Y + 1, familyPoint.Z));
                            }
                            reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First();
                            referenceArray.Append(reference1);
                        }
                        else
                        {
                            if (line == null)
                            {
                                line = Line.CreateBound(new XYZ(familyPoint.X, point.Y, familyPoint.Z), new XYZ(familyPoint.X + 1, point.Y, familyPoint.Z));
                            }
                            reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                            referenceArray.Append(reference1);
                        }
                    }
                    else
                    {
                        if (line == null)
                        {
                            line = Line.CreateBound(new XYZ(familyPoint.X, point.Y, familyPoint.Z), new XYZ(familyPoint.X + 1, point.Y, familyPoint.Z));
                        }
                        reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                        referenceArray.Append(reference1);
                    }

                }
                else
                {
                    bool collinear = false;
                    if (first)
                    {
                        first = false;
                        FamilyInstance familyInstance1 = doc.GetElement(references[0]) as FamilyInstance;
                        FamilyInstance familyInstance2 = doc.GetElement(references[1]) as FamilyInstance;
                        XYZ p1 = (familyInstance1.Location as LocationPoint).Point;
                        XYZ p2 = (familyInstance2.Location as LocationPoint).Point;
                        Transform transform1 = familyInstance1.GetTransform();
                        Transform transform2 = familyInstance2.GetTransform();
                        XYZ direction1 = transform1.OfVector(XYZ.BasisX);
                        XYZ direction2 = transform2.OfVector(XYZ.BasisX);
                        Line line1 = Line.CreateBound(p1 + direction1 * 20, p1 - direction1 * 20);
                        Line line2 = Line.CreateBound(p2 + direction2 * 20, p2 - direction2 * 20);
                        line1.MakeUnbound();
                        // 判断两条直线是否共线
                        SetComparisonResult result = line1.Intersect(line2, out IntersectionResultArray intersectionResult);
                        if (result == SetComparisonResult.Superset)
                        {
                            collinear = true;
                        }
                    }
                    if (collinear)
                    {
                        if (line == null)
                        {
                            Transform transform = familyInstance.GetTransform();
                            XYZ direction = transform.OfVector(XYZ.BasisX);
                            line = Line.CreateBound(point + direction * 200 / 304.8, point - direction * 200 / 304.8);
                        }
                        reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First();
                        referenceArray.Append(reference1);
                    }
                    else
                    {
                        if (line == null)
                        {
                            Transform transform = familyInstance.GetTransform();
                            XYZ direction = transform.OfVector(XYZ.BasisX);
                            XYZ verticesEnd0 = familyPoint - direction * 200 / 304.8;
                            XYZ verticesEnd1 = familyPoint + direction * 200 / 304.8;
                            XYZ vertical1 = verticesEnd0.CrossProduct(verticesEnd1);
                            XYZ verticalVector = new XYZ(vertical1.X, vertical1.Y, direction.Z).Normalize();
                            line = Line.CreateBound(point + verticalVector * 200 / 304.8, point - verticalVector * 200 / 304.8);
                        }
                        reference1 = familyInstance.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
                        referenceArray.Append(reference1);
                    }
                }
            }
            using (Transaction trans = new Transaction(doc, "在吊架间创建尺寸标注"))
            {
                trans.Start();
                Dimension dimension = doc.Create.NewDimension(doc.ActiveView, line, referenceArray);
                trans.Commit();
            }
            group.Assimilate();
            return Result.Succeeded;
        }
        // 获取垂直向量
        private XYZ GetPerpendicularVector(XYZ direction)
        {
            // 计算垂直向量，这里简单地使用直线方向向量的法向量
            XYZ perpendicularVector = new XYZ(-direction.Y, direction.X, 0);
            return perpendicularVector;
        }
    }
}
