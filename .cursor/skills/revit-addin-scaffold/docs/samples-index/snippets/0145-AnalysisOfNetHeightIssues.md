# Sample Snippet: AnalysisOfNetHeightIssues

Source project: `existingCodes\梁涛插件源代码\6.不常用\AnalysisOfNetHeightIssues\AnalysisOfNetHeightIssues`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Document = Autodesk.Revit.DB.Document;

namespace AnalysisOfNetHeightIssues
{
    [TransactionAttribute(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Document doc = uIDoc.Document;

            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("{三维}".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： {三维} 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            //IList<Reference> references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new DuctFilter());

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            RevitLinkInstance link = collector.OfClass(typeof(RevitLinkInstance)).Cast<RevitLinkInstance>().ToList().FirstOrDefault();

            Document linkDoc = link.GetLinkDocument();

            UserControl1 userControl = new UserControl1();
            userControl.ShowDialog();
            if (userControl.cancel)
            {
                return Result.Cancelled;
            }

            double spacing = Convert.ToDouble(userControl.tb.Text);
            List<Difference> differences = new List<Difference>();

            if (userControl.cs.IsChecked == false) 
            {
                Floor floor = new FilteredElementCollector(linkDoc).OfClass(typeof(Floor)).Where(x => x.Name.Contains("停车位")).Cast<Floor>().First();
                //楼板几何
                GeometryElement geometryElement = floor.get_Geometry(new Options());
                GeometryObject topFace = null;
                //获取楼板顶面
                foreach (GeometryObject geometryObject in geometryElement)
// ... truncated ...
```

## EventCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalysisOfNetHeightIssues
{
    public class EventCommand : IExternalEventHandler
    {
        public ElementId ductId {  get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            uIDoc.ShowElements(ductId);
            uIDoc.Selection.SetElementIds(new List<ElementId>() { ductId });
            uIDoc.RefreshActiveView();
        }

        public string GetName()
        {
            return "EventCommand";
        }
    }
}

```

