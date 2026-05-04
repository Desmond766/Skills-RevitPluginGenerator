# Sample Snippet: CalculatePipeLength

Source project: `existingCodes\梁涛插件源代码\3.管综\CalculatePipeLength\CalculatePipeLength`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CalculatePipeLength
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            MainWindow window = new MainWindow();
            window.ShowDialog();
            var result = window.DialogResult == true;
            if (!result)
            {
                return Result.Cancelled;
            }

            double length = 0;

            if (window.IsBoxSelection)
            {
                IList<Reference> refers;
                RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
                try
                {
                    listenUtils.startListen();
                    refers = sel.PickObjects(ObjectType.Element, new PipeAndFitFilter(), "框选管道与管件（按空格键完成框选，ESC键取消）");
                    listenUtils.stopListen();
                }
                catch (Exception)
                {
                    listenUtils.stopListen();
                    return Result.Cancelled;
                }
                List<Element> elems = refers.Select(r => doc.GetElement(r)).ToList();
                foreach (Element elem in elems)
                {
                    if (elem is Pipe) length += elem.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble();
                    else
                    {
                        XYZ elemPoint = (elem.Location as LocationPoint).Point;
                        foreach (Connector con in (elem as FamilyInstance).MEPModel.ConnectorManager.Connectors)
                        {
                            if (con.ConnectorType == ConnectorType.End) length += elemPoint.DistanceTo(con.Origin);
                        }
                    }
                }
            }
            else
            {
                List<UV> points = new List<UV>();
                int count = 0;
            Next:
                count++;
                XYZ point;
                try
                {
                    point = sel.PickPoint($"连续选择坐标点{count}（按ESC键结束选择）");
                    points.Add(new UV(point.X, point.Y));
                    goto Next;
                }
                catch (Exception)
                {

                }
                for (int i = 0; i < points.Count - 1; i++)
                {
                    length += points[i].DistanceTo(points[i + 1]);
                }
            }

            MessageBox.Show("总长度: " + Math.Round((length * 3.048), 2) + "M");

            return Result.Succeeded;
        }
    }
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

namespace CalculatePipeLength
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool IsBoxSelection { get; private set; } = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            IsBoxSelection = true;
            DialogResult = true;
            Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            IsBoxSelection = false;
            DialogResult = true;
            Close();
        }
    }
}

```

