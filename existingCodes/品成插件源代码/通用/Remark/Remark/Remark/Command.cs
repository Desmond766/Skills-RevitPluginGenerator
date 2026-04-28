using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

namespace Remark
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            OverrideGraphicSettings setting = GetRemarkSetting(doc);

            // Remark
            while (true)
            {
                try
                {
                    using (Transaction t = new Transaction(doc, "BimtransArchiTools.Remark"))
                    {
                        t.Start();
                        doc.ActiveView.SetElementOverrides(sel.PickObject(ObjectType.Element).ElementId, setting);
                        t.Commit();
                    }
                }
                catch
                {
                    TaskDialog.Show("Revit", "取消操作，程序结束！");
                    break;
                }
            }

            return Result.Succeeded;
        }

        #region 获得标记参数设置
        /// <summary>
        /// 获得标记参数设置
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        private OverrideGraphicSettings GetRemarkSetting(Document doc)
        {
            // 得到一个实体填充图案
            ElementId fillPatternId = ElementId.InvalidElementId;
            FilteredElementCollector coll = new FilteredElementCollector(doc);
            coll.OfClass(typeof(FillPatternElement));
            foreach (Element e in coll.ToElements())
            {
                FillPatternElement fe = e as FillPatternElement;
                if (fe.GetFillPattern().IsSolidFill)
                {
                    fillPatternId = e.Id;
                    break;
                }
            }
            // 设置颜色和填充图案
            OverrideGraphicSettings setting = new OverrideGraphicSettings();
            // 截面填充图案
            //setting.SetSurfaceTransparency(0);
            //setting.SetCutFillColor(new Color(255, 0, 0));
            //setting.SetCutFillPatternId(fillPatternId);
            // 表面填充图案
            setting.SetProjectionFillColor(new Color(255, 255, 0));
            setting.SetProjectionFillPatternId(fillPatternId);
            return setting;
        }
        #endregion

    }
}
