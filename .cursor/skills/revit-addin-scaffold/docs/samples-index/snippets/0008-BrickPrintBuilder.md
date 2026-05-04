# Sample Snippet: BrickPrintBuilder

Source project: `existingCodes\品成插件源代码\土建\BrickPrintBuilder\BrickPrintBuilder`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace BrickPrintBuilder
{
	public enum BuildMode
    {
        Horizontal = 0,
        Vertical = 1,
        Unknow = -1
    }

    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
		string verticalSymbolName = "标准砖";
		string horizontalSymbolName = "平面标准砖";
		public static double tickness { get; set; }
		public static bool grouped { get; set; }
		public static string unRegularBrick { get; set; }
		BuildMode mode;
		public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
			UIApplication application = commandData.Application;
            Document document = application.ActiveUIDocument.Document;
            Selection selection = application.ActiveUIDocument.Selection;

            if (new FilteredElementCollector(document).OfClass(typeof(Level)).Count() == 0)
            {
				message = "至少需要一个标高!";
				return Result.Cancelled;
            }
            var m = new FilteredElementCollector(document).OfClass(typeof(FloorType));

            MessageBox.Show(string.Join("\n", m.Select(u => u.Name)));
            //if (new FilteredElementCollector(document).OfClass(typeof(WallType)).Count() == 0)
            //         {
            //	message = "至少需要一个墙类型!";
            //	return Result.Cancelled;
            //}

            //显示对话框
            using (SettingForm settingForm = new SettingForm())
			{
				if (settingForm.ShowDialog() != DialogResult.OK)
                {
                    return Result.Cancelled;
                }
            }

			//选择底图
            Reference reference = selection.PickObject(ObjectType.Element);
            Element element = document.GetElement(reference.ElementId);

			if (!(element is Instance))
			{
				message = "请指定排砖图DWG!";
				return Result.Cancelled;
			}
			//判断排砖方向
			//XYZ max = element.get_BoundingBox(document.ActiveView).Max;
			//XYZ min = element.get_BoundingBox(document.ActiveView).Min;
			if (element.get_BoundingBox(document.ActiveView).Max.Z - element.get_BoundingBox(document.ActiveView).Min.Z < 0.001)
            {
				mode = BuildMode.Horizontal;
            }
			else//TODO
            {
				mode = BuildMode.Vertical;
			}

			//读取实体
			GeometryElement geometryElement = element.get_Geometry(new Options
			{
				View = document.ActiveView
			});
			Transform transform = (element as Instance).GetTransform();
			List<GeometryInstance> list = new List<GeometryInstance>();//块
			List<PolyLine> list2 = new List<PolyLine>();//标准矩形多段线
			List<PolyLine> list3 = new List<PolyLine>();//未知多段线，创建内建模型
			foreach (GeometryObject geometryObject in geometryElement)
			{
// ... truncated ...
```

## SettingForm.cs

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrickPrintBuilder
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            Command.unRegularBrick = rbtn_DirectShape.Checked ? "DirectShape" : "Floor";
            Command.tickness = double.Parse(this.tbx_tickness.Text) / 304.8;
            Command.grouped = this.cbx_Grouped.Checked;
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            base.Close();
        }
    }
}

```

