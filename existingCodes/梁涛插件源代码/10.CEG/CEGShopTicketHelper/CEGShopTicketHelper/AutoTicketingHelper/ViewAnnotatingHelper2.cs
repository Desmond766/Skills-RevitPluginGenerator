using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.LinkLabel;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public enum Location
    {
        Top = 0,
        Soffit = 1,
        SideA = 2,
        SideB = 3,
        End1 = 4,
        End2 = 5
    }

    public class ViewAnnotatingHelper2
    {
        public Document Doc { get; set; }//当前文档
        public View CurrentView { get; set; }//当前视图
        public AssemblyInstance Assembly { get; set; }//当前部件
        public FamilyInstance PCaPanel { get; set; }//板块
        public List<FamilyInstance> EmbedList { get; set; }//埋件列表

        //尺寸间距
        public double dimSpacing = 2.0;

        //标签类型
        public ElementId embedTagTypeId = null;
        public ElementId bentBarTagTypeId = null;
        public ElementId strBarTagTypeId = null;
        public string embedTagFamilyName = "";
        public string embedTagTypeName = "";
        public string bentBarTagFamilyName = "";
        public string bentBarTagTypeName = "";
        public string strBarTagFamilyName = "";
        public string strBarTagTypeName = "";

        //文字类型
        public ElementId textNodeTypeId = null;
        public string textNodeTypeName = "";

        //尺寸类型
        public DimensionType dimensionType = null;
        public string dimensionTypeName = "";

        //线条类型
        public Element lineStyle = null;
        public string lineStyleName = "";

        //定位文字
        public string locationStrTop = "TOP";
        public string locationStrSoffit = "SOFFIT";
        public string locationStrSideA = "SIDE-A";
        public string locationStrSideB = "SIDE-B";
        public string locationStrEnd1 = "END-1";
        public string locationStrEnd2 = "END-2";


        private int _indexOfDimSideA;
        private int _indexOfDimSideB;
        private int _indexOfDimEnd1;
        private int _indexOfDimEnd2;

        public Reference SideARef { get; set; }
        public Reference SideBRef { get; set; }
        public Reference End1Ref { get; set; }
        public Reference End2Ref { get; set; }
        public Reference TopRef { get; set; }
        public Reference SoffitRef { get; set; }

        public List<List<Reference>> GeomRefGroups { get; set; }

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

        public List<List<FamilyInstance>> SideALifterGroups { get; set; }
        public List<List<FamilyInstance>> SideBLifterGroups { get; set; }
        public List<List<FamilyInstance>> End1LifterGroups { get; set; }
        public List<List<FamilyInstance>> TopLifterGroups { get; set; }

        public ViewAnnotatingHelper2(AssemblyInstance assembly, View currentView)
        {
            Doc = assembly.Document;
            CurrentView = currentView;
            Assembly = assembly;
            dimSpacing = dimSpacing * CurrentView.Scale / 64.0;

            //读取自定义设置
            InitAnnoSetting();

            //确定方向
            DirUp = currentView.UpDirection;//Y
            DirDown = DirUp.Negate();
            DirRight = currentView.RightDirection;//X
            DirLeft = DirRight.Negate();
            DirTop = DirUp.CrossProduct(DirLeft);//Z
            DirSoffit = DirTop.Negate();
            InitCornerPoints();

            //初始化geometryList
            GeomRefGroups = new List<List<Reference>>();

            //初始化埋件组
            SideAEmbedGroups = new List<List<FamilyInstance>>();
            SideBEmbedGroups = new List<List<FamilyInstance>>();
            End1EmbedGroups = new List<List<FamilyInstance>>();
            End2EmbedGroups = new List<List<FamilyInstance>>();
            TopEmbedGroups = new List<List<FamilyInstance>>();
            SoffitEmbedGroups = new List<List<FamilyInstance>>();

            SideALifterGroups = new List<List<FamilyInstance>>();
            SideBLifterGroups = new List<List<FamilyInstance>>();
            End1LifterGroups = new List<List<FamilyInstance>>();
            TopLifterGroups = new List<List<FamilyInstance>>();

            //初始化族类型
            InitFamilyType();

            //初始化
            _indexOfDimSideA = 1;
            _indexOfDimSideB = 1;
            _indexOfDimEnd1 = 1;
            _indexOfDimEnd2 = 1;

        }

        #region InitAnnoSetting
        private void InitAnnoSetting()
        {
            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fileName = "CEGChinaAnnoSetting.txt";
            string path = Path.Combine(desktop, fileName);
            if (File.Exists(path))
            {
                foreach (string data in File.ReadAllLines(path))
                {
                    if (string.IsNullOrEmpty(data)) { continue; }
                    string[] array = data.Split('=');
                    if (array.Count() == 2)
                    {
                        string key = array[0].Trim();
                        string value = array[1].Trim();
                        if (!string.IsNullOrEmpty(key) 
                            && !string.IsNullOrEmpty(value))
                        {
                            if (key == "embedTagFamilyName")
                            {
                                embedTagFamilyName = value;
                            }
                            if (key == "embedTagTypeName")
                            {
                                embedTagTypeName = value;
                            }
                            if (key == "bentBarTagFamilyName")
                            {
                                bentBarTagFamilyName = value;
                            }
                            if (key == "bentBarTagTypeName")
                            {
                                bentBarTagTypeName = value;
                            }
                            if (key == "strBarTagFamilyName")
                            {
                                strBarTagFamilyName = value;
                            }
                            if (key == "strBarTagTypeName")
                            {
                                strBarTagTypeName = value;
                            }
                            if (key == "textNodeTypeName")
                            {
                                textNodeTypeName = value;
                            }
                            if (key == "dimensionTypeName")
                            {
                                dimensionTypeName = value;
                            }
                            if (key == "lineStyleName")
                            {
                                lineStyleName = value;
                            }
                            if (key == "dimSpacing")
                            {
                                dimSpacing = double.Parse(value);
                            }
                            if (key == "locationStrTop")
                            {
                                locationStrTop = value;
                            }
                            if (key == "locationStrSoffit")
                            {
                                locationStrSoffit = value;
                            }
                            if (key == "locationStrSideA")
                            {
                                locationStrSideA = value;
                            }
                            if (key == "locationStrSideB")
                            {
                                locationStrSideB = value;
                            }
                            if (key == "locationStrEnd1")
                            {
                                locationStrEnd1 = value;
                            }
                            if (key == "locationStrEnd2")
                            {
                                locationStrEnd2 = value;
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region InitCornerPoints
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
        #endregion

        #region InitFamilyType
        private void InitFamilyType()
        {
            //收集视图中的标记类型
            FilteredElementCollector col = new FilteredElementCollector(Doc);
            var tagSymbolList = col.OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_SpecialityEquipmentTags)
                .Cast<FamilySymbol>();
            if (tagSymbolList.Count() == 0)
            {
                TaskDialog.Show("r", "please load speciality equipment tag family and run again!");
            }
            ElementId defaultId = tagSymbolList.First().Id;
            var embedTagTypeList = tagSymbolList.Where(
                u => u.Name == embedTagTypeName
                && u.FamilyName == embedTagFamilyName);
            embedTagTypeId = embedTagTypeList.Count() == 0 ? defaultId : embedTagTypeList.First().Id;
            var bentBarTagTypeList = tagSymbolList.Where(
                u => u.Name == bentBarTagTypeName
                && u.FamilyName == bentBarTagFamilyName);
            bentBarTagTypeId = bentBarTagTypeList.Count() == 0 ? defaultId : bentBarTagTypeList.First().Id;
            var strBarTagTypeList = tagSymbolList.Where(
                u => u.Name == strBarTagTypeName
                && u.FamilyName == strBarTagFamilyName);
            strBarTagTypeId = strBarTagTypeList.Count() == 0 ? defaultId : strBarTagTypeList.First().Id;

            //收集视图中的文字类型
            FilteredElementCollector col2 = new FilteredElementCollector(Doc);
            var tntList = col2.OfClass(typeof(TextNoteType)).Cast<TextNoteType>();
            if (tntList.Count() == 0)
            {
                TaskDialog.Show("r", "please creat at lease 1 text note type and run again!");
            }
            ElementId defaultTextNoteTypeId = Doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
            var textNodeTypeList = tntList.Where(u => u.Name == textNodeTypeName);
            textNodeTypeId = textNodeTypeList.Count() == 0 ? defaultTextNoteTypeId : textNodeTypeList.First().Id;

            //收集视图中的尺寸类型
            FilteredElementCollector col3 = new FilteredElementCollector(Doc);
            var dtList = col3.OfClass(typeof(DimensionType)).Cast<DimensionType>();
            if (dtList.Count() == 0)
            {
                TaskDialog.Show("r", "please creat at lease 1 dimension type and run again!");
            }
            DimensionType defaultDimensionType = Doc.GetElement(Doc.GetDefaultElementTypeId(ElementTypeGroup.LinearDimensionType)) as DimensionType;
            var dimensionTypeList = dtList.Where(u => u.Name == dimensionTypeName);
            dimensionType = dimensionTypeList.Count() == 0 ? defaultDimensionType : dimensionTypeList.First();

            //线条视图中的线条类型
            FilteredElementCollector col4 = new FilteredElementCollector(Doc);
            var ltList = col4.OfClass(typeof(GraphicsStyle)).Cast<GraphicsStyle>();
            if (ltList.Count() == 0)
            {
                TaskDialog.Show("r", "please creat at lease 1 line style and run again!");
            }
            //Element defaultLineStyle = ltList.First();
            var lineStyleList = ltList.Where(u => u.Name == lineStyleName);
            lineStyle = lineStyleList.Count() == 0 ? null : lineStyleList.First();
        }
        #endregion

        #region InitEmbedGroups 自动判断 TODO

        public void InitEmbedGroups()
        {
            //收集埋件
            EmbedList = new List<FamilyInstance>();
            foreach (ElementId id in Assembly.GetMemberIds())
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
                        if (cegCategory.Contains("EMBED") || cegCategory.Contains("LIFTING"))
                        {
                            EmbedList.Add(elem as FamilyInstance);
                        }
                    }
                }
            }

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
            SideARef = SideAFaceSymbol.Reference;
            SideBRef = SideBFaceSymbol.Reference;
            End1Ref = End1FaceSymbol.Reference;
            End2Ref = End2FaceSymbol.Reference;
            TopRef = TopFaceSymbol.Reference;
            SoffitRef = SoffitFaceSymbol.Reference;

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
                    if (SideAFaceInstance.Project(embedPt).Distance < 0.01)
                    {
                        sideAEmbedList.Add(embed);
                    }
                }
                if (SideBFaceInstance.Project(embedPt) != null)
                {
                    if (SideBFaceInstance.Project(embedPt).Distance < 0.01)
                    {
                        sideBEmbedList.Add(embed);
                    }
                }
                if (End1FaceInstance.Project(embedPt) != null)
                {
                    if (End1FaceInstance.Project(embedPt).Distance < 0.01)
                    {
                        end1EmbedList.Add(embed);
                    }
                }
                if (End2FaceInstance.Project(embedPt) != null)
                {
                    if (End2FaceInstance.Project(embedPt).Distance < 0.01)
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
                    if (TopFaceInstance != null && TopFaceInstance.Project(embedPt) != null)
                    {
                        if (TopFaceInstance.Project(embedPt).Distance < 0.01)
                        {
                            topEmbedList.Add(embed);
                        }
                    }
                    else if (SoffitFaceInstance != null && SoffitFaceInstance.Project(embedPt) != null)
                    {
                        if (SoffitFaceInstance.Project(embedPt).Distance < 0.01)
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
        #endregion

        #region AddSideEndText
        /// <summary>
        /// 创建定位文字
        /// </summary>
        public void AddSideEndText()
        {
            TextNoteOptions opHorizontal = new TextNoteOptions()
            {
                TypeId = textNodeTypeId
            };
            TextNoteOptions opVertical = new TextNoteOptions()
            {
                TypeId = textNodeTypeId,
                Rotation = Math.PI / 2.0,
                HorizontalAlignment = HorizontalTextAlignment.Center
            };
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtLeftUpCorner + PtRightUpCorner) / 2.0 + DirUp * dimSpacing / 2.0,
                    "SIDE-A",
                    opHorizontal);
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtLeftDownCorner + PtRightDownCorner) / 2.0 + DirDown * dimSpacing / 8.0,
                    "SIDE-B",
                    opHorizontal);
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtLeftUpCorner + PtLeftDownCorner) / 2.0 + DirLeft * dimSpacing / 2.0,
                    "END-1",
                    opVertical);
            TextNote.Create(Doc,
                    CurrentView.Id,
                    (PtRightUpCorner + PtRightDownCorner) / 2.0 + DirRight * dimSpacing / 8.0,
                    "END-2",
                    opVertical);
        }
        #endregion

        #region OverallSideDim
        /// <summary>
        /// 横向总体标注
        /// </summary>
        public void OverallSideDim()
        {
            CreateSideDim(new List<Reference>(), Location.SideA);
        }
        #endregion

        #region OverallEndDim
        /// <summary>
        /// 纵向整体标注
        /// </summary>
        public void OverallEndDim()
        {
            CreateEndDim(new List<Reference>(), Location.End1);
        }
        #endregion

        #region GeomDim
        public void GeomDim()
        {
            foreach (List<Reference> group in GeomRefGroups)
            {
                Dimension dim1 = null;
                Dimension dim2 = null;
                if (group.Count == 2)
                {
                    //创建尺寸标注1
                    dim1 = CreateEndDim(new List<Reference>() { group[0] }, Location.End1);
                    //创建尺寸标注2
                    dim2 = CreateSideDim(new List<Reference>() { group[1] }, Location.SideA);
                }
                else//group.Count == 4
                {
                    //创建尺寸标注1
                    dim1 = CreateEndDim(new List<Reference>() { group[0], group[1] }, Location.End1);
                    //创建尺寸标注2
                    dim2 = CreateSideDim(new List<Reference>() { group[2], group[3] }, Location.SideA);
                }
                _indexOfDimEnd1 += 1;
                _indexOfDimSideA += 1;
                //创建标签
                CreateGeomDimInfo(dim2, dim1);
                CreateLineBetweenDims(dim1, dim2);
            }
        }
        #endregion

        #region SideDim
        /// <summary>
        /// 横向标注
        /// </summary>
        public void SideEmbedDim()
        {
            //SideAEmbed
            SideDim(SideAEmbedGroups, Location.SideA);
            //SideBEmbed
            SideDim(SideBEmbedGroups, Location.SideB);
        }

        public void SideLifterDim()
        {
            //SideALifter
            SideDim(SideALifterGroups, Location.SideA); ;
            //SideBLifter
            SideDim(SideBLifterGroups, Location.SideB);
        }

        private void SideDim(List<List<FamilyInstance>> embedGroups, Location location)
        {
            foreach (var group in embedGroups)
            {
                //创建尺寸标注
                Dimension dim = CreateSideDim(GetInstanceReferences(group, DirLeft), location);
                if (location == Location.SideA)
                {
                    _indexOfDimSideA += 1;
                }
                else//EmbedLocation.SideB
                {
                    _indexOfDimSideB += 1;
                }
                //创建标签
                CreateSideDimInfo(dim, group, location);
            }
        }

        #endregion

        #region EndDim
        /// <summary>
        /// 纵向标注
        /// </summary>
        public void EndEmbedDim()
        {
            //End1Embed
            EndDim(End1EmbedGroups, Location.End1);
            //End2Embed
            EndDim(End2EmbedGroups, Location.End2);
        }
        public void EndLifterDim()
        {
            //End1Lifter
            EndDim(End1LifterGroups, Location.End1);
        }

        private void EndDim(List<List<FamilyInstance>> embedGroups, Location location)
        {
            foreach (var group in embedGroups)
            {
                //创建尺寸标注
                Dimension dim = CreateEndDim(GetInstanceReferences(group, DirUp), location);
                if (location == Location.End1)
                {
                    _indexOfDimEnd1 += 1;
                }
                else//EmbedLocation.End2
                {
                    _indexOfDimEnd2 += 1;
                }
                //创建标签
                CreateEndDimInfo(dim, group, location);
            }
        }

        #endregion

        #region FaceDim
        /// <summary>
        /// 顶面标注
        /// </summary>
        public void FaceEmbedDim()
        {
            //TOP
            FaceDim(TopEmbedGroups, Location.Top);
            //SOFFIT
            FaceDim(SoffitEmbedGroups, Location.Soffit);
        }
        public void FaceLifterDim()
        {
            //TOPLIFTER
            FaceDim(TopLifterGroups, Location.Top);
        }

        private void FaceDim(List<List<FamilyInstance>> embedGroups, Location location)
        {
            foreach (var group in embedGroups)
            {
                List<FamilyInstance> groupSide = new List<FamilyInstance>();
                List<FamilyInstance> groupEnd = new List<FamilyInstance>();
                InitFaceEmbedMatrix(group, ref groupSide, ref groupEnd);
                //创建尺寸标注1
                Dimension dim1 = CreateSideDim(GetInstanceReferences(groupSide, DirLeft), location);
                _indexOfDimSideA += 1;
                //创建标签
                CreateSideDimInfo(dim1, group, location);
                //创建尺寸标注2
                Dimension dim2 = CreateEndDim(GetInstanceReferences(groupEnd, DirUp), location);
                _indexOfDimEnd1 += 1;
                CreateLineBetweenDims(dim1, dim2);
            }
        }

        #endregion

        #region InitFaceEmbedMatrix
        private bool InitFaceEmbedMatrix(List<FamilyInstance> embeds,
            ref List<FamilyInstance> groupSide,
            ref List<FamilyInstance> groupEnd)
        {
            //将TopEmbed分为两组标注用
            Line lineA = Line.CreateBound(PtLeftUpCorner, PtRightUpCorner);
            Line line1 = Line.CreateBound(PtLeftUpCorner, PtLeftDownCorner);
            var group1 = embeds.GroupBy(u =>
                Utils.GetProjectiveDis(lineA, (u.Location as LocationPoint).Point).ToString("0.0000"));
            var group2 = embeds.GroupBy(u =>
                Utils.GetProjectiveDis(line1, (u.Location as LocationPoint).Point).ToString("0.0000"));
            foreach (var item in group1)
            {
                groupEnd.Add(item.ToList().First());
            }
            foreach (var item in group2)
            {
                groupSide.Add(item.ToList().First());
            }
            if (groupSide.Count() * groupEnd.Count() == embeds.Count)
            {
                return true;
            }
            else//这种情况应该分为两道尺寸才对
            {
                return false;
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
        private Dimension CreateSideDim(List<Reference> embedRefs, Location location)
        {
            XYZ basePt = XYZ.Zero;
            XYZ dir = XYZ.Zero;
            int indexOfDim = 0;
            if (location == Location.SideA
                || location == Location.Top
                || location == Location.Soffit)
            {
                basePt = PtLeftUpCorner;
                dir = DirUp;
                indexOfDim = _indexOfDimSideA;
            }
            else//EmbedLocation.SideB
            {
                basePt = PtLeftDownCorner;
                dir = DirDown;
                indexOfDim = _indexOfDimSideB;
            }

            ReferenceArray refArray = new ReferenceArray();
            refArray.Append(End1Ref);
            foreach (Reference item in embedRefs)
            {
                refArray.Append(item);
            }
            refArray.Append(End2Ref);
            //创建尺寸标注
            Dimension dim = null;
            using (SubTransaction subTrans = new SubTransaction(Doc))
            {
                subTrans.Start();
                dim = Doc.Create.NewDimension(CurrentView,
                    Line.CreateUnbound(basePt + dir * dimSpacing * indexOfDim, DirRight),
                    refArray, dimensionType);
                if (!IsVaildDim(dim))
                {
                    //存在导致dim报错的reference，因此本次操作回滚
                    subTrans.RollBack();
                    //仅创建起点终点
                    refArray = new ReferenceArray();
                    refArray.Append(End1Ref);
                    refArray.Append(End2Ref);
                    dim = Doc.Create.NewDimension(CurrentView,
                        Line.CreateUnbound(basePt + dir * dimSpacing * indexOfDim, DirRight),
                        refArray, dimensionType);
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
        private Dimension CreateEndDim(List<Reference> embedRefs, Location location)
        {
            XYZ basePt = XYZ.Zero;
            XYZ dir = XYZ.Zero;
            int indexOfDim = 0;
            if (location ==  Location.End1
                || location == Location.Top 
                || location ==  Location.Soffit)
            {
                basePt = PtLeftDownCorner;
                dir = DirLeft;
                indexOfDim = _indexOfDimEnd1;
            }
            else//EmbedLocation.End2
            {
                basePt = PtRightDownCorner;
                dir = DirRight;
                indexOfDim = _indexOfDimEnd2;
            }

            ReferenceArray refArray = new ReferenceArray();
            refArray.Append(SideARef);
            foreach (Reference item in embedRefs)
            {
                refArray.Append(item);
            }
            refArray.Append(SideBRef);
            //创建尺寸标注
            Dimension dim = null;
            using (SubTransaction subTrans = new SubTransaction(Doc))
            {
                subTrans.Start();
                dim = Doc.Create.NewDimension(CurrentView,
                    Line.CreateUnbound(basePt + dir * dimSpacing * indexOfDim, DirUp),
                    refArray, dimensionType);
                if (!IsVaildDim(dim))
                {
                    //存在导致dim报错的reference，因此本次操作回滚
                    subTrans.RollBack();
                    //仅创建起点终点
                    refArray = new ReferenceArray();
                    refArray.Append(SideARef);
                    refArray.Append(SideBRef);
                    dim = Doc.Create.NewDimension(CurrentView,
                        Line.CreateUnbound(basePt + dir * dimSpacing * indexOfDim, DirUp),
                        refArray, dimensionType);
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
        /// <param name="direction">平行于尺寸线方向</param>
        /// <returns></returns>
        private Reference GetInstanceReference(FamilyInstance fi, XYZ direction)
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
        private void CreateSideDimInfo(Dimension dim, List<FamilyInstance> embedGroup, Location location)
        {
            TextNoteOptions opHorizontal = new TextNoteOptions()
            {
                TypeId = textNodeTypeId
            };

            //创建标签
            Line dimLine = dim.Curve as Line;
            dimLine.MakeBound(0, 1);
            XYZ dimStartPT = GetDimensionStartPoint(dim);
            XYZ dimEndPt = GetDimensionEndPoint(dim, dimStartPT);

            if (location == Location.SideA 
                || location == Location.Top 
                || location == Location.Soffit)
            {
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
                DetailCurve dc = Doc.Create.NewDetailCurve(CurrentView, line);
                if (null != lineStyle)
                {
                    dc.LineStyle = lineStyle;
                }
                //创建文字
                TextNote.Create(Doc,
                    CurrentView.Id,
                    XYZOffset(Doc, dimEndPt, 0.4 * CurrentView.Scale / 64, 0.8 * CurrentView.Scale / 64),
                    string.Format("({0})\n{1}", embedGroup.Count, GetLocationStr(location)),
                    opHorizontal);
            }
            else//EmbedLocation.SideB 
            {
                IndependentTag tag = IndependentTag.Create(Doc,
                CurrentView.Id,
                new Reference(embedGroup[0]),
                false,
                TagMode.TM_ADDBY_CATEGORY,
                TagOrientation.Horizontal,
                dimStartPT + dimLine.Direction.Negate() * 3.5 * CurrentView.Scale / 64);
                tag.ChangeTypeId(embedTagTypeId);
                //创建线
                Line line = Line.CreateBound(dimStartPT,
                    dimStartPT + dimLine.Direction.Negate() * 3.5 * CurrentView.Scale / 64);
                DetailCurve dc = Doc.Create.NewDetailCurve(CurrentView, line);
                if (null != lineStyle)
                {
                    dc.LineStyle = lineStyle;
                }
                //创建文字
                TextNote.Create(Doc,
                    CurrentView.Id,
                    XYZOffset(Doc, dimStartPT, -2.0 * CurrentView.Scale / 64, 0.8 * CurrentView.Scale / 64),
                    string.Format("({0})\n{1}", embedGroup.Count, GetLocationStr(location)),
                    opHorizontal);
            }
        }
        #endregion

        #region CreateEndDimInfo
        /// <summary>
        /// 创建纵向尺寸标签文字引线
        /// </summary>
        /// <param name="dim">尺寸</param>
        /// <param name="embedGroup">埋件组</param>
        /// <param name="locationStr">定位文字</param>
        private void CreateEndDimInfo(Dimension dim, List<FamilyInstance> embedGroup, Location location)
        {
            TextNoteOptions opVertical = new TextNoteOptions()
            {
                TypeId = textNodeTypeId,
                Rotation = Math.PI / 2.0
            };
            //创建标签
            Line dimLine = dim.Curve as Line;
            dimLine.MakeBound(0, 1);
            XYZ dimStartPt = GetDimensionStartPoint(dim);
            XYZ dimEndPt = GetDimensionEndPoint(dim, dimStartPt);
            if (location == Location.End1)
            {
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
                DetailCurve dc = Doc.Create.NewDetailCurve(CurrentView, line);
                if (null != lineStyle)
                {
                    dc.LineStyle = lineStyle;
                }
                //创建文字
                TextNote.Create(Doc,
                    CurrentView.Id,
                    XYZOffset(Doc, dimEndPt, -0.8 * CurrentView.Scale / 64, 0.4 * CurrentView.Scale / 64),
                    string.Format("({0})\n{1}", embedGroup.Count, GetLocationStr(location)),
                    opVertical);
            }
            else//EmbedLocation.End2
            {
                IndependentTag tag = IndependentTag.Create(Doc,
                CurrentView.Id,
                new Reference(embedGroup[0]),
                false,
                TagMode.TM_ADDBY_CATEGORY,
                TagOrientation.Vertical,
                dimStartPt + dimLine.Direction.Negate() * 3.25 * CurrentView.Scale / 64);
                tag.ChangeTypeId(embedTagTypeId);
                //创建线
                Line line = Line.CreateBound(dimStartPt,
                    dimStartPt + dimLine.Direction.Negate() * 3.25 * CurrentView.Scale / 64);
                DetailCurve dc = Doc.Create.NewDetailCurve(CurrentView, line);
                if (null != lineStyle)
                {
                    dc.LineStyle = lineStyle;
                }
                //创建文字
                TextNote.Create(Doc,
                    CurrentView.Id,
                    XYZOffset(Doc, dimStartPt, -0.8 * CurrentView.Scale / 64, -2.0 * CurrentView.Scale / 64),
                    string.Format("({0})\n{1}", embedGroup.Count, GetLocationStr(location)),
                    opVertical);
            }
        }
        #endregion

        #region CreateGeomDimInfo
        private void CreateGeomDimInfo(Dimension sideDim, Dimension endDim)
        {
            TextNoteOptions opHorizontal = new TextNoteOptions()
            {
                TypeId = textNodeTypeId
            };

            double lengthA = (Doc.GetElement(SideARef).GetGeometryObjectFromReference(SideARef) as Edge).ApproximateLength;
            double lengthB = (Doc.GetElement(SideBRef).GetGeometryObjectFromReference(SideBRef) as Edge).ApproximateLength;
            double length1 = (Doc.GetElement(End1Ref).GetGeometryObjectFromReference(End1Ref) as Edge).ApproximateLength;
            double length2 = (Doc.GetElement(End2Ref).GetGeometryObjectFromReference(End2Ref) as Edge).ApproximateLength;
            if (sideDim.Segments.Size == 2)
            {
                double dif1 = Math.Abs(double.Parse(sideDim.Segments.get_Item(0).Value.ToString()) - lengthA);
                double dif2 = Math.Abs(double.Parse(sideDim.Segments.get_Item(0).Value.ToString()) - lengthB);
                if (dif1 < 0.0001 || dif2 < 0.0001)
                {
                    sideDim.Segments.get_Item(1).Below = "B.O.";
                }
                else
                {
                    sideDim.Segments.get_Item(0).Below = "B.O.";
                }
            }
            if (sideDim.Segments.Size == 3)
            {
                sideDim.Segments.get_Item(1).Below = "B.O.";
            }
            if (endDim.Segments.Size == 2)
            {
                double dif1 = Math.Abs(double.Parse(endDim.Segments.get_Item(0).Value.ToString()) - length1);
                double dif2 = Math.Abs(double.Parse(endDim.Segments.get_Item(0).Value.ToString()) - length2);
                if (dif1 < 0.0001 || dif2 < 0.0001)
                {
                    endDim.Segments.get_Item(1).Below = "B.O.";
                }
                else
                {
                    endDim.Segments.get_Item(0).Below = "B.O.";
                }
            }
            if (endDim.Segments.Size == 3)
            {
                endDim.Segments.get_Item(1).Below = "B.O.";
            }

            //创建标签
            Line dimLine = sideDim.Curve as Line;
            dimLine.MakeBound(0, 1);
            XYZ dimEndPt = GetDimensionEndPoint(sideDim, GetDimensionStartPoint(sideDim));
            //创建线
            Line line = Line.CreateBound(dimEndPt,
                dimEndPt + dimLine.Direction * 3.25 * CurrentView.Scale / 64);
            DetailCurve dc = Doc.Create.NewDetailCurve(CurrentView, line);
            if (null != lineStyle)
            {
                dc.LineStyle = lineStyle;
            }
            //创建文字
            TextNote.Create(Doc,
                CurrentView.Id,
                XYZOffset(Doc, dimEndPt, 0.4 * CurrentView.Scale / 64, 0.8 * CurrentView.Scale / 64),
                string.Format("{0}", "BLOCKOUT"), opHorizontal);
        }
        #endregion

        #region CreateLineBetweenDims
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
            DetailCurve dc1 = Doc.Create.NewDetailCurve(CurrentView, line1);
            if (null != lineStyle)
            {
                dc1.LineStyle = lineStyle;
            }
            Line line2 = Line.CreateBound(pt2, intersectPt);
            DetailCurve dc2 = Doc.Create.NewDetailCurve(CurrentView, line2);
            if (null != lineStyle)
            {
                dc2.LineStyle = lineStyle;
            }
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

        #endregion

        #region MyRegion
        private XYZ XYZOffset(Document doc, XYZ pt1, double xOffset, double yOffset)
        {
            return pt1 + xOffset * DirRight + yOffset * DirUp;
        }
        #endregion

        #region GetLocationStr
        private string GetLocationStr(Location location)
        {
            if (location == Location.Top)
            {
                return locationStrTop;
            }
            if (location == Location.Soffit)
            {
                return locationStrSoffit;
            }
            if (location == Location.SideA)
            {
                return locationStrSideA;
            }
            if (location == Location.SideB)
            {
                return locationStrSideB;
            }
            if (location == Location.End1)
            {
                return locationStrEnd1;
            }
            if (location == Location.End2)
            {
                return locationStrEnd2;
            }
            return null;
        }
        #endregion

    }
}
