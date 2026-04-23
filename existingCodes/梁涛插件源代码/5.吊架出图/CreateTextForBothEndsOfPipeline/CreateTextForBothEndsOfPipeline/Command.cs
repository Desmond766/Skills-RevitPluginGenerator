using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CreateTextForBothEndsOfPipeline
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Document doc = null;
        View view = null;
        TextNoteType textNoteType = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            view = doc.ActiveView;

            SelWindow selWindow = new SelWindow();
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            bool isRound;
            if (selWindow.rb_round.IsChecked == true)
            {
                isRound = true;
            }
            else
            {
                isRound= false;
            }

            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(ObjectType.Element, new PipeFilter(), "框选管道（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            //获取文字注释类型
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").First();
            Transaction t = new Transaction(doc, "管道两端底部高程文字注释");
            t.Start();
            foreach (var item in references)
            {
                Pipe pipe = doc.GetElement(item) as Pipe;
                XYZ startP = ((pipe.Location as LocationCurve).Curve as Line).GetEndPoint(0);
                XYZ endP = ((pipe.Location as LocationCurve).Curve as Line).GetEndPoint(1);
                string startInfo = "";
                string endInfo = "";
                string rInfo = "";
                foreach (Parameter para in pipe.Parameters)
                {
                    if (para.Definition.Name == "起点中间高程") startInfo = (para.AsDouble() * 304.8).ToString();
                    if (para.Definition.Name == "端点中间高程") endInfo = (para.AsDouble() * 304.8).ToString();
                    //if (para.Definition.Name == "端点中间高程") endInfo = para.AsValueString();
                    //if (para.Definition.Name == "直径") rInfo = (Math.Round(para.AsDouble() * 304.8 / 2 / 10, 0) * 10).ToString();
                    if (para.Definition.Name == "直径") rInfo = (para.AsDouble() * 304.8 / 2).ToString();
                }

                if (startInfo != "" && endInfo != "" && rInfo != "")
                {
                    if (isRound) startInfo = (Math.Round((Convert.ToDouble(startInfo) - Convert.ToDouble(rInfo)) / 10, 0) * 10).ToString();
                    else startInfo = (Math.Round(Convert.ToDouble(startInfo) - Convert.ToDouble(rInfo), 2)).ToString();
                    if (isRound) endInfo = (Math.Round((Convert.ToDouble(endInfo) - Convert.ToDouble(rInfo)) / 10, 0) * 10).ToString();
                    else endInfo = (Math.Round(Convert.ToDouble(endInfo) - Convert.ToDouble(rInfo), 2)).ToString();
                    CreateTextNote(startP, startInfo, pipe, true);
                    CreateTextNote(endP, endInfo, pipe, false);
                    //CreateTextNote(endP, (Convert.ToInt32(endInfo) - Convert.ToInt32(rInfo)).ToString(), pipe, false);
                }
            }
            t.Commit();


            return Result.Succeeded;
        }
        public void CreateTextNote(XYZ p,string info,Pipe pipe,bool start)
        {
            TextNote textNote = TextNote.Create(doc, view.Id, p, info, textNoteType.Id);
            //移动文本 使得文本下边中心对其元素中点
            textNoteType.get_Parameter(BuiltInParameter.LEADER_OFFSET_SHEET).Set(0);
            view.Document.Regenerate();
            Line line = (pipe.Location as LocationCurve).Curve as Line;
            double scaleUp = view.Scale;
            double textNoteWidthUp = textNote.Width * scaleUp;
            // 计算偏移量，使对齐点为文本的下边中心
            XYZ offsetUp = new XYZ(-textNoteWidthUp / 2, 1.75, 0);
            //if (start)
            //{
            //    offsetUp = offsetUp + line.Direction * (500 / 304.8);
            //}
            //else
            //{
            //    offsetUp = offsetUp - line.Direction * (500 / 340.8);
            //}
            // 移动文本注释的位置
            ElementTransformUtils.MoveElement(doc, textNote.Id, offsetUp);
            double rotaUp = line.Direction.AngleTo(XYZ.BasisX);
            Line axisUp = Line.CreateBound(p, p + new XYZ(0, 0, 1));
            if (rotaUp > Math.PI / 2)
            {
                //TaskDialog.Show("sd", "sss");
                rotaUp = Math.PI - rotaUp;
            }
            //TaskDialog.Show("dd", rotaUp.ToString());
            ElementTransformUtils.RotateElement(doc, textNote.Id, axisUp, rotaUp);
            if (!(textNote.BaseDirection.IsAlmostEqualTo(((pipe.Location as LocationCurve).Curve as Line).Direction)
                || textNote.BaseDirection.Negate().IsAlmostEqualTo(((pipe.Location as LocationCurve).Curve as Line).Direction)))
                ElementTransformUtils.RotateElement(doc, textNote.Id, axisUp, -2 * rotaUp);
            if (start)
            {
                ElementTransformUtils.MoveElement(doc, textNote.Id, line.Direction * (500 / 304.8));
            }
            else
            {
                ElementTransformUtils.MoveElement(doc, textNote.Id, line.Direction.Negate() * (500 / 304.8));
            }
        }
    }
    public class PipeFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem.Category.Id.IntegerValue == -2008044)
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
