using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace MoveLRBasisOfLink
{
    class CsAddPanel:IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("距墙水平移动");
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("MoveLRBasisOfLink", "距墙水平移动", @"C:\ProgramData\Autodesk\Revit\Addins\2015\MoveLRBasisOfLink.dll", "MoveLRBasisOfLink.Command")) as PushButton;
            Uri uriImage = new Uri(@"C:\ProgramData\Autodesk\Revit\Addins\2015\MoveLRBasisOfLink.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }
    }
}
