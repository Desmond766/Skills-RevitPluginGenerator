using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CEGRegister
{
    public class Ribbon : IExternalApplication
    {
        //当前dll文件的完整路径
        static string AddinPath = typeof(Ribbon).Assembly.Location;
        public Result OnShutdown(UIControlledApplication application)
        {
            // 取消注册ApplicationInitialized事件处理程序
            application.ControlledApplication.ApplicationInitialized -= new EventHandler<ApplicationInitializedEventArgs>(OnApplicationInitialized);
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            // 注册ApplicationInitialized事件处理程序
            application.ControlledApplication.ApplicationInitialized += new EventHandler<ApplicationInitializedEventArgs>(OnApplicationInitialized);

            application.CreateRibbonTab("品成插件");
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("品成插件", "吊架插件");
            PushButtonData addHanger = new PushButtonData("布置支吊架", "布置支吊架", AddinPath, "CEGRegister.Command02");
            addHanger.ToolTip = "1.三维视图“3D支吊架”：显示链接2.在平面布置 操作步骤：先点击要布置的吊架，点击管线，点击位置";
            addHanger.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/addHanger.png")));
            ribbonPanel.AddItem(addHanger);

            PushButtonData addHanger4PLZM = new PushButtonData("布置喷淋照明共用吊架", "布置喷淋照明\n共用吊架", AddinPath, "CEGRegister.Command03");
            addHanger4PLZM.ToolTip = "1.三维视图“3D支吊架”：显示链接2.在平面布置 操作步骤：先点击要布置的吊架，点击喷淋管，点击线槽，点击位置";
            addHanger4PLZM.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/addHanger4PLZM.png")));
            ribbonPanel.AddItem(addHanger4PLZM);
            
            PushButtonData addHanger4GY = new PushButtonData("布置成排管线共用吊架", "布置成排管线\n共用吊架", AddinPath, "CEGRegister.Command04");
            addHanger4GY.ToolTip = "1.三维视图“3D支吊架”：显示链接2.在平面布置 操作步骤：先点击要布置的吊架，点击管线1，点击管线2，点击位置";
            addHanger4GY.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/addHanger4GY.png")));
            ribbonPanel.AddItem(addHanger4GY);
            
            PushButtonData pipeFittingParameterInputHanger = new PushButtonData("抗震吊架创建注释", "抗震吊架创建\n注释", AddinPath, "CEGRegister.Command05");
            pipeFittingParameterInputHanger.ToolTip = "框选门型抗震吊架点击完成，完成注释生成";
            pipeFittingParameterInputHanger.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/pipe.png")));
            ribbonPanel.AddItem(pipeFittingParameterInputHanger);

            PushButtonData mEPTagHelperForSlope = new PushButtonData("坡度管线平面标注", "坡度管线平面\n标注", AddinPath, "CEGRegister.Command06");
            mEPTagHelperForSlope.ToolTip = "1.三维视图“3D机电”：显示链接、关闭顶板2.标注的平面：显示链接、关闭顶板3.载入族4.文字设置，宋体3.78，默认当前5.比例1:100";
            mEPTagHelperForSlope.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/bimtrans.png")));
            ribbonPanel.AddItem(mEPTagHelperForSlope);

            PushButtonData positioningMarkingOfCShapedSteelHanger = new PushButtonData("C型钢吊架标注", "C型钢吊架标\n注", AddinPath, "CEGRegister.Command08");
            positioningMarkingOfCShapedSteelHanger.ToolTip = "运行插件，该视图所有C型钢吊架类型将会创建定位标注";
            positioningMarkingOfCShapedSteelHanger.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/bimtrans.png")));
            ribbonPanel.AddItem(positioningMarkingOfCShapedSteelHanger);

            PushButtonData singleTubeHangerNotes = new PushButtonData("单管吊架注释", "单管吊架注释", AddinPath, "CEGRegister.Command09");
            singleTubeHangerNotes.ToolTip = "";
            singleTubeHangerNotes.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/bimtrans.png")));
            ribbonPanel.AddItem(singleTubeHangerNotes);
            
            PushButtonData verticalLocation = new PushButtonData("垂直定位", "垂直定位", AddinPath, "CEGRegister.Command10");
            verticalLocation.ToolTip = "先选择好喷头后再运行插件";
            verticalLocation.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/bimtrans.png")));
            ribbonPanel.AddItem(verticalLocation);

            RibbonPanel ribbonPanel2 = application.CreateRibbonPanel("品成插件", "关于");
            PushButtonData re = new PushButtonData("注册", "注册", AddinPath, "CEGRegister.Command");
            re.ToolTip = "查看插件相关信息";
            re.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/re.png")));
            //re.ToolTipImage = new BitmapImage(new Uri(AddinPath.Replace("CEGRegister.dll", "icon/output-16_22_39.gif")));
            //re.LongDescription = "sassasasa";
            ribbonPanel2.AddItem(re);
            return Result.Succeeded;
        }

        // ApplicationInitialized事件处理程序
        private void OnApplicationInitialized(object sender, ApplicationInitializedEventArgs e)
        {
            // 在这里处理Revit启动时的逻辑
            GetNetworkTimeAndShow();
        }

        private static async Task<DateTime> FetchNetworkTimeAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                // 使用一个公开的时间API，例如 worldtimeapi.org
                //HttpResponseMessage response = await client.GetAsync("http://worldtimeapi.org/api/timezone/Etc/UTC");
                HttpResponseMessage response = await client.GetAsync("https://sapi.k780.com/?app=life.time&appkey=10003&sign=b59bc3ef6191eb9f747dd4e83c99f2a4&format=json");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                dynamic json = Newtonsoft.Json.JsonConvert.DeserializeObject(responseBody);
                //string utcDateTimeString = json.utc_datetime;
                string utcDateTimeString = json.result.datetime_1;

                return DateTime.Parse(utcDateTimeString);
            }
        }

        public static async void GetNetworkTimeAndShow()
        {
            try
            {
                DateTime networkTime = await FetchNetworkTimeAsync();
                TimeNow.time = networkTime;
                //TaskDialog.Show("Network Time", networkTime.ToString("yyyy-MM-dd HH:mm:ss") + "\n" + DateTime.Now.Date + "\n" + TimeNow.time);
            }
            catch (Exception ex)
            {
                TaskDialog.Show("Error", "Failed to get network time: " + ex.Message);
            }
        }
    }
    public static class TimeNow
    {
        public static DateTime time { get; set; }
    }
}