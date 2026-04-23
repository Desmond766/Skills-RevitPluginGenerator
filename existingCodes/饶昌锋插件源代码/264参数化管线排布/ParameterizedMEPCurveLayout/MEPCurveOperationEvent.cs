using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ParameterizedMEPCurveLayout
{
    public class MEPCurveOperationEvent : IExternalEventHandler
    {
        public IList<MEPCurve> mEPCurves { get; set; }
        public int sheetIndex { get; set; }
        public string structDistance { get; set; }
        public void Execute(UIApplication app)
        {
            //TaskDialog.Show("sadas", "已执行MEPCurveOperationEvent");
            //排序
            Document doc = app.ActiveUIDocument.Document;
            try { MEPCurveOperation.MEPCurveGroupSort(doc, mEPCurves, sheetIndex); } catch(Exception ex) { MessageBox.Show(ex.ToString()); }
           
            //创建剖面
            ViewSection sectionView = ProfileFrame.Create(doc, mEPCurves, structDistance);
            //打开剖面
            UIDocument uidoc = app.ActiveUIDocument;
            uidoc.ActiveView = sectionView;
            GroupAndWrap.MEPWraping(doc, mEPCurves, int.Parse(structDistance));
            Document sectionViewDoc = uidoc.Document;
            //只显示指定图元
            try
            {
                using (Transaction tran = new Transaction(sectionViewDoc, "Hide and Show Elements"))
                {
                    tran.Start("Hide and Show Elements");

                    // 隐藏视图中的所有元素
                    FilteredElementCollector collector = new FilteredElementCollector(sectionViewDoc, sectionView.Id);
                    ICollection<ElementId> allElementsInView = collector.ToElementIds();
                    // 显示指定的元素
                    List<ElementId> elementToShow = mEPCurves.Select(e => e.Id).ToList();
                    List<ElementId> hiddenElem = allElementsInView.Except(elementToShow).ToList();
                    foreach (ElementId item in hiddenElem)
                    {
                        Element elem = doc.GetElement(item);
                        Type type = elem.GetType();
                        if ((doc.GetElement(elem.GetTypeId()) as ViewFamilyType)?.ViewFamily.ToString() == "Section" || elem is Level)
                        {
                            continue;
                        }
                        if (elem.CanBeHidden(sectionView))
                        {
                            sectionView.HideElements(new List<ElementId> { item});
                        }
                    }
                    //elementToShow.Add(sectionView.Id);
                    //sectionView.UnhideElements(elementToShow);
                    // 提交事务
                    tran.Commit();
                }
            }
            catch (Exception ex) { TaskDialog.Show("提示", ex.ToString()); }

        }

        public string GetName()
        {
            return "";
        }
    }
}
