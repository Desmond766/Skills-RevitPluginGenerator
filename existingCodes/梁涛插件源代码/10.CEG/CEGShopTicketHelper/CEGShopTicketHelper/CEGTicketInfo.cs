using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    //用于复制完整制品图
    public class CEGTicketInfo
    {
        public AssemblyInstance HostAssembly { get; set; }
        public Document Doc { get; set; }
        public List<TicketInfo> CEGTickets { get; set; }

        //构造函数
        public CEGTicketInfo(AssemblyInstance assemblyInstance)
        {
            Doc = assemblyInstance.Document;
            HostAssembly = assemblyInstance;
            CEGTickets = new List<TicketInfo>();
            List<ViewSheet> sheets = new FilteredElementCollector(Doc)
                .OfClass(typeof(ViewSheet))
                .Cast<ViewSheet>().ToList();
            
            //从整个项目中找到assmbly用的图纸
            foreach (ViewSheet sheet in sheets)
            {
                ElementId id = sheet.AssociatedAssemblyInstanceId;
                if (null == id) { continue; }
                if (null == Doc.GetElement(id)) { continue; }
                if (Doc.GetElement(id).Name == HostAssembly.Name)
                {
                    TicketInfo ticketInfo = new TicketInfo(sheet);
                    CEGTickets.Add(ticketInfo);
                }
            }
        }

        public bool ExistSheetNumber(string sheetNumber)
        {
            return CEGTickets.Select(u => u.HostSheet.SheetNumber).ToList()
                .Contains(sheetNumber);
        }

        public ViewSheet GetSheetByNumber(string sheetNumber)
        {
            List<TicketInfo> infos = CEGTickets.Where(u => u.HostSheet.SheetNumber == sheetNumber).ToList();
            if (infos.Count == 1)
            {
                return infos[0].HostSheet;
            }
            return null;
        }

    }

    //单张制品图
    //包括图框，明细表，视图，图例，注释
    public class TicketInfo
    {
        public ViewSheet HostSheet { get; set; }
        Document Doc { get; set; }
        public List<Element> TicketElements { get; set; }
        public TitleBlockInfo TitleBlock { get; set; }
        public List<ScheduleInfo> Schedules { get; set; }
        public List<AssemblyViewInfo> AssemblyViews { get; set; }
        public List<ThreeDViewInfo> ThreeDViews { get; set; }
        public List<LegendViewInfo> LegendViews { get; set; }
        public List<ElementId> DetailItems { get; set; }

        //构造函数
        public TicketInfo(ViewSheet viewSheet)
        {
            HostSheet = viewSheet;
            Doc = viewSheet.Document;
            TicketElements = new FilteredElementCollector(Doc, viewSheet.Id)
                .ToElements().ToList();
            Init();
        }

        #region Init
        //初始化
        public void Init()
        {
            //初始化图框
            List<Element> tbElements = TicketElements
                .Where(u => u.Category.Id.IntegerValue
                == (int)BuiltInCategory.OST_TitleBlocks).ToList();
            if (tbElements.Count > 0)//图框大于1的情况未考虑
            {
                TitleBlock = new TitleBlockInfo(tbElements[0]);
            }

            //初始化明细表
            List<int> scheduleIds = new List<int>();
            List<Element> schElements = TicketElements
                .Where(u => u.Category.Id.IntegerValue
                == (int)BuiltInCategory.OST_ScheduleGraphics).ToList();

            Schedules = new List<ScheduleInfo>();
            foreach (Element e in schElements)
            {
                //2024.3.16 只收集不重复的
                int sId = (e as ScheduleSheetInstance).ScheduleId.IntegerValue;
                if (!scheduleIds.Contains(sId))
                {
                    var si = new ScheduleInfo(e);
                    //if (si.Schedule != null)
                    {
                        Schedules.Add(si);
                        scheduleIds.Add(sId);
                    }
                }
            }

            //初始化注释符号
            DetailItems = new List<ElementId>();
            foreach (Element e in TicketElements)
            {
                if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_TextNotes
                    || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_GenericAnnotation
                    || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_IOSDetailGroups
                    || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Lines)
                {
                    DetailItems.Add(e.Id);
                }
            }

            //初始化图例和视图
            LegendViews = new List<LegendViewInfo>();
            AssemblyViews = new List<AssemblyViewInfo>();
            ThreeDViews = new List<ThreeDViewInfo>();
            foreach (Element e in TicketElements)
            {
                if (!(e is Viewport)) { continue; }
                Viewport port = e as Viewport;
                Autodesk.Revit.DB.View view = e.Document.GetElement(port.ViewId) 
                    as Autodesk.Revit.DB.View;
                //图例
                if (view.ViewType == ViewType.Legend)
                {
                    LegendViewInfo info = new LegendViewInfo(port);
                    LegendViews.Add(info);
                }
                //视图
                if (view.ViewType == ViewType.Detail)
                {
                    AssemblyViewInfo info = new AssemblyViewInfo(port);
                    AssemblyViews.Add(info);
                }
                //3D视图
                if (view.ViewType == ViewType.ThreeD)
                {
                    ThreeDViewInfo info = new ThreeDViewInfo(port);
                    ThreeDViews.Add(info);
                }
            }
        }
        #endregion

        public bool ExistView(string ViewName)
        {
            return LegendViews.Select(u => u.Name).ToList().Contains(ViewName) 
                || Schedules.Select(u => u.Name).ToList().Contains(ViewName)
                || AssemblyViews.Select(u => u.Name).ToList().Contains(ViewName)
                || ThreeDViews.Select(u => u.Name).ToList().Contains(ViewName);
        }
    }

    public class TitleBlockInfo
    {
        public FamilyInstance HostTitleBlock { get; set; }
        public FamilySymbol Symbol { get; set; }
        public string SheetName { get; set; }
        public string SheetNumber { get; set; }
        public string DrawnBy { get; set; }
        public string CheckedBy { get; set; }

        public TitleBlockInfo(Element tb)
        {
            HostTitleBlock = tb as FamilyInstance;
            Symbol = tb.Document.GetElement(tb.GetTypeId()) as FamilySymbol;
            SheetName = tb.get_Parameter(BuiltInParameter.SHEET_NAME).AsString();
            SheetNumber = tb.get_Parameter(BuiltInParameter.SHEET_NUMBER).AsString();
            DrawnBy = tb.get_Parameter(BuiltInParameter.SHEET_DRAWN_BY).AsString();
            CheckedBy = tb.get_Parameter(BuiltInParameter.SHEET_CHECKED_BY).AsString();
        }
    }

    public class ScheduleInfo
    {
        public ScheduleSheetInstance HostSchedule { get; set; }
        public ViewSchedule Schedule { get; set; }
        public string Name { get; set; }
        public BuiltInCategory Category { get; set; }
        public ElementId TemplateId { get; set; }
        public XYZ Position { get; set; }
        public List<double> ColumnWidths { get; set; }

        public ScheduleInfo(Element sch)
        {
            HostSchedule = sch as ScheduleSheetInstance;
            ViewSchedule Schedule = sch.Document.GetElement(HostSchedule.ScheduleId) as ViewSchedule;
            //Name = HostSchedule.Name;
            Name = Schedule.Name;//2024.3.16 updated
            Category = (BuiltInCategory)Schedule.Definition.CategoryId.IntegerValue;
            TemplateId = Schedule.ViewTemplateId;
            Position = HostSchedule.Point;

            ColumnWidths = new List<double>();
            for (int i = 0; i < Schedule.Definition.GetFieldCount(); i++)
            {
                ScheduleField _field = Schedule.Definition.GetField(i);
                //set GridColumnWidth
                ColumnWidths.Add(_field.GridColumnWidth);
                //set SheetColumnWidth
                //_field.SheetColumnWidth =
            }
        }
    }

    public class AssemblyViewInfo
    {
        public string Name { get; set; }
        public string DetailNumber { get; set; }
        public string TitleOnSheet { get; set; }
        public ElementId TitleTypeId { get; set; }
        public ElementId ViewTypeId { get; set; }
        public int Scale { get; set; }
        public BoundingBoxXYZ Cropbox { get; set; }
        public bool CropboxActive { get; set; }
        public AssemblyDetailViewOrientation Orientation { get; set; }
        public ElementId TemplateId { get; set; }
        public XYZ Position { get; set; }//视口中心
        public XYZ UpDirection { get; set; }//视图上
        public XYZ Origin { get; set; }//视图位置
        public double FarClipOffset { get; set; }
        public double LabelLineLength { get; set; }
        public XYZ LabelOffset { get; set; }
        //构造函数
        public AssemblyViewInfo(Viewport port)
        {
            Document doc = port.Document;
            ViewSheet vs = doc.GetElement(port.OwnerViewId) as ViewSheet;
            AssemblyInstance assemblyInstance = doc.GetElement(vs.AssociatedAssemblyInstanceId)
                as AssemblyInstance;
            //view
            Autodesk.Revit.DB.View view = doc.GetElement(port.ViewId) 
                as Autodesk.Revit.DB.View;
            //assembly Transform
            Transform trans = assemblyInstance.GetTransform();

            Name = port.get_Parameter(BuiltInParameter.VIEW_NAME).AsString();
            DetailNumber = port.get_Parameter(BuiltInParameter.VIEWER_DETAIL_NUMBER).AsString();
            TitleOnSheet = port.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).AsString();
            TitleTypeId = port.GetTypeId();
            ViewTypeId = view.GetTypeId();
            Scale = view.Scale;
            Cropbox = view.CropBox;
            CropboxActive = view.CropBoxActive;
            TemplateId = view.ViewTemplateId;
            Orientation = GetOrientation(view.ViewDirection, trans);
            Position = port.GetBoxCenter();
            UpDirection = view.UpDirection;
            Origin = view.Origin;
            FarClipOffset = view.get_Parameter(BuiltInParameter.VIEWER_BOUND_OFFSET_FAR).AsDouble();
            LabelLineLength = port.LabelLineLength;
            LabelOffset = port.LabelOffset;
        }

        //根据视图方向向量判断应该用那个方向视图创建
        public AssemblyDetailViewOrientation GetOrientation(XYZ dir, Transform tran)
        {
            if (dir.IsAlmostEqualTo(tran.BasisZ)) return AssemblyDetailViewOrientation.ElevationTop;//(0, 0, 1)
            if (dir.IsAlmostEqualTo(tran.BasisZ.Negate())) return AssemblyDetailViewOrientation.ElevationBottom;//(0, 0, -1)
            if (dir.IsAlmostEqualTo(tran.BasisX.Negate())) return AssemblyDetailViewOrientation.ElevationLeft;//(-1, 0, 0)
            if (dir.IsAlmostEqualTo(tran.BasisX)) return AssemblyDetailViewOrientation.ElevationRight;//(1, 0, 0)
            if (dir.IsAlmostEqualTo(tran.BasisY.Negate())) return AssemblyDetailViewOrientation.ElevationFront;//(0, -1, 0)
            if (dir.IsAlmostEqualTo(tran.BasisY)) return AssemblyDetailViewOrientation.ElevationBack;//(0, 1, 0)
            return AssemblyDetailViewOrientation.ElevationTop;//bug
        }
    }

    public class ThreeDViewInfo
    {
        public string Name { get; set; }
        public string TitleOnSheet { get; set; }
        public ElementId TitleTypeId { get; set; }
        public ElementId ViewTypeId { get; set; }
        public int Scale { get; set; }
        public BoundingBoxXYZ Cropbox { get; set; }
        //public AssemblyDetailViewOrientation Orientation { get; set; }
        public ElementId TemplateId { get; set; }
        public XYZ Position { get; set; }//视口中心
        //public XYZ UpDirection { get; set; }//视图上
        public double LabelLineLength { get; set; }
        public XYZ LabelOffset { get; set; }
        //构造函数
        public ThreeDViewInfo(Viewport port)
        {
            Document doc = port.Document;
            ViewSheet vs = doc.GetElement(port.OwnerViewId) as ViewSheet;
            AssemblyInstance assemblyInstance = doc.GetElement(vs.AssociatedAssemblyInstanceId)
                as AssemblyInstance;
            //view
            Autodesk.Revit.DB.View view = doc.GetElement(port.ViewId)
                as Autodesk.Revit.DB.View;
            //assembly Transform
            Transform trans = assemblyInstance.GetTransform();

            Name = port.get_Parameter(BuiltInParameter.VIEW_NAME).AsString();
            TitleOnSheet = port.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).AsString();
            TitleTypeId = port.GetTypeId();
            ViewTypeId = view.GetTypeId();
            Scale = view.Scale;
            Cropbox = view.CropBox;
            TemplateId = view.ViewTemplateId;
            //Orientation = GetOrientation(view.ViewDirection, trans);
            Position = port.GetBoxCenter();
            //UpDirection = view.UpDirection;
            LabelLineLength = port.LabelLineLength;
            LabelOffset = port.LabelOffset;
        }
    }

    public class LegendViewInfo
    {
        public string TitleOnSheet { get; set; }
        public string Name { get; set; }
        public ElementId ViewId { get; set; }
        public ElementId TypeId { get; set; }
        public XYZ Position { get; set; }

        public LegendViewInfo(Viewport port)
        {
            TitleOnSheet = port.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).AsString();
            Name = (port.Document.GetElement(port.ViewId) as Autodesk.Revit.DB.View).Name;
            ViewId = port.ViewId;
            TypeId = port.GetTypeId();
            Position = port.GetBoxCenter();
        }
    }

}
