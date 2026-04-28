using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace ArrangeHangerAccordingToNozzle
{

    internal class Ribbon : IExternalApplication
    {
        //当前dll文件的完整路径
        static string AddinPath = typeof(Ribbon).Assembly.Location;
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            application.CreateRibbonTab("布置吊架");
            RibbonPanel panel = application.CreateRibbonPanel("布置吊架", "构建");
            PushButtonData addHanger = new PushButtonData("add hanger", "添加吊架", AddinPath, "ArrangeHangerAccordingToNozzle.AddPipeHanger");
            addHanger.ToolTip = "根据选择管道判断喷头位置来布置吊架";
            addHanger.LargeImage = new BitmapImage(new Uri(AddinPath.Replace("ArrangeHangerAccordingToNozzle.dll", "icon/addhanger.png")));
            panel.AddItem(addHanger);

            return Result.Succeeded;
        }
    }
}
