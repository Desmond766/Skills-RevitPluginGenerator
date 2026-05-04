# Sample Snippet: CutBox

Source project: `existingCodes\品成插件源代码\通用\CutBox\CutBox`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Structure;


namespace CutBox
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        UIApplication uiapp;
        Document doc;
        Selection sel;
        XYZ max;
        XYZ min;
        Solid sectionBox;
        SolidCurveIntersectionOptions intersectOptions = new SolidCurveIntersectionOptions();
        SolidCurveIntersection intersection;

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

            View3D view3D = doc.ActiveView as View3D;
            if (null == view3D)
            {
                TaskDialog.Show("Revit", "必须在三维视图下运行插件！");
                return Result.Failed;
            }
            if (view3D.IsSectionBoxActive)// 模式一：剖面框切割
            {
                BoundingBoxXYZ box = view3D.GetSectionBox();
                max = box.Transform.OfPoint(box.Max);
                min = box.Transform.OfPoint(box.Min);
                // 剖面框范围
                sectionBox = CreatBox(max, min);
            }
            else // 模式二：体量切割
            {
                Reference r = sel.PickObject(ObjectType.Element);
                Options opt = new Options();
                GeometryElement geo = doc.GetElement(r).get_Geometry(opt);
                foreach (GeometryObject obj in geo)
                {
                    Solid solid = obj as Solid;
                    if (solid != null)
                    {
                        sectionBox = solid;
                        break;
                    }
                }
                max = sectionBox.GetBoundingBox().Max;
                min = sectionBox.GetBoundingBox().Min;
            }

            // 过滤没有碰撞的物体
            FilteredElementCollector colOfUnIntersect = new FilteredElementCollector(doc).WherePasses(new ElementIntersectsSolidFilter(sectionBox, true));
            ICollection<ElementId> elemToDelete = colOfUnIntersect.ToElementIds();
            // 过滤碰撞的物体
            FilteredElementCollector colOfIntersect = new FilteredElementCollector(doc, view3D.Id);
            Location location;

            using (Transaction t = new Transaction(doc, "CutBox"))
            {
                t.Start();
                try
                {
                    foreach (Element elem in colOfIntersect)
                    {
                        location = elem.Location;
                        if (null == location)
                            continue;
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CutBox
{
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
            var regStr = regData[0];
            var localKey = regData[1];
            var diskNum = GetVolumeSerial("C");
            var generateKey = MD5Encrypt(regStr + diskNum);
            if (generateKey != localKey)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            //注册码,授权类型,授权时间
            var regParams = Base64Decode(regStr).Split(',');
            if (regParams.Length != 3)
            {
                MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                return false;
            }
            //验证授权类型
            if (regParams[1] != "0")
            {
                if (regParams[1] == "1")
                {
                    //时间戳
                    TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
                    string timestamp = Convert.ToInt64(ts.TotalSeconds).ToString();
                    //授权过期
                    if (int.Parse(timestamp) > int.Parse(regParams[2]))
                    {
                        MessageBox.Show("授权已过期，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                        return false;
                    }
                }
                else
                {
                    //授权类型错误
                    MessageBox.Show("注册信息错误，请重新注册！请联系福建品成建设工程顾问有限公司，电话：0591-87310215");
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region Base64解密
        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string Base64Decode(string result)
        {
            return Base64Decode(Encoding.UTF8, result);
        }

        /// <summary>
        /// Base64解密
        /// </summary>
// ... truncated ...
```

