using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.Attributes;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ArrangeHangerAccordingToNozzle
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        //int count3 = 0;
        UIDocument uIDoc = null;
        Document doc = null;
        View3D view3D = null;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {

            uIDoc = commandData.Application.ActiveUIDocument;
            doc = uIDoc.Document;
            //判断视图
            if (!(doc.ActiveView is ViewPlan))
            {
                TaskDialog.Show("提示", "请在平面视图中运行插件！");
                return Result.Cancelled;
            }

            View view = doc.ActiveView;

            //程序在3D 支吊架视图中完成
            //改为
            //先找当前视图 对应的3D视图， 找不到再用3D 支吊架，命名规则 3D {当前视图名称}
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

            IList<Reference> references = new List<Reference>();
            try
            {
                  references = uIDoc.Selection.PickObjects(Autodesk.Revit.UI.Selection.ObjectType.Element, new SprinklerFilter(), "框选喷头");
            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "已取消布置");
                return Result.Cancelled;
            }
            UserControl1 userControl1 = new UserControl1();
            userControl1.ShowDialog();
            if (userControl1.cancel)
            {
                return Result.Cancelled;
            }
            using (Transaction t = new Transaction(doc, "AddHanger"))
            {
                t.Start();
                foreach (Reference reference in references)
                {
                    FilteredElementCollector collector = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_PipeCurves).OfClass(typeof(Pipe));
                    FamilyInstance sprinkler = doc.GetElement(reference) as FamilyInstance;
                    XYZ p = (sprinkler.Location as LocationPoint).Point;
                    Line line1 = Line.CreateBound(new XYZ(p.X - 500 / 304.8, p.Y + 500 / 304.8, p.Z), new XYZ(p.X + 500 / 304.8, p.Y + 500 / 304.8, p.Z));
                    Line line2 = Line.CreateBound(new XYZ(p.X + 500 / 304.8, p.Y + 500 / 304.8, p.Z), new XYZ(p.X + 500 / 304.8, p.Y - 500 / 304.8, p.Z));
                    Line line3 = Line.CreateBound(new XYZ(p.X + 500 / 304.8, p.Y - 500 / 304.8, p.Z), new XYZ(p.X - 500 / 304.8, p.Y - 500 / 304.8, p.Z));
                    Line line4 = Line.CreateBound(new XYZ(p.X - 500 / 304.8, p.Y - 500 / 304.8, p.Z), new XYZ(p.X - 500 / 304.8, p.Y + 500 / 304.8, p.Z));
                    List<Curve> curveList = new List<Curve> { line1, line2, line3, line4 };
                    CurveLoop curveLoop = CurveLoop.Create(curveList);
                    IList<CurveLoop> curves = new List<CurveLoop> { curveLoop };
                    Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(curves, XYZ.BasisZ.Negate(), 1000 / 304.8);
                    List<Pipe> pipes = new List<Pipe>();
                    ElementIntersectsSolidFilter solidFilter = new ElementIntersectsSolidFilter(solid);
                    collector.WherePasses(solidFilter);
                    ////设置高亮
                    //uIDoc.Selection.SetElementIds(new Collection<ElementId> { new ElementId(3717283) });
                    ////聚焦元素
                    //uiApp.ActiveUIDocument.ShowElements(elementIds);
                    //uiApp.ActiveUIDocument.RefreshActiveView();
                    pipes = collector.Cast<Pipe>().ToList();
                    solid.Dispose();
                    collector.Dispose();
                    solidFilter.Dispose();
                    line1.Dispose();
                    line2.Dispose();
                    line3.Dispose();
                    line4.Dispose();
                    sprinkler.Dispose();
                    curveLoop.Dispose();
                    if (userControl1.value.Equals("上"))
                    {
                        Pipe pipe1 = null;
                        XYZ pipeP = null;
                        foreach (Pipe pipe in pipes)
                        {
                            pipeP = (pipe.Location as LocationCurve).Curve.GetEndPoint(0);
                            XYZ direction = (new XYZ(p.X, p.Y, 0) - new XYZ(pipeP.X, pipeP.Y, 0)).Normalize();
                            if (pipeP.Y - p.Y > 0.0001 && pipe.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() > 500/ 304.8 && (direction.IsAlmostEqualTo(XYZ.BasisY) || direction.IsAlmostEqualTo(XYZ.BasisY.Negate())))
                            {
                                pipe1 = pipe;
                                pipes.Remove(pipe1);
                                break;
                            }
                        }
                        if (pipe1 != null)
                        {
                            p = new XYZ(p.X, p.Y + 500 / 304.8, pipeP.Z);
                            AddHanger(p, XYZ.BasisY, pipe1);
                        }
                    }                    
                    if (userControl1.value.Equals("下"))
                    {
                        Pipe pipe1 = null;
                        XYZ pipeP = null;
                        foreach (Pipe pipe in pipes)
                        {
                            pipeP = (pipe.Location as LocationCurve).Curve.GetEndPoint(0);
                            XYZ direction = (new XYZ(p.X, p.Y, 0) - new XYZ(pipeP.X, pipeP.Y, 0)).Normalize();
                            if (pipeP.Y - p.Y < 0.0001 && pipe.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() > 500 / 304.8 && (direction.IsAlmostEqualTo(XYZ.BasisY) || direction.IsAlmostEqualTo(XYZ.BasisY.Negate())) )
                            {
                                pipe1 = pipe;
                                pipes.Remove(pipe1);
                                break;
                            }
                        }
                        if (pipe1 != null)
                        {
                            p = new XYZ(p.X, p.Y - 500 / 304.8, pipeP.Z);
                            AddHanger(p, XYZ.BasisY.Negate(), pipe1);
                        }
                    }                    
                    if (userControl1.value.Equals("左"))
                    {
                        Pipe pipe1 = null;
                        XYZ pipeP = null;
                        foreach (Pipe pipe in pipes)
                        {
                            pipeP = (pipe.Location as LocationCurve).Curve.GetEndPoint(0);
                            XYZ direction = (new XYZ(p.X, p.Y, 0) - new XYZ(pipeP.X, pipeP.Y, 0)).Normalize();
                            if (pipeP.X - p.X < 0.0001 && pipe.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() > 500 / 304.8 && (direction.IsAlmostEqualTo(XYZ.BasisX) || direction.IsAlmostEqualTo(XYZ.BasisX.Negate())))
                            {
                                pipe1 = pipe;
                                pipes.Remove(pipe1);
                                break;
                            }
                        }
                        if (pipe1 != null)
                        {
                            p = new XYZ(p.X - 500 / 304.8, p.Y, pipeP.Z);
                            AddHanger(p, XYZ.BasisX.Negate(), pipe1);
                        }
                    }                    
                    if (userControl1.value.Equals("右"))
                    {
                        Pipe pipe1 = null;
                        XYZ pipeP = null;
                        foreach (Pipe pipe in pipes)
                        {
                            pipeP = (pipe.Location as LocationCurve).Curve.GetEndPoint(0);
                            XYZ direction = (new XYZ(p.X, p.Y, 0) - new XYZ(pipeP.X, pipeP.Y, 0)).Normalize();
                            if (pipeP.X - p.X > 0.0001 && pipe.get_Parameter(BuiltInParameter.CURVE_ELEM_LENGTH).AsDouble() > 500 / 304.8 && (direction.IsAlmostEqualTo(XYZ.BasisX) || direction.IsAlmostEqualTo(XYZ.BasisX.Negate())))
                            {
                                pipe1 = pipe;
                                pipes.Remove(pipe1);
                                break;
                            }
                        }
                        if (pipe1 != null)
                        {
                            p = new XYZ(p.X + 500 / 304.8, p.Y, pipeP.Z);
                            AddHanger(p, XYZ.BasisX, pipe1);
                        }
                    }
                }
                t.Commit();
                t.Dispose();
                
            }
            return Result.Succeeded;
        }
        //添加吊架
        private void AddHanger(XYZ p,XYZ direction,Pipe pipe1)
        {
            FamilySymbol familySymbol1 = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).WhereElementIsElementType().Where(x => x.Name == "喷淋").First() as FamilySymbol;
            if (!familySymbol1.IsActive)
            {
                familySymbol1.Activate();
            }
            FamilySymbol familySymbol2 = new FilteredElementCollector(doc).OfClass(typeof(FamilySymbol)).WhereElementIsElementType().Where(x => x.Name == "照明和喷淋吊架-平行").First() as FamilySymbol;
            if (!familySymbol2.IsActive)
            {
                familySymbol2.Activate();
            }
            XYZ sxp1 = p;
            //获取吊架插入点到上楼板的距离
            double upFloorDistance = Utils.GetClearHeightUp(view3D, doc, sxp1);
            XYZ directionVector = direction;
            //获取旋转吊架需要的参数
            double angle = directionVector.AngleTo(XYZ.BasisX);
            Line axis = Line.CreateBound(sxp1, new XYZ(sxp1.X, sxp1.Y, 0));
            Pipe pipe = pipe1;
            //获取管道标高作为吊架的标高
            string levelName = pipe.get_Parameter(BuiltInParameter.RBS_START_LEVEL_PARAM).AsValueString();
            Level level = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Level)).WhereElementIsNotElementType().ToElements().Where(m => m.Name == levelName).ToList().FirstOrDefault() as Level;
            //判断下方有无桥架以使用不同的吊架
            ElementCategoryFilter elementCategoryFilter1 = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
            ReferenceIntersector referenceIntersector1 = new ReferenceIntersector(elementCategoryFilter1, FindReferenceTarget.All, view3D);
            ReferenceWithContext referenceWithContext1 = referenceIntersector1.FindNearest(sxp1, XYZ.BasisZ.Negate());
            bool name = true;
            if (referenceWithContext1 != null)
            {
                Reference reference = referenceWithContext1.GetReference();
                CableTray cableTray = doc.GetElement(reference) as CableTray;
                if (!cableTray.Name.Contains("照明线槽"))
                {
                    name = false;
                }
            }
            if (referenceWithContext1 == null || !name)
            {
                ///获取管道的直径和中间高程
                double diameter = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
                double middleElevation = pipe.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble();
                FamilyInstance familyInstance = doc.Create.NewFamilyInstance(sxp1, familySymbol1, level, StructuralType.NonStructural);
                familySymbol1.Dispose();
                //设置与楼板有关参数
                familyInstance.get_Parameter(BuiltInParameter.INSTANCE_FREE_HOST_OFFSET_PARAM).Set(0);
                familyInstance.LookupParameter("a_楼板底高").Set(middleElevation + upFloorDistance);
                //设置与管道有关参数
                familyInstance.LookupParameter("管道公称直径").Set(diameter);
                familyInstance.LookupParameter("管道中心标高").Set(middleElevation);
                //旋转吊架
                if (angle > 0.5 * Math.PI)
                {
                    angle = Math.PI - angle;
                }
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI - angle);
                Transform transform = familyInstance.GetTransform();

                if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(directionVector) - 0.5 * Math.PI) > 0.001)
                {
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (0.5 * Math.PI - angle));
                }
                familyInstance.Dispose();
            }
            else if (referenceWithContext1 != null && name)
            {
                //获取管道的直径和中间高程
                double diameter = pipe.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble();
                double middleElevation = pipe.get_Parameter(BuiltInParameter.RBS_END_OFFSET_PARAM).AsDouble();
                //获取找到的桥架的参数用以设置吊架参数
                Reference reference = referenceWithContext1.GetReference();
                CableTray cableTray = doc.GetElement(reference) as CableTray;
                //获取桥架的底标高和宽度
                double lowLevel = cableTray.get_Parameter(BuiltInParameter.RBS_CTC_BOTTOM_ELEVATION).AsDouble();
                double width = cableTray.get_Parameter(BuiltInParameter.RBS_CABLETRAY_WIDTH_PARAM).AsDouble();
                FamilyInstance familyInstance = doc.Create.NewFamilyInstance(sxp1, familySymbol2, level, StructuralType.NonStructural);
                familySymbol2.Dispose();
                //设置布置吊架的参数
                //设置与楼板有关参数
                familyInstance.get_Parameter(BuiltInParameter.INSTANCE_FREE_HOST_OFFSET_PARAM).Set(0);
                familyInstance.LookupParameter("a_楼板底高").Set(middleElevation + upFloorDistance);
                //设置与管道有关参数
                familyInstance.LookupParameter("管道公称直径").Set(diameter);
                familyInstance.LookupParameter("管道中心标高").Set(middleElevation);
                //设置与桥架有关参数
                familyInstance.LookupParameter("桥架底标高").Set(lowLevel);
                familyInstance.LookupParameter("吊架套筒长度").Set(width);
                //旋转吊架
                if (angle > 0.5 * Math.PI)
                {
                    angle = Math.PI - angle;
                }
                ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, 0.5 * Math.PI - angle);
                Transform transform = familyInstance.GetTransform();

                if (Math.Abs(transform.OfVector(XYZ.BasisX).AngleTo(directionVector) - 0.5 * Math.PI) > 0.001)
                {
                    ElementTransformUtils.RotateElement(doc, familyInstance.Id, axis, -2 * (0.5 * Math.PI - angle));
                }
                familyInstance.Dispose();
            }
        }

    }
}
