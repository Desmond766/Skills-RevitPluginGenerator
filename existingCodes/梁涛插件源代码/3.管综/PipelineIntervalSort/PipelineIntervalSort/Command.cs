using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
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

namespace PipelineIntervalSort
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            IList<Reference> refers;
            Reference reference;
            XYZ p1;
            XYZ p2;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                refers = sel.PickObjects(ObjectType.Element, new PipelineFilter(), "框选管线以排序（按空格键完成框选，ESC键取消）");
                reference = sel.PickObject(ObjectType.Element, new PipelineFilter(), "选择两点作为管线排序方向(第一点)");
                p1 = reference.GlobalPoint;
                p2 = sel.PickObject(ObjectType.Element, new PipelineFilter(), "选择两点作为管线排序方向(第二点)").GlobalPoint;
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Succeeded;
            }

            List<MEPCurve> mEPCurves = refers.Select(r => doc.GetElement(r) as MEPCurve).ToList();

            bool isMix = IsMix(mEPCurves);
            MainWindow mainWindow = new MainWindow(isMix);
            mainWindow.ShowDialog();
            if (mainWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

            p1 = new XYZ(p1.X, p1.Y, 0);
            p2 = new XYZ(p2.X, p2.Y, 0);

            XYZ sortDir = GetSortDir(doc.GetElement(reference), p1, p2);
            Line sortLine = Line.CreateUnbound(p1, sortDir);

            //TaskDialog.Show("re", Properties.Settings.Default.Distance.ToString());
            using (Transaction t = new Transaction(doc, "管线等间距排列"))
            {
                t.Start();
                if (isMix)
                {
                    SortMepCurves(mEPCurves, sortLine, p1, Properties.Settings.Default.Distance / 304.8, Properties.Settings.Default.CableMinToMax, Properties.Settings.Default.PipeMinToMax, Properties.Settings.Default.CableFirst);
                }
                else
                {
                    SortMepCurves(mEPCurves, sortLine, p1, Properties.Settings.Default.Distance / 304.8, Properties.Settings.Default.MinToMax, Properties.Settings.Default.CableFirst);
                }
                t.Commit();
            }

            return Result.Succeeded;
        }
        /// <summary>
        /// 判断mep集合中的是否存在多种类别
        /// </summary>
        /// <param name="meps"></param>
        /// <returns></returns>
        private bool IsMix(List<MEPCurve> meps)
        {
            bool result = false;

            var group = meps.GroupBy(m => m.Category.Id.IntegerValue);
            if (group.Count() >= 2)
            {
                result = true;
            }

            return result;
        }
        /// <summary>
        /// 获取元素在line上的投影点
        /// </summary>
        /// <param name="line"></param>
        /// <param name="mep"></param>
        /// <returns></returns>
        private XYZ GetProjectPoint(Line line, MEPCurve mep)
        {
            Curve mepCurve = (mep.Location as LocationCurve).Curve;
            XYZ point = mepCurve.GetEndPoint(0).Add(mepCurve.GetEndPoint(1)) / 2;
            return line.Project(point).XYZPoint;
        }

        /// <summary>
        /// 对mep进行从大到小/从小到大排序
        /// </summary>
        /// <param name="mEPCurves"></param>
        /// <param name="sortLine"></param>
        /// <param name="startPoint"></param>
        /// <param name="dis"></param>
        /// <param name="minToMax"></param>
        /// <param name="cableFirst"></param>
        private void SortMepCurves(List<MEPCurve> mEPCurves, Line sortLine, XYZ startPoint, double dis, bool minToMax, bool cableFirst)
        {
            if (minToMax)
            {
                if (cableFirst)
                {
                    mEPCurves = mEPCurves.OrderBy(m => m.Category.Id.IntegerValue).ThenBy(m => m.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? m.Width).ToList();
                }
                else
                {
                    mEPCurves = mEPCurves.OrderByDescending(m => m.Category.Id.IntegerValue).ThenBy(m => m.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? m.Width).ToList();
                }
                
            }
            else
            {
                if (cableFirst)
                {
                    mEPCurves = mEPCurves.OrderBy(m => m.Category.Id.IntegerValue).ThenByDescending(m => m.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? m.Width).ToList();
                }
                else
                {
                    mEPCurves = mEPCurves.OrderByDescending(m => m.Category.Id.IntegerValue).ThenByDescending(m => m.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? m.Width).ToList();
                }
            }
            XYZ sortDir = sortLine.Direction;
            for (int i = 0; i < mEPCurves.Count; i++)
            {
                XYZ pp = GetProjectPoint(sortLine, mEPCurves[i]);
                //startPoint += (GetMepWidth(mEPCurves[i]) / 2) * sortDir;
                mEPCurves[i].Location.Move(startPoint - pp);
                if (i <= mEPCurves.Count - 2) startPoint += sortLine.Direction * (dis + (GetMepWidth(mEPCurves[i]) + GetMepWidth(mEPCurves[i + 1])) / 2);
            }
        }
        private void SortMepCurves(List<MEPCurve> mEPCurves, Line sortLine, XYZ startPoint, double dis, bool cableMinToMax, bool pipeMinToMax, bool cableFirst)
        {
            List<MEPCurve> sortMeps = new List<MEPCurve>();
            List<MEPCurve> pipes = mEPCurves.Where(m => m is Pipe).ToList();
            List<MEPCurve> cables = mEPCurves.Where(m => m is CableTray).ToList();

            if (cableMinToMax)
            {
                cables = cables.OrderBy(c => c.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? c.Width).ToList();
            }
            else
            {
                cables = cables.OrderByDescending(c => c.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? c.Width).ToList();
            }

            if (pipeMinToMax)
            {
                pipes = pipes.OrderBy(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? p.Width).ToList();
            }
            else
            {
                pipes = pipes.OrderByDescending(p => p.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? p.Width).ToList();
            }

            if (cableFirst)
            {
                sortMeps.AddRange(cables);
                sortMeps.AddRange(pipes);
            }
            else
            {
                sortMeps.AddRange(pipes);
                sortMeps.AddRange(cables);
            }
           
            XYZ sortDir = sortLine.Direction;
            for (int i = 0; i < sortMeps.Count; i++)
            {
                XYZ pp = GetProjectPoint(sortLine, sortMeps[i]);
                sortMeps[i].Location.Move(startPoint - pp);
                if (i <= sortMeps.Count - 2) startPoint += sortLine.Direction * (dis + (GetMepWidth(sortMeps[i]) + GetMepWidth(sortMeps[i + 1])) / 2);
            }
        }

        /// <summary>
        /// 获取mep的宽度/直径
        /// </summary>
        /// <param name="mEPCurve"></param>
        /// <returns></returns>
        private double GetMepWidth(MEPCurve mEPCurve)
        {
            return mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? mEPCurve.Width;
        }
        /// <summary>
        /// 获取元素在平面上与自身Line的向量垂直的向量
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        private XYZ GetElementVerDir(Element element)
        {
            XYZ result;

            Line line = (element.Location as LocationCurve).Curve as Line;
            XYZ p0 = line.GetEndPoint(0);
            XYZ p1 = line.GetEndPoint(1);
            Line uvLine = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));

            result = uvLine.Direction.CrossProduct(XYZ.BasisZ).Normalize();



            return result;
        }
        /// <summary>
        /// 获取排序的方向
        /// </summary>
        /// <param name="element"></param>
        /// <param name="p1">向量起点</param>
        /// <param name="p2">未投影前的向量终点</param>
        /// <returns></returns>
        private XYZ GetSortDir(Element element, XYZ p1, XYZ p2)
        {
            XYZ result;

            XYZ verDir = GetElementVerDir(element);
            Line verLine = Line.CreateUnbound(p1, verDir);
            XYZ pp2 = verLine.Project(p2).XYZPoint;

            result = (pp2 - p1).Normalize();

            return result;
        }
    }
    public class PipelineFilter : ISelectionFilter
    {
        Element selElem = null;
        public bool AllowElement(Element elem)
        {
            //if (selElem != null)
            //{
            //    if (selElem.Category.Id == elem.Category.Id)
            //    {
            //        return true;
            //    }
            //    return false;
            //}
            //else if (elem is Pipe || elem is CableTray)
            //{
            //    selElem = elem;
            //    return true;
            //}
            if (elem is MEPCurve mep && (elem is Pipe || elem is CableTray))
            {
                selElem = elem;
                try
                {
                    double width = mep.get_Parameter(BuiltInParameter.RBS_PIPE_OUTER_DIAMETER)?.AsDouble() ?? mep.Width;
                }
                catch (Exception)
                {
                    return false;
                }
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
