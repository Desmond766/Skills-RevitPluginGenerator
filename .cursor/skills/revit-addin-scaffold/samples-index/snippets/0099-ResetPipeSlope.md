# Sample Snippet: ResetPipeSlope

Source project: `existingCodes\梁涛插件源代码\1.土建\ResetPipeSlope\ResetPipeSlope`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using RevitTemplate1.Https;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

// 批量重置管道坡度（变为0）
namespace ResetPipeSlope
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            HttpHelper.SendLog(doc.Title, "重置管道坡度", 129, 1);
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();

        Next:

            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                references = sel.PickObjects(ObjectType.Element, new PipeAndConduitFilter(), "框选要重置的管道/线管(空格完成选择 ESC结束)");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Succeeded;
            }

            try
            {
                using (Transaction t = new Transaction(doc, "批量重置管道坡度"))
                {
                    t.Start();
                    foreach (var refer in references)
                    {
                        Element element = doc.GetElement(refer);
                        Curve elemCurve = (element.Location as LocationCurve).Curve;
                        XYZ newEnd0 = elemCurve.GetEndPoint(0);
                        XYZ newEnd1 = elemCurve.GetEndPoint(1);
                        newEnd1 = new XYZ(newEnd1.X, newEnd1.Y, newEnd0.Z);
                        Curve newCurve = Line.CreateBound(newEnd0, newEnd1);
                        (element.Location as LocationCurve).Curve = newCurve;
                    }
                    t.Commit();
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                //return Result.Succeeded;
            }
            

            goto Next;
        }
    }
    public class PipeAndConduitFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Pipe || elem is Conduit)
            {
                Curve curve = (elem.Location as LocationCurve).Curve;
                XYZ e0 = curve.GetEndPoint(0);
                XYZ e1 = curve.GetEndPoint(1);
                e0 = new XYZ(e0.X, e0.Y, 0);
                e1 = new XYZ(e1.X, e1.Y, 0);
                if (e0.DistanceTo(e1) > 0.001)
                {
                    return true;
                }
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
using System.Security.Policy;
using System.Windows;
using System.Net.NetworkInformation;
using System.Windows.Forms;

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

