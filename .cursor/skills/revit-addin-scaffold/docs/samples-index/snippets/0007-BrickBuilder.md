# Sample Snippet: BrickBuilder

Source project: `existingCodes\品成插件源代码\土建\BrickBuilder\BrickBuilder`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;


//类说明：
//Brick--砖块类，存储砖块尺寸、材质、插入点信息
//PartWall--子墙父类，存储子墙砖块、砖块错缝、子墙高、基点
//BrickWall--砖墙类，存储塞缝墙、砌块墙、导墙、墙高、墙编号、灰缝及Revit墙的一系列信息
//Builder--砌墙类，由构造函数传入BrickWall，主函数Build()
//Utils--工具类
//SettingForm--窗口类，收集用户输入信息，构建BrickWall并返回给Command

//TODO:
//1、目前仅从起点往终点排，最好是是翻转能改变--改在点击的面上
//2、指定范围布置
//3、不够的填塞缝砖-需要把塞缝砖信息也加入的墙上
//4、目前只能左下角到右上角这样选择

namespace BrickBuilder
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
            
            //获得三维视图
            var view3d = doc.ActiveView as View3D;
            if (null == view3d)
            {
                message = "请在三维模式下运行插件！";
                return Result.Failed;
            }

            //选择直线建筑墙
            Reference reference = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new WallSelectFilter());
            }
            catch (Exception)
            {
                //取消选择，程序结束
                return Result.Cancelled;
            }
            var wall = doc.GetElement(reference) as Wall;
            var locationCurve = wall.Location as LocationCurve;
            if (null == locationCurve)
            {
                message = "仅支持【直线墙】！";
                return Result.Failed;
            }
            var wallLine = locationCurve.Curve as Line;
            if (null == wallLine)
            {
                message = "仅支持【直线墙】！";
                return Result.Failed;
            }

            //弹出设置对话框
            BrickWall wallInfo = null;
            using (SettingForm sf = new SettingForm(wall))
            {
                if (DialogResult.OK == sf.ShowDialog())
                {
                    wallInfo = sf.wallInfo;
                }
                else
                {
                    //取消设置，程序结束
                    return Result.Cancelled;
                }
            
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace BrickBuilder
{
    /// <summary>
    /// 工具类
    /// </summary>
    public class Utils
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
            var regStr = regData[0];
            var localKey = regData[1];
            var diskNum = GetVolumeSerial("C");
            var generateKey = MD5Encrypt(regStr + diskNum);
            if (generateKey != localKey)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
// ... truncated ...
```

## Brick.cs

```csharp
using Autodesk.Revit.DB;

namespace BrickBuilder
{
    public class Brick
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Tickness { get; set; }
        public string Material { get; set; }
        public XYZ InsertPoint { get; set; }

        public Brick()
        {
            //无参构造函数
        }

        public Brick(FamilyInstance brickInstance)
        {
            //加气混凝土砌块_600*180*200
            var infoArray = brickInstance.Symbol.Name.Split('_');
            Material = infoArray[0];
            Length = double.Parse(infoArray[1].Split('*')[0]) / 304.8;
            Width = double.Parse(infoArray[1].Split('*')[1]) / 304.8;
            Tickness = double.Parse(infoArray[1].Split('*')[2]) / 304.8;
            InsertPoint = (brickInstance.Location as LocationPoint).Point;
        }

        public Brick(string brickInfo)
        {
            //加气混凝土砌块_600*180*200
            var infoArray = brickInfo.Split('_');
            Material = infoArray[0];
            Length = double.Parse(infoArray[1].Split('*')[0]) / 304.8;
            Width = double.Parse(infoArray[1].Split('*')[1]) / 304.8;
            Tickness = double.Parse(infoArray[1].Split('*')[2]) / 304.8;
        }

        public override string ToString()
        {
// ... truncated ...
```

