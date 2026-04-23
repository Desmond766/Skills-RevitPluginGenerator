using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using System.Windows.Media.Imaging;

namespace BeamColor
{
    class CsAddPanel : IExternalApplication
    {
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            RibbonPanel ribbonPanel = application.CreateRibbonPanel("据梁净高赋色");
            PushButton pushButton = ribbonPanel.AddItem(new PushButtonData("BeamColor", "BeamColor", @"C:\ProgramData\Autodesk\Revit\Addins\2015\BeamColor.dll", "BeamColor.Command")) as PushButton;
            Uri uriImage = new Uri(@"C:\ProgramData\Autodesk\Revit\Addins\2015\BeamColor.png");
            BitmapImage largeImage = new BitmapImage(uriImage);
            pushButton.LargeImage = largeImage;
            return Result.Succeeded;
        }


    }
}
