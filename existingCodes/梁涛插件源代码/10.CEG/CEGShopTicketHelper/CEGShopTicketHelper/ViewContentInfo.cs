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
    public class ViewContentInfo
    {
        public AssemblyInstance HostInstance { get; set; }
        public View CurrentView { get; set; }
        public Document Doc { get; set; }
        public XYZ ViewOrigin { get; set; }
        public List<Element> ViewElements { get; set; }
        public List<EmbedRebarInfo> EmbedRebarInfos { get; set; }
        public List<PanelCorberInfo> PanelCorberInfos { get; set; }
        public List<ElementId> AnnotationItemIds { get; set; }
        public List<TagInfo> TagInfos { get; set; }
        public List<DimensionInfo> DimensionInfos { get; set; }
        public List<Element> SectionCallouts { get; set; }

        public ViewContentInfo(Autodesk.Revit.DB.View view)
        {
            CurrentView = view;
            Doc = view.Document;
            HostInstance = Doc.GetElement(view.AssociatedAssemblyInstanceId) as AssemblyInstance;
            ViewOrigin = HostInstance.GetTransform().OfPoint(XYZ.Zero);
            ViewElements = new FilteredElementCollector(Doc, Doc.ActiveView.Id).ToElements().ToList();
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
                        //tagInfo.HasElbow =
                        //    tag.GetLeaderElbow(new Reference(taggedElement)) != null;
                        tagInfo.HasElbow =
                            tag.HasLeaderElbow(new Reference(taggedElement));

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
                    try
                    {
                        tagInfo.TaggedElementXYZ = (taggedElement.Location as LocationPoint).Point;
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    
                    TagInfos.Add(tagInfo);
                }
            }
        }
        public void CollectAnnotationItems()
        {
            AnnotationItemIds = new List<ElementId>();
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
                        AnnotationItemIds.Add(element.Id);
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
    }

    public class TagInfo
    {
        public IndependentTag Tag { get; set; }
        public FamilySymbol TagSymbol { get; set; }
        public TagOrientation Orientation { get; set; }
        public bool HasLeader { get; set; }
        public bool HasElbow { get; set; }
        public XYZ LeaderElbow { get; set; }
        public XYZ LeaderEnd { get; set; }
        public LeaderEndCondition LeaderEndCondition { get; set; }
        public Element TaggedElement { get; set; }
        public XYZ TagXYZ { get; set; }
        public XYZ TaggedElementXYZ { get; set; }
    }

    public class EmbedRebarInfo
    {
        public FamilyInstance Host { get; set; }
        public XYZ Location { get; set; }
    }

    public class PanelCorberInfo
    {
        public FamilyInstance Host { get; set; }
        public XYZ Location { get; set; }
        public List<Reference> References { get; set; }
    }

    public class DimensionInfo
    {
        public Dimension Dim { get; set; }
        public DimensionType DimType { get; set; }
        public ReferenceArray References { get; set; }
        public DimensionSegmentArray Segments { get; set; }
        public Line Line { get; set; }

        public void CopySegments(Dimension dim)
        {
            for (int i = 0; i < Segments.Size; i++)
            {
                DimensionSegment seg1 = Segments.get_Item(i);
                DimensionSegment seg2 = dim.Segments.get_Item(i);
                seg2.Below = seg1.Below;
            }
            //foreach (DimensionSegment seg in dim.Segments)
            //{
            //    seg.Above
            //}
        }
    }
}
