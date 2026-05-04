# Sample Snippet: MEP_TeeRotater

Source project: `existingCodes\品成插件源代码\机电\MEP_TeeRotater\MEP_TeeRotater`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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
using Autodesk.Revit.DB.Plumbing;
using System.Windows.Forms;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Electrical;

namespace MEP_TeeRotater
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string rbtn_Direction = "向上";
        public static string rbtn_Angle = "30";

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            //        //注册验证
            //        string licFile = string.Format("{0}\\Key.lic",
            //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //        if (!BTAddInHelper.Utils.CheckReg(licFile))
            //        {
            //            return Result.Cancelled;
            //        }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;


            //弹出设置窗口
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
           
           
            //r0选择的三通，r1选择的支管
            Reference r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "请选择要旋转的三通");
            Reference r1 = sel.PickObject(ObjectType.Element, "请选择要与三通连接的支管");

            FamilyInstance familyinstance = doc.GetElement(r0) as FamilyInstance;
            Location location = familyinstance.Location;
            LocationPoint locationPoint = location as LocationPoint;

            //配件的插入点
            XYZ familyinstancePoint = locationPoint.Point;

            // 原管线
            MEPCurve mepCurve1 = doc.GetElement(r1) as MEPCurve;
            // 原管线中心线
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;

            // 原始属性
            Parameter parameter = mepCurve1.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM);
            ElementId levelId = parameter.AsElementId();

            Pipe pipe1 = mepCurve1 as Pipe;
            ElementId systemTypeId = pipe1.MEPSystem.GetTypeId();
            PipeType pipeType = pipe1.PipeType;



            //得到管线距离配件近的连接件
            Connector connPipe1 = Utils.FindConnectorCloseToPoint(doc.GetElement(r1), familyinstancePoint);

            //配件的连接件
            ConnectorSet connectorSet = Utils.GetConSet(doc.GetElement(r0));
            List<Connector> conList = new List<Connector>();
            List<Connector> con3List = new List<Connector>();
            //配件主管上的两个连接件
            foreach (Connector conn in connectorSet)
            {
                if (Utils.FindConnectedTo(conn) != null)
                {
                    conList.Add(conn);
                }
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

namespace MEP_TeeRotater
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

