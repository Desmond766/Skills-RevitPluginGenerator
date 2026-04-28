using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using System.Threading;
using System.Windows.Threading;
using RevitUtils;

namespace PipelineAlignment
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        // 管线对齐（选择对齐管道顶、中心、底对齐）
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //int rou = (int)Math.Round(2.5, 0, MidpointRounding.AwayFromZero);
            //MEPCurve mep2 = doc.GetElement(sel.PickObject(ObjectType.Element)) as MEPCurve;
            //TaskDialog.Show("revit", rou.ToString()+"\n"+mep2.Width);
            //return Result.Succeeded;

            MainWindow mainWindow = new MainWindow();
            var intPtr = commandData.Application.MainWindowHandle;
            // 一个提供WPF窗体和win32之间互相操作的类，允许开发者获取WPF窗体的hwnd和设置WPF窗体的所有者
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(mainWindow);
            windowInteropHelper.Owner = intPtr;
            mainWindow.Show();

            ListenUtils listenUtils = new ListenUtils();
        Next:
            Reference refer;
            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                refer = sel.PickObject(ObjectType.Element, new MEPFilter(), "选择基准管线(关闭窗口结束)");
                references = sel.PickObjects(ObjectType.Element, new MEPFilter(), "选择要对齐的管线(按空格键完成框选，关闭窗口结束)");
                listenUtils.stopListen();

                MEPCurve mEPCurve = doc.GetElement(refer) as MEPCurve;
                bool addInsulationLayer = Properties.Settings.Default.InsulationLayer;
                int alignment = Properties.Settings.Default.Alignment;
                using (TransactionGroup TG = new TransactionGroup(doc, "横管对齐"))
                {
                    TG.Start();

                    double selHeight = GetAlignmentHeight(mEPCurve, addInsulationLayer, alignment);
                    foreach (var reference in references)
                    {
                        MEPCurve mep = doc.GetElement(reference) as MEPCurve;
                        double height = GetAlignmentHeight(mep, addInsulationLayer, alignment);
                        SetAlignmentHeight(doc, mep, selHeight - height, alignment);
                    }
                    TG.Assimilate();
                }
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                if (mainWindow.IsClose == true) return Result.Succeeded;
                else goto Next;
            }
            if (mainWindow.IsClose == false) goto Next;
            //TaskDialog.Show("revit", (mainWindow.cb_thickness.IsChecked == true) + "\n" + (mainWindow.rb_bottom.IsChecked));
            //mainWindow.Close();

            return Result.Succeeded;
        }
        private double GetAlignmentHeight(MEPCurve mEPCurve, bool addLayer, int alignment)
        {
            double height = 0;

            if (alignment == 1)
            {
                double top = mEPCurve.get_Parameter(BuiltInParameter.RBS_DUCT_TOP_ELEVATION)?.AsDouble() ??
                    mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPE_TOP_ELEVATION)?.AsDouble() ??
                    mEPCurve.get_Parameter(BuiltInParameter.RBS_CTC_TOP_ELEVATION)?.AsDouble() ?? 0.0;

                if (addLayer) top += mEPCurve.get_Parameter(BuiltInParameter.RBS_REFERENCE_INSULATION_THICKNESS)?.AsDouble() ?? 0.0;
                height = top;
            }
            else if (alignment == 2)
            {
                double center = mEPCurve.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM).AsDouble();
                height = center;
            }
            else if (alignment == 3)
            {
                double bottom = mEPCurve.get_Parameter(BuiltInParameter.RBS_DUCT_BOTTOM_ELEVATION)?.AsDouble() ??
                    mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION)?.AsDouble() ??
                    mEPCurve.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION)?.AsDouble() ?? 0.0;

                if (addLayer) bottom -= mEPCurve.get_Parameter(BuiltInParameter.RBS_REFERENCE_INSULATION_THICKNESS)?.AsDouble() ?? 0.0;
                height = bottom;
            }

            return height;
        }
        private void SetAlignmentHeight(Document doc, MEPCurve mep, double height, int alignment)
        {
            Parameter alignmentPara = null;
            //Parameter centerPara = mep.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
            if (mep is Duct)
            {
                if (alignment == 1) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_DUCT_TOP_ELEVATION);
                else if (alignment == 2) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
                else if (alignment == 3) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_DUCT_BOTTOM_ELEVATION);
            }
            else if (mep is Pipe)
            {
                if (alignment == 1) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_PIPE_TOP_ELEVATION);
                else if (alignment == 2) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
                else if (alignment == 3) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_PIPE_BOTTOM_ELEVATION);
            }
            else if (mep is CableTray)
            {
                if (alignment == 1) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_CTC_TOP_ELEVATION);
                else if (alignment == 2) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
                else if (alignment == 3) alignmentPara = mep.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION);
            }
            using (Transaction t = new Transaction(doc, "对齐"))
            {
                t.Start();
                alignmentPara.Set(alignmentPara.AsDouble() + height);
                t.Commit();
            }
            using (Transaction t = new Transaction(doc, "中间高程取整"))
            {
                //Parameter centerPara = mep.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM);
                //double centerValue = Math.Ceiling(centerPara.AsDouble() * 304.8);
                //t.Start();
                //centerPara.Set(centerValue / 304.8);
                //t.Commit();
                Connector con = mep.ConnectorManager.Connectors.Cast<Connector>().First();
                var conShape = con.Shape;
                Parameter roundPara = conShape == ConnectorProfileType.Round ? mep.get_Parameter(BuiltInParameter.RBS_OFFSET_PARAM) : 
                    (conShape == ConnectorProfileType.Rectangular || conShape == ConnectorProfileType.Oval) ? mep.LookupParameter("底部高程") : null;
                if (roundPara != null)
                {
                    t.Start();

                    double roundValue = Math.Round((roundPara.AsDouble() * 304.8) / 10.0, 0, MidpointRounding.AwayFromZero) * 10.0;
                    roundPara.Set(roundValue / 304.8);

                    t.Commit();
                }
            }
        }
    }
    public class MEPFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is MEPCurve)
            {
                return true;
            }
            return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}
