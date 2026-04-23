using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//注册
namespace CEGRegister
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            using (Form1 form = new Form1())
            {
                if (DialogResult.OK != form.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            return Result.Succeeded;
        }
    }
}
