using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using System.Windows.Forms;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace MEP_MEPNETH
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        #region 声明字段和属性
        public static double d = 1000;
        #endregion

        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
           
            
           
            //View view = doc.ActiveView;
            ElementId viewId = doc.ActiveView.Id;

            View3D view3D = null;
            FilteredElementCollector fristCollector = new FilteredElementCollector(doc).OfClass(typeof(View3D));
            foreach (View3D view3 in fristCollector)
            {
                if ("3D 机电".Equals(view3.Name))
                {
                    view3D = view3;
                    break;
                }
            }


            //弹出对话框
            using (Form1 form = new Form1())
            {
                if (form.ShowDialog() != DialogResult.OK)
                {
                    return Result.Failed;
                }
            }

            //【1】框选，过滤出MEP管线，
            #region 【1】框选，过滤出MEP管线
            IList<Reference> iList;//选取到的构件集合

            RevitUtils.ListenUtils listenUtils = new RevitUtils.ListenUtils();
            try
            {
                listenUtils.startListen();
                iList = sel.PickObjects(ObjectType.Element, new MEPCurveSelectionFilter(), "选择机电管线（按空格键完成框选，ESC键取消）");
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }

            List<Element> mepList = new List<Element>();//MEP管线集合
            int beamnum_Y = 0;

            foreach (Reference item in iList)
            {
                Element elem = doc.GetElement(item);//得到构件
                mepList.Add(elem);
                //if (Math.Abs(elem.get_Parameter(BuiltInParameter.RBS_START_OFFSET_PARAM).AsDouble()
                //    - elem.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble()) < 10/304.8)//过滤掉立管
                //{
                //    mepList.Add(elem);
                //}
            }
            beamnum_Y = mepList.Count;

            #endregion
            //TaskDialog.Show("a", beamnum_Y.ToString());

            //【2】计算净高
            #region 【2】计算净高
            int num_Done = 0;
            int num_Pass = 0;
            Dictionary<Element, double> list = new Dictionary<Element, double>();
            List<double> heightList = new List<double>();
            //List<double> heightList = new List<double>();
            foreach (Element element in mepList)
            {
                Curve curve = ((element as MEPCurve).Location as LocationCurve).Curve;
                XYZ p = Utils.GetMinZPoint(curve.GetEndPoint(0), curve.GetEndPoint(1));

                try
                {
                    double height = Utils.GetClearHeight(view3D, doc, p);//计算净高
                    list.Add(element, height);
                    if (!heightList.Contains(height))
                    {
                        heightList.Add(height);
                    }

                }
                catch
                {
                    num_Pass += 1;
                    continue;
                }
            }
            num_Done = list.Count;

            heightList.Sort();
            //double  mindouble=heightList[0];
            
            //找到大于或等于输入值的最小净高
            List<double> workList = new List<double>();
            foreach (var item in heightList)
            {
                if (item>=d)
                {
                    workList.Add(item);
                }
            }
            workList.Sort();
            double mindouble = workList[0];

            //string info = "共计算" + beamnum_Y.ToString() + "根管线净高。" + "\n" + "成功计算" + num_Done.ToString() + "个，跳过" + num_Pass.ToString() +
            //    "个。\n" + "最低管道净高为：" + mindouble + "mm。";
            // + "最低的梁下净高为：" + heightList[0].ToString() + "mm。"
            //TaskDialog.Show("提示", info);

            List<Element> keyList = (from q in list
                                     where q.Value == mindouble
                                     select q.Key).ToList<Element>();
            TaskDialog.Show("净高分析", "最低管道净高为：" + mindouble + "mm。" + "\n" + "已选中该净高构件" + keyList.Count.ToString() + "个");

            List<ElementId> ids = new List<ElementId>() ;
            foreach (var item in keyList)
            {
                ids.Add(item.Id);
            }

            sel.SetElementIds(ids);

            ////【3】添加注释文字

            //using (Transaction t = new Transaction(doc, "标记管线净高"))
            //{
            //    t.Start();
            //    List<TextNote> textList = new List<TextNote>();
            //    foreach (KeyValuePair<Element, double> kv in list)
            //    {
            //        try
            //        {
            //            LocationCurve beamLocationCurve = kv.Key.Location as LocationCurve;
            //            Line beamLine = beamLocationCurve.Curve as Line;
            //            //文字插入的点
            //            XYZ point = (beamLine.GetEndPoint(0) + beamLine.GetEndPoint(1)) / 2;

            //            TextNoteOptions opts = new TextNoteOptions();
            //            opts.HorizontalAlignment = HorizontalTextAlignment.Center;
            //            opts.TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);

            //            TextNote tn = TextNote.Create(doc, viewId, point, kv.Value.ToString(), opts);



            //        }
            //        catch (Exception)
            //        {
            //            //
            //        }
            //    }

            //    t.Commit();
            //}



            #endregion






            return Result.Succeeded;
        }
    }
}
