using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddHanger4GY
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
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
            Reference ref_mep1 = null;
            Reference ref_mep2 = null;
            Reference ref_Hanger = null;

            //选择吊架进行参考布置———————————————————————————————————————————————————————————————————————————————————
            ref_Hanger = selection.PickObject(ObjectType.Element,new SelectionFilter4MechEquip(), "请选择要布置的吊架");
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

                    using (Transaction t = new Transaction(doc, "Add Hanger"))
                    {
                        t.Start();

                        ref_mep1 = selection.PickObject(ObjectType.Element,new SelectionFilter4MEPCurve(), "点击管线进行布置");
                        Element mep1 = doc.GetElement(ref_mep1);
                        ref_mep2 = selection.PickObject(ObjectType.Element, new SelectionFilter4MEPCurve(), "点击管线进行布置");
                        Element mep2 = doc.GetElement(ref_mep2);
                        XYZ location = selection.PickPoint();

                        // REMARK：25.12.18获取所有Mpe中最低高度
                        MEPCurve minMep = GetMinHeightMEP(doc, mep1, mep2, location);

                        ResolverForGY resolverForGY = new ResolverForGY(commandData);
                        resolverForGY.Resolve(view3D, hanger, mep1, mep2, location, minMep);
                        
                        
                        

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

        private MEPCurve GetMinHeightMEP(Document doc, Element mep1, Element mep2, XYZ location)
        {
            if (mep1.Id == mep2.Id) return mep1 as MEPCurve;

            MEPCurve mepCurve1 = mep1 as MEPCurve;
            Line mepLine1 = (mepCurve1.Location as LocationCurve).Curve as Line;
            MEPCurve mepCurve2 = mep2 as MEPCurve;
            Line mepLine2 = (mepCurve2.Location as LocationCurve).Curve as Line;
            //拾取点与MEP1中线交点
            IntersectionResult iResult1 = mepLine1.Project(location);
            XYZ p1 = iResult1.XYZPoint;
            //拾取点与MEP2中线交点
            IntersectionResult iResult2 = mepLine2.Project(location);
            XYZ p2 = iResult2.XYZPoint;
            //修正两点的Z值
            p2 = new XYZ(p2.X, p2.Y, p1.Z);

            //放样
            List<CurveLoop> loops = new List<CurveLoop>();
            XYZ p3 = p2 - XYZ.BasisZ * (100 / 304.8);
            XYZ p4 = p3 - (p2 - p1).Normalize() * (100 / 304.8);
            List<Curve> curveList = new List<Curve> { Line.CreateBound(p1, p2), Line.CreateBound(p2, p3), Line.CreateBound(p3, p4), Line.CreateBound(p4, p1) };
            CurveLoop curveLoop = CurveLoop.Create(curveList);
            loops.Add(curveLoop);
            //拉伸
            Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(loops, (p2 - p1).Normalize().CrossProduct((p3 - p2).Normalize()), 100 / 304.8);
            ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);

            ElementMulticategoryFilter multicategoryFilter = new ElementMulticategoryFilter(new List<BuiltInCategory>() { BuiltInCategory.OST_CableTray, BuiltInCategory.OST_DuctCurves, BuiltInCategory.OST_PipeCurves, BuiltInCategory.OST_Conduit });

            XYZ min = new XYZ(Math.Min(p1.X, p2.X), Math.Min(p1.Y, p2.Y), Math.Min(p1.Z, p2.Z) - 200 / 304.8);
            XYZ max = new XYZ(Math.Max(p1.X, p2.X), Math.Max(p1.Y, p2.Y), Math.Max(p1.Z, p2.Z) + 200 / 304.8);
            BoundingBoxIntersectsFilter intersectsFilter = new BoundingBoxIntersectsFilter(new Outline(min, max));


            var meps = new FilteredElementCollector(doc, doc.ActiveView.Id).WherePasses(multicategoryFilter).WherePasses(intersectsFilter).WherePasses(solidFilter).Where(m => GetLine(m).Direction.IsAlmostEqualTo(mepLine1.Direction) || GetLine(m).Direction.IsAlmostEqualTo(mepLine1.Direction.Negate()));

            MEPCurve result = null;
            if (meps.Count() > 0) result = meps.OrderBy(m => m.get_BoundingBox(doc.ActiveView).Min.Z).First() as MEPCurve;
            return result;
        }
        private Line GetLine(Element element)
        {
            return (element.Location as LocationCurve).Curve as Line;
        }
    }
}
