using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using System.Reflection;
using System.IO;
using System.Windows.Forms;

namespace NetHeightDim
{
    [Transaction(TransactionMode.Manual)]
    class SettingCmd : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
    //        #region 判断加密
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

    //        #endregion

            SettingForm sf = new SettingForm();

            if (sf.ShowDialog() != DialogResult.OK)
            {
                return Result.Failed;
            }

            if (sf.ActivePickMode)
            {
                UIApplication uiapp = commandData.Application;
                Selection sel = uiapp.ActiveUIDocument.Selection;
                Reference reference = sel.PickObject(ObjectType.PointOnElement);
                sf.settingUpdate[2] = "PickDatum";
                sf.settingUpdate[3] = (reference.GlobalPoint.Z * 0.3048).ToString("0.000");
            }
            string path = Path.ChangeExtension(Assembly.GetExecutingAssembly().Location, "txt");
            Utils.ListToTxt(sf.settingUpdate, path);

            return Result.Succeeded;
        }



    }
}
