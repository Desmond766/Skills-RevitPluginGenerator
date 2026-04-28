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
using View = Autodesk.Revit.DB.View;
using System.Reflection;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class CopyViewCmd3 : IExternalCommand
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

            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //View view = doc.ActiveView;

            //TaskDialog.Show("re", view.Origin.DistanceTo((element.Location as LocationPoint).Point).ToString() + "\n" + view.Origin + "\n" + (element.Location as LocationPoint).Point);

            //return Result.Succeeded;


            //1.check active view
            if (!doc.ActiveView.IsAssemblyView || !(doc.ActiveView is ViewSection))
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

            // get topface
            FamilyInstance instance = GetMainElement(sourceVCI.HostInstance) as FamilyInstance;
            FamilyInstance flatMember = GetFlatMember(doc, instance);
            List<Face> faces = GetFaceByElement(flatMember, new Options() { ComputeReferences = true });
            var planarFaces = GetPlanarFaces(faces);
            PlanarFace rightTopFace = GetTopFace(planarFaces, sourceVCI.CurrentView.RightDirection);
            PlanarFace upTopFace = GetTopFace(planarFaces, sourceVCI.CurrentView.UpDirection);
            PlanarFace leftTopFace = GetTopFace(planarFaces, sourceVCI.CurrentView.RightDirection.Negate());
            PlanarFace botTopFace = GetTopFace(planarFaces, sourceVCI.CurrentView.UpDirection.Negate());

            FamilyInstance instance2 = GetMainElement(targetVCI.HostInstance) as FamilyInstance;
            FamilyInstance flatMember2 = GetFlatMember(doc, instance2);
            List<Face> faces2 = GetFaceByElement(flatMember2, new Options() { ComputeReferences = true });
            var planarFaces2 = GetPlanarFaces(faces2);
            PlanarFace rightTopFace2 = GetTopFace(planarFaces2, targetVCI.CurrentView.RightDirection);
            PlanarFace upTopFace2 = GetTopFace(planarFaces2, targetVCI.CurrentView.UpDirection);
            PlanarFace leftTopFace2 = GetTopFace(planarFaces2, targetVCI.CurrentView.RightDirection.Negate());
            PlanarFace botTopFace2 = GetTopFace(planarFaces2, targetVCI.CurrentView.UpDirection.Negate());

            double tolerance = GetTolerance(doc, sourceVCI, targetVCI);

            //TaskDialog.Show("revit", sourceVCI.TagInfos.Count.ToString() + "\n" + (tolerance * 304.8));
            //5.init targetVCI tagInfos
            targetVCI.TagInfos = new List<TagInfo>();
            foreach (TagInfo tagInfo in sourceVCI.TagInfos)
            {
                Transform sourceTransform = sourceVCI.HostInstance.GetTransform();
                sourceTransform.Origin = sourceVCI.ViewOrigin + ((sourceVCI.HostInstance.Location as LocationPoint).Point - (sourceTransform.Origin));
                Transform targetTransform = targetVCI.HostInstance.GetTransform();
                targetTransform.Origin = targetVCI.ViewOrigin + ((targetVCI.HostInstance.Location as LocationPoint).Point - (targetTransform.Origin));

                string sourTagLocalSymbolName = GetTagLocalElementSymbolName(tagInfo);

                var embedRebarInfos = targetVCI.EmbedRebarInfos;
                embedRebarInfos = embedRebarInfos.Where(ei => GetSymbolName(ei.Host) == sourTagLocalSymbolName).ToList();

                GetTwoTagHostPosition(tagInfo.TaggedElementXYZ, leftTopFace, rightTopFace, botTopFace, upTopFace, out var upHostPosition, out var upDirDis, out var rightHostPosition, out var rightDirDis);

                string firstPosition;
                double firstDirDis;
                string secondPosition;
                double secondDirDis;
                if (upDirDis < rightDirDis)
                {
                    firstPosition = upHostPosition;
                    firstDirDis = upDirDis;
                    secondPosition = rightHostPosition;
                    secondDirDis = rightDirDis;
                }
                else
                {
                    firstPosition = rightHostPosition;
                    firstDirDis = rightDirDis;
                    secondPosition = upHostPosition;
                    secondDirDis = upDirDis;
                }
                embedRebarInfos = embedRebarInfos.OrderBy(ei => GetPointToTopFace(firstPosition, ei.Location, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2))
                        .ThenBy(ei => GetPointToTopFace(secondPosition, ei.Location, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2))
                        .ToList();
                //TaskDialog.Show("re", embedRebarInfos.Count.ToString());
                //return Result.Cancelled;
                foreach (var embedRebarInfo in embedRebarInfos)
                {
                    double firstDirDis2 = GetPointToTopFace(firstPosition, embedRebarInfo.Location, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2);
                    double secondDirDis2 = GetPointToTopFace(secondPosition, embedRebarInfo.Location, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2);

                    //if (embedRebarInfo.Host.Id.IntegerValue == 57352106)
                    //{
                    //    TaskDialog.Show("re", Math.Abs(firstDirDis - firstDirDis2) + "\n" + Math.Abs(secondDirDis - secondDirDis2) + "\n" + tolerance);
                    //}
                    if (Math.Abs(firstDirDis - firstDirDis2) >= tolerance || Math.Abs(secondDirDis - secondDirDis2) >= tolerance) continue;
                    
                    TagInfo newTagInfo = new TagInfo();
                    newTagInfo.TagSymbol = tagInfo.TagSymbol;
                    newTagInfo.Orientation = tagInfo.Orientation;
                    newTagInfo.HasLeader = tagInfo.HasLeader;
                    if (newTagInfo.HasLeader)
                    {
                        newTagInfo.HasElbow = tagInfo.HasElbow;
                        if (newTagInfo.HasElbow)
                        {
                            newTagInfo.LeaderElbow = sourceTransform.Inverse.Multiply(targetTransform).OfPoint(tagInfo.LeaderElbow + sourceVCI.ViewOrigin);
                            //newTagInfo.LeaderElbow = tagInfo.LeaderElbow + targetVCI.ViewOrigin;
                        }
                        newTagInfo.LeaderEndCondition = tagInfo.LeaderEndCondition;
                        if (newTagInfo.LeaderEndCondition == LeaderEndCondition.Free)
                        {
                            newTagInfo.LeaderEnd = sourceTransform.Inverse.Multiply(targetTransform).OfPoint(tagInfo.LeaderEnd + sourceVCI.ViewOrigin);
                            //newTagInfo.LeaderEnd = tagInfo.LeaderEnd + targetVCI.ViewOrigin;
                        }
                    }
                    newTagInfo.TagXYZ = sourceTransform.Inverse.Multiply(targetTransform).OfPoint(tagInfo.TagXYZ + sourceVCI.ViewOrigin);
                    //newTagInfo.TagXYZ = tagInfo.TagXYZ + targetVCI.ViewOrigin;
                    newTagInfo.TaggedElement = embedRebarInfo.Host;
                    targetVCI.TagInfos.Add(newTagInfo);
                    break;
                }
            }
            /*旧
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
            */
            //6.init targetVCI dimInfos
            targetVCI.DimensionInfos = new List<DimensionInfo>();

            foreach (DimensionInfo dimInfo in sourceVCI.DimensionInfos)
            {
                DimensionInfo newDimInfo = new DimensionInfo();

                ////dimension Line base on viewOrigin
                //Transform tf = Transform.CreateTranslation(targetVCI.ViewOrigin - sourceVCI.ViewOrigin);
                //newDimInfo.Line = dimInfo.Line.CreateTransformed(tf) as Line;

                Transform sourceTransform = sourceVCI.HostInstance.GetTransform();
                sourceTransform.Origin = sourceVCI.ViewOrigin + ((sourceVCI.HostInstance.Location as LocationPoint).Point - (sourceTransform.Origin));
                //sourceTransform.Origin = sourceVCI.ViewOrigin;

                Transform targetTransform = targetVCI.HostInstance.GetTransform();
                targetTransform.Origin = targetVCI.ViewOrigin + ((targetVCI.HostInstance.Location as LocationPoint).Point - (targetTransform.Origin));
                //targetTransform.Origin = targetVCI.ViewOrigin;

                if (dimInfo.Line == null) continue;
                XYZ lineOrigin = dimInfo.Line.Origin;
                XYZ lineDirPoint = dimInfo.Line.Origin + dimInfo.Line.Direction;
                //lineOrigin = targetTransform.OfPoint(sourceTransform.Inverse.OfPoint(lineOrigin));
                //lineDirPoint = targetTransform.OfPoint(sourceTransform.Inverse.OfPoint(lineDirPoint));
                lineOrigin = sourceTransform.Inverse.Multiply(targetTransform).OfPoint(lineOrigin);
                lineDirPoint = sourceTransform.Inverse.Multiply(targetTransform).OfPoint(lineDirPoint);
                newDimInfo.Line = Line.CreateUnbound(lineOrigin, (lineDirPoint - lineOrigin).Normalize());

                //XYZ sP = sourceVCI.HostInstance.GetTransform().Inverse.Inverse.OfPoint((sourceVCI.HostInstance.Location as LocationPoint).Point);
                //XYZ tP = targetVCI.HostInstance.GetTransform().Inverse.Inverse.OfPoint((targetVCI.HostInstance.Location as LocationPoint).Point);


                //referenceArray
                ReferenceArray referenceArray = new ReferenceArray();
                var dimReferences = dimInfo.References.Cast<Reference>().ToList();
                //var dimInstDict = GetInstanceDict(doc, dimReferences);
                var dimInstDict = GetInstanceDict(doc, dimInfo, leftTopFace, rightTopFace, botTopFace, upTopFace, XYZ.Zero, sourceVCI.CurrentView);

                List<FIInfo> hasAddInfos = new List<FIInfo>();

                foreach (var dimInstDic in dimInstDict)
                {
                    //if (dimInstDic.Key.Equals(GetSymbolName(flatMember2))) // 只有同类型的结构框架才能复制尺寸标注    `
                    if (dimInstDic.Key.Equals(GetSymbolName(flatMember))) // 不同类型的结构框架也可复制尺寸标注
                    {
                        foreach (var fiInfo in dimInstDic.Value)
                        {
                            var text = fiInfo.ReferenceCTSR.Replace(fiInfo.FamilyInstance.UniqueId, flatMember2.UniqueId);
                            var targetReference = Reference.ParseFromStableRepresentation(doc, text);

                            if (targetReference != null)
                            {
                                referenceArray.Append(targetReference);
                            }
                        }
                        continue;
                    }
                    foreach (var dimInst in dimInstDic.Value)
                    {
                        FamilyInstance familyInstance = dimInst.FamilyInstance;
                        XYZ point = (familyInstance.Location as LocationPoint).Point;

                        string dimPosition = GetDimPosition(dimInfo.Dim, leftTopFace, rightTopFace, botTopFace, upTopFace, point, out double topDis, sourceVCI.CurrentView);
                        double otherTopDis = GetOtherPointToTopFace(dimPosition, point, leftTopFace, rightTopFace, botTopFace, upTopFace);


                        // 合并结构框架与埋件
                        var targetFIS = targetVCI.PanelCorberInfos.Select(pcInfo => pcInfo.Host).ToList();
                        targetFIS.AddRange(targetVCI.EmbedRebarInfos.Select(erInfo => erInfo.Host));

                        //targetFIS = targetFIS.Where(p => GetSymbolName(p).Equals(dimInstDic.Key))
                        //    .Where(fi => Math.Abs(GetDistanceToOrigin(dimInst.FamilyInstance, sourceVCI.ViewOrigin) - GetDistanceToOrigin(fi, targetVCI.ViewOrigin)) < tolerance)
                        //    .OrderBy(fi => Math.Abs(GetDistanceToOrigin(dimInst.FamilyInstance, sourceVCI.ViewOrigin) - GetDistanceToOrigin(fi, targetVCI.ViewOrigin))).ToList();
                        targetFIS = targetFIS.Where(p => GetSymbolName(p).Equals(dimInstDic.Key))
                            .OrderBy(f => { XYZ p = (f.Location as LocationPoint).Point; return GetPointToTopFace(dimPosition, p, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2); })
                            .ThenBy(f => { XYZ p = (f.Location as LocationPoint).Point; return GetOtherPointToTopFace(dimPosition, p, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2); })
                            .ToList();

                        foreach (var targetFI in targetFIS)
                        {

                            XYZ point2 = (targetFI.Location as LocationPoint).Point;

                            double topDis2 = GetPointToTopFace(dimPosition, point2, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2);
                            double otherTopDis2 = GetOtherPointToTopFace(dimPosition, point2, leftTopFace2, rightTopFace2, botTopFace2, upTopFace2);

                            if (Math.Abs(topDis - topDis2) >= tolerance || Math.Abs(otherTopDis - otherTopDis2) >= tolerance) continue;

                            string text = dimInst.ReferenceCTSR.Replace(familyInstance.UniqueId, targetFI.UniqueId);
                            Reference targetReference = Reference.ParseFromStableRepresentation(doc, text);

                            if (targetReference == null || hasAddInfos.Any(fi => fi.FamilyInstance.Id == targetFI.Id && fi.ReferenceCTSR == text)) continue;

                            if (targetReference != null)
                            {
                                referenceArray.Append(targetReference);
                                hasAddInfos.Add(new FIInfo(targetFI, text));
                                break;
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
                /*旧
                // ---------------------
                //foreach (var pcInfo in pcInfos)
                //{
                //    string symbolName = GetSymbolName(pcInfo.Host);
                //    if (!dimInstDict.ContainsKey(symbolName)) continue;

                //    var list = dimInstDict[symbolName];
                //    var list2 = list.Where(fi => Math.Abs(GetDistanceToOrigin((FamilyInstance)doc.GetElement(fi.Key), sourceVCI.ViewOrigin) - GetDistanceToOrigin(pcInfo.Host, targetVCI.ViewOrigin)) < 0.01)
                //        .OrderBy(fi => Math.Abs(GetDistanceToOrigin((FamilyInstance)doc.GetElement(fi.Key), sourceVCI.ViewOrigin) - GetDistanceToOrigin(pcInfo.Host, targetVCI.ViewOrigin)));
                //    foreach (var fi in list2)
                //    {
                //        string text = fi.Value;
                //        Element element = doc.GetElement(fi.Key);
                //        text = text.Replace(element.UniqueId, pcInfo.Host.UniqueId);
                //        Reference sourceReference = Reference.ParseFromStableRepresentation(doc, text);
                //        if (sourceReference != null)
                //        {
                //            referenceArray.Append(sourceReference);
                //            break;
                //        }
                //    }


                //}
                //---------------------------

                //DimensionInfo newDimInfo = new DimensionInfo();

                ////dimension Line base on viewOrigin
                //Transform tf = Transform.CreateTranslation(targetVCI.ViewOrigin - sourceVCI.ViewOrigin);
                //newDimInfo.Line = dimInfo.Line.CreateTransformed(tf) as Line;

                ////referenceArray
                //ReferenceArray referenceArray = new ReferenceArray();
                //foreach (Reference r in dimInfo.References)
                //{
                //    Element dimElement = doc.GetElement(r);
                //    if (!(dimElement is FamilyInstance)) continue;
                //    FamilyInstance dimInst = (FamilyInstance)dimElement;
                //    if (dimInst.Location == null) continue;
                //    if (!(dimInst.Location is LocationPoint)) continue;

                //    //dim to precast panel
                //    if (dimInst.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                //    {
                //        // judege by c1 n1
                //        double c1 = 0.0;
                //        double n1 = 0.0;
                //        if (r.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_SURFACE)
                //        {
                //            PlanarFace face = dimInst.GetGeometryObjectFromReference(r) as PlanarFace;
                //            if (face != null)
                //            {
                //                c1 = PointToFaceDistance(dimInst, face, sourceVCI.ViewOrigin);
                //                n1 = face.Area;
                //            }
                //        }
                //        if (r.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_LINEAR)
                //        {
                //            if (!(dimInst.GetGeometryObjectFromReference(r) is Edge)) continue;
                //            Edge edge = dimInst.GetGeometryObjectFromReference(r) as Edge;
                //            c1 = PointToEdgeDistance(dimInst, edge, sourceVCI.ViewOrigin);
                //            n1 = edge.ApproximateLength;
                //        }
                //        //TaskDialog.Show("r1", c1.ToString("0.0") + "=>"+ n1.ToString("0.0"));
                //        var pcInfos = targetVCI.PanelCorberInfos;
                //        var pcGroup = pcInfos.GroupBy(p => GetSymbolName(p.Host));

                //        foreach (PanelCorberInfo pcInfo in targetVCI.PanelCorberInfos)
                //        {
                //            if (pcInfo.Host.Name != dimInst.Name) continue;

                //            //string text = r.ConvertToStableRepresentation(doc).Replace(dimInst.UniqueId, pcInfo.Host.UniqueId);
                //            //Reference reference = Reference.ParseFromStableRepresentation(doc, text);
                //            //if (reference != null) referenceArray.Append(reference);
                //            //continue;
                //            foreach (Reference rf in pcInfo.References)
                //            {
                //                double c2 = 0.0;
                //                double n2 = 0.0;
                //                if (rf.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_SURFACE)
                //                {
                //                    PlanarFace face = pcInfo.Host.GetGeometryObjectFromReference(rf) as PlanarFace;
                //                    if (face != null)
                //                    {
                //                        c2 = PointToFaceDistance(pcInfo.Host, face, targetVCI.ViewOrigin);
                //                        n2 = face.Area;
                //                        //if (n1.ToString("0.0")=="5.0")
                //                        //{
                //                        //    TaskDialog.Show("r2", c2.ToString("0.0") + "=>" + n2.ToString("0.0"));
                //                        //}
                //                    }
                //                }
                //                if (rf.ElementReferenceType == ElementReferenceType.REFERENCE_TYPE_LINEAR)
                //                {
                //                    Edge edge = pcInfo.Host.GetGeometryObjectFromReference(rf) as Edge;
                //                    c2 = PointToEdgeDistance(pcInfo.Host, edge, targetVCI.ViewOrigin);
                //                    n2 = edge.ApproximateLength;
                //                }

                //                if (Math.Abs(c1 - c2) < 0.001 && Math.Abs(n1 - n2) < 0.001)
                //                {
                //                    //code block by lt 2024.2.28
                //                    bool contains = false;
                //                    foreach (Reference refer in referenceArray)
                //                    {
                //                        if (refer.ConvertToStableRepresentation(doc)
                //                            == rf.ConvertToStableRepresentation(doc))
                //                        {
                //                            contains = true;
                //                        }
                //                    }
                //                    string convertTSR = r.ConvertToStableRepresentation(doc);
                //                    convertTSR = convertTSR.Substring(convertTSR.Length - 10);
                //                    string convertTSR2 = rf.ConvertToStableRepresentation(doc);
                //                    convertTSR2 = convertTSR2.Substring(convertTSR2.Length - 10);
                //                    if (convertTSR != convertTSR2) contains = true;
                //                    if (!contains)
                //                    {
                //                        referenceArray.Append(rf);
                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    //dim to embed/rebar
                //    if (dimInst.Category.Id.IntegerValue == (int)BuiltInCategory.OST_SpecialityEquipment)
                //    {
                //        //judge by d1
                //        double d1 = ((dimInst.Location as LocationPoint).Point - sourceVCI.ViewOrigin).GetLength();

                //        foreach (EmbedRebarInfo embedRebarInfo in targetVCI.EmbedRebarInfos)
                //        {
                //            double d2 = (embedRebarInfo.Location - targetVCI.ViewOrigin).GetLength();
                //            if (Math.Abs(d1 - d2) < 0.001)
                //            {
                //                //get embed reference per reference type in master ticket
                //                FamilyInstanceReferenceType rType = dimInst.GetReferenceType(r);

                //                //Reference reference = embedRebarInfo.Host.GetReferences(rType).FirstOrDefault();

                //                //2024-6-7 update
                //                string convertTSR = r.ConvertToStableRepresentation(doc);
                //                convertTSR = convertTSR.Substring(convertTSR.Length - 10);
                //                Reference reference = embedRebarInfo.Host.GetReferences(rType)
                //                    .FirstOrDefault(x =>
                //                    x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 10)
                //                    == convertTSR);

                //                if (null == reference)
                //                {
                //                    List<Reference> references = GetAllReferences(doc, embedRebarInfo.Host);
                //                    reference = references.FirstOrDefault(x =>
                //                    x.ConvertToStableRepresentation(doc).Substring(x.ConvertToStableRepresentation(doc).Length - 10)
                //                    == convertTSR);
                //                }

                //                if (null != reference)
                //                {
                //                    //code block by lt 2024.2.28
                //                    bool contains = false;
                //                    foreach (Reference refer in referenceArray)
                //                    {
                //                        if (refer.ConvertToStableRepresentation(doc) == reference.ConvertToStableRepresentation(doc))
                //                        {
                //                            contains = true;
                //                        }
                //                    }
                //                    if (!contains)
                //                    {
                //                        referenceArray.Append(reference);
                //                        break;
                //                    }
                //                }
                //            }
                //        }
                //    }
                //}
                //newDimInfo.References = referenceArray;

                //newDimInfo.DimType = dimInfo.DimType;

                //newDimInfo.Segments = dimInfo.Segments;

                //if (newDimInfo.References.Size >= 2)
                //{
                //    targetVCI.DimensionInfos.Add(newDimInfo);
                //}
                */
            }


            //7.Copy
            using (Transaction trans = new Transaction(doc, "copyView"))
            {
                trans.Start();

                //1.copy annotation items
                if (sourceVCI.AnnotationItemIds.Count > 0 && copyAnnotation)
                {
                    CopyPasteOptions copyPasteOptions = new CopyPasteOptions();

                    
                    Transform sourceTransform = sourceVCI.HostInstance.GetTransform();
                    sourceTransform.Origin = sourceVCI.ViewOrigin + ((sourceVCI.HostInstance.Location as LocationPoint).Point - (sourceTransform.Origin));
                    //sourceTransform.Origin = sourceVCI.HostInstance.get_BoundingBox(sourceVCI.CurrentView).Min;
                    Transform targetTransform = targetVCI.HostInstance.GetTransform();
                    targetTransform.Origin = targetVCI.ViewOrigin + ((targetVCI.HostInstance.Location as LocationPoint).Point - (targetTransform.Origin));
                    //targetTransform.Origin = targetVCI.HostInstance.get_BoundingBox(targetView).Min;

                    Transform transform = sourceTransform.Inverse.Multiply(targetTransform);
                    //foreach (var item in sourceVCI.AnnotationItemIds)
                    //{
                    //    Element element = doc.GetElement(item);
                    //    if (element is DetailLine detailLine)
                    //    {
                    //        Curve oldCurve = (detailLine.Location as LocationCurve).Curve;
                    //        Curve newCurve = oldCurve.CreateTransformed(transform);
                    //        var newDetailLine = doc.Create.NewDetailCurve(targetView, newCurve);
                    //        newDetailLine.LineStyle = detailLine.LineStyle;
                    //    }
                    //    else if (element is TextNote textNote)
                    //    {
                    //        TextNoteOptions textNoteOptions = new TextNoteOptions();
                    //        textNoteOptions.TypeId = textNote.GetTypeId();
                    //        textNoteOptions.Rotation = transform.OfVector(textNote.BaseDirection).AngleTo(targetView.RightDirection);
                    //        //textNoteOptions.Rotation = textNote.BaseDirection.AngleTo(targetView.RightDirection);
                    //        var newTextNote = TextNote.Create(doc, targetView.Id, transform.OfPoint(textNote.Coord), textNote.Width, textNote.Text, textNoteOptions);
                    //        newTextNote.HorizontalAlignment = textNote.HorizontalAlignment;
                    //        newTextNote.VerticalAlignment = textNote.VerticalAlignment;
                    //    }
                    //}

                    
                    List<ElementId> viewIds = sourceVCI.AnnotationItemIds.Where(id => doc.GetElement(id).Category.Id.Value == -2000278).ToList();
                    List<ElementId> otherIds = sourceVCI.AnnotationItemIds.Where(id => doc.GetElement(id).Category.Id.Value != -2000278).ToList();

                    List<ElementId> newIds = new List<ElementId>();
                    if (otherIds.Count > 0)
                    {
                        Transform transform1 = Transform.Identity;
                        var cropTra = targetView.CropBox.Transform;

                        transform1.Origin = targetTransform.Origin;


                        List<ElementId> newOtherIds = ElementTransformUtils.CopyElements(
                        doc.ActiveView, otherIds, targetView,
                        cropTra, copyPasteOptions).ToList();
                        newIds.AddRange(otherIds);
                    }
                    if (viewIds.Count > 0)
                    {
                        List<ElementId> newViewIds = ElementTransformUtils.CopyElements(
                        doc.ActiveView, viewIds, targetView,
                        Transform.Identity, copyPasteOptions).ToList();
                        newIds.AddRange(newViewIds);
                    }
                    
                    /*
                    Line axis2 = Line.CreateUnbound(targetVCI.ViewOrigin,
                        targetView.UpDirection.CrossProduct(targetView.RightDirection));

                    Transform tTransform = targetVCI.CurrentView.CropBox.Transform;
                    tTransform.Origin = XYZ.Zero;
                    Transform aTransform = targetVCI.HostInstance.GetTransform();
                    aTransform.Origin = XYZ.Zero;

                    //Transform transform = tTransform.Multiply(aTransform);
                    double angle2 = tTransform.OfVector(XYZ.BasisX).AngleTo(aTransform.OfVector(XYZ.BasisX));
                    // TODO:25.8.28 不需要对视图进行旋转，但因为没有旋转的原因，需对视图进行额外的位移
                    ElementTransformUtils.RotateElements(doc, newIds, axis2, angle2);

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
                    //pt1 = targetVCI.CurrentView.CropBox.Transform.OfPoint(sourceVCI.CurrentView.CropBox.Transform.Inverse.OfPoint(pt1));

                    XYZ pt2 = doc.GetElement(newIds.First()).get_BoundingBox(targetView).Max
                        - targetVCI.ViewOrigin;
                    // TODO:25.8.28 不同方向的板块不能用此方法(pt1, pt2)获取位移的距离与方向
                    ElementTransformUtils.MoveElements(doc, newIds, pt1 - pt2);
                    */

                    
                    /*
                    List<ElementId> newIds = ElementTransformUtils.CopyElements(
                        doc.ActiveView, sourceVCI.AnnotationItemIds, targetView,
                        Transform.Identity, copyPasteOptions).ToList();
                    Line axis2 = Line.CreateUnbound(targetVCI.ViewOrigin,
                        targetView.UpDirection.CrossProduct(targetView.RightDirection));

                    Transform tTransform = targetVCI.CurrentView.CropBox.Transform;
                    tTransform.Origin = XYZ.Zero;
                    Transform aTransform = targetVCI.HostInstance.GetTransform();
                    aTransform.Origin = XYZ.Zero;

                    //Transform transform = tTransform.Multiply(aTransform);
                    double angle2 = tTransform.OfVector(XYZ.BasisX).AngleTo(aTransform.OfVector(XYZ.BasisX));
                    // TODO:25.8.28 不需要对视图进行旋转，但因为没有旋转的原因，需对视图进行额外的位移
                    ElementTransformUtils.RotateElements(doc, newIds, axis2, angle2);

                    //Line axis2 = Line.CreateUnbound((targetVCI.HostInstance.Location as LocationPoint).Point,
                    //    targetView.UpDirection.CrossProduct(targetView.RightDirection));
                    //double angle2 = tTransform.OfVector(XYZ.BasisX).AngleTo(aTransform.OfVector(XYZ.BasisX));
                    //ElementTransformUtils.RotateElements(doc, newIds, axis2, angle2);

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
                    //pt1 = targetVCI.CurrentView.CropBox.Transform.OfPoint(sourceVCI.CurrentView.CropBox.Transform.Inverse.OfPoint(pt1));

                    XYZ pt2 = doc.GetElement(newIds.First()).get_BoundingBox(targetView).Max
                        - targetVCI.ViewOrigin;
                    // TODO:25.8.28 不同方向的板块不能用此方法(pt1, pt2)获取位移的距离与方向
                    ElementTransformUtils.MoveElements(doc, newIds, pt1 - pt2);
                    */

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

                                Dimension dim;
                                try
                                {
                                    dim = doc.Create.NewDimension(targetView, dimInfo.Line, dimInfo.References, dimInfo.DimType);
                                }
                                catch (Exception ex)
                                {
                                    //TaskDialog.Show("error", ex.Message);
                                    continue;
                                }


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

        private double GetTolerance(Document doc, ViewContentInfo sourceVCI, ViewContentInfo targetVCI)
        {
            double result = 0.1;

            try
            {
                FamilyInstance instance = GetMainElement(sourceVCI.HostInstance) as FamilyInstance;
                FamilyInstance sFlatMember = GetFlatMember(doc, instance);

                FamilyInstance instance2 = GetMainElement(targetVCI.HostInstance) as FamilyInstance;
                FamilyInstance tFlatMember = GetFlatMember(doc, instance2);

                double sLength = sFlatMember.LookupParameter("DIM_LENGTH").AsDouble();
                double sWidth = sFlatMember.LookupParameter("DIM_WIDTH").AsDouble();
                double tLength = tFlatMember.LookupParameter("DIM_LENGTH").AsDouble();
                double tWidth = tFlatMember.LookupParameter("DIM_WIDTH").AsDouble();

                result = Math.Max(Math.Abs(sLength - tLength), Math.Abs(sWidth - tWidth))
                    + Math.Abs(GetDistanceToOrigin(sFlatMember, sourceVCI.ViewOrigin) - GetDistanceToOrigin(tFlatMember, targetVCI.ViewOrigin))
                    + 50 / 304.8;
            }
            catch (Exception)
            {
            }


            return result;
        }

        private double GetPointToTopFace(string dimPosition, XYZ point, PlanarFace leftFace, PlanarFace rightFace, PlanarFace botFace, PlanarFace topFace)
        {
            double result = -1;

            switch (dimPosition)
            {
                case "LEFT":
                    result = PointToFace(point, leftFace);
                    break;
                case "RIGHT":
                    result = PointToFace(point, rightFace);
                    break;
                case "BOTTOM":
                    result = PointToFace(point, botFace);
                    break;
                case "TOP":
                    result = PointToFace(point, topFace);
                    break;
                default:
                    break;
            }

            return result;
        }
        private bool GetTwoTagHostPosition(XYZ hostP, PlanarFace leftFace, PlanarFace rightFace, PlanarFace botFace, PlanarFace topFace, out string upHostPosition, out double upDis, out string rightHostPosition, out double rightDis)
        {
            bool result = true;

            double num = PointToFace(hostP, topFace);
            double num2 = PointToFace(hostP, botFace);
            if (num < num2)
            {
                upHostPosition = "TOP";
                upDis = PointToFace(hostP, topFace);
            }
            else
            {
                upHostPosition = "BOTTOM";
                upDis = PointToFace(hostP, botFace);
            }

            double num3 = PointToFace(hostP, leftFace);
            double num4 = PointToFace(hostP, rightFace);
            if (num3 < num4)
            {
                rightHostPosition = "LEFT";
                rightDis = PointToFace(hostP, leftFace);
            }
            else
            {
                rightHostPosition = "RIGHT";
                rightDis = PointToFace(hostP, rightFace);
            }


            return result;
        }
        private string GetDimPosition(Dimension dim, PlanarFace leftFace, PlanarFace rightFace, PlanarFace botFace, PlanarFace topFace, XYZ point, out double distance, View view)
        {
            distance = 0;
            string result = string.Empty;

            if (dim.Curve == null || dim.Curve as Line == null) return null;
            Line line = dim.Curve as Line;

            XYZ origin = line.Origin;
            XYZ lineDir = line.Direction;
            XYZ upDir = view.UpDirection;
            XYZ rightDir = view.RightDirection;

            // 尺寸标注与upDir方向垂直
            if (Math.Abs(lineDir.DotProduct(upDir)) < 0.001)
            {
                double num = PointToFace(origin, topFace);
                double num2 = PointToFace(origin, botFace);
                if (num < num2)
                {
                    result = "TOP";
                    distance = PointToFace(point, topFace);
                }
                if (num > num2)
                {
                    result = "BOTTOM";
                    distance = PointToFace(point, botFace);
                }
            }
            // 尺寸标注方向与rightDir垂直
            else if (Math.Abs(lineDir.DotProduct(rightDir)) < 0.001)
            {
                double num = PointToFace(origin, leftFace);
                double num2 = PointToFace(origin, rightFace);
                if (num < num2)
                {
                    result = "LEFT";
                    distance = PointToFace(point, leftFace);
                }
                if (num > num2)
                {
                    result = "RIGHT";
                    distance = PointToFace(point, rightFace);
                }
            }

            return result;
        }
        private double GetOtherPointToTopFace(string dimPosition, XYZ point, PlanarFace leftFace, PlanarFace rightFace, PlanarFace botFace, PlanarFace topFace)
        {
            double result = -1;

            switch (dimPosition)
            {
                case "LEFT":
                    result = PointToFace(point, topFace);
                    break;
                case "RIGHT":
                    result = PointToFace(point, botFace);
                    break;
                case "BOTTOM":
                    result = PointToFace(point, leftFace);
                    break;
                case "TOP":
                    result = PointToFace(point, rightFace);
                    break;
                default:
                    break;
            }

            return result;
        }
        public List<PlanarFace> GetPlanarFaces(List<Face> faces)
        {
            List<PlanarFace> list = new List<PlanarFace>();
            foreach (Face face in faces)
            {
                PlanarFace planarFace = face as PlanarFace;
                bool flag = planarFace != null;
                if (flag)
                {
                    list.Add(planarFace);
                }
            }
            return list;
        }
        public double PointToFace(XYZ point, PlanarFace face)
        {
            XYZ faceNormal = face.FaceNormal;
            XYZ xYZ = point - face.Origin;
            return Math.Abs(xYZ.DotProduct(faceNormal) / faceNormal.GetLength());
        }
        public PlanarFace GetTopFace(IList<PlanarFace> faces, XYZ direction)
        {
            PlanarFace result = null;
            double num = double.MinValue;
            XYZ point = new XYZ();
            double num2 = double.MinValue;
            foreach (PlanarFace face in faces)
            {
                foreach (EdgeArray edgeArray in face.EdgeLoops)
                {
                    foreach (Edge edge in edgeArray)
                    {
                        Curve curve = edge.AsCurve();
                        bool flag = curve == null;
                        if (!flag)
                        {
                            XYZ endPoint = curve.GetEndPoint(0);
                            XYZ endPoint2 = curve.GetEndPoint(1);
                            double num3 = endPoint.DotProduct(direction);
                            double num4 = endPoint2.DotProduct(direction);
                            bool flag2 = num3 > num2;
                            if (flag2)
                            {
                                point = endPoint;
                                num2 = num3;
                            }
                            bool flag3 = num4 > num2;
                            if (flag3)
                            {
                                point = endPoint2;
                                num2 = num4;
                            }
                        }
                    }
                }
            }
            List<PlanarFace> list = new List<PlanarFace>();
            foreach (PlanarFace face2 in faces)
            {
                double num5 = PointToFace(point, face2);
                bool flag4 = num5 < 0.001;
                if (flag4)
                {
                    list.Add(face2);
                }
            }
            foreach (PlanarFace face3 in list)
            {
                XYZ faceNormal = face3.FaceNormal;
                double num6 = faceNormal.DotProduct(direction);
                bool flag5 = num6 > num;
                if (flag5)
                {
                    result = face3;
                    num = num6;
                }
            }
            return result;
        }
        public FamilyInstance GetSuperInstance(FamilyInstance instance)
        {
            FamilyInstance familyInstance = instance;
            bool flag = instance.SuperComponent != null;
            while (flag)
            {
                familyInstance = (familyInstance.SuperComponent as FamilyInstance);
                flag = (((familyInstance != null) ? familyInstance.SuperComponent : null) != null);
            }
            return familyInstance;
        }
        public FamilyInstance GetFlatMember(Document doc, FamilyInstance instance)
        {
            FamilyInstance result;
            if (instance.Symbol.Name.Contains("_FLAT"))
            {
                result = instance;
            }
            else
            {
                FamilyInstance superInstance = this.GetSuperInstance(instance);
                foreach (ElementId id in superInstance.GetSubComponentIds())
                {
                    FamilyInstance familyInstance = doc.GetElement(id) as FamilyInstance;
                    if (familyInstance != null)
                    {
                        string familyName = familyInstance.Symbol.FamilyName;
                        if (familyName.Contains("_FLAT"))
                        {
                            result = familyInstance;
                            return result;
                        }
                    }
                }
                result = superInstance;
            }
            return result;
        }
        public Element GetMainElement(AssemblyInstance assemblyInstance)
        {
            Element element = null;
            Document document = assemblyInstance.Document;
            ICollection<ElementId> memberIds = assemblyInstance.GetMemberIds();
            List<FamilyInstance> list = new List<FamilyInstance>();
            FilteredElementCollector filteredElementCollector = new FilteredElementCollector(document, memberIds);
            IList<Element> list2 = filteredElementCollector.OfClass(typeof(FamilyInstance)).OfCategory(BuiltInCategory.OST_StructuralFraming).ToElements();
            foreach (Element elem in list2)
            {
                FamilyInstance familyInstance = elem as FamilyInstance;
                if (familyInstance != null)
                {
                    Parameter markPara = familyInstance.LookupParameter("CONTROL_MARK");
                    string text = markPara?.AsString() ?? "";

                    if (!string.IsNullOrEmpty(text))
                    {
                        if (text == assemblyInstance.AssemblyTypeName)
                        {
                            list.Add(familyInstance);
                        }
                    }
                }
            }
            Element result;
            if (list.Count == 0)
            {
                result = null;
            }
            else
            {
                FamilyInstance familyInstance2 = null;
                foreach (FamilyInstance current2 in list)
                {
                    bool flag5 = current2.Symbol.Name.Contains("_FLAT");
                    if (flag5)
                    {
                        familyInstance2 = current2;
                    }
                }
                bool flag6 = familyInstance2 != null;
                if (flag6)
                {
                    element = familyInstance2;
                }
                bool flag7 = element == null;
                if (flag7)
                {
                    element = list[0];
                }
                result = element;
            }
            return result;
        }
        public List<Face> GetFaceByElement(Element item, Options options)
        {
            List<Face> listFace = new List<Face>();
            // 根据打开的方式得到几何信息
            GeometryElement geometry = item.get_Geometry(options);
            foreach (GeometryObject geomObj in geometry)
            {
                GeometryInstance geomInstance = geomObj as GeometryInstance;
                if (geomInstance != null)
                {
                    foreach (GeometryObject instObj in geomInstance.GetInstanceGeometry())
                    {
                        // 三维的实体
                        Solid instsolid = instObj as Solid;
                        if (instsolid == null || instsolid.Faces.Size == 0 || instsolid.Edges.Size == 0)
                        {
                            continue;
                        }
                        foreach (Face face in instsolid.Faces)
                        {
                            listFace.Add(face);
                        }
                    }
                }
                Solid solid = geomObj as Solid;
                if (solid != null)
                {
                    if (solid.Faces.Size == 0 || solid.Edges.Size == 0)
                    {
                        continue;
                    }
                    else
                    {
                        foreach (Face face in solid.Faces)
                        {
                            listFace.Add(face);
                        }
                    }
                }
            }
            return listFace;
        }
        public Dictionary<string, List<FIInfo>> GetInstanceDict(Document doc, DimensionInfo dimInfo, PlanarFace leftFace, PlanarFace rightFace, PlanarFace botFace, PlanarFace topFace, XYZ point, View view)
        {
            var references = dimInfo.References.Cast<Reference>().ToList();

            string dimPosition = GetDimPosition(dimInfo.Dim, leftFace, rightFace, botFace, topFace, point, out double topDis, view);
            references = references.Where(r => { Element e = doc.GetElement(r); if (e.Location != null && e.Location is LocationPoint) return true; return false; }).ToList();
            references = references.OrderBy(r => { XYZ p = (doc.GetElement(r).Location as LocationPoint).Point; return GetPointToTopFace(dimPosition, p, leftFace, rightFace, botFace, topFace); })
                .ThenBy(r => { XYZ p = (doc.GetElement(r).Location as LocationPoint).Point; return GetOtherPointToTopFace(dimPosition, p, leftFace, rightFace, botFace, topFace); })
                .ToList();

            return GetInstanceDict(doc, references);

        }
        // symbolName;familyInstance.Id;reference.ConvertToStableRepresentation
        public Dictionary<string, List<FIInfo>> GetInstanceDict(Document doc, List<Reference> references)
        {
            Dictionary<string, List<FIInfo>> dictionary = new Dictionary<string, List<FIInfo>>();
            foreach (Reference reference in references)
            {
                Element element = doc.GetElement(reference);
                if (!(element is FamilyInstance)) continue;
                if (element.Location == null) continue;
                if (!(element.Location is LocationPoint)) continue;

                FamilyInstance familyInstance = (FamilyInstance)element;

                if (familyInstance != null)
                {
                    string symbolName = GetSymbolName(familyInstance);
                    if (dictionary.ContainsKey(symbolName))
                    {
                        dictionary[symbolName].Add(new FIInfo(familyInstance, reference.ConvertToStableRepresentation(doc)));
                    }
                    else
                    {
                        dictionary[symbolName] = new List<FIInfo>()
                        {
                            new FIInfo(familyInstance, reference.ConvertToStableRepresentation(doc))
                        };

                    }
                }
            }
            return dictionary;
        }
        private string GetTagLocalElementSymbolName(TagInfo tagInfo)
        {
            FamilyInstance host = tagInfo.Tag.GetTaggedLocalElements().First() as FamilyInstance;
            return host.Symbol.Name + ":" + host.Symbol.FamilyName;
        }
        private string GetSymbolName(FamilyInstance familyInstance)
        {
            return familyInstance.Symbol.Name + ":" + familyInstance.Symbol.FamilyName;
        }
        private double GetDistanceToOrigin(FamilyInstance fi, XYZ origin)
        {
            double distance = -1;

            if (fi.Location != null && fi.Location is LocationPoint locationPoint)
            {
                distance = (locationPoint.Point - origin).GetLength();
            }

            return distance;
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
    public class FIInfo
    {
        public FIInfo(FamilyInstance familyInstance, string referenceCTSR)
        {
            FamilyInstance = familyInstance;
            ReferenceCTSR = referenceCTSR;
        }
        public FamilyInstance FamilyInstance { get; set; }
        public string ReferenceCTSR { get; set; }
    }
}
