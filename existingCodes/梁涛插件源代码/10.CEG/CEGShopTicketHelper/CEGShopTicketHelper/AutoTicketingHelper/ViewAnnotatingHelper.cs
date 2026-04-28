using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public class ViewAnnotatingHelper
    {
        public Document Doc { get; set; }//当前文档
        public View CurrentView { get; set; }//当前视图
        public AssemblyInstance Assembly { get; set; }//当前部件
        public FamilyInstance PCaPanel { get; set; }//板块
        public List<FamilyInstance> EmbedList { get; set; }//埋件列表


        public double dimSpacing = 1.5;//尺寸间距
        public ElementId embedTagTypeId = null;
        public ElementId embedTagLargeTypeId = null;
        public ElementId bentBarTagTypeId = null;
        public ElementId strBarTagTypeId = null;
        public string embedTagFamilyName = "SPECIALTY EQUIPMENT TEXT(NO DES)";
        public string embedTagTypeName = "No Leaders";
        public string embedTagLargeFamilyName = "SPECIALTY EQUIPMENT TEXT_WIDEN(NO DES)";
        public string embedTagLargeTypeName = "No Leaders";
        public string bentBarTagFamilyName = "LEGACY_REBAR_TAG";
        public string bentBarTagTypeName = "No Leaders";
        public string strBarTagFamilyName = "LEGACY_STRBAR_TAG";
        public string strBarTagTypeName = "StraightBar ARROW";
        public ElementId textNodeTypeId = null;
        public string textNodeTypeName = "3/32\" Arial Narrow";


        public Face SideAFaceSymbol { get; set; }
        public Face SideBFaceSymbol { get; set; }
        public Face End1FaceSymbol { get; set; }
        public Face End2FaceSymbol { get; set; }
        public Face TopFaceSymbol { get; set; }
        public Face SoffitFaceSymbol { get; set; }

        public Face SideAFaceInstance { get; set; }
        public Face SideBFaceInstance { get; set; }
        public Face End1FaceInstance { get; set; }
        public Face End2FaceInstance { get; set; }
        public Face TopFaceInstance { get; set; }
        public Face SoffitFaceInstance { get; set; }

        public XYZ DirUp { get; set; }
        public XYZ DirDown { get; set; }
        public XYZ DirLeft { get; set; }
        public XYZ DirRight { get; set; }
        public XYZ DirTop { get; set; }
        public XYZ DirSoffit { get; set; }
        public XYZ PtLeftUpCorner { get; set; }
        public XYZ PtRightUpCorner { get; set; }
        public XYZ PtLeftDownCorner { get; set; }
        public XYZ PtRightDownCorner { get; set; }

        public List<List<FamilyInstance>> SideAEmbedGroups { get; set; }
        public List<List<FamilyInstance>> SideBEmbedGroups { get; set; }
        public List<List<FamilyInstance>> End1EmbedGroups { get; set; }
        public List<List<FamilyInstance>> End2EmbedGroups { get; set; }
        public List<List<FamilyInstance>> TopEmbedGroups { get; set; }
        public List<List<FamilyInstance>> SoffitEmbedGroups { get; set; }

        public ViewAnnotatingHelper(AssemblyInstance assembly, View currentView)
        {
            Doc = assembly.Document;
            CurrentView = currentView;
            Assembly = assembly;
            dimSpacing = dimSpacing * CurrentView.Scale / 64.0;

            //确定方向
            DirUp = currentView.UpDirection;//Y
            DirDown = DirUp.Negate();
            DirRight = currentView.RightDirection;//X
            DirLeft = DirRight.Negate();
            DirTop = DirUp.CrossProduct(DirLeft);//Z
            DirSoffit = DirTop.Negate();
            InitCornerPoints();

            //收集埋件
            EmbedList = new List<FamilyInstance>();
            foreach (ElementId id in assembly.GetMemberIds())
            {
                Element elem = Doc.GetElement(id);
                if (elem.Category.Id.IntegerValue
                    == (int)BuiltInCategory.OST_StructuralFraming)
                {
                    if (!elem.Name.Contains("CORBEL"))
                    {
                        //System.Windows.Forms.MessageBox.Show(elem.Name);
                        PCaPanel = elem as FamilyInstance;
                    }
                }
                if (elem.Category.Id.IntegerValue
                    == (int)BuiltInCategory.OST_SpecialityEquipment)
                {
                    string cegCategory = Utils.GetParameterByName(
                        (elem as FamilyInstance).Symbol,
                        "MANUFACTURE_COMPONENT");
                    if (null != cegCategory)
                    {
                        if (cegCategory.Contains("EMBED"))
                        {
                            EmbedList.Add(elem as FamilyInstance);
                        }
                    }
                }
            }

            //收集视图中的标记类型
            FilteredElementCollector col = new FilteredElementCollector(Doc);
            var symbolList = col.OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>();
            embedTagTypeId = symbolList.Where(
                u => u.Name == embedTagTypeName
                && u.FamilyName == embedTagFamilyName)
                .First().Id;
            embedTagLargeTypeId = symbolList.Where(
                u => u.Name == embedTagLargeTypeName
                && u.FamilyName == embedTagLargeFamilyName)
                .First().Id;
            bentBarTagTypeId = symbolList.Where(
                u => u.Name == bentBarTagTypeName
                && u.FamilyName == bentBarTagFamilyName)
                .First().Id;
            strBarTagTypeId = symbolList.Where(
                u => u.Name == strBarTagTypeName
                && u.FamilyName == strBarTagFamilyName)
                .First().Id;

            //收集视图中的文字类型
            FilteredElementCollector col2 = new FilteredElementCollector(Doc);
            var tntList = col2.OfClass(typeof(TextNoteType)).Cast<TextNoteType>();
            textNodeTypeId = tntList.Where(u => u.Name == textNodeTypeName).First().Id;


            InitEmbedGroups();
        }

        private void InitCornerPoints()
        {
            XYZ min = Assembly.get_BoundingBox(Doc.ActiveView).Min;
            XYZ max = Assembly.get_BoundingBox(Doc.ActiveView).Max;
            XYZ center = (min + max) / 2.0;
            XYZ v = min - max;
            double vertDistance = Math.Abs(v.DotProduct(DirDown));
            double horzDistance = Math.Abs(v.DotProduct(DirRight));
            PtLeftUpCorner = center + DirLeft * horzDistance / 2.0
                 + DirUp * vertDistance / 2.0;//左上
            PtRightUpCorner = PtLeftUpCorner + DirRight * horzDistance;//右上
            PtRightDownCorner = PtRightUpCorner + DirDown * vertDistance;//右下
            PtLeftDownCorner = PtLeftUpCorner + DirDown * vertDistance;//左下
        }

        //初始化埋件分组
        //及四个定位面
        public void InitEmbedGroups()
        {
            UV uv = new UV(0, 0);

            Options geOpt = new Options();
            geOpt.View = CurrentView;
            geOpt.ComputeReferences = true;//ensure we calculate the reference
            geOpt.IncludeNonVisibleObjects = true;
            List<Solid> symbolSolids = Utils.GetElementSymbolSolids(PCaPanel, geOpt);
            foreach (Solid solid in symbolSolids)
            {
                if (null == solid || 0 == solid.Faces.Size || 0 == solid.Edges.Size)
                {
                    continue;
                }
                foreach (Face f in solid.Faces)
                {
                    XYZ normal = PCaPanel.GetTransform()
                        .OfVector(f.ComputeNormal(uv));
                    normal = f.ComputeNormal(uv);
                    if (normal.IsAlmostEqualTo(DirUp))
                    {
                        SideAFaceSymbol = f;
                    }
                    if (normal.IsAlmostEqualTo(DirDown))
                    {
                        SideBFaceSymbol = f;
                    }
                    if (normal.IsAlmostEqualTo(DirLeft))
                    {
                        End1FaceSymbol = f;
                    }
                    if (normal.IsAlmostEqualTo(DirRight))
                    {
                        End2FaceSymbol = f;
                    }
                    if (normal.IsAlmostEqualTo(DirTop))
                    {
                        TopFaceSymbol = f;
                    }
                    if (normal.IsAlmostEqualTo(DirSoffit))
                    {
                        SoffitFaceSymbol = f;
                    }
                }
            }

            List<Solid> instanceSolids = Utils.GetElementInstanceSolids(PCaPanel, geOpt);
            foreach (Solid solid in instanceSolids)
            {
                if (null == solid || 0 == solid.Faces.Size || 0 == solid.Edges.Size)
                {
                    continue;
                }
                foreach (Face f in solid.Faces)
                {
                    XYZ normal = f.ComputeNormal(uv);
                    if (normal.IsAlmostEqualTo(DirUp))
                    {
                        SideAFaceInstance = f;
                    }
                    if (normal.IsAlmostEqualTo(DirDown))
                    {
                        SideBFaceInstance = f;
                    }
                    if (normal.IsAlmostEqualTo(DirLeft))
                    {
                        End1FaceInstance = f;
                    }
                    if (normal.IsAlmostEqualTo(DirRight))
                    {
                        End2FaceInstance = f;
                    }
                    if (normal.IsAlmostEqualTo(DirTop))
                    {
                        TopFaceInstance = f;
                    }
                    if (normal.IsAlmostEqualTo(DirSoffit))
                    {
                        SoffitFaceInstance = f;
                    }
                }
            }

            List<FamilyInstance> sideAEmbedList = new List<FamilyInstance>();
            List<FamilyInstance> sideBEmbedList = new List<FamilyInstance>();
            List<FamilyInstance> end1EmbedList = new List<FamilyInstance>();
            List<FamilyInstance> end2EmbedList = new List<FamilyInstance>();
            List<FamilyInstance> topEmbedList = new List<FamilyInstance>();
            List<FamilyInstance> soffitEmbedList = new List<FamilyInstance>();

            //查找边上的埋件
            foreach (FamilyInstance embed in EmbedList)
            {
                if (!(embed.Location is LocationPoint))
                {
                    continue;
                }
                XYZ embedPt = (embed.Location as LocationPoint).Point;
                if (SideAFaceInstance.Project(embedPt) != null)
                {
                    if (SideAFaceInstance.Project(embedPt).Distance < 0.5)//6"
                    {
                        sideAEmbedList.Add(embed);
                    }
                }
                if (SideBFaceInstance.Project(embedPt) != null)
                {
                    if (SideBFaceInstance.Project(embedPt).Distance < 0.5)//6"
                    {
                        sideBEmbedList.Add(embed);
                    }
                }
                if (End1FaceInstance.Project(embedPt) != null)
                {
                    if (End1FaceInstance.Project(embedPt).Distance < 0.5)//6"
                    {
                        end1EmbedList.Add(embed);
                    }
                }
                if (End2FaceInstance.Project(embedPt) != null)
                {
                    if (End2FaceInstance.Project(embedPt).Distance < 0.5)//6"
                    {
                        end2EmbedList.Add(embed);
                    }
                }
            }
            //剩余的埋件中找top和soffit埋件
            foreach (FamilyInstance embed in EmbedList)
            {
                if (!(embed.Location is LocationPoint))
                {
                    continue;
                }
                XYZ embedPt = (embed.Location as LocationPoint).Point;
                if (!sideAEmbedList.Contains(embed)
                    && !sideBEmbedList.Contains(embed)
                    && !end1EmbedList.Contains(embed)
                    && !end2EmbedList.Contains(embed))
                {
                    if (TopFaceInstance.Project(embedPt) != null)
                    {
                        if (TopFaceInstance.Project(embedPt).Distance < 0.25)//3"
                        {
                            topEmbedList.Add(embed);
                        }
                    }
                    else if (SoffitFaceInstance.Project(embedPt) != null)
                    {
                        if (SoffitFaceInstance.Project(embedPt).Distance < 0.25)//3"
                        {
                            soffitEmbedList.Add(embed);
                        }
                    }
                }
            }

            //将埋件根据名字分组
            SideAEmbedGroups = sideAEmbedList.GroupBy(x => x.Name)
                .Select(x => x.ToList()).ToList();
            SideBEmbedGroups = sideBEmbedList.GroupBy(x => x.Name)
                .Select(x => x.ToList()).ToList();
            End1EmbedGroups = end1EmbedList.GroupBy(x => x.Name)
                .Select(x => x.ToList()).ToList();
            End2EmbedGroups = end2EmbedList.GroupBy(x => x.Name)
                .Select(x => x.ToList()).ToList();
            TopEmbedGroups = topEmbedList.GroupBy(x => x.Name)
                .Select(x => x.ToList()).ToList();
            SoffitEmbedGroups = soffitEmbedList.GroupBy(x => x.Name)
                .Select(x => x.ToList()).ToList();
        }

        #region AddSideEndText
        /// <summary>
        /// 创建定位文字
        /// </summary>
        public void AddSideEndText()
        {
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtLeftUpCorner + PtRightUpCorner) / 2.0 + DirUp * dimSpacing / 2.0,
                    "SIDE-A",
                    new TextNoteOptions() { TypeId = textNodeTypeId });
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtLeftDownCorner + PtRightDownCorner) / 2.0 + DirDown * dimSpacing / 8.0,
                    "SIDE-B",
                    new TextNoteOptions() { TypeId = textNodeTypeId });
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtLeftUpCorner + PtLeftDownCorner) / 2.0 + DirLeft * dimSpacing / 2.0,
                    "END-1",
                    new TextNoteOptions() { TypeId = textNodeTypeId, Rotation = Math.PI / 2.0 , 
                        HorizontalAlignment = HorizontalTextAlignment.Center });
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtRightUpCorner + PtRightDownCorner) / 2.0 + DirRight * dimSpacing / 8.0,
                    "END-2",
                    new TextNoteOptions() { TypeId = textNodeTypeId, Rotation = Math.PI / 2.0,
                        HorizontalAlignment = HorizontalTextAlignment.Center });
        }
        #endregion

        #region OverallSideDim
        /// <summary>
        /// 横向总体标注
        /// </summary>
        public void OverallSideDim()
        {
            int indexOfDim = SideAEmbedGroups.Count + TopEmbedGroups.Count + 1;
            CreateSideDim(indexOfDim, new List<Reference>());
        }
        #endregion

        #region OverallEndDim
        /// <summary>
        /// 纵向整体标注
        /// </summary>
        public void OverallEndDim()
        {
            int indexOfDim = End1EmbedGroups.Count + TopEmbedGroups.Count + 1;
            CreateEndDim(indexOfDim, new List<Reference>());
        }
        #endregion

        public void GeomDim()
        {

        }

        #region SideDim
        /// <summary>
        /// 横向标注
        /// </summary>
        public void SideDim()
        {
            //确定尺寸的位置
            int indexOfDim = TopEmbedGroups.Count + 1;
            foreach (var group in SideAEmbedGroups)
            {
                //创建尺寸标注
                Dimension dim = CreateSideDim(indexOfDim, GetInstanceReferences(group, DirUp));
                //创建标签
                CreateSideDimInfo(dim, group, "SIDE-A");
                indexOfDim++;
            }
        }
        #endregion

        #region EndDim
        /// <summary>
        /// 纵向标注
        /// </summary>
        public void EndDim()
        {
            //确定尺寸的位置
            int indexOfDim = TopEmbedGroups.Count + 1;
            foreach (var group in End1EmbedGroups)
            {
                //创建尺寸标注
                Dimension dim = CreateEndDim(indexOfDim, GetInstanceReferences(group, DirLeft));
                //创建标签
                CreateEndDimInfo(dim, group, "END-1");
                indexOfDim++;
            }
        }
        #endregion

        #region TopDim
        /// <summary>
        /// 顶面标注
        /// </summary>
        public void TopDim()
        {
            //确定尺寸的位置
            int indexOfDim = 1;
            foreach (var group in TopEmbedGroups)
            {
                //创建尺寸标注1
                Dimension dim1 = CreateSideDim(indexOfDim, GetInstanceReferences(group, DirUp));
                //创建标签
                CreateSideDimInfo(dim1, group, "TOP");
                //创建尺寸标注2
                Dimension dim2 = CreateEndDim(indexOfDim, GetInstanceReferences(group, DirLeft));
                CreateLineBetweenDims(dim1, dim2);
                indexOfDim++;
            }
        }
        #endregion

        #region CreateSideDim
        /// <summary>
        /// 创建横向尺寸标注
        /// </summary>
        /// <param name="indexOfDim">尺寸标注序号</param>
        /// <param name="embedRefs">埋件中心线</param>
        /// <returns></returns>
        private Dimension CreateSideDim(int indexOfDim, List<Reference> embedRefs)
        {
            ReferenceArray refArray = new ReferenceArray();
            refArray.Append(End1FaceSymbol.Reference);
            foreach (Reference item in embedRefs)
            {
                refArray.Append(item);
            }
            refArray.Append(End2FaceSymbol.Reference);
            //创建尺寸标注
            Dimension dim = null;
            using (SubTransaction subTrans = new SubTransaction(Doc))
            {
                subTrans.Start();
                dim = Doc.Create.NewDimension(CurrentView,
                    Line.CreateUnbound(PtLeftUpCorner + DirUp * dimSpacing * indexOfDim, DirRight),
                    refArray);
                if (!IsVaildDim(dim))
                {
                    //存在导致dim报错的reference，因此本次操作回滚
                    subTrans.RollBack();
                    //仅创建起点终点
                    refArray = new ReferenceArray();
                    refArray.Append(End1FaceSymbol.Reference);
                    refArray.Append(End2FaceSymbol.Reference);
                    dim = Doc.Create.NewDimension(CurrentView,
                        Line.CreateUnbound(PtLeftUpCorner + DirUp * dimSpacing * indexOfDim, DirRight),
                        refArray);
                }
                else
                {
                    subTrans.Commit();
                }
            }
            return dim;
        }
        #endregion

        #region CreateEndDim
        /// <summary>
        /// 创建纵向尺寸标注
        /// </summary>
        /// <param name="indexOfDim">尺寸标注序号</param>
        /// <param name="embedRefs">埋件中心线</param>
        /// <returns></returns>
        private Dimension CreateEndDim(int indexOfDim, List<Reference> embedRefs)
        {
            ReferenceArray refArray = new ReferenceArray();
            refArray.Append(SideAFaceSymbol.Reference);
            foreach (Reference item in embedRefs)
            {
                refArray.Append(item);
            }
            refArray.Append(SideBFaceSymbol.Reference);
            //创建尺寸标注
            Dimension dim = null;
            using (SubTransaction subTrans = new SubTransaction(Doc))
            {
                subTrans.Start();
                dim = Doc.Create.NewDimension(CurrentView,
                    Line.CreateUnbound(PtLeftDownCorner + DirLeft * dimSpacing * indexOfDim, DirUp),
                    refArray);
                if (!IsVaildDim(dim))
                {
                    //存在导致dim报错的reference，因此本次操作回滚
                    subTrans.RollBack();
                    //仅创建起点终点
                    refArray = new ReferenceArray();
                    refArray.Append(SideAFaceSymbol.Reference);
                    refArray.Append(SideBFaceSymbol.Reference);
                    dim = Doc.Create.NewDimension(CurrentView,
                        Line.CreateUnbound(PtLeftDownCorner + DirLeft * dimSpacing * indexOfDim, DirUp),
                        refArray);
                }
                else
                {
                    subTrans.Commit();
                }
            }
            return dim;
        }
        #endregion

        #region IsVaildDim
        /// <summary>
        /// 判断尺寸是否合法
        /// </summary>
        /// <param name="dim"></param>
        /// <returns></returns>
        private bool IsVaildDim(Dimension dim)
        {
            if (dim.Segments.Size > 0)
            {
                if (dim.Segments.get_Item(0).Value.ToString() == "-1")
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region GetInstanceReference
        /// <summary>
        /// 埋件中心线
        /// </summary>
        /// <param name="fi">埋件</param>
        /// <param name="direction">垂直于尺寸线方向</param>
        /// <returns></returns>
        private Reference GetInstanceReference(FamilyInstance fi, XYZ direction)
        {
            XYZ xDir = fi.GetTransform().OfVector(XYZ.BasisX);
            XYZ yDir = fi.GetTransform().OfVector(XYZ.BasisY);
            if (direction.AngleTo(xDir) - Math.PI / 2.0 < 0.0001)
            {
                return fi.GetReferences(FamilyInstanceReferenceType.CenterLeftRight).First();
            }
            else if (DirUp.AngleTo(yDir) - Math.PI / 2.0 < 0.0001)
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
        private List<Reference> GetInstanceReferences(List<FamilyInstance> fiList, XYZ direction)
        {
            List<Reference> refList = new List<Reference>();
            foreach (var fi in fiList)
            {
                refList.Add(GetInstanceReference(fi, direction));
            }
            return refList;
        }
        #endregion

        #region CreateSideDimInfo
        /// <summary>
        /// 创建横向尺寸标签文字引线
        /// </summary>
        /// <param name="dim">尺寸</param>
        /// <param name="embedGroup">埋件族</param>
        /// <param name="locationStr">定位文字</param>
        private void CreateSideDimInfo(Dimension dim, List<FamilyInstance> embedGroup, string locationStr)
        {
            //创建标签
            Line dimLine = dim.Curve as Line;
            dimLine.MakeBound(0, 1);
            XYZ dimEndPt = GetDimensionEndPoint(dim, GetDimensionStartPoint(dim));
            IndependentTag tag = IndependentTag.Create(Doc,
                CurrentView.Id,
                new Reference(embedGroup[0]),
                false,
                TagMode.TM_ADDBY_CATEGORY,
                TagOrientation.Horizontal,
                dimEndPt + dimLine.Direction * 3.5 * CurrentView.Scale / 64);
            tag.ChangeTypeId(embedTagTypeId);
            //创建线
            Line line = Line.CreateBound(dimEndPt,
                dimEndPt + dimLine.Direction * 3.5 * CurrentView.Scale / 64);
            Doc.Create.NewDetailCurve(CurrentView, line);
            //创建文字
            TextNote.Create(Doc,
                CurrentView.Id,
                XYZOffset(Doc, dimEndPt, 0.4 * CurrentView.Scale / 64, 0.8 * CurrentView.Scale / 64),
                string.Format("({0})\n{1}", embedGroup.Count, locationStr),
                textNodeTypeId);
        }
        #endregion

        #region CreateEndDimInfo
        /// <summary>
        /// 创建纵向尺寸标签文字引线
        /// </summary>
        /// <param name="dim">尺寸</param>
        /// <param name="embedGroup">埋件组</param>
        /// <param name="locationStr">定位文字</param>
        private void CreateEndDimInfo(Dimension dim, List<FamilyInstance> embedGroup, string locationStr)
        {
            //创建标签
            Line dimLine = dim.Curve as Line;
            dimLine.MakeBound(0, 1);
            XYZ dimEndPt = GetDimensionEndPoint(dim, GetDimensionStartPoint(dim));
            IndependentTag tag = IndependentTag.Create(Doc,
                CurrentView.Id,
                new Reference(embedGroup[0]),
                false,
                TagMode.TM_ADDBY_CATEGORY,
                TagOrientation.Vertical,
                dimEndPt + dimLine.Direction * 3.25 * CurrentView.Scale / 64);
            tag.ChangeTypeId(embedTagTypeId);
            //创建线
            Line line = Line.CreateBound(dimEndPt,
                dimEndPt + dimLine.Direction * 3.25 * CurrentView.Scale / 64);
            Doc.Create.NewDetailCurve(CurrentView, line);
            //创建文字
            TextNote tn = TextNote.Create(Doc,
                CurrentView.Id,
                XYZOffset(Doc, dimEndPt, -0.8 * CurrentView.Scale / 64, 0.4 * CurrentView.Scale / 64),
                string.Format("({0})\n{1}", embedGroup.Count, locationStr),
                new TextNoteOptions() { TypeId = textNodeTypeId, Rotation = Math.PI / 2.0 });
        }
        #endregion

        private void CreateLineBetweenDims(Dimension dim1, Dimension dim2)
        {
            Line dimLine1 = dim1.Curve as Line;
            Line dimLine2 = dim2.Curve as Line;
            XYZ dim1StartPt = GetDimensionStartPoint(dim1);
            XYZ dim1EndPt = GetDimensionEndPoint(dim1, dim1StartPt);
            XYZ dim2StartPt = GetDimensionStartPoint(dim2);
            XYZ dim2EndPt = GetDimensionEndPoint(dim2, dim2StartPt);
            //交点
            XYZ intersectPt = dimLine2.Project(dim1EndPt).XYZPoint;
            //判断两个端点
            XYZ pt1 = dim1StartPt;
            if (dim1EndPt.DistanceTo(intersectPt) 
                < dim1StartPt.DistanceTo(intersectPt))
            {
                pt1 = dim1EndPt;
            }
            XYZ pt2 = dim2StartPt;
            if (dim2EndPt.DistanceTo(intersectPt)
                < dim2StartPt.DistanceTo(intersectPt))
            {
                pt2 = dim2EndPt;
            }
            //创建线
            Line line1 = Line.CreateBound(pt1, intersectPt);
            Doc.Create.NewDetailCurve(CurrentView, line1);
            Line line2 = Line.CreateBound(pt2, intersectPt);
            Doc.Create.NewDetailCurve(CurrentView, line2);
        }

        #region GetDimensionEndPoint
        //https://thebuildingcoder.typepad.com/blog/2017/06/determining-dimension-segment-endoints.html
        /// <summary>
        /// Retrieve the start and end points of
        /// each dimension segment, based on the 
        /// dimension origin determined above.
        /// </summary>
        private XYZ GetDimensionStartPoint(
            Dimension dim)
        {
            XYZ p = null;
            Line dimLine = dim.Curve as Line;
            if (dimLine == null) return null;
            dimLine.MakeBound(0, 1);
            XYZ pt1 = dimLine.GetEndPoint(0);
            XYZ pt2 = dimLine.GetEndPoint(1);
            XYZ direction = pt2.Subtract(pt1).Normalize();
            try
            {
                XYZ v = (double)dim.Value * direction;
                p = dim.Origin;
                p -= 0.5 * v;
            }
            catch
            {
                //Debug.Assert(ex.Message.Equals("Cannot access this method if this dimension has more than one segment."));

                foreach (DimensionSegment seg in dim.Segments)
                {
                    XYZ v = (double)seg.Value * direction;
                    p = seg.Origin;
                    p -= 0.5 * v;
                    break;
                }
            }
            return p;
        }
        
        private XYZ GetDimensionEndPoint(
          Dimension dim,
          XYZ pStart)
        {
            Line dimLine = dim.Curve as Line;
            if (dimLine == null) return null;
            List<XYZ> pts = new List<XYZ>();

            dimLine.MakeBound(0, 1);
            XYZ pt1 = dimLine.GetEndPoint(0);
            XYZ pt2 = dimLine.GetEndPoint(1);
            XYZ direction = pt2.Subtract(pt1).Normalize();

            if (0 == dim.Segments.Size)
            {
                XYZ v = (double)dim.Value * direction;
                pStart += v;
            }
            else
            {
                foreach (DimensionSegment seg in dim.Segments)
                {
                    XYZ v = (double)seg.Value * direction;
                    pStart += v;
                }
            }
            return pStart;
        }
        #endregion

        private XYZ XYZOffset(Document doc, XYZ pt1, double xOffset, double yOffset)
        {
            return pt1 + xOffset * DirRight + yOffset * DirUp;
        }

    }

    #region 错误处理
    /// <summary>
    /// FailureHandler
    /// </summary>
    public class FailureHandler : IFailuresPreprocessor
    {
        public string ErrorMessage { set; get; }
        public string ErrorSeverity { set; get; }

        public FailureHandler()
        {
            ErrorMessage = "";
            ErrorSeverity = "";
        }

        public FailureProcessingResult PreprocessFailures(FailuresAccessor failuresAccessor)
        {
            IList<FailureMessageAccessor> failureMessages = failuresAccessor.GetFailureMessages();

            foreach (FailureMessageAccessor failureMessageAccessor in failureMessages)
            {
                // We're just deleting all of the warning level 
                // failures and rolling back any others

                FailureDefinitionId id = failureMessageAccessor.GetFailureDefinitionId();

                try
                {
                    ErrorMessage = failureMessageAccessor.GetDescriptionText();
                }
                catch
                {
                    ErrorMessage = "Unknown Error";
                }

                try
                {
                    FailureSeverity failureSeverity = failureMessageAccessor.GetSeverity();

                    ErrorSeverity = failureSeverity.ToString();

                    if (failureSeverity == FailureSeverity.Warning)
                    {
                        // 如果是警告，则禁止消息框
                        failuresAccessor.DeleteWarning(failureMessageAccessor);
                    }
                    else
                    {
                        // 如果是错误：则取消导致错误的操作，但是仍然继续整个事务
                        return FailureProcessingResult.ProceedWithRollBack;
                    }
                }
                catch
                {
                }
            }
            return FailureProcessingResult.Continue;
        }
    }
    #endregion

}
