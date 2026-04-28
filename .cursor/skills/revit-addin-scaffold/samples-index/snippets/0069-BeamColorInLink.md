# Sample Snippet: BeamColorInLink

Source project: `existingCodes\品成插件源代码\通用\BeamColorInLink\BeamColorInLink`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
//20171106
//添加新的加密方式
//20171115
//添加新的加密方式
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;

using Autodesk.Revit.DB.Mechanical;
using System.Xml;
using Autodesk.Revit.UI.Events;
using System.IO;
using System.Windows.Forms;
using RevitUtils;
using Autodesk.Revit.Exceptions;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;

namespace BeamColorInLink
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public bool _isShowBeamSize = true;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
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
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            ElementId viewId = doc.ActiveView.Id;

            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Cancelled;
            }
            _isShowBeamSize = sf.IsShowBeamSize;

            ListenUtils listenUtils = new ListenUtils();
            //【1】框选，过滤出梁
            #region 【1】框选，过滤出梁
            IList<Reference> iList;//选取到的链接构件集合
            // UPDATE:26.2.3框选后可按空格键完成框选
            try
            {
                listenUtils.startListen();
                iList = sel.PickObjects(ObjectType.LinkedElement, new LinkBeamFilter(doc), "框选连接构件集合（按空格键完成框选，ESC键取消）");//选取到的链接构件集合
                listenUtils.stopListen();
            }
            catch (OperationCanceledException)
            {
                listenUtils.stopListen();
                return Result.Cancelled;
            }
            List<FamilyInstance> beamList = new List<FamilyInstance>();//链接梁集合

            int beamnum_Y = 0;
            int beamnum_N = 0;
            foreach (Reference item in iList)
            {
                RevitLinkInstance linkIns = doc.GetElement(item) as RevitLinkInstance;
                Element elem = linkIns.GetLinkDocument().GetElement(item.LinkedElementId);//得到链接构件
                FamilyInstance f = elem as FamilyInstance;
                try
                {
                    if (f.Category.Id.IntegerValue == (int)BuiltInCategory.OST_StructuralFraming)
                    {
                        beamList.Add(f);
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

namespace BeamColorInLink
{
    class Utils
    {

        #region 获得梁底净高 考虑高低板
        public static double GetBeamClearHeight(Document doc, FamilyInstance f)
        {

            LocationCurve beamLocationCurve = f.Location as LocationCurve;
            Line beamLine = beamLocationCurve.Curve as Line;
            XYZ point1 = beamLine.GetEndPoint(0);
            XYZ point2 = beamLine.GetEndPoint(1);
            //梁的计算点point_Do 
            XYZ point_Up = new XYZ((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);
            BoundingBoxXYZ beamBoundingBox = f.get_BoundingBox(doc.ActiveView);
            XYZ point = new XYZ(point_Up.X, point_Up.Y, (beamBoundingBox.Min).Z);
            XYZ point_Do = new XYZ(point_Up.X, point_Up.Y, point.Z - (1000 / 304.8));//减1000是为了防止梁交叉位置刚好是梁中点时，向下反射找到交叉的梁


            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);

            View3D view = doc.ActiveView as View3D;
            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point_Do, XYZ.BasisZ.Negate());
            double distance = 0.0;

            Reference r2 = referenceWithContext.GetReference();

            if (null != r2)
            {
                List<ElementFilter> filterList1 = new List<ElementFilter>();
                filterList1.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFraming));
                LogicalOrFilter structuralFraming = new LogicalOrFilter(filterList1);
                //相交
                ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(structuralFraming, FindReferenceTarget.All, view);
                referenceIntersector1.FindReferencesInRevitLinks = true;

                ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(r2.GlobalPoint, XYZ.BasisZ);
                Reference r3 = referenceWithContext1.GetReference();
                distance = r3.GlobalPoint.DistanceTo(r2.GlobalPoint) * 304.8;

            }
            return Math.Round(distance, 0);

        }
        #endregion

        #region 获得梁底净高 考虑高低板（304）
        //public static double GetBeamClearHeight(Document doc, FamilyInstance f)
        //{

        //    LocationCurve beamLocationCurve = f.Location as LocationCurve;
        //    Line beamLine = beamLocationCurve.Curve as Line;
        //    XYZ point1 = beamLine.GetEndPoint(0);
        //    XYZ point2 = beamLine.GetEndPoint(1);
        //    //梁的中点
        //    XYZ point = new XYZ((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);


        //    List<ElementFilter> filterList = new List<ElementFilter>();
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_StructuralFoundation));
        //    filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

        //    LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);

        //    View3D view = doc.ActiveView as View3D;
// ... truncated ...
```

