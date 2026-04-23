using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using RevitUtils;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace MoveLR_Smart
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static double distance = 100;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            ListenUtils listenUtils = new ListenUtils();

            //多选
            IList<Reference> allRef;
            try
            {
                listenUtils.startListen();
                allRef = sel.PickObjects(ObjectType.Element, new MEPCurveSelectionFilter(), "框选要排列的管线（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<Element> list = new List<Element>();
            foreach (Reference item in allRef)
            {
                list.Add(doc.GetElement(item));
            }

            //选择基准管线
            Reference firstPick = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择基准管线");
            Element firstEle = doc.GetElement(firstPick);

            LocationCurve locationCurve1 = firstEle.Location as LocationCurve;
            XYZ firstDir = (locationCurve1.Curve as Line).Direction;
            XYZ firstPo = locationCurve1.Curve.GetEndPoint(0);
            XYZ firstPo1 = locationCurve1.Curve.GetEndPoint(1);

            //弹出对话框，输入希望移动第二个构件后，两个构件的最后距离
            using (Form1 form = new Form1())
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return Result.Failed;
                }
            }

            //排序要移动的管
            list =list.OrderBy(u => (u.Location as LocationCurve).Curve.GetEndPoint(0).DistanceTo
                (Utils.GetProjectivePoint(firstPo, firstPo1, (u.Location as LocationCurve).Curve.GetEndPoint(0)))).ToList();
            if (list[0].Id==firstEle.Id)
            {
                list.RemoveAt(0);//将基准管移出要移动的list
            }
            
            //方向
            LocationCurve locationCurve02 = list[0].Location as LocationCurve;
            XYZ secPo = locationCurve02.Curve.GetEndPoint(0);
            XYZ pLine02 = Utils.GetProjectivePoint(firstPo, firstPo1, secPo);
            //判断方向
            XYZ dir = (pLine02 - secPo).Normalize();
            

            foreach (var secondEle in list)
            {
                LocationCurve locationCurve2 = secondEle.Location as LocationCurve;
                XYZ secondPo = locationCurve2.Curve.GetEndPoint(0);
                XYZ pLine = Utils.GetProjectivePoint(firstPo, firstPo1, secondPo);
                
                //判断方向
                XYZ secondDir = (pLine - secondPo).Normalize();

                double w1 = Utils.GetHalfWidth(firstEle);
                double w2 = Utils.GetHalfWidth(secondEle);
                double w = (w1 + w2) / 304.8;
                double dAB = pLine.DistanceTo(secondPo);
                double dAC;

                if (secondDir.IsAlmostEqualTo(dir))
                {
                    dAC = dAB - w - distance / 304.8;
                }
                else
                {
                    dAC = dAB + w + (Math.Abs(distance)) / 304.8;
                }
                XYZ newLocation = new XYZ();
                newLocation = (pLine - secondPo).Normalize() * dAC;
                using (Transaction t = new Transaction(doc, "水平移动"))
                {
                    t.Start();
                    locationCurve2.Move(newLocation);
                    t.Commit();
                }
                firstEle = secondEle;
                firstPo = (firstEle.Location as LocationCurve).Curve.GetEndPoint(0);
                firstPo1 = (firstEle.Location as LocationCurve).Curve.GetEndPoint(1);
                
               

            }

            return Result.Succeeded;
        }
    }
}
