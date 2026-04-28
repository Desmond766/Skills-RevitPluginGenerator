# Sample Snippet: Com_PointGridLocation

Source project: `existingCodes\品成插件源代码\通用\Com_PointGridLocation\Com_PointGridLocation`

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

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.IO;

namespace Com_PointGridLocation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        private static string s;
        public static string S
        {
            get { return Command.s; }
            set { Command.s = value; }
        }
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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //选取的点位置
            Reference reference = sel.PickObject(ObjectType.PointOnElement);
            XYZ point = reference.GlobalPoint;

            //收集模型中所有的轴网（无法收集到链接的）
            FilteredElementCollector gridCollector = new FilteredElementCollector(doc);
            gridCollector.OfClass(typeof(Grid)).OfCategory(BuiltInCategory.OST_Grids);

            //收集离选取点的位置最近的4根轴网
            //用来收集轴网、轴网离选取点的坐标距离
            Dictionary<Grid, double> gridLeftDic = new Dictionary<Grid, double>();
            Dictionary<Grid, double> gridRightDic = new Dictionary<Grid, double>();
            Dictionary<Grid, double> gridTopDic = new Dictionary<Grid, double>();
            Dictionary<Grid, double> gridDownDic = new Dictionary<Grid, double>();
            //用来收集轴网离选取点的坐标距离
            List<double> gridLeft = new List<double>();
            List<double> gridRight = new List<double>();
            List<double> gridTop = new List<double>();
            List<double> gridDown = new List<double>();
            //收集4根轴网的值
            string gridLeftValue = "";
            string gridRightValue = "";
            string gridTopValue = "";
            string gridDownValue = "";
            //将collector里面的元素加到list
            List<Grid> list = new List<Grid>();
            foreach (Grid item in gridCollector)
            {
                list.Add(item);
            }
            if (list.Count < 4)
            {
                TaskDialog.Show("提示", "请确认是否导入轴网模型。");
                return Result.Failed;
            }

            #region 用坐标比较的方法

            foreach (Grid item in gridCollector)
            {
                Line line = item.Curve as Line;
                XYZ point0 = line.GetEndPoint(0);
                XYZ point1 = line.GetEndPoint(1);
                if (Math.Abs(point0.X - point1.X) < 0.3)
                {
                    if (point.X - point0.X >= 0)
                    {
                        Parameter gridLeftParam = item.get_Parameter(BuiltInParameter.DATUM_TEXT);
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
            if (generateKey != localKey)
            {
// ... truncated ...
```

