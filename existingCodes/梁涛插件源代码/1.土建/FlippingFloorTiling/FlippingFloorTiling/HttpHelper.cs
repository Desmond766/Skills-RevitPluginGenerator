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

                if (val == null)
                    sb.Append("null");
                else if (val is string s)
                    sb.Append($"\"{EscapeJsonString(s)}\"");
                else if (val is bool b)
                    sb.Append(b ? "true" : "false");
                else if (val is DateTime dt)
                    sb.Append($"\"{dt:yyyy-MM-dd HH:mm:ss}\""); // 按需格式化
                else // 数字、枚举等直接 ToString()
                    sb.Append(val.ToString()); // 注意：文化不变格式，但数字没问题
            }
            sb.Append("}");
            return sb.ToString();
        }


        /// <summary>
        /// 转义 JSON 字符串中的特殊字符（双引号、反斜杠、控制字符等）
        /// </summary>
        private static string EscapeJsonString(string raw)
        {
            if (string.IsNullOrEmpty(raw)) return "";

            var sb = new StringBuilder();
            foreach (char c in raw)
            {
                switch (c)
                {
                    case '"': sb.Append("\\\""); break;
                    case '\\': sb.Append("\\\\"); break;
                    case '\b': sb.Append("\\b"); break;
                    case '\f': sb.Append("\\f"); break;
                    case '\n': sb.Append("\\n"); break;
                    case '\r': sb.Append("\\r"); break;
                    case '\t': sb.Append("\\t"); break;
                    default:
                        if (c < 0x20) // 其他控制字符转为 Unicode 转义
                            sb.Append($"\\u{(int)c:X4}");
                        else
                            sb.Append(c);
                        break;
                }
            }
            return sb.ToString();
        }

        public static string GetMacAddress()
        {
            // 获取所有网络接口
            var interfaces = NetworkInterface.GetAllNetworkInterfaces();

            // 筛选出正在运行、非回环、非隧道、非虚拟机的物理网卡
            var mac = (from nic in interfaces
                       where nic.OperationalStatus == OperationalStatus.Up &&
                             nic.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                             nic.NetworkInterfaceType != NetworkInterfaceType.Tunnel &&
                             nic.NetworkInterfaceType != NetworkInterfaceType.Ppp &&           // 拨号连接
                             !nic.Description.ToLower().Contains("virtual") &&                 // 过滤常见虚拟网卡
                             !nic.Description.ToLower().Contains("vmware") &&
                             !nic.Description.ToLower().Contains("hyper-v")
                       select nic.GetPhysicalAddress().ToString())
                       .FirstOrDefault();

            return mac ?? "未找到有效的MAC地址";
        }
    }
}
