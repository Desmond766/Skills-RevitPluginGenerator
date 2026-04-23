using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Media.Imaging;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;

namespace MoveUDBasisOfLink
{
    class CsAddPanel:IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("距梁垂直移动");
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("MoveUDBasisOfLink", "距梁垂直移动", @"C:\ProgramData\Autodesk\Revit\Addins\2015\MoveUDBasisOfLink.dll", "MoveUDBasisOfLink.Command")) as PushButton;
            Uri uriImage = new Uri(@"C:\ProgramData\Autodesk\Revit\Addins\2015\MoveUDBasisOfLink.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }
    }
}
