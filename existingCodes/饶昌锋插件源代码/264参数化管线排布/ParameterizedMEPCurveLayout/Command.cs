using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace ParameterizedMEPCurveLayout
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        private StartWindow window;
        private System.Windows.Controls.Frame frame;
        //事件
        MEPCurveOperationEvent mEPCurveOperationEvent;
        ExternalEvent mEPCurveOperationExternalEvent;

        ReOrderAndIntervalEvent reOrderAndIntervalEvent;
        ExternalEvent reOrderAndIntervalExternalEvent;

        PipelineConnectionEvent pipelineConnectionEvent;
        ExternalEvent pipelineConnectionExternalEvent;

        BottomAlignmentHeightDifferenceEvent bottomAlignmentHeightDifferenceEvent;
        ExternalEvent bottomAlignmentHeightDifferenceExternalEvent;


        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;

            //截断的中间管线
            IList<MEPCurve> mEPCurves = new List<MEPCurve>();
            //遍历元素 打断管线
            List<MEPCurveGroup> mEPCurveGroups = new List<MEPCurveGroup>();
            GetTargetMEPCurve.GetMEPCurveElement(uidoc, ref mEPCurves, ref mEPCurveGroups);
            double sructDistance = ProfileFrame.GetStructuralClearance(doc, mEPCurves);
            //StatrApplication.Main(uidoc);
            //WindowControl window = new WindowControl();
            window = new StartWindow();
            window.SetStructDistance(sructDistance.ToString());
            //外部事件的注册
            mEPCurveOperationEvent = new MEPCurveOperationEvent();
            mEPCurveOperationEvent.mEPCurves = mEPCurves;
            mEPCurveOperationExternalEvent = ExternalEvent.Create(mEPCurveOperationEvent);

            reOrderAndIntervalEvent = new ReOrderAndIntervalEvent();
            reOrderAndIntervalExternalEvent = ExternalEvent.Create(reOrderAndIntervalEvent);

            pipelineConnectionEvent = new PipelineConnectionEvent
            {
                mEPCurveGroups = mEPCurveGroups,
                mEPCurves = mEPCurves
            };
            pipelineConnectionExternalEvent = ExternalEvent.Create(pipelineConnectionEvent);

            bottomAlignmentHeightDifferenceEvent = new BottomAlignmentHeightDifferenceEvent();
            bottomAlignmentHeightDifferenceEvent.mEPCurves = mEPCurves;
            bottomAlignmentHeightDifferenceExternalEvent = ExternalEvent.Create(bottomAlignmentHeightDifferenceEvent);

            //外部事件的触发
            window.MEPCurveOperationEventHandler += Window_MEPCurveOperationEventHandler;
            window.ReOrderAndIntervalHandler += Window_ReOrderAndIntervalHandler;
            window.PipelineConnectionHandler += Window_PipelineConnectionHandler;
            window.BottomAlignmentHeightDifferenceHandler += Window_BottomAlignmentHeightDifferenceHandler;

            window.Show();
            frame = window.Windows;


            return Result.Succeeded;
        }

        /// <summary>
        /// 下对齐及高度间距修改的外部事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void Window_BottomAlignmentHeightDifferenceHandler(object sender, EventArgs e)
        {
            bottomAlignmentHeightDifferenceExternalEvent.Raise();
        }

        /// <summary>
        /// 管线连接排序的外部触发事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PipelineConnectionHandler(object sender, EventArgs e)
        {
            pipelineConnectionExternalEvent.Raise();
            pipelineConnectionEvent.inputInterval = window.GetInputIntervalTextBoxValue();
        }

        /// <summary>
        /// 重新选择并排序的外部事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_ReOrderAndIntervalHandler(object sender, EventArgs e)
        {
            if (window.insulatedRadioButtonIsChecked)
            {
                reOrderAndIntervalEvent.sheetIndex = 1;
            }
            else
            {
                reOrderAndIntervalEvent.sheetIndex = 2;
            }
            reOrderAndIntervalExternalEvent.Raise();
        }

        /// <summary>
        /// 分组排序的外部事件触发
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MEPCurveOperationEventHandler(object sender, EventArgs e)
        {
            window.GetInsulatedRadioButton();
            //判断类型 传递参数选择相对的表
            if (window.insulatedRadioButtonIsChecked)
            {
                mEPCurveOperationEvent.sheetIndex = 1;
            }
            else
            {
                mEPCurveOperationEvent.sheetIndex = 2;
            }
            mEPCurveOperationEvent.structDistance = window.GetInsulatedTextBoxValue();
            reOrderAndIntervalEvent.structDistance = window.GetInsulatedTextBoxValue();
            mEPCurveOperationExternalEvent.Raise();
        }


    }
}
