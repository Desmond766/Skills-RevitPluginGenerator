using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class CopyTicketCmd : IExternalCommand
    {
        List<AssemblyInstance> selectedAssemblyList = new List<AssemblyInstance> ();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            if (!CEGToolsHelper.Utils.CheckReg())
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //1.check active view
            if (!doc.ActiveView.IsAssemblyView || !(doc.ActiveView is ViewSheet))
            {
                message = "tool should run inside a assembly sheet!";
                return Result.Cancelled;
            }

            //2.show dialog
            CopyTicketFrm frm = new CopyTicketFrm(doc);
            if (DialogResult.OK != frm.ShowDialog())
            {
                return Result.Cancelled;
            }
            selectedAssemblyList = frm._selectedAssemblyList;

            if (selectedAssemblyList.Count == 0)
            {
                message = "couldn't find any seleted assembly in the project!";
                return Result.Cancelled;
            }

            //3.sourceCTI
            ViewSheet activeSheet = doc.GetElement(doc.ActiveView.Id) as ViewSheet;
            AssemblyInstance sourceAssembly = doc.GetElement(activeSheet.AssociatedAssemblyInstanceId) 
                as AssemblyInstance;
            
            CEGTicketInfo sourceCTI = new CEGTicketInfo(sourceAssembly);

            using (Transaction t = new Transaction(doc, "CopyTicket"))
            {
                t.Start();

                foreach (AssemblyInstance targetAssembly in selectedAssemblyList)
                {
                    //跳过本身
                    if (targetAssembly.Name == sourceAssembly.Name) { continue; }

                    //4.targetCTI
                    CEGTicketInfo targetCTI = new CEGTicketInfo(targetAssembly);

                    //创建元组集合收集明细表
                    //等循环结束后再修改明细表列宽
                    List<Tuple<ViewSchedule, List<double>>> scheduleList = new List<Tuple<ViewSchedule, List<double>>>();

                    //R2024 schedule重名会报错
                    //因此在最外面收集已创建的schedule
                    List<ViewSchedule> newScheduleList = new List<ViewSchedule>();
                    foreach (TicketInfo tInfo in sourceCTI.CEGTickets)
                    {
                        CopyPasteOptions copyPasteOptions = new CopyPasteOptions();

                        //W-26X W-26X1 W-26X2
                        //sheet number = assemblyName + suffix
                        string suffix = tInfo.TitleBlock.SheetNumber.Replace(sourceCTI.HostAssembly.Name, "");
                        string sheetNumber = targetCTI.HostAssembly.Name + suffix;

                        ViewSheet sheet = null;
                        if (targetCTI.ExistSheetNumber(sheetNumber))
                        {
                            sheet = targetCTI.GetSheetByNumber(sheetNumber);
                        }
                        else
                        {
                            //1.Create blank Sheet
                            sheet = AssemblyViewUtils.CreateSheet
                            (doc, targetCTI.HostAssembly.Id, ElementId.InvalidElementId);
                            //copy titleblock
                            List<ElementId> newIds = ElementTransformUtils.CopyElements(
                                tInfo.HostSheet, new List<ElementId>() { tInfo.TitleBlock.HostTitleBlock.Id }, sheet,
                                Transform.Identity, copyPasteOptions).ToList();
                            //setting parameter
                            sheet.get_Parameter(BuiltInParameter.SHEET_NAME).Set(targetCTI.HostAssembly.Name);

                            //targetCTI.CEGTickets.First().HostSheet
                            sheet.get_Parameter(BuiltInParameter.SHEET_NUMBER).Set(targetCTI.HostAssembly.Name + suffix);
                            sheet.get_Parameter(BuiltInParameter.SHEET_DRAWN_BY).Set(tInfo.TitleBlock.DrawnBy);
                            sheet.get_Parameter(BuiltInParameter.SHEET_CHECKED_BY).Set(tInfo.TitleBlock.CheckedBy);
                        }
                        //如果图纸创建不成功
                        if (sheet == null) { continue; }

                        //复制的图纸
                        TicketInfo newTicket = new TicketInfo(sheet);
                        //2.Create Schedule
                        foreach (ScheduleInfo sInfo in tInfo.Schedules)
                        {
                            if (newTicket.ExistView(sInfo.Name)) { continue; }
                            //create schedule
                            ViewSchedule schedule = null;
                            if (!newScheduleList.Select(u => u.Name).Contains(sInfo.Name))
                            {
                                try
                                {
                                    schedule = AssemblyViewUtils.CreateSingleCategorySchedule
                                    (doc, targetCTI.HostAssembly.Id,
                                    new ElementId(sInfo.Category), sInfo.TemplateId, true);
                                    schedule.Name = sInfo.Name;
                                    newScheduleList.Add(schedule);//收集新建的schedule
                                }
                                catch (Exception)
                                {
                                    //it is project schedule
                                }
                                
                            }
                            else//直接用已有的
                            {
                                schedule = newScheduleList.Where(u => u.Name == sInfo.Name).FirstOrDefault();
                            }

                            //add to sheet
                            if (null != schedule) ScheduleSheetInstance.Create(doc, sheet.Id, schedule.Id, sInfo.Position);

                            //添加到元组集合中
                            if (null != schedule) scheduleList.Add(new Tuple<ViewSchedule, List<double>>(schedule, sInfo.ColumnWidths));

                            //不能在这里直接改列宽 BUG
                            //TaskDialog.Show(schedule.Name, schedule.Definition.GetFieldCount().ToString()
                            //    + "\n" + sInfo.ColumnWidths.Count.ToString());
                            //for (int i = 0; i < schedule.Definition.GetFieldCount(); i++)
                            //{
                            //    ScheduleField _field = schedule.Definition.GetField(i);
                            //    //set GridColumnWidth
                            //    _field.GridColumnWidth = sInfo.ColumnWidths[i];
                            //    //set SheetColumnWidth
                            //    //_field.SheetColumnWidth =
                            //}
                        }

                        //3.Copy DetailItems
                        if (tInfo.DetailItems.Count > 0)
                        {
                            ElementTransformUtils.CopyElements(
                                tInfo.HostSheet, tInfo.DetailItems, sheet,
                                Transform.Identity, copyPasteOptions).ToList();
                        }

                        //4.Create LegendView
                        foreach (LegendViewInfo lInfo in tInfo.LegendViews)
                        {
                            if (newTicket.ExistView(lInfo.Name)) { continue; }
                            Viewport port = Viewport.Create(
                                    doc, sheet.Id, lInfo.ViewId, lInfo.Position);
                            port.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).Set(lInfo.TypeId);
                            port.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).Set(lInfo.TitleOnSheet);
                        }

                        //5.Create AssemblyView
                        foreach (AssemblyViewInfo aInfo in tInfo.AssemblyViews)
                        {
                            if (newTicket.ExistView(aInfo.Name)) { continue; }
                            ViewSection v = AssemblyViewUtils.CreateDetailSection(
                                doc, targetCTI.HostAssembly.Id, aInfo.Orientation, aInfo.TemplateId, true);
                            v.Name = aInfo.Name;
                            v.Scale = aInfo.Scale;
                            v.ChangeTypeId(aInfo.ViewTypeId);
                            v.CropBoxVisible = true;//旋转前必须打开这个

                            if (aInfo.CropboxActive)//剖面
                            {
                                //移动剖面符号到正确位置

                                //找到view所对应的剖面符号OST_Viewers
                                Element elem = doc.GetElement(new ElementId(v.Id.IntegerValue - 1));

                                //更新far clip offset
                                v.get_Parameter(BuiltInParameter.VIEWER_BOUND_OFFSET_FAR).Set(aInfo.FarClipOffset);

                                v.CropBox = aInfo.Cropbox;
                                v.CropBoxActive = aInfo.CropboxActive;

                                //doesn't work
                                //v.CropBox.Transform = aInfo.Cropbox.Transform;

                                //移动
                                ElementTransformUtils.MoveElement(doc, elem.Id,
                                    aInfo.Cropbox.Transform.Origin - v.CropBox.Transform.Origin);

                                //旋转
                                XYZ rotationAxis;
                                double rotationAngle;
                                Utils.GetRotationFromTransforms(v.CropBox.Transform, aInfo.Cropbox.Transform,
                                    out rotationAxis, out rotationAngle);
                                Line axis = Line.CreateUnbound(aInfo.Cropbox.Transform.Origin, rotationAxis);
                                ElementTransformUtils.RotateElement(doc, elem.Id, axis, rotationAngle);

                                //部件offset
                                XYZ center1 = GetAssemblyOrigin(sourceAssembly);
                                XYZ center2 = GetAssemblyOrigin(targetAssembly);
                                ElementTransformUtils.MoveElement(doc, elem.Id,
                                    center2 - center1);
                            }

                            //创建vp
                            Viewport vp = Viewport.Create(
                                doc, sheet.Id, v.Id, aInfo.Position);
                            if (null == vp)
                            {
                                continue;
                            }
                            vp.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).Set(aInfo.TitleTypeId);
                            vp.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).Set(aInfo.TitleOnSheet);
                            vp.LabelLineLength = aInfo.LabelLineLength;
                            vp.LabelOffset = aInfo.LabelOffset;
                            vp.get_Parameter(BuiltInParameter.VIEWPORT_DETAIL_NUMBER).Set(aInfo.DetailNumber);

                            //旋转
                            if (!v.UpDirection.IsAlmostEqualTo(aInfo.UpDirection))
                            {
                                RotateView(doc, v, aInfo.UpDirection);
                            }
                        }

                        //6.Create 3Dview
                        foreach (ThreeDViewInfo threeDInfo in tInfo.ThreeDViews)
                        {
                            if (newTicket.ExistView(threeDInfo.Name)) { continue; }
                            View3D v = AssemblyViewUtils.Create3DOrthographic(
                                doc, targetCTI.HostAssembly.Id, threeDInfo.TemplateId, true);
                            v.Name = threeDInfo.Name;
                            v.Scale = threeDInfo.Scale;
                            v.ChangeTypeId(threeDInfo.ViewTypeId);
                            Viewport vp = Viewport.Create(
                                doc, sheet.Id, v.Id, threeDInfo.Position);
                            vp.get_Parameter(BuiltInParameter.ELEM_TYPE_PARAM).Set(threeDInfo.TitleTypeId);
                            vp.get_Parameter(BuiltInParameter.VIEW_DESCRIPTION).Set(threeDInfo.TitleOnSheet);
                            vp.LabelLineLength = threeDInfo.LabelLineLength;
                            vp.LabelOffset = threeDInfo.LabelOffset;
                        }

                    }

                    //在这修改明细表列宽
                    foreach (Tuple<ViewSchedule, List<double>> item in scheduleList)
                    {
                        for (int i = 0; i < item.Item1.Definition.GetFieldCount(); i++)
                        {
                            ScheduleField _field = item.Item1.Definition.GetField(i);
                            //set GridColumnWidth
                            if (item.Item2.Count >= i + 1)
                            {
                                _field.GridColumnWidth = item.Item2[i];
                            }
                            //set SheetColumnWidth
                            //_field.SheetColumnWidth =
                        }
                    }
                }

                t.Commit();
            }
            return Result.Succeeded;
        }

        // what we need to rotat is CropBoxElemenet
        public ElementId GetCropBoxFor(Autodesk.Revit.DB.View view)
        {
            ParameterValueProvider provider
              = new ParameterValueProvider(new ElementId(
                (int)BuiltInParameter.ID_PARAM));

            FilterElementIdRule rule
              = new FilterElementIdRule(provider,
                new FilterNumericEquals(), view.Id);

            ElementParameterFilter filter
              = new ElementParameterFilter(rule);

            return new FilteredElementCollector(view.Document)
              .WherePasses(filter)
              .ToElementIds()
              .Where<ElementId>(a => a.IntegerValue
               != view.Id.IntegerValue)
              .FirstOrDefault<ElementId>();
        }
        public void RotateView(Document doc, Autodesk.Revit.DB.View view, XYZ sourceUpDir)
        {
            double angle = view.UpDirection.AngleTo(sourceUpDir);
            ElementId cropBoxElementId = GetCropBoxFor(view);
            BoundingBoxXYZ bbox = doc.GetElement(cropBoxElementId).get_BoundingBox(view);
            //BoundingBoxXYZ bbox = view.CropBox;
            if (null == bbox)
            {
                //bbox = view.CropBox;//有bug//直接return
                return;
            }
            //BoundingBoxXYZ bbox = doc.GetElement(view.AssemblyInstanceId).get_BoundingBox(view);
            XYZ center = 0.5 * (bbox.Max + bbox.Min);

            Line axis = Line.CreateBound(
              center, center + view.ViewDirection);

            //向量试旋转
            Transform t = Transform.CreateRotation(view.ViewDirection, angle);
            if (t.OfVector(view.UpDirection).IsAlmostEqualTo(sourceUpDir))
            {
                ElementTransformUtils.RotateElement(doc,
              cropBoxElementId, axis, angle);
            }
            else
            {
                ElementTransformUtils.RotateElement(doc,
              cropBoxElementId, axis, -angle);
            }
        }

        private XYZ GetAssemblyOrigin(AssemblyInstance assembly)
        {
            List<Element> pCaList = new List<Element>();
            Document doc = assembly.Document;
            foreach (ElementId id in assembly.GetMemberIds())
            {
                Element elem = doc.GetElement(id);
                if (elem != null)
                {
                    if (elem.Category.Id.IntegerValue
                        == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        if (!elem.Name.Contains("CORBEL"))
                        {
                            pCaList.Add(elem);
                        }
                    }
                }
            }
            if (pCaList.Count > 0)
            {
                return (pCaList[0].Location as LocationPoint).Point;
            }
            return null;
        }
    }
}
