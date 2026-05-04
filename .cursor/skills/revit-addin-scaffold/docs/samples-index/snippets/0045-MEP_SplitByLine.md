# Sample Snippet: MEP_SplitByLine

Source project: `existingCodes\品成插件源代码\机电\MEP_SplitByLine\MEP_SplitByLine`

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
using System.Windows.Forms;

namespace MEP_SplitByLine
{
    #region 枚举
    public enum SplitTypeList
    {
        Plane,
        Vertical
    }
    #endregion

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 字段属性
        private static SplitTypeList _splitType;
        public static SplitTypeList SplitType
        {
            get { return Command._splitType; }
            set { Command._splitType = value; }
        }

        UIApplication uiapp;
        Document doc;
        Selection sel;
        Curve splitCurve;
        #endregion

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
          
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            uiapp = commandData.Application;
            doc = uiapp.ActiveUIDocument.Document;
            sel = uiapp.ActiveUIDocument.Selection;

            // 过滤选择集
            List<ModelCurve> modelCurveList = new List<ModelCurve>();
            List<MEPCurve> mepCurveList = new List<MEPCurve>();
            Element e;
            foreach (ElementId id in sel.GetElementIds())
            {
                e = doc.GetElement(id);
                if (e is ModelCurve)
                {
                    modelCurveList.Add(e as ModelCurve);
                }
                if (e is MEPCurve)
                {
                    mepCurveList.Add(e as MEPCurve);
                }
            }
            if (modelCurveList.Count != 1)
            {
                message = "仅支持【一条】模型线切割！";
                return Result.Failed;
            }
            splitCurve = (modelCurveList[0].Location as LocationCurve).Curve;
            if (!IsOnXYPlane(splitCurve))
            {
                message = "切割模型线必须在【XY平面上】！";
                return Result.Failed;
            }

            // 弹出对话框
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
        if (generateKey != localKey)
        {
// ... truncated ...
```

