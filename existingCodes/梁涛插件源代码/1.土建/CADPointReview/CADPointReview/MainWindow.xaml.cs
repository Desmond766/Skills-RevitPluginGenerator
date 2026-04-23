using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace CADPointReview
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //public List<string> FamilyNames { get; private set; } = new List<string>();
        //public BuiltInCategory Category { get; private set; }
        public List<CategoryInfo> CategoryInfos { get; private set; } = new List<CategoryInfo>();
        public List<Param> ColumnParams { get; private set; } = new List<Param>();
        public string ShowFamilyName { get; private set; }
        public MainWindow(string blockName)
        {
            InitializeComponent();
            //img_point.Source = ConvertBitmapToImageSource(Resource1.应急照明_壁灯_300);
            List<TypeInfo> typeInfos = InitializeResources();
            cb_type.ItemsSource = typeInfos;
            tb_r.Text = Properties.Settings.Default.R.ToString();
            tb_block_name.Text = blockName;
        }

        private List<TypeInfo> InitializeResources()
        {
            List<TypeInfo> result = new List<TypeInfo>();

            List<CategoryInfo> categoryInfo1s = new List<CategoryInfo>()
            {
                new CategoryInfo() { Category = BuiltInCategory.OST_FireAlarmDevices, FamilyNames = new List<string>() { "消防广播-吸顶扬声器" } },
                new CategoryInfo() { Category = BuiltInCategory.OST_CommunicationDevices, FamilyNames = new List<string>() { "壁挂式安装扬声器" } } 
            };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo1s,
                ShowFamilyName = "广播",
                Image = ConvertBitmapToImageSource(Resource1.壁挂式安装扬声器300),
                ColumnParams = new List<Param>() { Param.消防广播}
            });

            List<CategoryInfo> categoryInfo2s = new List<CategoryInfo>() { new CategoryInfo() { Category = BuiltInCategory.OST_DataDevices, FamilyNames = new List<string>() { "监控", "监控-吸顶", "吊杆式监控-基于面" } } };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo2s,
                ShowFamilyName = "监控",
                Image = ConvertBitmapToImageSource(Resource1.监控300),
                ColumnParams = new List<Param>() { Param.监控, Param.监控右, Param.监控左 }
            });

            List<CategoryInfo> categoryInfo3s = new List<CategoryInfo>() { new CategoryInfo() { Category = BuiltInCategory.OST_SecurityDevices, FamilyNames = new List<string>() { "声光报警器", "手动报警按钮+声光报警器" } } };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo3s,
                ShowFamilyName = "声光报警",
                Image = ConvertBitmapToImageSource(Resource1.声光报警300),
                ColumnParams = new List<Param>() { Param.声光报警 }
            });

            List<CategoryInfo> categoryInfo4s = new List<CategoryInfo>() { new CategoryInfo() { Category = BuiltInCategory.OST_SecurityDevices, FamilyNames = new List<string>() { "手动报警按钮", "手动报警按钮+声光报警器" } } };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo4s,
                ShowFamilyName = "手动报警按钮",
                Image = ConvertBitmapToImageSource(Resource1.手动报警按钮300),
                ColumnParams = new List<Param>() { Param.手动报警按钮}
            });

            List<CategoryInfo> categoryInfo5s = new List<CategoryInfo>() { new CategoryInfo() { Category = BuiltInCategory.OST_SecurityDevices, FamilyNames = new List<string>() { "疏散指示灯（2-0）+应急照明", "疏散指示灯（2.0）", "疏散指示灯（向前）", "疏散指示（双向）" } } };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo5s,
                ShowFamilyName = "疏散指示牌",
                Image = ConvertBitmapToImageSource(Resource1.疏散指示_向右_300),
                ColumnParams = new List<Param>() { Param.疏散指示灯左右, Param.疏散指示牌右, Param.疏散指示牌左}
            });

            List<CategoryInfo> categoryInfo6s = new List<CategoryInfo>() { new CategoryInfo() { Category = BuiltInCategory.OST_FireAlarmDevices, FamilyNames = new List<string>() { "温感" } } };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo6s,
                ShowFamilyName = "温感",
                Image = ConvertBitmapToImageSource(Resource1.温感300),
                ColumnParams = new List<Param>()
            });

            List<CategoryInfo> categoryInfo7s = new List<CategoryInfo>() { new CategoryInfo() { Category = BuiltInCategory.OST_FireAlarmDevices, FamilyNames = new List<string>() { "烟感" } } };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo7s,
                ShowFamilyName = "烟感",
                Image = ConvertBitmapToImageSource(Resource1.烟感300),
                ColumnParams = new List<Param>()
            });
            
            List<CategoryInfo> categoryInfo8s = new List<CategoryInfo>() 
            { 
                new CategoryInfo() { Category = BuiltInCategory.OST_LightingFixtures, FamilyNames = new List<string>() { "应急照明", "应急照明灯-吸顶" } },
                new CategoryInfo() { Category = BuiltInCategory.OST_SecurityDevices, FamilyNames = new List<string>() { "疏散指示灯（2-0）+应急照明" } }
            };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo8s,
                ShowFamilyName = "应急照明",
                Image = ConvertBitmapToImageSource(Resource1.应急照明_壁灯_300),
                ColumnParams = new List<Param>() { Param.应急照明}
            });
            
            List<CategoryInfo> categoryInfo9s = new List<CategoryInfo>() 
            { 
                new CategoryInfo() { Category = BuiltInCategory.OST_ElectricalEquipment, FamilyNames = new List<string>() { "卷帘门模块箱" } }
            };
            result.Add(new TypeInfo()
            {
                CategoryInfos = categoryInfo9s,
                ShowFamilyName = "卷帘门模块箱",
                Image = ConvertBitmapToImageSource(Resource1.卷帘门模块箱300),
                ColumnParams = new List<Param>()
            });


            return result;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cb_type.SelectedIndex == -1)
                {
                    MessageBox.Show("请选择一个Revit点位名称");
                    return;
                }
                Properties.Settings.Default.R = Convert.ToDouble(tb_r.Text);
                Properties.Settings.Default.Save();

                TypeInfo typeInfo = cb_type.SelectedItem as TypeInfo;
                //FamilyNames = typeInfo.FamilyNames;
                //Category = typeInfo.Category;
                CategoryInfos = typeInfo.CategoryInfos;
                ColumnParams = typeInfo.ColumnParams;
                ShowFamilyName = typeInfo.ShowFamilyName;

                DialogResult = true;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TypeInfo typeInfo = cb_type.SelectedItem as TypeInfo;
            img_point.Source = typeInfo.Image;
            lbl_point.Content = typeInfo.ShowFamilyName;
        }
    }
    public class TypeInfo
    {
        // 族名称集合
        //public List<string> FamilyNames { get; set; } = new List<string>();
        // 显示的图片
        public ImageSource Image { get; set; }
        // 显示的名称
        public string ShowFamilyName { get; set; }
        // 类型
        //public BuiltInCategory Category { get; set; }
        // 结构柱中的参数ID
        public List<Param> ColumnParams { get; set; } = new List<Param>();

        public List<CategoryInfo> CategoryInfos { get; set; } = new List<CategoryInfo>();

    }
    public class CategoryInfo
    {
        public List<string> FamilyNames { get; set; } = new List<string>();
        public BuiltInCategory Category { get; set; }
    }
}
