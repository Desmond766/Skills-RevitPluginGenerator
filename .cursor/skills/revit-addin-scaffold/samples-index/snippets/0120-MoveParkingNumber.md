# Sample Snippet: MoveParkingNumber

Source project: `existingCodes\梁涛插件源代码\2.机电建模及算量\MoveParkingNumber\MoveParkingNumber`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoveParkingNumber
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            // TODO: 添加误差与寻找范围窗口、添加对链接模型的坐标转换，否则在一些项目调整会出错误;
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            TaskDialog taskDialog = new TaskDialog("运行前提示");
            taskDialog.MainInstruction = "确认当前视图为三维视图且停车位、照明线槽桥架、车位号在当前视图中都可见后点击确定运行插件";
            taskDialog.CommonButtons = TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel;
            var res = taskDialog.Show();
            if (res != TaskDialogResult.Ok)
            {
                return Result.Cancelled;
            }

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }
            double errorValue = window.ErrorValue / 304.8;
            double angle = (window.Angle / 180.0) * Math.PI;

            if (!(doc.ActiveView is View3D))
            {
                TaskDialog.Show("提示", "请在三维视图中运行该插件");
                return Result.Cancelled;
            }
            View3D view3D = (View3D)doc.ActiveView;

            List<RevitLinkInstance> linkInstances = new FilteredElementCollector(doc).WhereElementIsNotElementType()
                .OfCategory(BuiltInCategory.OST_RvtLinks)
                .Cast<RevitLinkInstance>().ToList();
                
            // 所有链接模型中的桥架
            List<LinkCableTrayInfo> linkCableTrays = new List<LinkCableTrayInfo>();

            foreach (var linkInstance in linkInstances)
            {
                Transform linkTransform = linkInstance.GetTransform();
                Document linkDoc = linkInstance.GetLinkDocument();
                List<CableTray> linkCables = new FilteredElementCollector(linkDoc).OfCategory(BuiltInCategory.OST_CableTray).WhereElementIsNotElementType().Where(c => c.Name.Contains("照明线槽")).Cast<CableTray>().ToList();

                List<FamilyInstance> parkings = new FilteredElementCollector(linkDoc).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType().Where(x => x.Name.Contains("普通车位")).Cast<FamilyInstance>().ToList();

                foreach (var linkCable in linkCables)
                {
                    LinkCableTrayInfo linkCableTray = TransformCableTray(linkInstance, linkCable);
                    linkCableTrays.Add(linkCableTray);
                }
            }

            // 车牌号
            List<FamilyInstance> parkingNumbers = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_StructuralColumns).WhereElementIsNotElementType()
                .Where(p => p.Name.Contains("车位号")).Cast<FamilyInstance>().ToList();

            int count = 0;
            List<ElementId> failedResult = new List<ElementId>();
            List<ElementId> result = new List<ElementId>();
            using (Transaction t = new Transaction(doc, "调整车位号"))
            {
                ElementId ruleParamId = new ElementId(BuiltInParameter.ELEM_TYPE_PARAM);
                FilterRule filteRule = ParameterFilterRuleFactory.CreateContainsRule(ruleParamId, "普通车位", false);
                ElementParameterFilter paramFilter = new ElementParameterFilter(filteRule);

                ElementCategoryFilter categoryFilter = new ElementCategoryFilter(BuiltInCategory.OST_StructuralColumns);

                LogicalAndFilter andFilter = new LogicalAndFilter(paramFilter, categoryFilter);

                t.Start();

                foreach (var pn in parkingNumbers)
// ... truncated ...
```

## FailWindow.xaml.cs

```csharp
using Autodesk.Revit.DB;
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

namespace MoveParkingNumber
{
    /// <summary>
    /// FailWindow.xaml 的交互逻辑
    /// </summary>
    public partial class FailWindow : Window
    {
        readonly UIDocument UIDoc = null;
        public FailWindow(UIDocument uidoc)
        {
            InitializeComponent();
            UIDoc = uidoc;
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ElementId elementId = list.SelectedItem as ElementId;
                UIDoc.ShowElements(elementId);
                UIDoc.Selection.SetElementIds(new ElementId[] { elementId });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}

```

