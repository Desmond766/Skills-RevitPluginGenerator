# Sample Snippet: PlaceByCurve

Source project: `existingCodes\品成插件源代码\通用\PlaceByCurve\PlaceByCurve`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB.Structure;

namespace PlaceByCurve
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        //布置间距
        public static double spacing { get; set; }
        //起点偏移
        public static double offset { get; set; }

        const double smallLength = 2.0 / 304.8;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //弹出对话框，获取用户输入
            using (SettingForm sf = new SettingForm())
            {
                if (sf.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {
                    return Result.Cancelled;
                }
            }
            if (spacing < smallLength)
            {
                message = "间距过短";
                return Result.Cancelled;
            }

            //选择线条
            Reference reference = null;
            Curve curve = null;
            try
            {
                reference = sel.PickObject(ObjectType.Element, new ModelCurveSelectionFilter(), "请选择一条模型线");
                ModelCurve modelCurve = doc.GetElement(reference) as ModelCurve;
                curve = (modelCurve.Location as LocationCurve).Curve;
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("取消选择，程序结束！");
                return Result.Cancelled;
            }
            if (curve.Length < smallLength)
            {
                message = "线条过短";
                return Result.Cancelled;
            }

            //确认初始点
            XYZ hitPoint = reference.GlobalPoint;
            XYZ startPoint = curve.GetEndPoint(0);
            XYZ endPoint = curve.GetEndPoint(1);
            bool reverse = false;
            if (hitPoint.DistanceTo(curve.GetEndPoint(1)) < hitPoint.DistanceTo(curve.GetEndPoint(0)))//存在出错的几率
            {
                startPoint = curve.GetEndPoint(1);
                endPoint = curve.GetEndPoint(0);
                reverse = true;
            }

            //获得点集合
            var points = GetPoints(curve, offset, spacing, reverse);
            if (points.Count == 0)
            {
                message = "没有找到符合的点";
                return Result.Cancelled;
            }

            //选择实例
            FamilyInstance instance = null;
// ... truncated ...
```

## SettingForm.cs

```csharp
using System;
using System.Windows.Forms;

namespace PlaceByCurve
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        //默认值
        public static string _offset = "0";
        public static string _spacing = "500";

        private void SettingForm_Load(object sender, EventArgs e)
        {
            //初始化填入默认值
            tbx_Offset.Text = _offset;
            tbx_Spacing.Text = _spacing;
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            try
            {
                var m_offset = double.Parse(tbx_Offset.Text) / 304.8;
                var m_spacing = double.Parse(tbx_Spacing.Text) / 304.8;
                if (m_offset < 0.0 || m_spacing < 0.0)
                {
                    MessageBox.Show("数据非法！");
                    return;
                }
                //赋值
                Command.offset = m_offset;
                Command.spacing = m_spacing;
                //更新默认值
                _offset = tbx_Offset.Text;
                _spacing = tbx_Spacing.Text;
                DialogResult = DialogResult.OK;
                Close();
            }
            catch
            {
                MessageBox.Show("数据非法！");
                return;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

```

