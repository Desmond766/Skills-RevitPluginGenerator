using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
//using System.Windows.Forms;
using System.IO;
using System.Windows.Forms;

namespace MEP_SmartOffset
{
    [Transaction(TransactionMode.Manual)]
    public class Command:IExternalCommand
    {
        public static string rbtn_Angle = "45度";
        public static double cbx_Distance = 100;
        public static double cbx_DistanceHor = 100;
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //弹出设置窗口
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }


            //拾取障碍构件
            TaskDialog.Show("提示：", "请拾取障碍管线");
            Reference r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");

            //选择爬升构件
            TaskDialog.Show("提示：", "选择要爬升的管线，点击左上角“完成”按钮结束选择");
            IList<Reference> iList = sel.PickObjects(ObjectType.Element, new MEPCurveSelectionFilter(), "选择要爬升的构件");

            Resolver resolver = new Resolver(commandData);
            
             using (Transaction t = new Transaction(doc, "机电管线避让"))
             {
                 t.Start();
                 resolver.Resolve(r1, iList);
                 t.Commit();
             }

            return Result.Succeeded;
        }
    }
}
