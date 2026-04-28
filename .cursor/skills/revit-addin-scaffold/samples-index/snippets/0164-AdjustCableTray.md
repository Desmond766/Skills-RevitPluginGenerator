# Sample Snippet: AdjustCableTray

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\AdjustCableTray\AdjustCableTray`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Architecture;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdjustCableTray
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;


            //Application app = commandData.Application.Application;
            ////创建对话框
            //TaskDialog mainDialog = new TaskDialog("isBIM模术师");//对话框的名称
            //mainDialog.MainInstruction = "产品使用说明";//对话框标题
            //mainDialog.MainContent = "isBIM模术师是基于Autodesk Revit软件的本地化功能插件集";//对话框的主要内容
            //mainDialog.ExpandedContent = "可用于建筑、结构、水电以及暖通等专业中";//对话框的扩展内容
            ////添加命令链接
            //mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink1, "查看当前Revit版本信息", "Command1");
            //mainDialog.AddCommandLink(TaskDialogCommandLinkId.CommandLink2, "查看模术师产品信息");
            //mainDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel | TaskDialogCommonButtons.Retry;
            //mainDialog.VerificationText = "不再显示该信息";
            //mainDialog.MainIcon = TaskDialogIcon.TaskDialogIconInformation;
            ////mainDialog.ExtraCheckBoxText = "测试";
            ////添加文字超链接
            //mainDialog.FooterText = "<a href=\"http://www.bimcheng.com\">" + "点此处了解更多信息</a>";

            ////显示对话框并取得返回值
            //TaskDialogResult tResult = mainDialog.Show();

            ////使用对话框返回结果
            //if (TaskDialogResult.CommandLink1 == tResult)
            //{
            //    //链接一的扩展的对话框内容
            //    TaskDialog dialog_CommandLink1 = new TaskDialog("版本信息");
            //    dialog_CommandLink1.MainInstruction = "版本名:" + app.VersionNumber + "\n" + "版本号:"
            //        + app.VersionNumber;
            //    dialog_CommandLink1.Show();
            //}
            //else if (TaskDialogResult.CommandLink2 == tResult)
            //{
            //    //链接二的扩展的对话框内容
            //    TaskDialog.Show("模术师产品介绍", "isBIM模术师是一个全过程、全专业的高效解决方案");
            //}
            //else if (tResult == TaskDialogResult.Retry)
            //{
            //    TaskDialog.Show("模术师产品介绍", "retry");
            //}

            //return Result.Succeeded;



            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double currentDis = window.Dis / 304.8;


            //Reference reference = sel.PickObject(ObjectType.Element);
            //CableTray cableTray = doc.GetElement(reference) as CableTray;
            //Transaction t = new Transaction(doc, "move");
            //t.Start();
            //cableTray.Location.Move(XYZ.BasisY.Negate() * 100 / 304.8);
            //t.Commit();
            //return Result.Succeeded;

            Reference refer = sel.PickObject(ObjectType.LinkedElement, "选择一个链接模型");
            RevitLinkInstance linkInstance = doc.GetElement(refer) as RevitLinkInstance;
            Transform transform = linkInstance.GetTransform();
            Document linkDoc = linkInstance.GetLinkDocument();
            FilteredElementCollector collector = new FilteredElementCollector(linkDoc).WhereElementIsNotElementType().OfCategory(BuiltInCategory.OST_StairsRailing);
            List<Railing> rails = collector.Cast<Railing>().ToList();
// ... truncated ...
```

## MainWindow.xaml.cs

```csharp
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
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

namespace AdjustCableTray
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public double Dis { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
            Dis_TB.Text = Properties.Settings.Default.distance.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dis = Convert.ToDouble(Dis_TB.Text);
                if (Dis < 0)
                {
                    TaskDialog.Show("提示", "输入的值不能小于0");
                    Close();

                }
                else
                {
                    Properties.Settings.Default.distance = Dis;
                    Properties.Settings.Default.Save();
                    DialogResult = true;
                    Close();
                }

            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "请输入正确的数值");
                Close();
            }

        }
    }
}

```

