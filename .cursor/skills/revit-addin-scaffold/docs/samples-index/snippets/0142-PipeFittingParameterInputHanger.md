# Sample Snippet: PipeFittingParameterInputHanger

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\PipeFittingParameterInputHanger\PipeFittingParameterInputHanger`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using BTAddInHelper;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Autodesk.Revit.DB.Electrical;
using System.Windows.Documents;
using System.Windows.Controls;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Collections;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace PipeFittingParameterInputHanger
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        UIDocument uidoc = null;
        int failedCount = 0;
        int insCount = 0;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion
            UIApplication uiapp = commandData.Application;
            uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();

            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                references = uidoc.Selection.PickObjects(ObjectType.Element, new HangerFilter(), "框选门型抗震吊架（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }

            UserControl1 userControl = new UserControl1();
            userControl.ShowDialog();
            if (userControl.cancel) return Result.Cancelled;

            View3D view3D = null;
            FilteredElementCollector viewCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (Element element in viewCollector)
            {
                View3D view3 = element as View3D;

                if (view3.Name.Equals("{三维}"))
                {
                    // 将获取到的3D视图添加到列表中
                    view3D = view3;
                }
            }
            if (view3D == null)
            {
                foreach (Element element in viewCollector)
                {
                    View3D view3 = element as View3D;

                    if (view3.Name.Equals("{3D}"))
                    {
                        // 将获取到的3D视图添加到列表中
                        view3D = view3;
                    }
                }
            }
            //TransactionGroup group = new TransactionGroup(doc, "创建吊架文字注释");
// ... truncated ...
```

## UserControl1.xaml.cs

```csharp
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

namespace PipeFittingParameterInputHanger
{
    /// <summary>
    /// UserControl1.xaml 的交互逻辑
    /// </summary>
    public partial class UserControl1 : Window
    {
        public bool cancel { get; private set; } = true;
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            cancel = false;
            Close();
        }
    }
}

```

