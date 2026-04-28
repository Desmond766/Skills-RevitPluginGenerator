using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Demo02
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command08 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            UserControl05 userControl05 = new UserControl05();
            userControl05.ShowDialog();
            if (userControl05.cancel )
            {
                return Result.Cancelled;
            }
            using (Transaction tran = new Transaction(doc, "Modifying Family Type Parameters"))
            {
                tran.Start();
                //数字决定execl的第几张表
                try
                {
                    ReadExcelFile.GetData(doc, 1, userControl05);
                }
                catch (Exception)
                {

                    //MessageBox.Show("Please confirm if there is a \"参数.xlsx\" file under the D drive.");
                    MessageBox.Show("The file was not found.");
                    return Result.Failed;
                }

                tran.Commit();
            }
            return Result.Succeeded;
        }
    }
}
