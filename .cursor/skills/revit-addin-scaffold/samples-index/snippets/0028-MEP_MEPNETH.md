# Sample Snippet: MEP_MEPNETH

Source project: `existingCodes\品成插件源代码\机电\MEP_MEPNETH\MEP_MEPNETH`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
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

// ... truncated ...
```

## Utils.cs

```csharp
using System;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.UI;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEP_MEPNETH
{
    class Utils
    {
        #region 获得管线净高 考虑高低板
        public static double GetClearHeight(View3D view, Document doc, XYZ point_Do)
        {
            double distance = 0.0;
            //梁的计算点point_Do 

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);


            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());



            Reference r2 = referenceWithContext.GetReference();

            if (null != r2)
            {
                List<ElementFilter> filterList1 = new List<ElementFilter>();
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves));
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_CableTray));
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves));
                LogicalOrFilter structuralFraming = new LogicalOrFilter(filterList1);
                //相交
                ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(structuralFraming, FindReferenceTarget.All, view);
                referenceIntersector1.FindReferencesInRevitLinks = true;

                ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(r2.GlobalPoint, XYZ.BasisZ);
                Reference r3 = referenceWithContext1.GetReference();
                distance = r3.GlobalPoint.DistanceTo(r2.GlobalPoint) * 304.8;
            }
            else
            {
                TaskDialog.Show("报错原因", "放射方法r2为空");
            }
            return Math.Round(distance, 0);

        }
        #endregion


        #region 得到Z 小的点

        public static XYZ GetMinZPoint(XYZ point1, XYZ point2)
        {
            double d = point1.Z - point2.Z;
            if (d > 0)
            {
                return point2;
            }
            else
            {
                return point1;
            }


        }
        #endregion


    }
}

```

