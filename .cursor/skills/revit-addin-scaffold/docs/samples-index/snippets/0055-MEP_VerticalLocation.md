# Sample Snippet: MEP_VerticalLocation

Source project: `existingCodes\品成插件源代码\机电\MEP_VerticalLocation\MEP_VerticalLocation`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using System.Windows.Forms;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;
using System.Diagnostics;

namespace MEP_VerticalLocation
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 字段属性
        private static XYZ _direction;
        public static XYZ Direction
        {
            get { return Command._direction; }
            set { Command._direction = value; }
        }
        private static string _distance;
        public static string Distance
        {
            get { return Command._distance; }
            set { Command._distance = value; }
        }
        #endregion

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }
            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            //判断是否存在三维视图
            View3D view = Get3DView(doc);
            if (null == view)
            {
                message = "错误1：未找到｛三维｝视图！";
                return Result.Failed;
            }
            //判断选择集非空
            Selection selection = uiapp.ActiveUIDocument.Selection;
            List<ElementId> elementIds = selection.GetElementIds() as List<ElementId>;
            if (elementIds.Count == 0)
            {
                message = "错误2：未选择任何构件！";
                return Result.Failed;
            }
            //弹出对话框提示用户输入
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }
            //距离必须不为空且为数值型
            if (string.IsNullOrEmpty(Distance))
            {
                message = "错误3：距离不能为空！";
                return Result.Failed;
            }
            try
            {
                double distance = double.Parse(Distance);
            }
            catch
            {
                message = "错误4：输入的距离必须为数值！";
                return Result.Failed;
            }
            //计时开始
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //主程序开始
            int num_Done = 0;
// ... truncated ...
```

## SettingForm.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MEP_VerticalLocation
{
    public partial class SettingForm : System.Windows.Forms.Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {

        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            if (rbtn_Top.Checked)
            {
                Command.Direction = XYZ.BasisZ;
            }
            else
            {
                Command.Direction = XYZ.BasisZ.Negate();
            }
            Command.Distance = tbx_Distance.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void Btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

```

