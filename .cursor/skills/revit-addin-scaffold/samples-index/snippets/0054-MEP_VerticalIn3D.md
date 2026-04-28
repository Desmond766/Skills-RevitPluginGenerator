# Sample Snippet: MEP_VerticalIn3D

Source project: `existingCodes\品成插件源代码\机电\MEP_VerticalIn3D\MEP_VerticalIn3D`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_VerticalIn3D
{
    [Transaction(TransactionMode.Manual)]
    public class Command:IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            try
            {



                while (true)
                {


                    //选择第一个管线，为基准
                    Reference r1 = sel.PickObject(ObjectType.Element);
                    Element e1 = doc.GetElement(r1.ElementId);
                    if (!(e1 is MEPCurve))
                    {
                        TaskDialog.Show("提示", "您所选的构件并非管线");
                        return Result.Cancelled;
                    }
                    //选择第二个管线，使其跟第一根垂直
                    Reference r2 = sel.PickObject(ObjectType.Element);
                    Element e2 = doc.GetElement(r2.ElementId);
                    if (!(e2 is MEPCurve))
                    {
                        TaskDialog.Show("提示", "您所选的构件并非管线");
                        return Result.Cancelled;
                    }
                    //基准管线的方向向量directin1
                    LocationCurve locationCurve1 = e1.Location as LocationCurve;
                    Line line1 = locationCurve1.Curve as Line;
                    XYZ direction1 = line1.Direction;
                    //第二个管线原始的方向向量directin2
                    LocationCurve locationCurve2 = e2.Location as LocationCurve;
                    Line line2 = locationCurve2.Curve as Line;
                    XYZ direction2 = line2.Direction;

                    //与基准管线方向向量垂直的向量，与垂直向量的叉乘crossProduct
                    XYZ crossProduct = (direction1.CrossProduct(new XYZ(0, 0, 1))).Normalize();

                    //第二个管线的两个端点secPoint1、secPoint2、长度length2
                    XYZ secPoint1 = line2.GetEndPoint(0);
                    XYZ secPoint2 = line2.GetEndPoint(1);
                    Double length2 = e2.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();

                    //求第二个管线新的方向向量
                    //判断方向向量
                    XYZ newDirection = crossProduct * length2;
                    XYZ newPoint1 = secPoint1 + newDirection;
                    XYZ newPoint2 = secPoint1 - newDirection;
                    Line newLocationLine = null;
                    if (newPoint1.DistanceTo(secPoint2) - newPoint2.DistanceTo(secPoint2) < 0)
                    {
                        newLocationLine = Line.CreateBound(secPoint1, newPoint1);
                    }
                    else
                    {
                        newLocationLine = Line.CreateBound(secPoint1, newPoint2);
                    }

                    using (Transaction t = new Transaction(doc, "使垂直"))
                    {
// ... truncated ...
```

## Utils.cs

```csharp
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
            MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
            return false;
        }
// ... truncated ...
```

