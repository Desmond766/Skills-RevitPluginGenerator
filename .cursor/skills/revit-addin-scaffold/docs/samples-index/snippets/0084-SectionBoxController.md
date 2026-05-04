# Sample Snippet: SectionBoxController

Source project: `existingCodes\品成插件源代码\通用\SectionBoxController\SectionBoxController`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace SectionBoxController
{
    public static class GlobalVaule
    {
        public static double SPACING = 1000.0;
    }

    public enum BoxUpdateCmd
    {
        TopUp,
        TopDown,
        BottomUp,
        BottomDown,
        NorthPlus,
        NorthMinus,
        SouthPlus,
        SouthMinus,
        WestPlus,
        WestMinus,
        EastPlus,
        EastMinus
    }


    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //设置步距
            SpacingForm sForm = new SpacingForm();
            sForm.ShowDialog();
            //控制窗口
            SettingForm sf = new SettingForm();
            sf.Show();
            return Result.Succeeded;
        }

    }
}

```

## BoxUpdateHandler.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SectionBoxController
{
    class BoxUpdateHandler : IExternalEventHandler
    {
        BoxUpdateCmd _cmd = BoxUpdateCmd.TopUp;
        double _spacing = 1000 / 304.8;

        public BoxUpdateHandler(BoxUpdateCmd cmd)
        {
            _cmd = cmd;
            _spacing = GlobalVaule.SPACING / 304.8;
        }

        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            using (Transaction transaction = new Transaction(doc, "SectionBoxController"))
            {
                transaction.Start();
                View3D view3d = doc.ActiveView as View3D;
                if (!view3d.IsSectionBoxActive)
                {
                    TaskDialog.Show("Error", "请先开启剖面框");
                    return;
                }
                BoundingBoxXYZ box = view3d.GetSectionBox();
                if (false == box.Enabled)
                {
                    TaskDialog.Show("Error", "The section box for View3D isn't Enable.");
                    return;
                }
                switch (_cmd)
                {
                    case BoxUpdateCmd.TopUp:
                        box.Max = box.Max + _spacing * XYZ.BasisZ;
                        break;
                    case BoxUpdateCmd.TopDown:
                        box.Max = box.Max + _spacing * XYZ.BasisZ.Negate();
                        break;
                    case BoxUpdateCmd.BottomUp:
                        box.Min = box.Min + _spacing * XYZ.BasisZ;
                        break;
                    case BoxUpdateCmd.BottomDown:
                        box.Min = box.Min + _spacing * XYZ.BasisZ.Negate();
                        break;
                    case BoxUpdateCmd.NorthPlus:
                        box.Max = box.Max + _spacing * XYZ.BasisY;
                        break;
                    case BoxUpdateCmd.NorthMinus:
                        box.Max = box.Max + _spacing * XYZ.BasisY.Negate();
                        break;
                    case BoxUpdateCmd.SouthPlus:
                        box.Min = box.Min + _spacing * XYZ.BasisY.Negate();
                        break;
                    case BoxUpdateCmd.SouthMinus:
                        box.Min = box.Min + _spacing * XYZ.BasisY;
                        break;
                    case BoxUpdateCmd.WestPlus:
                        box.Min = box.Min + _spacing * XYZ.BasisX.Negate();
                        break;
                    case BoxUpdateCmd.WestMinus:
                        box.Min = box.Min + _spacing * XYZ.BasisX;
                        break;
                    case BoxUpdateCmd.EastPlus:
                        box.Max = box.Max + _spacing * XYZ.BasisX;
                        break;
                    case BoxUpdateCmd.EastMinus:
                        box.Max = box.Max + _spacing * XYZ.BasisX.Negate();
                        break;
                }
               
                view3d.SetSectionBox(box);

                transaction.Commit();
            }
        }

        public string GetName()
        {
            return "BoxUpdateHandler";
        }
    }
// ... truncated ...
```

