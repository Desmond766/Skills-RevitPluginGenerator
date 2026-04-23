using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace SystemIsolate
{
    public class CsAddPanel : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {


            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("隔离所选系统");
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("SystemIsolate", "SystemIsolate", @"C:\ProgramData\Autodesk\Revit\Addins\2015\SystemIsolate.dll", "SystemIsolate.Command")) as PushButton;
            Uri uriImage = new Uri(@"C:\ProgramData\Autodesk\Revit\Addins\2015\SystemIsolate.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }
    }


}


