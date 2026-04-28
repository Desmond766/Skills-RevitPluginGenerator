//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace Com_ShowElement
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密

     //       string licFile = string.Format("{0}\\Key.lic",
     //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
     //       if (!BTAddInHelper.Utils.CheckReg(licFile))
     //       {
     //           return Result.Cancelled;
     //       }

            #endregion
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //将选中的构件收集起来
            ICollection<ElementId> list = sel.GetElementIds();
            if (list.Count == 0)
            {
                TaskDialog.Show("提示", "请选择要居中显示的构件。");
            }
            else
            {
                //居中显示这些构件
                uidoc.ShowElements(list);
            }


            return Result.Succeeded;
        }
    }
}
