using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
{
    //用于复制视图内容
    //需要复制的内容包括
    //文字 线条 详图 详图组
    //标签
    //尺寸标注
    //剖面，大样
    public class ViewContentInfo2
    {
        public AssemblyInstance HostInstance { get; set; }
        public FamilyInstance MainPanel { get; set; }
        public Document Doc { get; set; }
        public View View { get; set; }
        public XYZ ViewOrigin { get; set; }
        public List<Element> ViewElements { get; set; }
        public List<EmbedRebarInfo> EmbedRebarInfos { get; set; }
        public List<PanelCorberInfo> PanelCorberInfos { get; set; }
        public List<ElementId> AnnotationItemIds { get; set; }
        public List<ElementId> ViewerItemIds { get; set; }
        public List<TagInfo> TagInfos { get; set; }
        public List<DimensionInfo> DimensionInfos { get; set; }
        public List<Element> SectionCallouts { get; set; }

        //上下左右四个面的引用
        public List<Reference> UpReferences { get; set; }
        public Reference UpReference { get; set; }
        public List<Reference> DownReferences { get; set; }
        public Reference DownReference { get; set; }
        public List<Reference> LeftReferences { get; set; }
        public Reference LeftReference { get; set; }
        public List<Reference> RightReferences { get; set; }
        public Reference RightReference { get; set; }

        public ViewContentInfo2(Autodesk.Revit.DB.View view)
        {
            Doc = view.Document;
            View = view;
            HostInstance = Doc.GetElement(view.AssociatedAssemblyInstanceId) as AssemblyInstance;
            MainPanel = GetMainPanel();
            ViewOrigin = HostInstance.GetTransform().OfPoint(XYZ.Zero);
            ViewElements = new FilteredElementCollector(Doc, Doc.ActiveView.Id).ToElements().ToList();
            InitBoundaryReferences();
        }

        public void CollectTagInfos()
        {
            TagInfos = new List<TagInfo>();
            foreach (Element element in ViewElements)
            {
                if (element is IndependentTag)
                {
                    IndependentTag tag = element as IndependentTag;
                    //Element taggedElement = Doc.GetElement(tag.TaggedLocalElementId);//2021API
                    Element taggedElement = Doc.GetElement(tag.GetTaggedLocalElementIds().First());

                    //create a tagInfo
                    TagInfo tagInfo = new TagInfo();
                    tagInfo.Tag = tag;
                    tagInfo.TagSymbol = Doc.GetElement(tag.GetTypeId()) as FamilySymbol;
                    tagInfo.Orientation = tag.TagOrientation;
                    tagInfo.HasLeader = tag.HasLeader;
                    if (tagInfo.HasLeader)
                    {
                        //tagInfo.HasElbow = tag.HasElbow;//2021API
                        tagInfo.HasElbow =
                            tag.GetLeaderElbow(new Reference(taggedElement)) != null;

                        if (tagInfo.HasElbow)
                        {
                            //tagInfo.LeaderElbow = tag.LeaderElbow - ViewOrigin;//2021API
                            tagInfo.LeaderElbow =
                                tag.GetLeaderElbow(new Reference(taggedElement)) - ViewOrigin;
                        }
                        tagInfo.LeaderEndCondition = tag.LeaderEndCondition;
                        if (tag.LeaderEndCondition == LeaderEndCondition.Free)
                        {
                            //tagInfo.LeaderEnd = tag.LeaderEnd - ViewOrigin;//2021API
                            tagInfo.LeaderEnd =
                                tag.GetLeaderEnd(new Reference(taggedElement)) - ViewOrigin;
                        }
                    }
                    tagInfo.TaggedElement = taggedElement;
                    tagInfo.TagXYZ = tag.TagHeadPosition - ViewOrigin;
                    tagInfo.TaggedElementXYZ = (taggedElement.Location as LocationPoint).Point;
                    TagInfos.Add(tagInfo);
                }
            }
        }
        public void CollectAnnotationItems()
        {
            AnnotationItemIds = new List<ElementId>();
            ViewerItemIds = new List<ElementId>();
            foreach (Element element in ViewElements)
            {
                if (null != element.Category)
                {
                    int idInt = element.Category.Id.IntegerValue;
                    if (idInt == (int)BuiltInCategory.OST_TextNotes
                    || idInt == (int)BuiltInCategory.OST_Lines
                    || idInt == (int)BuiltInCategory.OST_GenericAnnotation
                    || idInt == (int)BuiltInCategory.OST_DetailComponents
                    || idInt == (int)BuiltInCategory.OST_IOSDetailGroups
                    || idInt == (int)BuiltInCategory.OST_RevisionClouds)
                    {
                        AnnotationItemIds.Add(element.Id);
                    }
                    if (idInt == (int)BuiltInCategory.OST_Viewers && element.ViewSpecific)
                    {
                        ViewerItemIds.Add(element.Id);
                    }
                }
            }
        }

        public void CollectDimensionInfos()
        {
            DimensionInfos = new List<DimensionInfo>();
            foreach (Element element in ViewElements)
            {
                if (element is Dimension)
                {
                    Dimension dim = element as Dimension;

                    //create a dimInfo
                    DimensionInfo dimInfo = new DimensionInfo();
                    dimInfo.Dim = dim;
                    dimInfo.DimType = Doc.GetElement(dim.GetTypeId()) as DimensionType;
                    dimInfo.References = dim.References;
                    dimInfo.Segments = dim.Segments;
                    dimInfo.Line = dim.Curve as Line;
                    DimensionInfos.Add(dimInfo);
                }
            }
        }

        public void InitAssemblyMemberInfos()
        {
            Options opt = new Options();
            opt.View = Doc.ActiveView;
            opt.ComputeReferences = true;

            EmbedRebarInfos = new List<EmbedRebarInfo>();
            PanelCorberInfos = new List<PanelCorberInfo>();
            foreach (ElementId id in HostInstance.GetMemberIds())
            {
                Element e = Doc.GetElement(id);
                if (e.Location is LocationPoint && e is FamilyInstance)
                {
                    XYZ loc = (e.Location as LocationPoint).Point;
                    if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        PanelCorberInfo panelCorberInfo = new PanelCorberInfo();
                        panelCorberInfo.Location = loc;
                        panelCorberInfo.Host = e as FamilyInstance;
                        //references
                        panelCorberInfo.References = new List<Reference>();
                        List<Solid> solids = Utils.GetElementSymbolSolids(e, opt);
                        foreach (Solid solid in solids)
                        {
                            if (null == solid || 0 == solid.Faces.Size || 0 == solid.Edges.Size)
                            {
                                continue;
                            }
                            foreach (Face f in solid.Faces)
                            {
                                if (f.Area > 0 && f.Reference != null)
                                {
                                    panelCorberInfo.References.Add(f.Reference);
                                }
                            }
                            foreach (Edge ed in solid.Edges)
                            {
                                if (ed.ApproximateLength > 0 && ed.Reference != null)
                                {
                                    panelCorberInfo.References.Add(ed.Reference);
                                }
                            }
                        }
                        PanelCorberInfos.Add(panelCorberInfo);
                    }
                    if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_SpecialityEquipment)
                    {
                        EmbedRebarInfo embedRebarInfo = new EmbedRebarInfo();
                        embedRebarInfo.Host = e as FamilyInstance;
                        embedRebarInfo.Location = loc;
                        EmbedRebarInfos.Add(embedRebarInfo);
                    }
                }
            }

        }

        public FamilyInstance GetMainPanel()
        {
            foreach (ElementId id in HostInstance.GetMemberIds())
            {
                Element e = Doc.GetElement(id);
                if (e.Location is LocationPoint && e is FamilyInstance)
                {
                    if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        if (!e.Name.Contains("CORBEL") && !e.Name.Contains("LEDGE"))
                        {
                            return e as FamilyInstance;
                        }
                    }
                }
            }
            return null;
        }

        public void InitBoundaryReferences()
        {
            if (MainPanel == null) return;

            Options opt = new Options();
            opt.View = View;
            opt.ComputeReferences = true;
            Transform transform = MainPanel.GetTransform();
            GeometryElement geometryElement = MainPanel.get_Geometry(opt);
            //View currentView = Doc.ActiveView;
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
                            //solid = SolidUtils.CreateTransformed(solid, transform);
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
            if (solid == null) return;
            UpReferences = GetFaceReferences(View.UpDirection, solid.Faces);
            if (UpReferences.Count > 0) { UpReference = UpReferences.First(); }
            DownReferences = GetFaceReferences(View.UpDirection.Negate(), solid.Faces);
            if (DownReferences.Count > 0) { DownReference = DownReferences.First(); }
            LeftReferences = GetFaceReferences(View.RightDirection.Negate(), solid.Faces);
            if (LeftReferences.Count > 0) { LeftReference = LeftReferences.First(); }
            RightReferences = GetFaceReferences(View.RightDirection, solid.Faces);
            if (RightReferences.Count > 0) { RightReference = RightReferences.First(); }
        }

        private List<Reference> GetFaceReferences(XYZ viewDir, FaceArray faces)
        {
            List<PlanarFace> planarFaces = new List<PlanarFace>();
            foreach (Face face in faces)
            {
                if (face is PlanarFace planarFace1 && planarFace1.FaceNormal.IsAlmostEqualTo(viewDir))
                {
                    planarFaces.Add(planarFace1);
                }
            }
            if (planarFaces.Count == 1) return planarFaces.Select(u => u.Reference).ToList();
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
                return samePPDirFaces.Select(u => u.Reference).ToList();
            }
            if (nePPDirFaces.Count > 0)
            {
                return nePPDirFaces.Select(u => u.Reference).ToList();
            }
            return planarFaces.Select(u => u.Reference).ToList();
        }

        public Reference FindBoundaryReference(Reference sourceRef, ViewContentInfo2 targetVCI)
        {
            //TaskDialog.Show("r", string.Format("{0},{1},{2},{3}|{4},{5},{6},{7}",
            //    UpReferences.Count(), DownReferences.Count(), LeftReferences.Count(), RightReferences.Count(),
            //    targetVCI.UpReferences.Count(), targetVCI.DownReferences.Count(), targetVCI.LeftReferences.Count(), targetVCI.RightReferences.Count()));

            //TaskDialog.Show("r", (UpReferences.Count()).ToString());

            var list1 = UpReferences.Where(u => u.EqualTo(sourceRef));
            if (list1.Count() > 0) { 
                //TaskDialog.Show("r", "Up");
                return targetVCI.UpReference; } 
            var list2 = DownReferences.Where(u => u.EqualTo(sourceRef));
            if (list2.Count() > 0) { 
                //TaskDialog.Show("r", "Down");
                return targetVCI.DownReference; }
            var list3 = LeftReferences.Where(u => u.EqualTo(sourceRef));
            if (list3.Count() > 0) { 
                //TaskDialog.Show("r", "Left"); 
                return targetVCI.LeftReference; }
            var list4 = RightReferences.Where(u => u.EqualTo(sourceRef));
            if (list4.Count() > 0) { 
                //TaskDialog.Show("r", "Right"); 
                return targetVCI.RightReference; }
            return null;
        }

        #region GetInstanceReference
        /// <summary>
        /// 埋件中心线
        /// </summary>
        /// <param name="fi">埋件</param>
        /// <param name="direction">平行于尺寸线方向</param>
        /// <returns></returns>
        public Reference GetInstanceReference(FamilyInstance fi, XYZ direction)
        {
            XYZ xDir = fi.GetTransform().OfVector(XYZ.BasisX);
            XYZ yDir = fi.GetTransform().OfVector(XYZ.BasisY);

            if (direction.IsAlmostEqualTo(xDir) | direction.IsAlmostEqualTo(xDir.Negate()))
            {
                return fi.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First();
            }
            else if (direction.IsAlmostEqualTo(yDir) | direction.IsAlmostEqualTo(yDir.Negate()))
            {
                return fi.GetReferences(FamilyInstanceReferenceType.CenterFrontBack).First();
            }
            else
            {
                //埋件不是基于面的
                //埋件无法标注
                return null;
            }
        }

        /// <summary>
        /// 埋件中心线集合
        /// </summary>
        /// <param name="fiList">埋件集合</param>
        /// <param name="direction">垂直于尺寸线方向</param>
        /// <returns></returns>
        public List<Reference> GetInstanceReferences(List<FamilyInstance> fiList, XYZ direction)
        {
            List<Reference> refList = new List<Reference>();
            foreach (var fi in fiList)
            {
                refList.Add(GetInstanceReference(fi, direction));
            }
            return refList;
        }
        #endregion

    }
}
