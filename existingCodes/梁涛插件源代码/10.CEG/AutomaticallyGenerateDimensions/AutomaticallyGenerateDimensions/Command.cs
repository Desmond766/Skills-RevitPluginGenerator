using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomaticallyGenerateDimensions
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            View view = doc.ActiveView;
            //TaskDialog.Show("sd", view.UpDirection.ToString() + "\n");
            //return Result.Succeeded;
            XYZ upDir = view.UpDirection;
            XYZ rightDir = view.RightDirection;
            XYZ viewDir = view.ViewDirection;
            Element elem= new FilteredElementCollector(doc,doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralFraming).WhereElementIsNotElementType().FirstOrDefault();
            FamilyInstance familyInstance = elem as FamilyInstance;
            ReferenceArray referenceArray = new ReferenceArray();
            XYZ max = elem.get_BoundingBox(null).Max;
            XYZ min = elem.get_BoundingBox(null).Min;
            Options options = new Options();
            options.ComputeReferences = true;
            GeometryElement geometryElement = elem.get_Geometry(options);
            foreach (var item in geometryElement)
            {
                if (item is Solid solid && solid.Volume > 0)
                {
                    double minVal1 = double.MaxValue;
                    double minVal2 = double.MaxValue;
                    Reference upReference = null;
                    Reference downReference = null;
                    foreach (var face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                        { 
                            if (planarFace.Origin.Z - min.Z < minVal1)
                            {
                                
                                minVal1 = planarFace.Origin.Z - min.Z;
                                downReference = planarFace.Reference;
                            }
                        }
                    }
                    foreach (var face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(XYZ.BasisZ))
                        {
                            if (max.Z - planarFace.Origin.Z < minVal2)
                            {
                                minVal2 = max.Z - planarFace.Origin.Z;
                                upReference = planarFace.Reference;
                            }
                        }
                    }
                    referenceArray.Append(upReference); 
                    referenceArray.Append(downReference);
                }
            }

            Options options2 = new Options();
            options2.ComputeReferences = true;
            GeometryElement geometryElement2 = elem.get_Geometry(options2);
            ReferenceArray referenceArray2 = new ReferenceArray();
            referenceArray2 = GetReferences(geometryElement2, max, min, view);

            
            XYZ pA = max.Add(new XYZ(max.X, max.Y, min.Z)) / 2;
            pA = pA + upDir * 1 + rightDir.Negate() * 2;
            XYZ pB = min.Add(new XYZ(min.X, min.Y, max.Z)) / 2;
            pB = pB + upDir.Negate() * 0.2 + rightDir.Negate() * 2;
            XYZ p1 = max.Add(new XYZ(min.X, min.Y, max.Z)) / 2;
            p1 = p1 + rightDir.Negate() * 2;
            XYZ p2 = min.Add(new XYZ(max.X, max.Y, min.Z)) / 2;
            //Line axis1 = Line.CreateBound(p1 - viewDir * 2, p1 + viewDir * 2);
            //Line axis2 = Line.CreateBound(p2 - viewDir * 2, p2 + viewDir * 2);

            double rota = (90 / 180) * Math.PI;
            List<ReferenceArray> upRefs = new List<ReferenceArray>();
            List<ReferenceArray> leftRefs = new List<ReferenceArray>();
            upRefs.Add(referenceArray);
            leftRefs.Add(referenceArray2);
            Transaction t = new Transaction(doc, "create dim");
            t.Start();
            //上方向6TON引用
            List<Reference> upDir6TONs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_SpecialityEquipment)
                .WhereElementIsNotElementType().Where(x => x.Name == "6TON")
                .Cast<FamilyInstance>().Where(y => y.HandOrientation.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                .Select(z => z.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First()).ToList();
            ReferenceArray _6TONRefers = new ReferenceArray();
            foreach (Reference item in referenceArray)
            {
                _6TONRefers.Append(item);
            }
            foreach (var item in upDir6TONs)
            {
                _6TONRefers.Append(item);
            }
            if (_6TONRefers.Size > 2)
            {
                upRefs.Add(_6TONRefers);
            }
            //左方向6TON引用
            List<Reference> leftDir6TONs = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_SpecialityEquipment)
                .WhereElementIsNotElementType().Where(x => x.Name == "6TON")
                .Cast<FamilyInstance>().Where(y => y.HandOrientation.IsAlmostEqualTo(XYZ.BasisX))
                .Select(z => z.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First()).ToList();
            ReferenceArray left6TONRefers = new ReferenceArray();
            foreach (Reference item in referenceArray2)
            {
                left6TONRefers.Append(item);
            }
            foreach (var item in leftDir6TONs)
            {
                left6TONRefers.Append(item);
            }
            if (left6TONRefers.Size > 2)
            {
                leftRefs.Add(left6TONRefers);
            }
            //上方向P100引用
            List<Reference> upDirP100s = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_SpecialityEquipment)
                .WhereElementIsNotElementType().Where(x => x.Name == "P100 - MiniV_Angle")
                .Cast<FamilyInstance>().Where(y => y.HandOrientation.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                .Select(z => z.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First()).ToList();
            ReferenceArray P100Refers = new ReferenceArray();
            foreach (Reference item in referenceArray)
            {
                P100Refers.Append(item);
            }
            foreach (var item in upDirP100s)
            {
                P100Refers.Append(item);
            }
            if (P100Refers.Size > 2)
            {
                upRefs.Add(P100Refers);
            }
            //右方向P1的引用


            //new XYZ(15266.791718711, 5172.711092470, 126.288508542)
            //1.创建四个文字注释
            TextNote.Create(doc, doc.ActiveView.Id, pA, 0.037912848991075, "SIDE-A", new ElementId(333320));
            TextNote.Create(doc, doc.ActiveView.Id, pB, 0.037912848991075, "SIDE-B", new ElementId(333320));
            TextNote textNote1 = TextNote.Create(doc, doc.ActiveView.Id, p1, 0.037912848991075, "END-1", new ElementId(333320));
            TextNote textNote2 = TextNote.Create(doc, doc.ActiveView.Id, p2, 0.037912848991075, "END-2", new ElementId(333320));

            int upC = 1;
            upRefs.Reverse();
            //创建updir所有的尺寸标注
            foreach (var item in upRefs)
            {
                doc.Create.NewDimension(doc.ActiveView, Line.CreateBound(pA + upDir * upC, pA + rightDir + upDir * upC), item);
                upC += 2;
            }
            int leftC = 1;
            leftRefs.Reverse();
            //创建leftDir所有尺寸标注
            foreach (var item in leftRefs)
            {
                doc.Create.NewDimension(doc.ActiveView, Line.CreateBound(p1 + rightDir.Negate() * leftC, p1 + upDir + rightDir.Negate() * leftC), item);
                leftC += 2;
            }
            //2.1.创建结构框架尺寸标注
            //if (referenceArray.get_Item(0) != null && referenceArray.get_Item(1) != null)
            //{
            //    doc.Create.NewDimension(doc.ActiveView, Line.CreateBound(pA, pA + rightDir), referenceArray);
            //    doc.Create.NewDimension(doc.ActiveView, Line.CreateBound(p1, p1 + upDir), referenceArray2);
            //}
            //2.2.创建6TON+结构框架尺寸标注
            //2.3.创建P100+结构框架尺寸标注
            //2.4.创建P101+结构框架尺寸标注

            t.Commit();
            XYZ pn1 = textNote1.get_BoundingBox(doc.ActiveView).Min.Add(textNote1.get_BoundingBox(doc.ActiveView).Max) / 2;
            XYZ pn2 = textNote2.get_BoundingBox(doc.ActiveView).Min.Add(textNote2.get_BoundingBox(doc.ActiveView).Max) / 2;
            Line axis1 = Line.CreateBound(pn1, pn1 + viewDir);
            Line axis2 = Line.CreateBound(pn2, pn2 + viewDir);
            //Transaction t2 = new Transaction(doc, "rotation");
            //t2.Start();
            //ElementTransformUtils.RotateElement(doc, textNote1.Id, axis1, rota);
            //ElementTransformUtils.RotateElement(doc, textNote2.Id, axis2, rota);
            //t2.Commit();
            //TaskDialog.Show("sd", view.UpDirection.ToString() + "\n" + pA);

            return Result.Succeeded;
        }

        public ReferenceArray GetReferences(GeometryElement geometryElement ,XYZ max, XYZ min,View view)
        {
            ReferenceArray referenceArray = new ReferenceArray();
            foreach (var item in geometryElement)
            {
                if (item is Solid solid && solid.Volume > 0)
                {
                    double minVal1 = double.MaxValue;
                    double minVal2 = double.MaxValue;
                    Reference upReference = null;
                    Reference downReference = null;
                    foreach (var face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(view.UpDirection))
                        {
                            if (view.UpDirection.IsAlmostEqualTo(XYZ.BasisX) && max.X - planarFace.Origin.X < minVal1)
                            {

                                minVal1 = max.X - planarFace.Origin.X;
                                downReference = planarFace.Reference;
                            }
                            if (view.UpDirection.IsAlmostEqualTo(XYZ.BasisY) && max.Y - planarFace.Origin.Y < minVal1)
                            {
                                minVal1 = max.Y - planarFace.Origin.Y;
                                downReference = planarFace.Reference;
                            }
                            if (view.UpDirection.IsAlmostEqualTo(XYZ.BasisX.Negate()) && planarFace.Origin.X - min.X < minVal1)
                            {

                                minVal1 = planarFace.Origin.X - min.X;
                                downReference = planarFace.Reference;
                            }
                            if (view.UpDirection.IsAlmostEqualTo(XYZ.BasisY.Negate()) && planarFace.Origin.Y - min.Y < minVal1)
                            {
                                minVal1 = planarFace.Origin.Y - min.Y;
                                downReference = planarFace.Reference;
                            }
                        }
                    }
                    foreach (var face in solid.Faces)
                    {
                        if (face is PlanarFace planarFace && planarFace.FaceNormal.IsAlmostEqualTo(view.UpDirection.Negate()))
                        {
                            if (view.UpDirection.Negate().IsAlmostEqualTo(XYZ.BasisX) && max.X - planarFace.Origin.X < minVal2)
                            {

                                minVal2 = max.X - planarFace.Origin.X;
                                upReference = planarFace.Reference;
                            }
                            if (view.UpDirection.Negate().IsAlmostEqualTo(XYZ.BasisY) && max.Y - planarFace.Origin.Y < minVal2)
                            {
                                minVal2 = max.Y - planarFace.Origin.Y;
                                upReference = planarFace.Reference;
                            }
                            if (view.UpDirection.Negate().IsAlmostEqualTo(XYZ.BasisX.Negate()) && planarFace.Origin.X - min.X < minVal2)
                            {

                                minVal2 = planarFace.Origin.X - min.X;
                                upReference = planarFace.Reference;
                            }
                            if (view.UpDirection.Negate().IsAlmostEqualTo(XYZ.BasisY.Negate()) && planarFace.Origin.Y - min.Y < minVal2)
                            {
                                minVal2 = planarFace.Origin.Y - min.Y;
                                upReference = planarFace.Reference;
                            }
                        }
                    }
                    if (upReference == null)
                    {
                        TaskDialog.Show("fd;", "111");
                    }
                    if (downReference == null)
                    {
                        TaskDialog.Show("fd;", "222");
                    }
                    referenceArray.Append(upReference);
                    referenceArray.Append(downReference);
                }
            }
            return referenceArray;
        }
    }
}
