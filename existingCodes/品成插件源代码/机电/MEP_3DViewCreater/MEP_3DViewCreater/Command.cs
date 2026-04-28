using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using System.IO;
using System.Windows.Forms;

namespace MEP_3DViewCreater
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {

        //剖面视图list         listSectionView
        //剖面视图名称list      listSectionViewStr
        public static List<Autodesk.Revit.DB.View> listSectionView = new List<Autodesk.Revit.DB.View>();
        public static List<string> listSectionViewStr = new List<string>();

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            #region 判断加密

            //注册验证
            string licFile = string.Format("{0}\\Key.lic",
    System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
            if (!BTAddInHelper.Utils.CheckReg(licFile))
            {
                return Result.Cancelled;
            }

            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;

            //收集项目中所有视图      listAllviews
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            IList<Element> listAllviews = collector.OfClass(typeof(Autodesk.Revit.DB.View)).ToElements();

            //收集项目中所有剖面视图
            foreach (Element ele in listAllviews)
            {
                Autodesk.Revit.DB.View view = ele as Autodesk.Revit.DB.View;
                if (view != null)
                {
                    if (view.ViewType == ViewType.Section)
                    {
                        if (view.ViewName != null)
                        {
                            listSectionView.Add(view);
                            listSectionViewStr.Add(view.ViewName);
                        }
                    }
                }
            }

            //弹出对话框，收集要生成局部三维的剖面
            using (SettingForm sf = new SettingForm())
            {
                if (DialogResult.OK != sf.ShowDialog())
                {
                    return Result.Failed;
                }
            }

            //已收集到用户勾选的要生成三维的剖面名称，在所有剖面中找到用户勾选的这些名称的剖面
            //实际要生成局部三维的剖面的范围框 list     listBox

            List<Autodesk.Revit.DB.View> list = new List<Autodesk.Revit.DB.View>();
            foreach (var item in listSectionView)
            {
                foreach (var itemStr in listSectionViewStr)
                {
                    if (item.ViewName == itemStr)
                    {
                        list.Add(item);
                    }
                }
            }

            //提醒已经存在的局部三维,在listBox中去除
            //收集项目中所有三维视图
            List<Autodesk.Revit.DB.View> list3DView = new List<Autodesk.Revit.DB.View>();
            foreach (Element ele in listAllviews)
            {
                Autodesk.Revit.DB.View view = ele as Autodesk.Revit.DB.View;
                if (view != null)
                {
                    if (view.ViewType == ViewType.ThreeD)
                    {
                        if (view.ViewName != null)
                        {
                            list3DView.Add(view);
                        }
                    }
                }
            }

            //已存在三维的剖面list  listDeleSec
            List<Autodesk.Revit.DB.View> listDeleSec = new List<Autodesk.Revit.DB.View>();
            string s = "以下局部三维已存在：";
            foreach (var viewSec in list)
            {
                foreach (var view3D in list3DView)
                {
                    if (view3D.ViewName == viewSec.ViewName + "-局部三维")
                    {
                        listDeleSec.Add(viewSec);
                        s += "\n" + viewSec.ViewName + "-局部三维";
                    }
                }
            }
            foreach (var item in listDeleSec)
            {
                list.Remove(item);
            }

            //创建局部三维
            ViewFamilyType viewFamilyType = (from v in new FilteredElementCollector(doc).OfClass(typeof(ViewFamilyType)).Cast<ViewFamilyType>()
                                             where v.ViewFamily == ViewFamily.ThreeDimensional
                                             select v).First();

            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            //Timer time = new Timer();
            //time.Start();
            watch.Start();//开始计时

            using (Transaction t = new Transaction(doc, "SetSectionBox"))
            {
                t.Start();


                foreach (var item in list)
                {
                    BoundingBoxXYZ cropBox = item.CropBox;
                    if (cropBox != null)
                    {
                        XYZ ma = new XYZ(cropBox.Max.X, cropBox.Max.Y, cropBox.Max.X+10);
                        XYZ mi = new XYZ(cropBox.Min.X, cropBox.Min.Y, cropBox.Min.X-10);
                        BoundingBoxXYZ newBox = new BoundingBoxXYZ();
                        newBox.Max = ma;
                        newBox.Min = mi;
                        newBox.Transform = cropBox.Transform;

                        //TaskDialog.Show("a", cropBox.Max.ToString() + "\n" + cropBox.Min.ToString());
                        View3D view3D = View3D.CreateIsometric(doc, viewFamilyType.Id);//创建三维
                        view3D.get_Parameter(BuiltInParameter.VIEW_NAME).Set(item.ViewName + "-局部三维");//命名
                        view3D.SetSectionBox(newBox);//剖面框

                        view3D.DetailLevel = ViewDetailLevel.Fine;//精细
                        view3D.DisplayStyle = DisplayStyle.ShadingWithEdges;//着色

                        //TaskDialog.Show("a", box.Max.ToString() + "\n"+box.Min.ToString()); 
                    }

                }
                t.Commit();
            }

            watch.Stop();//停止计时
            //time.Stop();

            //弹出提示
            if (listDeleSec.Count == 0)
            {
                TaskDialog.Show("提示", "新生成局部三维" + list.Count.ToString() + "张" + "\n" + "耗时:" + watch.Elapsed.Seconds + "秒");
            }
            else
            {
                TaskDialog.Show("提示", s + "\n" + "新生成局部三维" + list.Count.ToString() + "张" + "\n" + "耗时:" + watch.Elapsed.Seconds + "秒");
            }
            return Result.Succeeded;
        }
    }
}
