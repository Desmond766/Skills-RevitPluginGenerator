# Sample Snippet: MEP_SmartTrim90

Source project: `existingCodes\品成插件源代码\机电\MEP_SmartTrim90\MEP_SmartTrim90`

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

namespace MEP_SmartTrim90
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        XYZ startPoint;
        XYZ endPoint;
        XYZ fittingPoint1;
        XYZ fittingPoint2;
        XYZ corner1;
        XYZ corner2;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
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
                message = "构件不垂直或没有交点！";
                return Result.Failed;
            }
            double trimDistance = pipe1.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() * 1.6;
            corner1 = projectivePoint + direction1 * trimDistance;
            corner2 = projectivePoint + direction2 * trimDistance;


            using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartTrim"))
            {
                t.Start();
                Trim90(doc, pipe1, pipe2);
                t.Commit();
            }

            return Result.Succeeded;
        }

        #region 90度弯头
        /// <summary>
        /// 90度弯头
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="pipe1"></param>
        /// <param name="pipe2"></param>
        private void Trim90(Document doc, Pipe pipe1, Pipe pipe2)
        {
            // 原管属性
            Parameter parameter = pipe1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
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
    #endregion

    #region 给一个字符串进行MD5加密
    /// <summary>  
    /// 给一个字符串进行MD5加密
    /// </summary>  
    /// <param name="strText">待加密字符串</param>  
    /// <returns>加密后的字符串</returns>  
    public static string MD5Encrypt(string strText)
    {
        char[] md5Chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'a', 'b', 'c', 'd', 'e', 'f' };
        System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
        byte[] result = md5.ComputeHash(System.Text.Encoding.UTF8.GetBytes(strText));
        char[] chars = new char[result.Length * 2];
        int i = 0;
        foreach (byte b in result)
        {
            char c0 = md5Chars[(b & 0xf0) >> 4];
            chars[i++] = c0;
            char c1 = md5Chars[b & 0xf];
            chars[i++] = c1;
        }
        return new String(chars);
    }
    #endregion

    #region 验证注册
    /// <summary>
    /// 验证注册
    /// </summary>
    /// <returns></returns>
    public static bool AddInCheckIn()
    {
        var assemblyPath = System.Reflection.Assembly.GetExecutingAssembly().Location;
        var path = Path.Combine(Path.GetDirectoryName(assemblyPath), "BimtransToolReg.log");
        if (!File.Exists(path))
        {
            MessageBox.Show("插件未注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
            return false;
        }
        var regData = File.ReadAllLines(path);
        if (regData.Length != 2)
        {
            MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
            return false;
        }
        var seriesNum = regData[0];
        var localKey = regData[1];
        var diskNum = GetVolumeSerial("C");
        var generateKey = MD5Encrypt(seriesNum + diskNum);
// ... truncated ...
```

