# Sample Snippet: MEP_SmartTrim

Source project: `existingCodes\品成插件源代码\机电\MEP_SmartTrim\MEP_SmartTrim`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using System.Linq;

namespace MEP_SmartTrim
{
    [Transaction(TransactionMode.Manual)]
    class Command : IExternalCommand
    {
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ corner1;
        XYZ corner2;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // 选择构件
            Reference r1 = sel.PickObject(ObjectType.Element, new MepSelFilter(), "选择管道\\风管\\桥架1");
            Reference r2 = sel.PickObject(ObjectType.Element, new MepSelFilter(doc.GetElement(r1)), "选择管道\\风管\\桥架2");
            MEPCurve mEPCurve1 = doc.GetElement(r1) as MEPCurve;
            MEPCurve mEPCurve2 = doc.GetElement(r2) as MEPCurve;
            Line line1 = (mEPCurve1.Location as LocationCurve).Curve as Line;
            Line line2 = (mEPCurve2.Location as LocationCurve).Curve as Line;

            // 判断起点、终点
            double maxDistance = 0.0;
            double distance;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    distance = line1.GetEndPoint(i).DistanceTo(line2.GetEndPoint(j));
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        startPoint = line1.GetEndPoint(i);
                        fittingPoint1 = line1.GetEndPoint(1 - i);
                        endPoint = line2.GetEndPoint(j);
                        fittingPoint2 = line2.GetEndPoint(1 - j);
                    }
                }
            }

            // 计算关键点
            XYZ projectivePoint = Utils.GetProjectivePoint(line2, startPoint);
            XYZ direction1 = (startPoint - projectivePoint).Normalize();
            XYZ direction2 = (endPoint - projectivePoint).Normalize();
            if (!direction1.IsAlmostEqualTo(line1.Direction) && !direction1.IsAlmostEqualTo(line1.Direction.Negate()))
            {
                message = "构件不垂直！";
                return Result.Failed;
            }
            //double trimDistance = mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 1.6;
            double trimDistance = (mEPCurve1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM)?.AsDouble() ?? mEPCurve1.Width) * 1.6;
            corner1 = projectivePoint + direction1 * trimDistance;
            corner2 = projectivePoint + direction2 * trimDistance;

            //using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartTrim"))
            //{
            //    t.Start();
            //    Trim(doc, mEPCurve1 as Pipe, mEPCurve2 as Pipe);
            //    t.Commit();
            //}
            //using (TransactionGroup TG = new TransactionGroup(doc, "BimtransMEPTools.SmartTrim"))
            //{
            //    TG.Start();
            //    Trim(doc, mEPCurve1, mEPCurve2);
            //    TG.Assimilate();
// ... truncated ...
```

## Command2.cs

```csharp
using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;

namespace MEP_SmartTrim
{
    [Transaction(TransactionMode.Manual)]
    class Command2 : IExternalCommand
    {
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ corner1;
        XYZ corner2;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            // 选择构件
            Reference r1 = sel.PickObject(ObjectType.Element, new PipeSelectionFilter(), "选择管道");
            Reference r2 = sel.PickObject(ObjectType.Element, new PipeSelectionFilter(), "选择管道");
            Pipe pipe1 = doc.GetElement(r1) as Pipe;
            Pipe pipe2 = doc.GetElement(r2) as Pipe;
            Line line1 = (pipe1.Location as LocationCurve).Curve as Line;
            Line line2 = (pipe2.Location as LocationCurve).Curve as Line;

            // 判断起点、终点
            double maxDistance = 0.0;
            double distance;
            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    distance = line1.GetEndPoint(i).DistanceTo(line2.GetEndPoint(j));
                    if (distance > maxDistance)
                    {
                        maxDistance = distance;
                        startPoint = line1.GetEndPoint(i);
                        fittingPoint1 = line1.GetEndPoint(1 - i);
                        endPoint = line2.GetEndPoint(j);
                        fittingPoint2 = line2.GetEndPoint(1 - j);
                    }
                }
            }

            // 计算关键点
            XYZ projectivePoint = Utils.GetProjectivePoint(line2, startPoint);
            XYZ direction1 = (startPoint - projectivePoint).Normalize();
            XYZ direction2 = (endPoint - projectivePoint).Normalize();
            if (!direction1.IsAlmostEqualTo(line1.Direction) && !direction1.IsAlmostEqualTo(line1.Direction.Negate()))
            {
                message = "构件不垂直！";
                return Result.Failed;
            }
            double trimDistance = pipe1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 1.6;
            corner1 = projectivePoint + direction1 * trimDistance;
            corner2 = projectivePoint + direction2 * trimDistance;

            using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartTrim"))
            {
                t.Start();
                Trim(doc, pipe1, pipe2);
                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 45度倒角
        /// <summary>
        /// 45度倒角
        /// </summary>
        /// <param name="doc"></param>
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


class Utils
{

    #region 获得硬盘序列号
    [System.Runtime.InteropServices.DllImport("kernel32.dll")]
    private static extern long GetVolumeInformation(
        string PathName,
        StringBuilder VolumeNameBuffer,
        UInt32 VolumeNameSize,
        ref UInt32 VolumeSerialNumber,
        ref UInt32 MaximumComponentLength,
        ref UInt32 FileSystemFlags,
        StringBuilder FileSystemNameBuffer,
        UInt32 FileSystemNameSize);

    public static string GetVolumeSerial(string strDriveLetter)
    {
        uint serNum = 0;
        uint maxCompLen = 0;
        StringBuilder VolLabel = new StringBuilder(256); // Label
        UInt32 VolFlags = new UInt32();
        StringBuilder FSName = new StringBuilder(256); // File System Name
        strDriveLetter += "://"; // fix up the passed-in drive letter for the API call
        long Ret = GetVolumeInformation(strDriveLetter, VolLabel, (UInt32)VolLabel.Capacity, ref serNum, ref maxCompLen, ref VolFlags, FSName, (UInt32)FSName.Capacity);
        return Convert.ToString(serNum);
    }
// ... truncated ...
```

