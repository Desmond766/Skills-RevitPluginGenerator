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
