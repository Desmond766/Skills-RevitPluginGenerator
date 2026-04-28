# Sample Snippet: CutFloor

Source project: `existingCodes\梁涛插件源代码\3.管综\CutFloor\CutFloor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CutFloor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //TaskDialog.Show("revit", sel.PickPoint().ToString() + "\n" + Convert.ToInt32(0.51));
            //return Result.Succeeded;

            Reference reference = sel.PickObject(ObjectType.Element, new FloorPlanarFaceFilter(), "选择一块楼板");
            Floor floor = doc.GetElement(reference) as Floor;

            XYZ selP0 = sel.PickObject(ObjectType.PointOnElement, "选择两点以确定拆分方向（第一点）").GlobalPoint;
            XYZ selP1 = sel.PickObject(ObjectType.PointOnElement, "选择两点以确定拆分方向（第二点）").GlobalPoint;

            MainWindow window = new MainWindow();
            window.ShowDialog();
            if (window.DialogResult == false)
            {
                return Result.Cancelled;
            }

            var faceRef = HostObjectUtils.GetTopFaces(floor);
            Face face = floor.GetGeometryObjectFromReference(faceRef.First()) as Face;

            FloorParaInfo floorParaInfo;

            TransactionGroup TG2 = new TransactionGroup(doc, "拆分楼板");
            TG2.Start();
            using (Transaction t = new Transaction(doc, "删除旧楼板"))
            {
                List<Parameter> paras = new List<Parameter>();
                paras = floor.Parameters.Cast<Parameter>().ToList();

                floorParaInfo = new FloorParaInfo() {FloorType = floor.FloorType, LevelId = floor.LevelId
                    , IsStructural = floor.get_Parameter(BuiltInParameter.FLOOR_PARAM_IS_STRUCTURAL).AsInteger()
                    , HeightOffset = floor.get_Parameter(BuiltInParameter.FLOOR_HEIGHTABOVELEVEL_PARAM)?.AsDouble()
                    , Paras = paras
                };
                t.Start();
                doc.Delete(floor.Id);
                t.Commit();
            }
            selP0 = GetProjectPointToFace(selP0, face as PlanarFace);
            selP1 = GetProjectPointToFace(selP1, face as PlanarFace);

            Line intersectLine = Line.CreateBound(selP0, selP1);
            XYZ horDir = intersectLine.Direction;
            XYZ verDir = (face as PlanarFace).FaceNormal.CrossProduct(horDir);
            List<Line> testLines = face.EdgeLoops.Cast<EdgeArray>().First().Cast<Edge>().Select(e => e.AsCurve() as Line).ToList();
            //TaskDialog.Show("revit", verDir.ToString());
            //TaskDialog.Show("revit", selP0 + "\n" + verDir + "\n" + testLines[0].GetEndPoint(0));

            int num;
            double space;
            if (window.SplitBySpace)
            {
                space = window.Space;
                num = GetSplitNum(selP0, intersectLine, testLines, space, out var newStartP);
                selP0 = newStartP;
            }
            else
            {
                num = window.Num;
                space = GetSplitSpace(selP0, intersectLine, testLines, num, out var newStartP);
                selP0 = newStartP;
            }
            
            
            

            for (int i = 0; i < num; i++)
            {
                XYZ startP = selP0 + horDir * space;
                Line testLine = Line.CreateUnbound(startP, verDir);
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

namespace CutFloor
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool SplitByNum { get; private set; }
        public bool SplitBySpace { get; private set; }
        public int Num { get; private set; }
        public double Space { get; private set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rb_num.IsChecked == true)
            {
                SplitByNum = true;
                try
                {
                    Num = Convert.ToInt32(tb_num.Text);
                    if (Num <= 0)
                    {
                        MessageBox.Show("输入的数需大于0");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            else
            {
                SplitBySpace = true;
                try
                {
                    Space = Convert.ToDouble(tb_space.Text) / 304.8;
                    if (Space <= 0)
                    {
                        MessageBox.Show("输入的数需大于0");
                        return;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            DialogResult = true;
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

```

