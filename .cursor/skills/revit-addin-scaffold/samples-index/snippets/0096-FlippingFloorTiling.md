# Sample Snippet: FlippingFloorTiling

Source project: `existingCodes\梁涛插件源代码\1.土建\FlippingFloorTiling\FlippingFloorTiling`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitTemplate1.Https;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace FlippingFloorTiling
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            HttpHelper.SendLog(doc.Title, "地面铺砖翻模", 131, 1);

            FamilySymbol familySymbol = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_GenericModel).OfClass(typeof(FamilySymbol)).Cast<FamilySymbol>().FirstOrDefault(f => f.Name.Contains("美缝-5mm") && f.FamilyName.Contains("美缝"));
            if (familySymbol == null)
            {
                TaskDialog.Show("提示", "未找到美缝族");
                return Result.Cancelled;
            }

            Reference cadRefer;
            Reference floorOrWallRefer;
            Next:
            try
            {
                cadRefer = sel.PickObject(ObjectType.PointOnElement, new LinkCADFilter(doc), "选择链接CAD中的一条美缝(按ESC键结束操作)");
                floorOrWallRefer = sel.PickObject(ObjectType.Face, new FloorFilter(), "选择要创建美缝的楼板\\墙的面(按ESC键结束操作)");
            }
            catch (OperationCanceledException)
            {
                MessageBox.Show("已结束操作");
                return Result.Succeeded;
            }
            ImportInstance importInstance = doc.GetElement(cadRefer) as ImportInstance;
            if (importInstance.IsLinked == false)
            {
                TaskDialog.Show("提示", "请在链接CAD中选择");
                return Result.Cancelled;
            }

            // 获取美缝线在CAD中的所在图层名称
            GeometryObject geoSel = importInstance.GetGeometryObjectFromReference(cadRefer);
            string layerName = GetSelectEntityLayerName(doc, geoSel);

            // 获取指定图层中所有线段(包含块参照中的线段)
            List<Line> lines = GetLinesInCADByLayerName(doc, importInstance, layerName);
            if (lines.Count == 0)
            {
                TaskDialog.Show("提示", "未找到该图层中的线段");
                goto Next;
            }

            Element floorOrWall = doc.GetElement(floorOrWallRefer);
            //PlanarFace floorFace = floor.GetGeometryObjectFromReference(HostObjectUtils.GetTopFaces(floor).First()) as PlanarFace;
            PlanarFace floorOrWallFace = floorOrWall.GetGeometryObjectFromReference(floorOrWallRefer) as PlanarFace;
            // 将面转换为带完整引用的面
            GetSameFaceWithComputeReference(doc, floorOrWall, ref floorOrWallFace);

            List<Line> createLines = new List<Line>();

            /*
            List<ModelCurve> createModels = new List<ModelCurve>();
            using (Transaction t = new Transaction(doc, "创建临时模型线"))
            {
                t.Start();

                foreach (var modelLine in lines)
                {
                    if (modelLine.Length < 0.01) continue;
                    Plane plane = Plane.CreateByNormalAndOrigin(doc.ActiveView.ViewDirection.CrossProduct(modelLine.Direction).Normalize(), modelLine.GetEndPoint(0));
                    SketchPlane sketchPlane = SketchPlane.Create(doc, plane);
                    ModelCurve modelCurve = doc.Create.NewModelCurve(modelLine, sketchPlane);
                    createModels.Add(modelCurve);
                }

// ... truncated ...
```

## HttpHelper.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Autodesk.Revit.Creation;
using System.Windows.Controls;
using System.Security.Policy;
using System.Windows;
using System.Net.NetworkInformation;

namespace RevitTemplate1.Https
{
    internal class HttpHelper
    {
        private static readonly HttpClient httpClient = new HttpClient();
        private static readonly string _url = "http://192.168.11.202:8033/pluginReceive";
        //private static readonly string _url = "http://localhost:8080/pluginReceive";

        /// <summary>
        /// 发送http请求
        /// </summary>
        /// <param name="title">项目标题</param>
        /// <param name="plug_in_name">插件名</param>
        /// <param name="num">插件序号</param>
        /// <param name="category">分类</param>1:土建 | 2:几点建模算量 | 3:管综 | 4:吊架布置 | 5:吊架出图 | 6:不常用
        public static async void SendLog(string title, string plug_in_name, int num, int category)
        {
            string _macAddress = "";
            try
            {
                _macAddress=GetMacAddress();
            }
            catch (Exception)
            {
                _macAddress = "异常";
            }
            SendLog(title, plug_in_name,num,category, _macAddress, _url);
        }

        /// <summary>
        /// 发送http请求
        /// </summary>
        /// <param name="title">项目标题</param>
        /// <param name="plug_in_name">插件名</param>
        /// <param name="num">插件序号</param>
        /// <param name="category">分类</param>1:土建 | 2:几点建模算量 | 3:管综 | 4:吊架布置 | 5:吊架出图 | 6:不常用
        /// <param name="macAddress">mac地址</param>
        /// <param name="url">发送地址</param>
        public static async void SendLog(string title,string plug_in_name,int num,int category,string macAddress, string url)
        {
            try
            {
                // 手动构建 JSON 字符串
                long timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                string json = BuildJson(
                     ("projectName", title),
                     ("plugInName", plug_in_name),
                     ("macAddress", macAddress),
                     ("timestamp", timestamp), 
                     ("num", num),
                     ("category", category)
                 );
                //MessageBox.Show(json);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await httpClient.PostAsync(url, content);
            }
            catch
            {
                // 忽略异常
            }
        }

        /// <summary>
        /// 拼接json
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        private static string BuildJson(params (string key, object value)[] fields)
        {
            var sb = new StringBuilder("{");
            for (int i = 0; i < fields.Length; i++)
            {
                if (i > 0) sb.Append(",");
                string key = fields[i].key;
                object val = fields[i].value;

                sb.Append($"\"{key}\":");

// ... truncated ...
```

