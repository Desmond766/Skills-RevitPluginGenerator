# Sample Snippet: SystemIsolate

Source project: `existingCodes\品成插件源代码\机电\SystemIsolate\SystemIsolate`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
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
using Autodesk.Revit.DB.Mechanical;
using System.IO;

namespace SystemIsolate
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
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

            //将视图中可见的桥架、桥架配件、线管、线管配件过滤收集起来
            FilteredElementCollector collectorCableTray = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collectorCableTray.OfCategory(BuiltInCategory.OST_CableTray);
            FilteredElementCollector collectorCableTaryFitting = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collectorCableTaryFitting.OfCategory(BuiltInCategory.OST_CableTrayFitting);
            FilteredElementCollector collectorConduit = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collectorConduit.OfCategory(BuiltInCategory.OST_Conduit);
            FilteredElementCollector collectorConduitFitting = new FilteredElementCollector(doc, doc.ActiveView.Id);
            collectorConduitFitting.OfCategory(BuiltInCategory.OST_ConduitFitting);
            //将视图中可见的所有构件收集起来
            FilteredElementCollector collector = new FilteredElementCollector(doc, doc.ActiveView.Id);
            //创建一个list用来收集满足条件的同类构件
            List<ElementId> list = new List<ElementId>();
            string sys = "";

            //拾取管线
            ICollection<Reference> icollection = sel.PickObjects(ObjectType.Element);
            foreach (Reference items in icollection)
            {
                Element e = doc.GetElement(items);

                //拾取的是桥架或者桥架配件的情况，判断：族的类型名称
                if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray
                    || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTrayFitting)
                {
                    sys = e.Name;
                    foreach (Element item in collectorCableTray)
                    {
                        if (item.Name == sys)
                        {
                            list.Add(item.Id);
                        }
                    }
                    foreach (Element item in collectorCableTaryFitting)
                    {
                        FamilyInstance itemFamilyInstance = item as FamilyInstance;
                        if (itemFamilyInstance.Name == sys)
                        {
                            list.Add(item.Id);
                        }
                    }
                }
                //拾取的是线管或者线管配件的情况，判断：族的类型名称
                else if (e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_Conduit
                    || e.Category.Id.IntegerValue == (int)BuiltInCategory.OST_ConduitFitting)
                {
                    sys = e.Name;
                    foreach (Element item in collectorConduit)
                    {
                        if (item.Name == sys)
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

namespace SystemIsolate
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
// ... truncated ...
```

