# Sample Snippet: CreateTextForBothEndsOfPipeline

Source project: `existingCodes\梁涛插件源代码\5.吊架出图\CreateTextForBothEndsOfPipeline\CreateTextForBothEndsOfPipeline`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace CreateTextForBothEndsOfPipeline
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Document doc = null;
        View view = null;
        TextNoteType textNoteType = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            view = doc.ActiveView;

            SelWindow selWindow = new SelWindow();
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            bool isRound;
            if (selWindow.rb_round.IsChecked == true)
            {
                isRound = true;
            }
            else
            {
                isRound= false;
            }

            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            IList<Reference> references;
            try
            {
                listenUtils.startListen();
                references = uIDoc.Selection.PickObjects(ObjectType.Element, new PipeFilter(), "框选管道（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            //获取文字注释类型
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").First();
            Transaction t = new Transaction(doc, "管道两端底部高程文字注释");
            t.Start();
            foreach (var item in references)
            {
                Pipe pipe = doc.GetElement(item) as Pipe;
                XYZ startP = ((pipe.Location as LocationCurve).Curve as Line).GetEndPoint(0);
                XYZ endP = ((pipe.Location as LocationCurve).Curve as Line).GetEndPoint(1);
                string startInfo = "";
                string endInfo = "";
                string rInfo = "";
                foreach (Parameter para in pipe.Parameters)
                {
                    if (para.Definition.Name == "起点中间高程") startInfo = (para.AsDouble() * 304.8).ToString();
                    if (para.Definition.Name == "端点中间高程") endInfo = (para.AsDouble() * 304.8).ToString();
                    //if (para.Definition.Name == "端点中间高程") endInfo = para.AsValueString();
                    //if (para.Definition.Name == "直径") rInfo = (Math.Round(para.AsDouble() * 304.8 / 2 / 10, 0) * 10).ToString();
                    if (para.Definition.Name == "直径") rInfo = (para.AsDouble() * 304.8 / 2).ToString();
                }

                if (startInfo != "" && endInfo != "" && rInfo != "")
                {
                    if (isRound) startInfo = (Math.Round((Convert.ToDouble(startInfo) - Convert.ToDouble(rInfo)) / 10, 0) * 10).ToString();
                    else startInfo = (Math.Round(Convert.ToDouble(startInfo) - Convert.ToDouble(rInfo), 2)).ToString();
                    if (isRound) endInfo = (Math.Round((Convert.ToDouble(endInfo) - Convert.ToDouble(rInfo)) / 10, 0) * 10).ToString();
                    else endInfo = (Math.Round(Convert.ToDouble(endInfo) - Convert.ToDouble(rInfo), 2)).ToString();
                    CreateTextNote(startP, startInfo, pipe, true);
                    CreateTextNote(endP, endInfo, pipe, false);
                    //CreateTextNote(endP, (Convert.ToInt32(endInfo) - Convert.ToInt32(rInfo)).ToString(), pipe, false);
                }
            }
// ... truncated ...
```

## SelWindow.xaml.cs

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

namespace CreateTextForBothEndsOfPipeline
{
    /// <summary>
    /// SelWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelWindow : Window
    {
        public SelWindow()
        {
            InitializeComponent();
            bool isRound = Properties.Settings.Default.IsRound;
            if (isRound)
            {
                rb_round.IsChecked = true;
            }
            else
            {
                rb_save.IsChecked = true;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (rb_round.IsChecked == true)
            {
                Properties.Settings.Default.IsRound = true;
            }
            else
            {
                Properties.Settings.Default.IsRound = false;
            }
            Properties.Settings.Default.Save();
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

