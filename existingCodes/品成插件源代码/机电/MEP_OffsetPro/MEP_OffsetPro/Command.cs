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

namespace MEP_OffsetPro
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {



        //静态参数，用于记住上次选择
        public static string type = "单侧";
        public static double distance ;
        public static double diameter ;
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

            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Failed;
            }



            //try
            //{
            //    while (true)
            //    {



                    Reference r0 = null;
                    Reference r1 = null;
                    Reference r2 = null;

                    //如果弹窗设置选择的是单侧爬升，即主管连三通
                    if (type == "单侧")
                    {
                        //选择配件
                        r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "配件");
                        //选择喷淋支管
                        r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");

                        ResolverOne resolverone = new ResolverOne(commandData);
                        //try
                        //{
                            using (Transaction t = new Transaction(doc, "单侧喷淋支管升降"))
                            {
                                t.Start();
                                ResolverOne.Distance = distance;
                                resolverone.Resolve(r0, r1);
                                if (!string.IsNullOrEmpty(ResolverOne.Message))
                                {
                                    message = ResolverOne.Message;
                                    return Result.Failed;
                                }
                                else
                                {
                                    t.Commit();
                                }
                            }
                        //}
                        //catch (Exception e)
                        //{
                        //    message = e.Message;
                        //    return Result.Failed;
                        //}
                    }
                    //如果弹窗设置选择的是双侧爬升，即主管连四通
                    else
                    {
                        //选择配件
                        r0 = sel.PickObject(ObjectType.Element, new FamilyinstanceSelectionFilter(), "配件");
                        //选择喷淋支管
                        r1 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");
                        r2 = sel.PickObject(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线");

                        ResolverTwo resolvertwo = new ResolverTwo(commandData);
                       
                        
                        
                        //try
                        //{



                            using (Transaction t = new Transaction(doc, "双侧喷淋支管升降"))
                            {
                                t.Start();
                                ResolverTwo.Distance = distance;
                                ResolverTwo.Diameter = diameter;
                                resolvertwo.Resolve(r0, r1, r2);
                                if (!string.IsNullOrEmpty(ResolverTwo.Message))
                                {
                                    message = ResolverTwo.Message;
                                    return Result.Failed;
                                }
                                else
                                {
                                    t.Commit();
                                }
                           }


                        //}
                        //catch (Exception e)
                        //{
                        //    message = e.Message;
                        //    return Result.Failed;
                        //}



                    }





            //    }
            //}
            //catch
            //{
            //}




            return Result.Succeeded;
        }
    }
}
