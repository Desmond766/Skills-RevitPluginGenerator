using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGRegister
{
    [Transaction(TransactionMode.Manual)]
    public class Command03 : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            //if (!BTAddInHelper.Utils.CheckReg(licFile))
            //{
            //    return Result.Cancelled;
            //}
            if (!CheckRegClass.CheckReg(licFile))
            {
                return Result.Cancelled;
            }
            #endregion
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection selection = uiapp.ActiveUIDocument.Selection;
            UIDocument uiDoc = commandData.Application.ActiveUIDocument;

            //判断视图————————————————————————————————————————————————————————————————————————————————————————————————————————————————
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("Revit", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }
            Autodesk.Revit.DB.View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
            View3D view3D = null;
            View3D default3Dview = null;
            View3D target3Dview = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 支吊架".Equals(view3.Name))
                {
                    default3Dview = view3;
                }
                if (string.Format("3D {0}", doc.ActiveView.Name).Equals(view3.Name))
                {
                    target3Dview = view3;
                }
            }
            if (null != target3Dview)
            {
                view3D = target3Dview;
            }
            else
            {
                if (null != default3Dview)
                {
                    view3D = default3Dview;
                }
                else
                {
                    message = string.Format("未找到3D视图： 3D 支吊架 或 3D {0}", doc.ActiveView.Name);
                    return Result.Cancelled;
                }
            }

            //定义几个变量———————————————————————————————————————————————————————————————————————————————————
            Reference ref_mepxc = null;
            Reference ref_meppl = null;
            Reference ref_Hanger = null;

            //选择吊架进行参考布置———————————————————————————————————————————————————————————————————————————————————
            ref_Hanger = selection.PickObject(ObjectType.Element, new SelectionFilter4MechEquip(), "请选择要布置的吊架");
            Element hanger = doc.GetElement(ref_Hanger);
            if (!hanger.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("吊架"))
            {
                TaskDialog.Show("revit", "选择的构件不是吊架, 程序结束");
                return Result.Failed;
            }

            //主程序开始———————————————————————————————————————————————————————————————————————————————————
            while (true)
            {
                try
                {

                    using (Transaction t = new Transaction(doc, "Add Hanger4PLXC"))
                    {
                        t.Start();

                        ref_meppl = selection.PickObject(ObjectType.Element, new SelectionFilter4PipeCurve(), "点击喷淋管线");
                        Element meppl = doc.GetElement(ref_meppl);
                        if (meppl.Category.Id.IntegerValue != (int)BuiltInCategory.OST_PipeCurves)
                        {
                            TaskDialog.Show("revit", "选择的构件不是管线, 程序结束");
                            return Result.Failed;
                        }

                        ref_mepxc = selection.PickObject(ObjectType.Element, new SelectionFilter4CableTray(), "点击照明线槽");
                        Element mepxc = doc.GetElement(ref_mepxc);
                        if (mepxc.Category.Id.IntegerValue != (int)BuiltInCategory.OST_CableTray)
                        {
                            TaskDialog.Show("revit", "选择的构件不是线槽, 程序结束");
                            return Result.Failed;
                        }

                        XYZ location = selection.PickPoint();

                        ResolverForPLZM resolverForPLZM = new ResolverForPLZM(commandData);
                        resolverForPLZM.Resolve(view3D, hanger, meppl, mepxc, location);

                        t.Commit();
                    }
                }
                //ESC退出布置
                catch (Exception ex)
                {
                    if (ex.Message == "The user aborted the pick operation.")
                    {
                        TaskDialog.Show("Revit", "结束布置");
                        break;
                    }
                    else
                    {
                        TaskDialog.Show("Revit", ex.Message + "\n" + ex.StackTrace.ToString());
                        break;
                    }
                }
            }



            return Result.Succeeded;
        }
    }
}
