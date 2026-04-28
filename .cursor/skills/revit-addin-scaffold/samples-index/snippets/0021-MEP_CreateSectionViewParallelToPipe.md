# Sample Snippet: MEP_CreateSectionViewParallelToPipe

Source project: `existingCodes\品成插件源代码\机电\MEP_CreateSectionViewParallelToPipe\MEP_CreateSectionViewParallelToPipe`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_CreateSectionViewParallelToPipe
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
            Document doc = uidoc.Document;

            ////获取选中管线
            Selection sel = uidoc.Selection;
            Reference r = sel.PickObject(ObjectType.Element);
            Element e = doc.GetElement(r);
            MEPCurve mepcurve = e as MEPCurve;

            //确认是直线管线
            LocationCurve lc = mepcurve.Location as LocationCurve;
            Line line = lc.Curve as Line;
            if (null == line)
            {
                message = "无法获取直管线。";
                return Result.Failed;
            }

            // 获取视图类型对象
            ViewFamilyType vft = new FilteredElementCollector(doc)
                .OfClass(typeof(ViewFamilyType))
                .Cast<ViewFamilyType>()
                .FirstOrDefault<ViewFamilyType>(x => ViewFamily.Section == x.ViewFamily);

            BoundingBoxXYZ sectionBox = GetSectionViewParalleToPipe(mepcurve);
            
            // 创建平行于管线剖视图
            using (Transaction tx = new Transaction(doc))
            {
                tx.Start("创建平行于管线的剖面视图。");
                ViewSection.CreateSection(doc, vft.Id, sectionBox);
                tx.Commit();
            }
            
            return Result.Succeeded;
        }


        #region 获得平行于管线的范围框
        /// <summary>
        /// 获得平行于管线的范围框
        /// </summary>
        /// <param name="mepcurve">管线</param>
        /// <returns>范围框</returns>
        BoundingBoxXYZ GetSectionViewParalleToPipe(MEPCurve mepcurve)
        {
            LocationCurve lc = mepcurve.Location as LocationCurve;
            Line line = lc.Curve as Line;

            XYZ p = line.GetEndPoint(0);
            XYZ q = line.GetEndPoint(1);
            q = new XYZ(q.X, q.Y, p.Z);
            XYZ v = q - p;//修正z高度，避免transform坐标不正交，报错

            BoundingBoxXYZ bb = mepcurve.get_BoundingBox(null);


            double minZ = bb.Min.Z;
            double maxZ = bb.Max.Z;
            
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


    class Utils
    {
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
            return true;
        }
        #endregion

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
// ... truncated ...
```

