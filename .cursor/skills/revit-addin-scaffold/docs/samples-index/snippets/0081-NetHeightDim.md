# Sample Snippet: NetHeightDim

Source project: `existingCodes\品成插件源代码\通用\NetHeightDim\NetHeightDim`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
//20171122
//添加可选择查看管中的净高选项
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Reflection;
using System.IO;

namespace NetHeightDim
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //#region 判断加密
            ////注册验证
            //string licFile = string.Format("{0}\\Key.lic",
            //     System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}

            //#endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //获得三维视图
            if (!(doc.ActiveView is View3D))
            {
                message = "请在三维视图中使用该功能！";
                return Result.Failed;
            }
            View3D view3d = doc.ActiveView as View3D;

            //标注图元ID
            List<ElementId> ids = new List<ElementId>();

            //读取设置
            string path = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "txt");
            List<string> setting = Utils.TxtToList(path);
            if (null == setting)
            {
                //setting = new List<string>() { "SelectCurrent","SlabDatum", "-", "DeleteNote" };
                setting = new List<string>()
                { "SelectCurrent", "Bottom", "SlabDatum", "-", "DeleteNote" };//陈清修改。还有以下的索引值[1][2][4]
            }

            //循环选择
            while (true)
            {
                try
                {
                    Reference reference;
                    XYZ pickedPoint;
                    //选择设置
                    if (setting[0] == "SelectCurrent")
                    {
                        reference = sel.PickObject(ObjectType.Element);
                        Element element = doc.GetElement(reference);
                        BoundingBoxXYZ bbox = element.get_BoundingBox(doc.ActiveView);
                        pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, bbox.Min.Z);
                        //管底、管中：陈清添加
                        if (setting[1] == "Middle")
                        {
                            double d = bbox.Max.Z - bbox.Min.Z;
                            pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, bbox.Min.Z + d * 0.5);
                        }
                        else//Bottom
                        {
                            pickedPoint = new XYZ(reference.GlobalPoint.X, reference.GlobalPoint.Y, bbox.Min.Z);
                        }
                    }
                    else//Link
                    {
                        reference = sel.PickObject(ObjectType.LinkedElement);
// ... truncated ...
```

## Utils.cs

```csharp
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NetHeightDim
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
            if (generateKey != localKey)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
// ... truncated ...
```

