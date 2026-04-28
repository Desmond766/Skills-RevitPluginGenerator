using Autodesk.AutoCAD.GraphicsInterface;
using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using ImageSource = System.Windows.Media.Imaging.BitmapImage;

namespace TextRecognitionInCAD
{
    public class Ribbon
    {
        private const string MY_TAB_ID = "MY_TAB_ID";

        [CommandMethod("ADDNR")]
        public void createRibbon()
        {
            RibbonControl ribCntrl = Autodesk.AutoCAD.Ribbon.RibbonServices.RibbonPaletteSet.RibbonControl;
            //can also be Autodesk.Windows.ComponentManager.Ribbon;     

            //add the tab
            RibbonTab ribTab = new RibbonTab();
            ribTab.Title = "CAD插件集合";
            ribTab.Id = MY_TAB_ID;
            ribCntrl.Tabs.Add(ribTab);

            //create and add both panels
            addPanel1(ribTab);
            addPanel2(ribTab);

            //set as active tab
            ribTab.IsActive = true;
        }

        private void addPanel2(RibbonTab ribTab)
        {
            //create the panel source
            RibbonPanelSource ribPanelSource = new RibbonPanelSource();
            ribPanelSource.Title = "修改图层";

            Bitmap bitmap = Resource1.Layer;
            var image = ConvertBitmapToImageSource(bitmap);

            //create the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribPanelSource;
            ribTab.Panels.Add(ribPanel); 

            //create button1
            RibbonButton mLOL = new RibbonButton();
            mLOL.Text = "修改灯具图层";
            mLOL.ShowText = true;
            //pay attention to the SPACE after the command name
            mLOL.CommandParameter = "MLOL ";
            mLOL.CommandHandler = new AdskCommandHandler();
            mLOL.LargeImage = image;
            mLOL.Size = RibbonItemSize.Large;
            mLOL.Orientation = System.Windows.Controls.Orientation.Vertical;
            mLOL.ShowImage = true;

            ribPanelSource.Items.Add(mLOL);
            
            //create button1
            RibbonButton mLOC = new RibbonButton();
            mLOC.Text = "修改线管图层";
            mLOC.ShowText = true;
            //pay attention to the SPACE after the command name
            mLOC.CommandParameter = "MLOC ";
            mLOC.CommandHandler = new AdskCommandHandler();
            mLOC.LargeImage = image;
            mLOC.Size = RibbonItemSize.Large;
            mLOC.Orientation = System.Windows.Controls.Orientation.Vertical;
            mLOC.ShowImage = true;

            ribPanelSource.Items.Add(mLOC);
            
            //create button1
            RibbonButton aOML = new RibbonButton();
            aOML.Text = "新增直线";
            aOML.ShowText = true;
            //pay attention to the SPACE after the command name
            aOML.CommandParameter = "AOML ";
            aOML.CommandHandler = new AdskCommandHandler();
            aOML.LargeImage = image;
            aOML.Size = RibbonItemSize.Large;
            aOML.Orientation = System.Windows.Controls.Orientation.Vertical;
            aOML.ShowImage = true;

            ribPanelSource.Items.Add(aOML);
            

        }

        private void addPanel1(RibbonTab ribTab)
        {

            //create the panel source
            RibbonPanelSource ribPanelSource = new RibbonPanelSource();
            ribPanelSource.Title = "提取文字";

            //create the panel
            RibbonPanel ribPanel = new RibbonPanel();
            ribPanel.Source = ribPanelSource;
            ribTab.Panels.Add(ribPanel);

            //create button1
            RibbonButton gTIA2 = new RibbonButton();
            gTIA2.Text = "提取回路表";
            gTIA2.ShowText = true;
            //pay attention to the SPACE after the command name
            gTIA2.CommandParameter = "GTIA2 ";
            gTIA2.CommandHandler = new AdskCommandHandler();

            Bitmap bitmap = Resource1.ExtractExcelData;
            gTIA2.LargeImage = ConvertBitmapToImageSource(bitmap);
            gTIA2.Size = RibbonItemSize.Large;
            gTIA2.Orientation = System.Windows.Controls.Orientation.Vertical;
            gTIA2.ShowImage = true;

            ribPanelSource.Items.Add(gTIA2);
        }

        static ImageSource ConvertBitmapToImageSource(Bitmap bitmap)
        {
            // 使用 MemoryStream 将 Bitmap 转换为流
            // 在图片需要载入之前MemoryStream就被释放导致图片无法显示
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // 将 Bitmap 保存到 MemoryStream
                bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
                memoryStream.Position = 0; // 重置流的读取位置

                // 使用 BitmapImage 从 MemoryStream 加载图像
                BitmapImage bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = memoryStream;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad; // 防止在显示图片之前流就已经被释放
                bitmapImage.EndInit();
                return bitmapImage;
            }
        }
    }
}
