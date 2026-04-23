using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace AddHanger
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public int is_more = 0;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UserControl1 u1 = new UserControl1();

            u1.ShowDialog();

            //  bool ups = u1.Option1.i
            bool no_more = u1.No_More.IsChecked.Value;
            bool is_more = u1.Is_More.IsChecked.Value;


            //if ( (!is_more) || (!no_more))
            //{
            //    TaskDialog.Show("提示", "请选择");
            //    return Result.Failed;

            //}




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
            Reference ref_mep = null;
            Reference ref_mep1 = null;
            Reference ref_mep2 = null;
            Reference ref_Hanger = null;




            //选择吊架进行参考布置———————————————————————————————————————————————————————————————————————————————————
            ref_Hanger = selection.PickObject(ObjectType.Element, new SelectionFilter4MechEquip(), "请选择要布置的吊架");
            Element hanger = doc.GetElement(ref_Hanger);
            if (!hanger.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("吊架"))
            {
                TaskDialog.Show("revit", "选择的构件不是吊架, 程序结束");
                return Result.Failed;
            }
            bool no_more_name = hanger.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("单管道");

            if (is_more && no_more_name)
            {
                TaskDialog.Show("revit", "单管道吊架不支持多管道架设");
                return Result.Failed;
            }



            //主程序开始———————————————————————————————————————————————————————————————————————————————————
            while (true)
            {
                try
                {
                    if (no_more)
                    {
                        using (Transaction t = new Transaction(doc, "Add Hanger"))
                        {
                            t.Start();
                            ref_mep = selection.PickObject(ObjectType.LinkedElement, new SelectionFilter4MEPCurve(), "点击管线进行布置");
                            RevitLinkInstance revitLinkInstance = doc.GetElement(ref_mep.ElementId) as RevitLinkInstance;
                            Document linkDoc = revitLinkInstance.GetLinkDocument();
                            Element mep = linkDoc.GetElement(ref_mep.LinkedElementId);
                            //Element mep = doc.GetElement(ref_mep);
                            //判断单管道吊架是否布置在水管上
                            if (hanger.get_Parameter(BuiltInParameter.ELEM_FAMILY_PARAM).AsValueString().Contains("单管道") && (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves || mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray))
                            {
                                    TaskDialog.Show("提示", "只能在水管上布置此吊架");
                                    return Result.Failed;
                            }
                            XYZ location = selection.PickPoint();
                            Transform transform = revitLinkInstance.GetTransform();

                            //风管
                            if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_DuctCurves)
                            {
                                ResolverForDuct resolverForDuct = new ResolverForDuct(commandData,transform);
                                resolverForDuct.Resolve(view3D, hanger, mep, location);
                            }
                            //水管
                            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_PipeCurves)
                            {
                                ResolverForPipe resolverForPipe = new ResolverForPipe(commandData,transform);
                                resolverForPipe.Resolve(view3D, hanger, mep, location);
                            }
                            //线槽
                            else if (mep.Category.Id.IntegerValue == (int)BuiltInCategory.OST_CableTray)
                            {
                                ResolverForCableTray resolverForCableTray = new ResolverForCableTray(commandData, transform);
                                resolverForCableTray.Resolve(view3D, hanger, mep, location);
                            }
                            t.Commit();
                        }
                    }
                    if (is_more)
                    {
                        using (Transaction t = new Transaction(doc, "Add Hanger4GY"))
                        {
                            t.Start();

                            ref_mep1 = selection.PickObject(ObjectType.LinkedElement, new SelectionFilter4MEPCurve(), "点击管线进行布置");
                            RevitLinkInstance revitLinkInstance2 = doc.GetElement(ref_mep1.ElementId) as RevitLinkInstance;
                            Document linkDoc2 = revitLinkInstance2.GetLinkDocument();
                            Element mep1 = linkDoc2.GetElement(ref_mep1.LinkedElementId);
                            ref_mep2 = selection.PickObject(ObjectType.LinkedElement, new SelectionFilter4MEPCurve(), "点击管线进行布置");
                            RevitLinkInstance revitLinkInstance3 = doc.GetElement(ref_mep2.ElementId) as RevitLinkInstance;
                            Document linkDoc3 = revitLinkInstance3.GetLinkDocument();
                            Element mep2 = linkDoc3.GetElement(ref_mep2.LinkedElementId);
                            XYZ location = selection.PickPoint();
                            Transform transform = revitLinkInstance2.GetTransform();
                            Transform transform1 = revitLinkInstance3.GetTransform();


                            ResolverForGY resolverForGY = new ResolverForGY(commandData,transform,transform1);
                            resolverForGY.Resolve(view3D, hanger, mep1, mep2, location);
                            t.Commit();
                        }
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
