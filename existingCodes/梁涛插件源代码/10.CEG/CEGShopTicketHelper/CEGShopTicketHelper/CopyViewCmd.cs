using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Collections;
using System.Xml.Linq;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class CopyViewCmd : IExternalCommand
    {
        Autodesk.Revit.DB.View targetView = null;
        bool copyAnnotation = true;
        bool copyTag = true;
        bool copyDimension = true;
        string annotationRotation = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //1.check active view
            if(!doc.ActiveView.IsAssemblyView || !(doc.ActiveView is ViewSection))
            {
                message = "tool should run inside a assembly view!";
                return Result.Cancelled;
            }

            //2.show dialog
            CopyViewFrm frm = new CopyViewFrm(doc);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            targetView = frm._selectedView;
            copyAnnotation = frm._copyAnnotations; 
            copyTag = frm._copyTags; 
            copyDimension = frm._copyDimensions;
            annotationRotation = frm._annotationRotation;

            if (null == targetView)
            {
                message = string.Format("couldn't find {0} : {1} in the project!",
                    doc.GetElement(targetView.AssociatedAssemblyInstanceId).Name, targetView.Name);
                return Result.Cancelled;
            }

            //3.sourceVCI
            ViewContentInfo sourceVCI = new ViewContentInfo(doc.ActiveView);
            sourceVCI.CollectTagInfos();
            sourceVCI.CollectAnnotationItems();
            sourceVCI.CollectDimensionInfos();

            //4. targetVCI
            ViewContentInfo targetVCI = new ViewContentInfo(targetView);
            targetVCI.InitAssemblyMemberInfos();

            //5.init targetVCI tagInfos
            targetVCI.TagInfos = new List<TagInfo>();
            foreach (TagInfo tagInfo in sourceVCI.TagInfos)
            {
                double d1 = (tagInfo.TaggedElementXYZ - sourceVCI.ViewOrigin).GetLength();
                foreach (EmbedRebarInfo embedRebarInfo in targetVCI.EmbedRebarInfos)
                {
                    double d2 = (embedRebarInfo.Location - targetVCI.ViewOrigin).GetLength();
                    if (Math.Abs(d1 - d2) < 0.001)
                    {
                        TagInfo newTagInfo = new TagInfo();
                        newTagInfo.TagSymbol = tagInfo.TagSymbol;
                        newTagInfo.Orientation = tagInfo.Orientation;
                        newTagInfo.HasLeader = tagInfo.HasLeader;
                        if (newTagInfo.HasLeader)
                        {
                            newTagInfo.HasElbow = tagInfo.HasElbow;
                            if (newTagInfo.HasElbow)
                            {
                                newTagInfo.LeaderElbow = tagInfo.LeaderElbow + targetVCI.ViewOrigin;
                            }
                            newTagInfo.LeaderEndCondition = tagInfo.LeaderEndCondition;
                            if (newTagInfo.LeaderEndCondition == LeaderEndCondition.Free)
                            {
                                newTagInfo.LeaderEnd = tagInfo.LeaderEnd + targetVCI.ViewOrigin;
                            }
                        }
                        newTagInfo.TagXYZ = tagInfo.TagXYZ + targetVCI.ViewOrigin;
                        newTagInfo.TaggedElement = embedRebarInfo.Host;
                        targetVCI.TagInfos.Add(newTagInfo);
                        break;
                    }
                }
            }

            //6.init targetVCI dimInfos
            targetVCI.DimensionInfos = new List<DimensionInfo>();
            foreach (DimensionInfo dimInfo in sourceVCI.DimensionInfos)
            {
                DimensionInfo newDimInfo = new DimensionInfo();

                //dimension Line base on viewOrigin
                Transform tf = Transform.CreateTranslation(targetVCI.ViewOrigin - sourceVCI.ViewOrigin);
                newDimInfo.Line = dimInfo.Line.CreateTransformed(tf) as Line;

                //referenceArray
                ReferenceArray referenceArray = new ReferenceArray();
                foreach (Reference r in dimInfo.References)
                {
                    Element dimElement = doc.GetElement(r);
                    if (!(dimElement is FamilyInstance)) continue;
                    FamilyInstance dimInst = (FamilyInstance)dimElement;
                    if (dimInst.Location == null) continue;
                    if (!(dimInst.Location is LocationPoint)) continue;

                    //dim to precast panel
                    if (dimInst.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        // judege by c1 n1
                        double c1 = 0.0;
                        double n1 = 0.0;
                        if (r.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_SURFACE)
                        {
                            PlanarFace face = dimInst.GetGeometryObjectFromReference(r) as PlanarFace;
                            if (face != null)
                            {
                                c1 = PointToFaceDistance(dimInst, face, sourceVCI.ViewOrigin);
                                n1 = face.Area;
                            }
                        }
                        if (r.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_LINEAR)
                        {
                            if (!(dimInst.GetGeometryObjectFromReference(r) is Edge)) continue;
                            Edge edge = dimInst.GetGeometryObjectFromReference(r) as Edge;
                            c1 = PointToEdgeDistance(dimInst, edge, sourceVCI.ViewOrigin);
                            n1 = edge.ApproximateLength;
                        }
                        //TaskDialog.Show("r1", c1.ToString("0.0") + "=>"+ n1.ToString("0.0"));
                        foreach (PanelCorberInfo pcInfo in targetVCI.PanelCorberInfos)
                        {
                            if (pcInfo.Host.Name != dimInst.Name) continue;
                            foreach (Reference rf in pcInfo.References)
                            {
                                double c2 = 0.0;
                                double n2 = 0.0;
                                if (rf.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_SURFACE)
                                {
                                    PlanarFace face = pcInfo.Host.GetGeometryObjectFromReference(rf) as PlanarFace;
                                    if (face != null)
                                    {
                                        c2 = PointToFaceDistance(pcInfo.Host, face, targetVCI.ViewOrigin);
                                        n2 = face.Area;
                                        //if (n1.ToString("0.0")=="5.0")
                                        //{
                                        //    TaskDialog.Show("r2", c2.ToString("0.0") + "=>" + n2.ToString("0.0"));
                                        //}
                                    }
                                }
                                if (rf.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_LINEAR)
                                {
                                    Edge edge = pcInfo.Host.GetGeometryObjectFromReference(rf) as Edge;
                                    c2 = PointToEdgeDistance(pcInfo.Host, edge, targetVCI.ViewOrigin);
                                    n2 = edge.ApproximateLength;
                                }

                                if (Math.Abs(c1 - c2) < 0.001 && Math.Abs(n1 - n2) < 0.001)
                                {
                                    //code block by lt 2024.2.28
                                    bool contains = false;
                                    foreach (Reference refer in referenceArray)
                                    {
                                        if (refer.ConvertToStableRepresentation(doc)
                                            == rf.ConvertToStableRepresentation(doc))
                                        {
                                            contains = true;
                                        }
                                    }
                                    string convertTSR = r.ConvertToStableRepresentation(doc);
                                    convertTSR = convertTSR.Substring(convertTSR.Length - 10);
                                    string convertTSR2 = rf.ConvertToStableRepresentation(doc);
                                    convertTSR2 = convertTSR2.Substring(convertTSR2.Length - 10);
                                    if (convertTSR != convertTSR2) contains = true;
                                    if (!contains)
                                    {
                                        referenceArray.Append(rf);
                                        break;
                                    }
                                }
                            }
                        }
                    }

                    //dim to embed/rebar
                    if (dimInst.Category.Id.IntegerValue == (int)BuiltInCategory.OST_SpecialityEquipment)
                    {
                        //judge by d1
                        double d1 = ((dimInst.Location as LocationPoint).Point - sourceVCI.ViewOrigin).GetLength();

                        foreach (EmbedRebarInfo embedRebarInfo in targetVCI.EmbedRebarInfos)
                        {
                            double d2 = (embedRebarInfo.Location - targetVCI.ViewOrigin).GetLength();
                            if (Math.Abs(d1 - d2) < 0.001)
                            {
                                //get embed reference per reference type in master ticket
                                FamilyInstanceReferenceType rType = dimInst.GetReferenceType(r);
                                
                                //Reference reference = embedRebarInfo.Host.GetReferences(rType).FirstOrDefault();

                                //2024-6-7 update
                                string convertTSR = r.ConvertToStableRepresentation(doc);
                                convertTSR = convertTSR.Substring(convertTSR.Length - 10);
                                Reference reference = embedRebarInfo.Host.GetReferences(rType)
                                    .FirstOrDefault(x =>
                                    x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 10)
                                    == convertTSR);

                                if (null == reference)
                                {
                                    List<Reference> references = GetAllReferences(doc, embedRebarInfo.Host);
                                    reference = references.FirstOrDefault(x =>
                                    x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 10)
                                    == convertTSR);
                                }

                                if (null != reference)
                                {
                                    //code block by lt 2024.2.28
                                    bool contains = false;
                                    foreach (Reference refer in referenceArray)
                                    {
                                        if (refer.ConvertToStableRepresentation(doc) == reference.ConvertToStableRepresentation(doc))
                                        {
                                            contains = true;
                                        }
                                    }
                                    if (!contains)
                                    {
                                        referenceArray.Append(reference);
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                newDimInfo.References = referenceArray;

                newDimInfo.DimType = dimInfo.DimType;

                newDimInfo.Segments = dimInfo.Segments;

                if (newDimInfo.References.Size >= 2)
                {
                    targetVCI.DimensionInfos.Add(newDimInfo);
                }
            }


            //7.Copy
            using (Transaction trans = new Transaction(doc,"copyView"))
            {
                trans.Start();

                //1.copy annotation items
                if (sourceVCI.AnnotationItemIds.Count > 0 && copyAnnotation)
                {
                    CopyPasteOptions copyPasteOptions = new CopyPasteOptions();
                    List<ElementId> newIds = ElementTransformUtils.CopyElements(
                        doc.ActiveView, sourceVCI.AnnotationItemIds, targetView,
                        Transform.Identity, copyPasteOptions).ToList();

                    ////rotate
                    //double angle = -doc.ActiveView.RightDirection.AngleTo(doc.ActiveView.CropBox.Transform.BasisX);
                    //TaskDialog.Show("R", doc.ActiveView.RightDirection.ToString()
                    //    + "\n" + doc.ActiveView.CropBox.Transform.BasisX.ToString()
                    //    + "\n" + angle.ToString());
                    //if (Math.Abs(angle) > 0.0001)
                    //{
                    //    Line axis = Line.CreateUnbound(targetVCI.ViewOrigin,
                    //    targetView.UpDirection.CrossProduct(targetView.RightDirection));
                    //    ElementTransformUtils.RotateElements(doc, newIds, axis, angle);
                    //}

                    //rotate
                    if (annotationRotation == "90" || annotationRotation == "-90")
                    {
                        double angle = Math.PI / 2.0;
                        if (annotationRotation == "-90")
                        {
                            angle = -angle;
                        }
                        Line axis = Line.CreateUnbound(targetVCI.ViewOrigin,
                        targetView.UpDirection.CrossProduct(targetView.RightDirection));
                        ElementTransformUtils.RotateElements(doc, newIds, axis, angle);
                    }

                    //move elements to fix offset
                    XYZ pt1 = doc.GetElement(sourceVCI.AnnotationItemIds.First()).get_BoundingBox(doc.ActiveView).Max
                        - sourceVCI.ViewOrigin;
                    XYZ pt2 = doc.GetElement(newIds.First()).get_BoundingBox(targetView).Max
                        - targetVCI.ViewOrigin;
                    ElementTransformUtils.MoveElements(doc, newIds, pt1 - pt2);
                }

                //2.copy tag
                if (copyTag)
                {
                    foreach (TagInfo tagInfo in targetVCI.TagInfos)
                    {
                        IndependentTag newTag = IndependentTag.Create(
                            doc,
                            tagInfo.TagSymbol.Id,
                            targetView.Id,
                            new Reference(tagInfo.TaggedElement),
                            tagInfo.HasLeader,
                            tagInfo.Orientation,
                            tagInfo.TagXYZ);
                        if (tagInfo.HasLeader)
                        {
                            newTag.TagHeadPosition = tagInfo.TagXYZ;
                            if (tagInfo.HasElbow)
                            {
                                //newTag.LeaderElbow = tagInfo.LeaderElbow;//2021API
                                newTag.SetLeaderElbow(new Reference(tagInfo.TaggedElement), tagInfo.LeaderElbow);
                            }
                            newTag.LeaderEndCondition = tagInfo.LeaderEndCondition;
                            if (tagInfo.LeaderEndCondition == LeaderEndCondition.Free)
                            {
                                //newTag.LeaderEnd = tagInfo.LeaderEnd;//2021API
                                newTag.SetLeaderEnd(new Reference(tagInfo.TaggedElement), tagInfo.LeaderEnd);
                            }
                        }
                    }
                }

                trans.Commit();

                //3.copy dimensions
                if (copyDimension)
                {
                    TransactionGroup tg = new TransactionGroup(doc, "copy dim group");
                    tg.Start();
                    foreach (DimensionInfo dimInfo in targetVCI.DimensionInfos)
                    {
                        try
                        {
                            using (Transaction st1 = new Transaction(doc, "copy dim"))
                            {
                                st1.Start();
                                var dim = doc.Create.NewDimension(targetView, dimInfo.Line, dimInfo.References, dimInfo.DimType);

                                if (dim.Id.IntegerValue == -1)
                                {
                                    TaskDialog.Show("r", "1");
                                    st1.RollBack();
                                }

                                //2024-6-5更新
                                //如果尺寸完全复制过来，那么把文字也给复制过去
                                //目前只复制底下的文字
                                if (null != dim.Segments && null != dimInfo.Segments)
                                {
                                    //TaskDialog.Show("r", dim.Segments.Size.ToString() + ";" + dimInfo.Segments.Size.ToString());
                                    if (dim.Segments.Size == dimInfo.Segments.Size)
                                    {
                                        dimInfo.CopySegments(dim);
                                    }
                                }
                                st1.Commit();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message + ex.StackTrace);
                        }
                    }
                    tg.Assimilate();
                }
            }

            return Result.Succeeded;
        }

        private double PointToFaceDistance(FamilyInstance fi, PlanarFace face, XYZ pt)
        {
            XYZ planeOrigin = face.Origin;
            if (!fi.HasModifiedGeometry())//if not modify, we need to apply transform to origin
            {
                planeOrigin = fi.GetTransform().OfPoint(face.Origin);
            }
            Plane p = Plane.CreateByNormalAndOrigin(face.FaceNormal, planeOrigin);
            UV uv = new UV();
            double distance = 0.0;
            p.Project(pt, out uv, out distance);
            return distance;
        }

        private double PointToEdgeDistance(FamilyInstance fi, Edge edge, XYZ pt)
        {
            Line line = edge.AsCurve() as Line;
            //if (line == null) { return 0.0; }
            XYZ origin = null;
            if (line == null)
            {
                origin = edge.AsCurve().GetEndPoint(0);
            }
            else
            {
                origin = line.Origin;
            }
            if (!fi.HasModifiedGeometry())//if not modify, we need to apply transform to origin
            {
                origin = fi.GetTransform().OfPoint(origin);
            }
            return (origin - pt).GetLength();
        }

        //获得元素所有的reference
        public List<Reference> GetAllReferences(Document doc, Element element)
        {
            // 创建一个列表来存储所有的Reference对象
            List<Reference> references = new List<Reference>();

            // 获取元素的几何选项
            Options geomOptions = new Options
            {
                ComputeReferences = true, // 需要计算Reference
                IncludeNonVisibleObjects = false // 只包含可见的对象
            };

            // 获取元素的几何信息
            GeometryElement geomElement = element.get_Geometry(geomOptions);

            // 遍历几何信息中的所有几何实例
            foreach (GeometryObject geomObj in geomElement)
            {
                if (geomObj is GeometryInstance)
                {
                    GeometryInstance geomInstance = geomObj as GeometryInstance;
                    GeometryElement syGeomElement = geomInstance.GetSymbolGeometry();

                    foreach (GeometryObject instanceGeomObj in syGeomElement)
                    {
                        ProcessGeometryObject(instanceGeomObj, references);
                    }
                }
                else
                {
                    ProcessGeometryObject(geomObj, references);
                }
            }

            return references;
        }

        private void ProcessGeometryObject(GeometryObject geomObj, List<Reference> references)
        {
            if (geomObj is Solid solid && solid.SurfaceArea != 0)
            {
                foreach (Face face in solid.Faces)
                {
                    references.Add(face.Reference);
                }
                foreach (Edge edge in solid.Edges)
                {
                    references.Add(edge.Reference);
                }
            }
        }

    }
}
