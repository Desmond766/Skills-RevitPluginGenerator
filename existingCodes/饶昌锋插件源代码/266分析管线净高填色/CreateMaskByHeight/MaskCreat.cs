using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CreateMaskByHeight
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public static class MaskCreat
    {
        public static Dictionary<ElementId, double> Creat(UIDocument uidoc, Floor floor, int minValue, int maxValue,ref Document linkDocs)
        {
            Document doc = uidoc.Document;

            View3D view3D = Utils.set3D(doc);
            //获取楼板
            //FloorFilter floorFilter = new FloorFilter();
            //Reference reference = uidoc.Selection.PickObject(ObjectType.Element, floorFilter);
            //Floor floor = doc.GetElement(reference) as Floor;
            //楼板几何
            GeometryElement geometryElement = floor.get_Geometry(new Options());
            GeometryObject topFace = null;
            //获取楼板顶面
            foreach (GeometryObject geometryObject in geometryElement)
            {
                if (geometryObject is Solid)
                {
                    Solid solid1 = geometryObject as Solid;
                    foreach (Face face in solid1.Faces)
                    {
                        if (face is CylindricalFace)
                        {
                            CylindricalFace cylindricalFace = face as CylindricalFace;
                            if (cylindricalFace.Axis.Z > 0)
                            {
                                topFace = face;
                                break;
                            }
                        }
                        if(face is PlanarFace) 
                        {
                            PlanarFace planarFace = face as PlanarFace;
                            if (planarFace.FaceNormal.Z > 0)
                            {
                                topFace = face;
                                break;
                            }
                        }
                       
                    }
                    if (topFace != null)
                    {
                        break;
                    }
                }
            }
            Face newTopFace = topFace as Face;
            //获取顶面的线

            List<FloorLoops> floorLoops = new List<FloorLoops>();
            foreach (EdgeArray edgeArray in newTopFace.EdgeLoops)
            {

                List<CurveLoop> loops1 = new List<CurveLoop>();
                List<Curve> curveList = new List<Curve>();
                foreach (Edge edge in edgeArray)
                {
                    Curve curve = edge.AsCurve();
                    //using (Transaction tran = new Transaction(doc, "Asda"))
                    //{
                    //    tran.Start();
                    //    Utils.CreateModelLine(doc, curve.GetEndPoint(0), curve.GetEndPoint(1));

                    //    tran.Commit();
                    //}
                    curveList.Add(curve);
                }
                CurveLoop curveLoop = CurveLoop.Create(curveList);
                //MessageBox.Show("Asdasd");
                loops1.Add(curveLoop);
                floorLoops.Add(new FloorLoops() { LoopsList = loops1 });
            }
            IList<Solid> solids = new List<Solid>();
            //放样 创建solid


            foreach (FloorLoops item in floorLoops)
            {
                Solid solid = GeometryCreationUtilities.CreateExtrusionGeometry(item.LoopsList, XYZ.BasisZ, 6000 / 304.8);
                solids.Add(solid);
            }


            //若只有一个 直接获取 则获取与其他的不想交的地方
            Solid finallySolid = solids.First();
            if (floorLoops.Count > 1)
            {
                for (int i = 1; i < floorLoops.Count; i++)
                {
                    finallySolid = BooleanOperationsUtils.ExecuteBooleanOperation(finallySolid, solids[i], BooleanOperationsType.Difference);
                }
            }
            //获取链接模型
            RevitLinkInstance revitLink = Utils.GetRevitLinks(doc).FirstOrDefault();
            Transform tf = revitLink.GetTotalTransform();
            //碰撞检测，房间里面的管道



            Document linkDoc = revitLink.GetLinkDocument();
            linkDocs = linkDoc;
            //FilteredElementCollector collector2 = new FilteredElementCollector(linkDoc);

            //List<Element> pipes = new List<Element>();


            List<ElementFilter> elementFilters = new List<ElementFilter>();//过滤器种类
            ElementCategoryFilter catFilter1 = new ElementCategoryFilter(BuiltInCategory.OST_DuctCurves);
            ElementCategoryFilter catFilter2 = new ElementCategoryFilter(BuiltInCategory.OST_CableTray);
            ElementCategoryFilter catFilter3 = new ElementCategoryFilter(BuiltInCategory.OST_PipeCurves);
            elementFilters.Add(catFilter1);
            elementFilters.Add(catFilter2);
            elementFilters.Add(catFilter3);

            LogicalOrFilter logicalOrFilter = new LogicalOrFilter(elementFilters);






            //collector2.WherePasses(logicalOrFilter);


            //pipes = collector2.ToList();
            List<Element> pipes1 = Utils.LinkElementIntersetSolid(SolidUtils.CreateTransformed(finallySolid, tf.Inverse), Utils.GetLinkPipe(revitLink, logicalOrFilter));

            //MessageBox.Show(pipes1.Count.ToString());
            List<Row_attr> list = new List<Row_attr>();
            double row_height = 0;
            foreach (MEPCurve item in pipes1)
            {
                //MessageBox.Show("as");
                XYZ center3 = null;
                XYZ tPoint1 = null;
                XYZ tPoint2 = null;


                if (Utils.CheckVertical(doc, item)) { continue; }//排除竖管
                LocationCurve locationCureve = item.Location as LocationCurve;
                //构件链接模型坐标轴转换
                Curve curve = locationCureve.Curve;
                XYZ start = curve.GetEndPoint(0);
                XYZ end = curve.GetEndPoint(1);
                tPoint1 = tf.OfPoint(start);
                tPoint2 = tf.OfPoint(end);
                center3 = (start + end) / 2;

                XYZ rayDirection4 = new XYZ(0, 0, -1);//向下的法向量

                List<ElementFilter> elementFilters2 = new List<ElementFilter>();//*过滤器种类OST_Floors
                ElementCategoryFilter catFilter72 = new ElementCategoryFilter(BuiltInCategory.OST_Floors);
                elementFilters2.Add(catFilter72);
                ReferenceWithContext refWithContexts2 = Utils.Ray(view3D, rayDirection4, center3, elementFilters2);
                if (refWithContexts2 != null)
                {
                    Reference refe2 = refWithContexts2.GetReference();
                    Element hitElement = doc.GetElement(refe2);
                    row_height = (refe2.GlobalPoint.DistanceTo(center3) - item.ParameterHeight()) * 304.8 - 100;
                    Row_attr pro8 = new Row_attr() { eid = item.Id, row_height = row_height, ename = item.Name, center_point = center3, end_point = refe2.GlobalPoint, start_p = tPoint1, end_p = tPoint2 };
                    list.Add(pro8);
                    //doc.NewTransaction("Asdasd", () => {
                    //    Utils.CreateModelLine(doc, center3, refe2.GlobalPoint);
                    //});
                }
            }
            var sumResult = from s1 in list orderby s1.row_height ascending select s1;
            var bb = sumResult.Take(1);
            if (bb.Count() != 0)
            {
                row_height = bb.FirstOrDefault().row_height;
            }
            if ((topFace as PlanarFace).FaceNormal.Z != 1)
            {
                row_height = -row_height;
            }

            //MessageBox.Show(row_height.ToString());


            //创建填充区域

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            List<FilledRegionType> lstFilledRegionType = collector.OfClass(typeof(FilledRegionType)).Cast<FilledRegionType>().ToList();
            FilledRegionType filledRegionType = null;
            //MessageBox.Show(lstFilledRegionType.Count.ToString());
            bool flag = false;

            string colorName = row_height.GetMarkColorName(minValue, maxValue);
            foreach (FilledRegionType item in lstFilledRegionType)
            {
                //MessageBox.Show(item.Name);
                if (item.Name == colorName)
                {
                    filledRegionType = item;
                    flag = true;
                }
            }
            if (!flag)
            {
                filledRegionType = lstFilledRegionType.First().Duplicate(colorName) as FilledRegionType;
            }
            //MessageBox.Show(row_height.GetMarkColorName()+" "+row_height.GetMarkColorName().GetMarkColor().ToString());
            IList<CurveLoop> loops = new List<CurveLoop>();
            foreach (EdgeArray edgeArray in newTopFace.EdgeLoops)
            {
                List<Curve> curveList = new List<Curve>();
                foreach (Edge edge in edgeArray)
                {
                    Curve curve = edge.AsCurve();
                    curveList.Add(curve);
                }
                CurveLoop curveLoop = CurveLoop.Create(curveList);
                loops.Add(curveLoop);
            }
            filledRegionType.ForegroundPatternColor = colorName.GetMarkColor();
            //填充图案
            FilteredElementCollector patternCollector = new FilteredElementCollector(doc);
            ICollection<Element> fillPatterns = patternCollector.OfClass(typeof(FillPatternElement)).ToElements();
            foreach (Element patternElement in fillPatterns)
            {
                FillPatternElement fillPattern = patternElement as FillPatternElement;

                // 根据图案名称或其他属性来判断是否为目标图案
                if (fillPattern.Name.Equals("<实体填充>"))
                {
                    // 将填充图案应用于填充区域类型
                    filledRegionType.ForegroundPatternId = fillPattern.Id;

                    break;
                }
            }
            FilledRegion.Create(doc, filledRegionType.Id, uidoc.ActiveView.Id, loops);
            if (bb.Count() != 0)
            {
                return new Dictionary<ElementId, double>() { { bb.First().eid, row_height } };
            }
            return null;
        }


        public static double ParameterHeight(this MEPCurve mEPCurve)
        {
            double width = 0;
            if (mEPCurve.Category.Id.ToString() == "-2008000")
            {
                try { width = mEPCurve.get_Parameter(BuiltInParameter.RBS_CURVE_HEIGHT_PARAM).AsDouble() / 2; } catch { width = mEPCurve.get_Parameter(BuiltInParameter.RBS_CURVE_DIAMETER_PARAM).AsDouble() / 2; }
            }
            if (mEPCurve.Category.Id.ToString() == "-2008044")
            {
                width = mEPCurve.get_Parameter(BuiltInParameter.RBS_PIPE_DIAMETER_PARAM).AsDouble() / 2;
            }
            if (mEPCurve.Category.Id.ToString() == "-2008130")
            {
                width = mEPCurve.get_Parameter(BuiltInParameter.RBS_CABLETRAY_HEIGHT_PARAM).AsDouble() / 2;
            }
            return width;
        }
    }
}

