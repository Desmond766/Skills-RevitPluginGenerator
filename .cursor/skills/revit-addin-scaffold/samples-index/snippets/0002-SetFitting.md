# Sample Snippet: SetFitting

Source project: `existingCodes\其他插件源代码\SetFitting`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## CommandFit.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using SetFitting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MepPractice
{
    [TransactionAttribute(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class CommandFit : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;
            Autodesk.Revit.DB.Document doc = uiDoc.Document;

            MainWindow mainWindow = new MainWindow();
            // 非模态窗口
             //mainWindow.Show();

            // 模态窗口,
            mainWindow.ShowDialog();

            if (!mainWindow.IsClickClosed)
            {
                return Result.Cancelled;
            }

            double gap = Convert.ToDouble(mainWindow.Text_btwSpace.Text);
            //if(null == gap)
            //{
            //    TaskDialog.Show("")
            //}
            double spaceBetween = ToFoot(gap);

            string CbxTypeString = mainWindow.Cbx_Type.Text.ToString();
            string CbxOriginString = mainWindow.Cbx_origin.Text.ToString();

            Reference beamRef1, beamRef2, ductRef;
            try
            {
                //点选两根梁 一根风管
                beamRef1 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "选择第一根梁");// new BeamSelectionFilter()
                beamRef2 = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "选择第二根梁");// new BeamSelectionFilter()
                ductRef = uiDoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, "选择风管");
            }
            catch (Autodesk.Revit.Exceptions.OperationCanceledException)
            {
                return Result.Cancelled;
            }

            // 获取选择的梁元素
            Element beam1 = doc.GetElement(beamRef1);
            Element beam2 = doc.GetElement(beamRef2);
            //获取选择的风管元素
            Element duct = doc.GetElement(ductRef);
            //获取风管的标高
            Level level = duct as Level;

            // 获取梁的几何信息
            LocationCurve locationCurve1 = beam1.Location as LocationCurve;
            LocationCurve locationCurve2 = beam2.Location as LocationCurve;
            Curve curve1 = locationCurve1.Curve;
            Curve curve2 = locationCurve2.Curve;

            //获取风管的几何信息
            LocationCurve locationCurveDuct = duct.Location as LocationCurve;
            Line lineDuct = locationCurveDuct.Curve as Line;
            XYZ referenceDirection = lineDuct.Direction;
            // 计算最短距离和相应的点
            XYZ closesPoint1, closesPoint2;
            double minDistance = GetClosesPoints(curve1, curve2, out closesPoint1, out closesPoint2);

            //TaskDialog.Show("最近点", $"最近的距离为：{minDistance}" +
            //$"\n点1坐标：{closesPoint1}" +
            //$"\n点2坐标：{closesPoint2}");
            Curve closesCurve = Line.CreateBound(closesPoint1, closesPoint2);
            XYZ beamMidPoint = closesCurve.Evaluate(0.5, true);
            //获得两条梁之间最短距离线段的中点到风管的投影点
            XYZ midPoint = GetProjectivePoint(lineDuct, beamMidPoint);

            //获得风管在平面上被梁截出的线段的中点
            XYZ movePoint0, movePoint1, movePoint2, movePoint3;
            Line MoveLine1 = GetMoveLine(doc, curve1, lineDuct, out movePoint0, out movePoint1);
            Line MoveLine2 = GetMoveLine(doc, curve2, lineDuct, out movePoint2, out movePoint3);
            XYZ intersectionPoint1 = GetIntersection(MoveLine1, lineDuct);       //获得梁1投影线段与风管的交点
// ... truncated ...
```

## MainWindow.xaml.cs

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

namespace SetFitting
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public bool IsClickClosed { get; set; } = false;
        List<string> setTypeList = new List<string>();
        List<string> setOriginList = new List<string>();
        public MainWindow()
        {
            InitializeComponent();

            //Cbx_Type.DataContext = setTypeList;
            setTypeList.Add("中心创建上固定");
            setTypeList.Add("中心创建下固定");
            setOriginList.Add("梁最短距离中心");
            setOriginList.Add("风管于梁之间的中心");

            Cbx_Type.ItemsSource = setTypeList;
            Cbx_Type.SelectedIndex = -1;
            Cbx_origin.ItemsSource = setOriginList;
            Cbx_origin.SelectedIndex = -1;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            IsClickClosed = true;
            this.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Cbx_Type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

           
        }
        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Cbx_Type.ItemsSource = setTypeList;
        }

    }

}

```

