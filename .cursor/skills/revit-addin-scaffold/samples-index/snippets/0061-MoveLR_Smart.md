# Sample Snippet: MoveLR_Smart

Source project: `existingCodes\品成插件源代码\机电\MoveLR_Smart\MoveLR_Smart`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MoveLR_Smart
{
    class Utils
    {
        #region 传入直线上两点和线外一点，得到线外点在直线上的投影点
        public static XYZ GetProjectivePoint(XYZ standardStartPoint, XYZ standardEndPoint, XYZ modifyStartPoint)
        {
            XYZ pLine = new XYZ();
            double k = (standardEndPoint.Y - standardStartPoint.Y) / (standardEndPoint.X - standardStartPoint.X);
            if (Math.Abs(k) < 0.1) //if (k == 0)
            {
                pLine = new XYZ(modifyStartPoint.X, standardStartPoint.Y, modifyStartPoint.Z);

            }
            else if (Math.Abs(standardEndPoint.X - standardStartPoint.X) < 0.1)
            {
                pLine = new XYZ(standardEndPoint.X, modifyStartPoint.Y, modifyStartPoint.Z);
            }
            else
            {
                double x = (k * (standardStartPoint.X) + ((modifyStartPoint.X) / k) + modifyStartPoint.Y - standardStartPoint.Y) / (1 / k + k);
                double y = -1 / k * (x - modifyStartPoint.X) + modifyStartPoint.Y;
                pLine = new XYZ(x, y, modifyStartPoint.Z);

            }
            return pLine;
        }

        #endregion

        #region 传入Element,得到其一半的宽度值
        public static double GetHalfWidth(Element e)
        {
            double w = 0.0;
            if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        w = double.Parse(value) / 2;
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "宽度")
                    {
                        w = double.Parse(p.AsValueString()) / 2;
                    }
                }
            }
            else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves
                || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit)
            {
                foreach (Parameter p in e.Parameters)
                {
                    if (p.Definition.Name == "外径")
                    {
                        string s = p.AsValueString();
                        int idx = s.LastIndexOf(" ");
                        string value = s.Substring(0, idx);
                        w = double.Parse(value) / 2;

                    }
                }
            }
            return w;
        }
        #endregion
    }
}

```

