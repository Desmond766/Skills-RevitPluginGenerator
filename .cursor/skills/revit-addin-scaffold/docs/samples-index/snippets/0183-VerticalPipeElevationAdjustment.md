# Sample Snippet: VerticalPipeElevationAdjustment

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\VerticalPipeElevationAdjustment\VerticalPipeElevationAdjustment`

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
using System.Windows.Controls;

namespace VerticalPipeElevationAdjustment
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            View3D view3D = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Views).WhereElementIsNotElementType()
                .Where(x => x is View3D).Cast<View3D>().FirstOrDefault(y => y.Name.Contains("3D 机电"));

            if (view3D == null)
            {
                TaskDialog.Show("提示", "未找到视图：3D 机电");
                return Result.Cancelled;
            }




            //return Result.Succeeded;

            var references = sel.PickObjects(ObjectType.Element, new MepCurveFilter(), "框选立管");

            SelWindow selWindow = new SelWindow();
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }
            // 打开指定视图中楼板的可见性
            var openIds = DisplayFloor(doc, view3D, out bool isHidden);

            var pipes = references.Select(x => doc.GetElement(x) as MEPCurve);
            TransactionGroup TG = new TransactionGroup(doc, "立管两端标高调整");
            TG.Start();
            foreach (var pipe in pipes)
            {
                XYZ pointUp;
                XYZ pointDown;
                Line line = (pipe.Location as LocationCurve).Curve as Line;
                XYZ dir = line.Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisZ))
                {
                    pointUp = line.GetEndPoint(1);
                    pointDown = line.GetEndPoint(0);
                }
                else
                {
                    pointUp = line.GetEndPoint(0);
                    pointDown = line.GetEndPoint(1);
                }
                double upDis = 0;
                double downDis = 0;
                if (selWindow.cb_up.IsChecked == true)
                {
                    try
                    {
                        upDis = Convert.ToDouble(selWindow.tb_up.Text) / 304.8;
                    }
                    catch (Exception)
                    {
                        break;
                    }

                    if (GetDistanceToFloor(view3D, pointUp, XYZ.BasisZ, false, doc) == -1) continue;

                    double dis = upDis;

                    if (upDis > 0)
                    {
                        dis += GetDistanceToFloor(view3D, pointUp, XYZ.BasisZ, true, doc);
                    }
                    else
                    {
// ... truncated ...
```

## MepCurveFilter.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VerticalPipeElevationAdjustment
{
    public class MepCurveFilter : ISelectionFilter
    {
        public bool AllowElement(Element elem)
        {
            if (elem is Pipe || elem is Conduit || elem is CableTray)
            {
                XYZ dir = ((elem.Location as LocationCurve).Curve as Line).Direction;
                if (dir.IsAlmostEqualTo(XYZ.BasisZ) || dir.IsAlmostEqualTo(XYZ.BasisZ.Negate()))
                {
                    return true;
                }
            }return false;
        }

        public bool AllowReference(Reference reference, XYZ position)
        {
            return false;
        }
    }
}

```

