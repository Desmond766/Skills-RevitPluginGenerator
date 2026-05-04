# Sample Snippet: MEP_SmartSplitTwo

Source project: `existingCodes\品成插件源代码\机电\MEP_SmartSplitTwo\MEP_SmartSplitTwo`

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
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;
using System.IO;

namespace MEP_SmartSplitTwo
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
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

            Reference r1;
            Reference r2;
            MEPCurve e1;
            MEPCurve e2;
            XYZ splitPoint1;
            XYZ splitPoint2;
            while (true)
            {
                try
                {
                    // 拾取构件
                    r1 = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    e1 = doc.GetElement(r1) as MEPCurve;
                    splitPoint1 = Utils.GetProjectivePoint((e1.Location as LocationCurve).Curve as Line, r1.GlobalPoint);

                    r2 = sel.PickObject(ObjectType.Element, new MEPSelectionFilter(), "点击【管道】、【风管】、【桥架】、【线管】");
                    e2 = doc.GetElement(r2) as MEPCurve;
                    splitPoint2 = Utils.GetProjectivePoint((e2.Location as LocationCurve).Curve as Line, r2.GlobalPoint);
                    // Split
                    using (Transaction t = new Transaction(doc, "BimtransMEPTools.SmartSplit"))
                    {
                        t.Start();
                        Split(doc, e1, splitPoint1, splitPoint2);
                        t.Commit();
                    }
                }
                catch
                {
                    break;
                }
            }



            return Result.Succeeded;
        }

        #region 智能打断
        /// <summary>
        /// 智能打断
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="elem"></param>
        /// <param name="splitPoint"></param>
        public static void Split(Document doc, MEPCurve elem, XYZ splitPoint1, XYZ splitPoint2)
        {
            Line center = (elem.Location as LocationCurve).Curve as Line;
            // 计算关键点
            XYZ startPoint = center.GetEndPoint(0);
            XYZ endPoint = center.GetEndPoint(1);

            // 起点、终点连接件
            Connector startConn = Utils.FindConnectedTo(elem, startPoint);
            Connector endConn = Utils.FindConnectedTo(elem, endPoint);

            XYZ splitPoint11;
            XYZ splitPoint22;
            double distance1 = splitPoint1.DistanceTo(startPoint);
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

namespace MEP_SmartSplitTwo
{
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

