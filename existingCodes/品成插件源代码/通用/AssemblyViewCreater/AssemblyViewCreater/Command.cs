using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssemblyViewCreater
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public List<ElementId> selectedSheetList = new List<ElementId>();
        public List<AssemblyViewInfo> assemblyInfoList = new List<AssemblyViewInfo>();

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // select
            if (sel.GetElementIds().Count == 0)
            {
                message = "Select Schedule First!";
                return Result.Cancelled;
            }

            // collect info
            foreach (ElementId id in sel.GetElementIds())
            {
                Element elem = doc.GetElement(id);
                if (elem is Viewport)
                {
                    Viewport viewPortInst = elem as Viewport;
                    ViewSection vs = doc.GetElement(viewPortInst.ViewId) as ViewSection;

                    AssemblyViewInfo info = new AssemblyViewInfo()
                    {
                        Name = vs.Name,
                        TemplateId = vs.ViewTemplateId,
                        Position = viewPortInst.GetBoxCenter(),
                        direction = GetAssemblyViewDirection(vs.Name)
                    };
                    assemblyInfoList.Add(info);
                }
            }
            if (assemblyInfoList.Count == 0)
            {
                message = "No Assembly Slected!";
                return Result.Cancelled;
            }
            
            //show dialog
            AssemblySheetFrm frm = new AssemblySheetFrm(doc);
            frm.ShowDialog();
            selectedSheetList = frm.selectedSheetList;

            using (Transaction tran = new Transaction(doc, "View"))
            {
                tran.Start();
                foreach (ElementId id in selectedSheetList)
                {
                    //try
                    //{
                    ViewSheet sheet = doc.GetElement(id) as ViewSheet;
                    ElementId assemblyInstanceId = sheet.AssociatedAssemblyInstanceId;
                    if (null != sheet)
                    {
                        foreach (AssemblyViewInfo info in assemblyInfoList)
                        {
                            //create schedule
                            ViewSection schedule = AssemblyViewUtils.CreateDetailSection
                                (doc, assemblyInstanceId, info.direction, info.TemplateId, true);
                            schedule.Name = info.Name;
                            //schedule.Title = info.TitleOnSheet;
                            //add to sheet
                            Viewport.Create(doc, sheet.Id, schedule.Id, info.Position);
                        }
                    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    TaskDialog.Show("r", ex.Message + ex.StackTrace);
                    //    continue;
                    //}
                }

                tran.Commit();
            }


            return Result.Succeeded;
        }


        public class AssemblyViewInfo
        {
            public string Name { get; set; }
            public string TitleOnSheet { get; set; }
            public BuiltInCategory Category { get; set; }
            public ElementId TemplateId { get; set; }
            public XYZ Position { get; set; }
            public AssemblyDetailViewOrientation direction { get; set; }
        }

        public static AssemblyDetailViewOrientation GetAssemblyViewDirection(string s)
        {
            AssemblyDetailViewOrientation direction=new AssemblyDetailViewOrientation();
            if (s.Contains("Front"))
            {
                direction = AssemblyDetailViewOrientation.ElevationFront;
            }
            else if (s.Contains("Back"))
            {
                direction = AssemblyDetailViewOrientation.ElevationBack;
            }
            else if (s.Contains("Left"))
            {
                direction = AssemblyDetailViewOrientation.ElevationLeft;
            }
            else if (s.Contains("Right"))
            {
                direction = AssemblyDetailViewOrientation.ElevationRight;
            }
            else if (s.Contains("Top"))
            {
                direction = AssemblyDetailViewOrientation.ElevationTop;
            }
            else if (s.Contains("Bottom"))
            {
                direction = AssemblyDetailViewOrientation.ElevationBottom;
            }
            else if (s.Contains("Detail Section A"))
            {
                direction = AssemblyDetailViewOrientation.DetailSectionA;
            }
            else if (s.Contains("Detail Section B"))
            {
                direction = AssemblyDetailViewOrientation.DetailSectionB;
            }
            else if (s.Contains("Plan Detail"))
            {
                direction = AssemblyDetailViewOrientation.HorizontalDetail;
            }
            else
            {
                TaskDialog.Show("提示", "无法判断选取的视图方向");
            }
            return direction;
        }
    }
}
