using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public enum PrecastCategory
    {
        COLUMN = 1,
        ITBEAM = 2,
        LBEAM = 3,
        RBEAM = 4,
        WALL = 5,
        RAMPWALL = 6,
        SHEARWALL = 7,
        SPANDREL = 8,
        DOUBLETEE = 9,
        FLATSLAB = 10,
        STAIR = 11,
        UNKNOW = 12
    }

    public class PCaTicketingHelper
    {
        public Document Doc { get; set; }//当前文档
        public AssemblyInstance Assembly { get; set; }//选择的assembly

        public List<View> ViewTemplates { get; set; }
        public View TopView { get; set; }
        public View BottomView { get; set; }
        public View FrontView { get; set; }
        public View BackView { get; set; }
        public View LeftView { get; set; }
        public View RightView { get; set; }

        public string TitleBlockName = "LEGACY PRECAST_11X17";
        public ElementId TitleBlockId = null;
        public ViewSheet Sheet = null;

        public string View3DTemplateName = "MODEL COLORS - 30% TRANSPARENT";
        public ElementId View3DTemplateId = null;
        public Element View3D= null;

        public string ViewPortTypeName = "Title w Line (LARGE NUMBER) (No Scale)";
        public ElementId ViewPortTypeId = null;
        
        public PCaTicketingHelper(AssemblyInstance assembly)
        {
            Doc = assembly.Document;
            Assembly = assembly;

            //收集视图中的视图样板
            FilteredElementCollector viewTemplateCol = new FilteredElementCollector(Doc);
            ViewTemplates = viewTemplateCol
                .OfClass(typeof(View))
                .Cast<View>()
                .Where(u => u.IsTemplate)
                .ToList();
            View3DTemplateId = ViewTemplates.Where(u => u.Name == View3DTemplateName).First().Id;
            
            //收集视图中的图框
            FilteredElementCollector titleBlockCol = new FilteredElementCollector(Doc);
            List<Element> titleBlocks = titleBlockCol.OfClass(typeof(FamilySymbol))
                .OfCategory(BuiltInCategory.OST_TitleBlocks)
                .ToElements()
                .ToList();
            TitleBlockId = titleBlocks.Where(u => u.Name == TitleBlockName).First().Id;

            //收集视图中的类型
            FilteredElementCollector viewPortTypeCol = new FilteredElementCollector(Doc);
            List<Element> viewPortTypes = viewPortTypeCol.OfClass(typeof(ElementType))
                .ToElements()
                .ToList();
            ViewPortTypeId = viewPortTypes.Where(u => u.Name == ViewPortTypeName).First().Id;

        }

        public void CreateAssemblySheet()
        {
            //创建图纸
            Sheet = AssemblyViewUtils.CreateSheet(Doc, Assembly.Id, TitleBlockId);
            Sheet.Name = Assembly.Name;
            Sheet.SheetNumber = Assembly.Name;
        }

        public void Create3DView()
        {
            //创建三维视图
            View3D = AssemblyViewUtils.Create3DOrthographic(Doc, Assembly.Id, View3DTemplateId, true);
        }

        public View CreateAssemblyView(
            AssemblyDetailViewOrientation viewOrientation, 
            string viewName,
            string templateName,
            XYZ origin)
        {
            //视图样板
            ElementId templateId = ElementId.InvalidElementId;
            var templates = ViewTemplates.Where(u => u.Name == templateName);
            if (templates.Count() > 0)
            {
                templateId = ViewTemplates.Where(u => u.Name == templateName).First().Id;
            }
            //创建视图
            ViewSection view = AssemblyViewUtils.CreateDetailSection(
                Doc,
                Assembly.Id,
                viewOrientation,
                templateId,
                true);
            view.Name = viewName;
            Viewport viewPort = Viewport.Create(Doc, Sheet.Id, view.Id, origin);
            viewPort.ChangeTypeId(ViewPortTypeId);
            return view;
        }
        public virtual void CreateAssemblyView()
        {
            //任意组合需要的视图
        }

        public virtual void TicketingView()
        {

        }
    }
}
