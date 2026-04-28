using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using System.IO;

namespace MEP_FittingOffset
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public static string rbtn_Direction = "升降";
        public static string rbtn_Angle = "90度";
        public static double cbx_Distance = 200;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
    //        //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

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
            try
            {
                while (true)
                {
                    //选择机电管线

                    Reference r1 = null;
                    Reference r2 = null;
                    Reference r3 = null;

                    r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    r2 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                    r3 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");

                    Resolver resolver = new Resolver(commandData);
                    try
                    {
                        using (Transaction t = new Transaction(doc, "机电管线避让"))
                        {
                            t.Start();
                            resolver.Resolve(r1, r2, r3);
                            if (!string.IsNullOrEmpty(Resolver.Message))
                            {
                                message = Resolver.Message;
                                return Result.Failed;
                            }
                            else
                            {
                                t.Commit();
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        message = e.Message;
                        return Result.Failed;
                    }
                }
            }
            catch
            {
            }

            return Result.Succeeded;
        }
    }
}
