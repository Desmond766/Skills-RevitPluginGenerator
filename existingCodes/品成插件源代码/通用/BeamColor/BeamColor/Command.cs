//20171106
//添加新的加密方式
//20171115
//添加新的加密方式

//2019.5.20不能离项目基点太远
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.Attributes;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace BeamColor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public bool _isShowBeamSize = true;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            #region 判断加密
            //注册验证
    //        string licFile = string.Format("{0}\\Key.lic",
    //System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location));
    //        if (!BTAddInHelper.Utils.CheckReg(licFile))
    //        {
    //            return Result.Cancelled;
    //        }

            #endregion

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            //Reference reference = sel.PickObject(ObjectType.Element);
            //FamilyInstance element = doc.GetElement(reference) as FamilyInstance;

            //double height2 = GetBeamClearHeight(doc, element);
            //TaskDialog.Show("ll", height2.ToString());
            //return Result.Succeeded;

            SettingForm sf = new SettingForm();
            if (DialogResult.OK != sf.ShowDialog())
            {
                return Result.Cancelled;
            }
            _isShowBeamSize = sf.IsShowBeamSize;

            //【1】交互模式，先选择，后执行外部程序:收集模型中所有梁
            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfCategory(BuiltInCategory.OST_StructuralFraming).OfClass(typeof(FamilyInstance));                         // TaskDialog.Show("r", collector.Count().ToString());

            //【2】计算所有梁的净高
            int num_Done = 0;
            int num_Pass = 0;
            Dictionary<FamilyInstance, double> list = new Dictionary<FamilyInstance, double>();
            List<double> heightList = new List<double>();
            List<BeamInfo> beamInfos = new List<BeamInfo>();
            foreach (FamilyInstance item in collector)
            {
                try
                {
                    double height = GetBeamClearHeight(doc, item);

                    list.Add(item, height);
                    if (!heightList.Contains(height))
                    {
                        heightList.Add(height);
                    }

                    double b = 0;
                    double h = 0;
                    FamilySymbol familySymbol = doc.GetElement(item.GetTypeId()) as FamilySymbol;
                    foreach (Parameter para in familySymbol.Parameters)
                    {
                        if (para.Definition.Name == "b") b = Convert.ToDouble(para.AsValueString());
                        if (para.Definition.Name == "h" || para.Definition.Name == "梁高" || para.Definition.Name == "高度") h = Convert.ToDouble(para.AsValueString());
                    }
                    if (height < sf.errorBeamHigh)
                    {
                        BeamInfo beamInfo = new BeamInfo() { B = b, H = h, BeamId = item.Id, BeamHigh = height };
                        beamInfos.Add(beamInfo);
                    }
                }
                catch
                {
                    num_Pass += 1;
                    continue;
                }

            }
            num_Done = list.Count;
            string info = "成功计算" + num_Done.ToString() + "个\n跳过" + num_Pass.ToString();
            TaskDialog.Show("提示", info);

            //【3】计算对应的RGB
            heightList.Sort();//排序
            //List<Color> RGBList = GetRGBList(heightList);
            //TaskDialog.Show("r", string.Join(";", heightList));
            //System.Windows.Clipboard.SetDataObject(string.Join(";", heightList));
            //【4】给梁赋予对应的颜色、在梁上写净高
            FilteredElementCollector fillPatternFilter = new FilteredElementCollector(doc);
            fillPatternFilter.OfClass(typeof(FillPatternElement));
            FillPatternElement fp = fillPatternFilter.First(m => (m as FillPatternElement).GetFillPattern().IsSolidFill) as FillPatternElement;

            using (Transaction t = new Transaction(doc, "给梁赋色写净高"))
            {
                t.Start();

                #region 创建对应的材质
                //List<ElementId> materialIds = new List<ElementId>();
                //Material materialnew = null;
                //string info = "";
                //int n = heightList.Count;
                //for (int i = 0; i < n; i++)
                //{
                //    double height = heightList[i];
                //    Color RGB = RGBList[i];
                //    info = "Beam梁底净高为" + height.ToString("0");
                //    ElementId idnew = Material.Create(doc, info);
                //    materialnew = doc.GetElement(idnew) as Material;
                //    materialnew.Color = RGB;
                //    materialIds.Add(idnew);
                //}
                #endregion

                foreach (KeyValuePair<FamilyInstance, double> kv in list)
                {
                    try
                    {

                        //由原来的GetRGBList 改为分段颜色
                        //2021-8-23 BY JL

                        //给梁赋予对应的颜色
                        //int index = heightList.IndexOf(kv.Value);
                        //Color color = RGBList[index];

                        Color color = GetColorByClearHeight(kv.Value, sf.errorBeamHigh);

                        OverrideGraphicSettings ogs = doc.ActiveView.GetElementOverrides(kv.Key.Id);
                        //ogs.SetProjectionFillPatternId(fp.Id);
                        //ogs.SetProjectionFillColor(color);
                        ogs.SetSurfaceForegroundPatternId(fp.Id);
                        ogs.SetSurfaceForegroundPatternColor(color);
                        doc.ActiveView.SetElementOverrides(kv.Key.Id, ogs);

                        //在梁上写净高
                        LocationCurve beamLocationCurve = kv.Key.Location as LocationCurve;
                        Line beamLine = beamLocationCurve.Curve as Line;
                        //XYZ point = (beamLine.GetEndPoint(0) + beamLine.GetEndPoint(1)) / 2;
                        XYZ point1 = beamLine.GetEndPoint(0);
                        XYZ point2 = beamLine.GetEndPoint(1);
                        //梁的中点
                        XYZ point = new XYZ((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);

                        //TaskDialog.Show("r", (point.X * 304.8).ToString() + "\n" + (point.Y * 304.8).ToString() + "\n" + (point.Z * 304.8).ToString());
                        //TaskDialog.Show("r", (XYZ.Zero.DistanceTo(point)* 304.8).ToString());

                        XYZ direction;
                        XYZ direction2;
                        if (beamLine.Direction.IsAlmostEqualTo(new XYZ(0, 1, 0)) || beamLine.Direction.IsAlmostEqualTo(new XYZ(0, -1, 0)))
                        {
                            direction = new XYZ(0, 1, 0);
                            direction2 = new XYZ(1, 0, 0);
                        }
                        else
                        {
                            direction = new XYZ(1, 0, 0);
                            direction2 = new XYZ(0, 1, 0);
                        }
                        //TextNote tn = doc.Create.NewTextNote(doc.ActiveView, point, direction, direction2, 0.05, TextAlignFlags.TEF_ALIGN_MIDDLE, kv.Value.ToString());
                        //ElementId id = new ElementId(1014166);
                        //var options = new TextNoteOptions() { TypeId = id };
                        //var options = new TextNoteOptions();
                        TextNoteOptions opts = new TextNoteOptions();
                        opts.HorizontalAlignment = HorizontalTextAlignment.Center;
                        opts.TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType);
                        string contextStr = "";
                        if (_isShowBeamSize)
                        {
                            contextStr = GetBeamSize2(kv.Key) + " BL+ " + kv.Value.ToString();
                        }
                        else
                        {
                            contextStr = kv.Value.ToString();
                        }
                        TextNote tn = TextNote.Create(doc, doc.ActiveView.Id, point, contextStr, opts);
                        MoveRotateToFit(doc, kv.Key, tn);

                    }
                    catch (Exception ex)
                    {
                        TaskDialog.Show("ex", ex.Message+ex.StackTrace);
                        break;
                    }
                }
                t.Commit();
            }
            ShowWindow showWindow = new ShowWindow();
            beamInfos = beamInfos.OrderBy(x => x.B).ThenBy(y => y.H).ThenBy(z => z.BeamHigh).ToList();
            showWindow.list.ItemsSource = beamInfos;
            showWindow.Title = $"不满足净高(<{sf.errorBeamHigh}mm)的梁";
            showWindow.Show();


            return Result.Succeeded;
        }

        /// <summary>
        /// 梁尺寸//2021-8-23 BY JL
        /// </summary>
        /// <param name="beamInst"></param>
        /// <returns></returns>
        private string GetBeamSize(FamilyInstance beamInst)
        {
            return beamInst.Name.Split('-').Last().Replace("*", "x");
        }

        private string GetBeamSize2(FamilyInstance beamInst)
        {
            string bstring = "";
            string hstring = "";
            foreach (Parameter p in beamInst.Symbol.Parameters)
            {
                if (p.Definition.Name == "b")
                {
                    bstring = p.AsValueString();
                }
                if (p.Definition.Name == "h")
                {
                    hstring = p.AsValueString();
                }
            }
            return bstring + "x" + hstring;
        }

        /// <summary>
        /// 旋转对齐//2021-8-23 BY JL
        /// </summary>
        /// <param name="beamInst"></param>
        /// <param name="tn"></param>
        private void MoveRotateToFit(Document doc, FamilyInstance beamInst, TextNote tn)
        {
            var curve = (beamInst.Location as LocationCurve).Curve;
            XYZ midPt = (curve.GetEndPoint(0) + curve.GetEndPoint(1)) / 2.0;
            XYZ beamDir = XYZ.Zero;
            if (curve is Line)
            {
                beamDir = (curve as Line).Direction.Normalize();
            }
            else
            {
                beamDir = (curve.GetEndPoint(0) - curve.GetEndPoint(1)).Normalize();
            }
            double angle = XYZ.BasisX.AngleTo(beamDir);
            var axis = Line.CreateBound(tn.Coord, tn.Coord + XYZ.BasisZ);

            //旋转
            if (angle > 0.0001)
            {
                // 利用XYZ.BasisX预旋转
                Transform tran = Transform.CreateRotation(XYZ.BasisZ, angle);
                XYZ preRotate = tran.OfVector(XYZ.BasisX);
                if (preRotate.IsAlmostEqualTo(beamDir)
                 || preRotate.IsAlmostEqualTo(beamDir.Negate()))
                {
                    ElementTransformUtils.RotateElement(
                    doc, tn.Id, axis, angle);
                }
                else
                {
                    ElementTransformUtils.RotateElement(
                    doc, tn.Id, axis, angle * -1.0);
                }
            }

            //移动
            ElementTransformUtils.MoveElement(
                doc, tn.Id, tn.UpDirection * 220.0 / 304.8);
        }

        #region 获得梁底净高 考虑高低板
        private double GetBeamClearHeight(Document doc, FamilyInstance f)
        {
            LocationCurve beamLocationCurve = f.Location as LocationCurve;
            Line beamLine = beamLocationCurve.Curve as Line;
            XYZ point1 = beamLine.GetEndPoint(0);
            XYZ point2 = beamLine.GetEndPoint(1);
            //梁的中点
            XYZ point = new XYZ((point1.X + point2.X) / 2, (point1.Y + point2.Y) / 2, (point1.Z + point2.Z) / 2);
            XYZ point3 = point - XYZ.BasisZ * 0.0001;
            //梁底面的中心点
            BoundingBoxXYZ box = f.get_BoundingBox(doc.ActiveView);
            XYZ newp = new XYZ(box.Max.X, box.Max.Y, box.Min.Z);
            XYZ center = box.Min.Add(newp).Multiply(0.5);

            List<ElementFilter> filterList = new List<ElementFilter>();
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Floors));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_Ceilings));
            filterList.Add(new ElementCategoryFilter(BuiltInCategory.OST_RvtLinks));

            LogicalOrFilter floorOrCeiling = new LogicalOrFilter(filterList);

            View3D view = doc.ActiveView as View3D;
            //相交
            ReferenceIntersector referenceIntersector = new ReferenceIntersector(floorOrCeiling, FindReferenceTarget.All, view);
            referenceIntersector.FindReferencesInRevitLinks = true;

            ReferenceWithContext referenceWithContext = referenceIntersector.FindNearest(point3, XYZ.BasisZ.Negate());
            Reference r2 = referenceWithContext.GetReference();

            double h = 0.0;
            foreach (Parameter p in f.Symbol.Parameters)
            {
                if (p.Definition.Name == "h" || p.Definition.Name == "梁高" || p.Definition.Name == "高度")
                {
                    h = double.Parse(p.AsValueString());
                    break;
                }
            }
            double h1 = 0.0;
            double h2 = 0.0;
            foreach (Parameter p in f.Parameters)
            {
                if (p.Definition.Name == "Z 轴偏移值")
                {
                    h1 = double.Parse(p.AsValueString());
                }
                if (p.Definition.Name == "Z 轴对正")
                {
                    if (p.AsValueString() == "顶")
                    {
                        h2 = h;
                    }
                    else if (p.AsValueString() == "底")
                    {
                        h2 = 0.0;
                    }
                    else
                    {
                        h2 = h / 2;
                    }
                }
            }

            double distance = r2.GlobalPoint.DistanceTo(point) * 304.8 + h1 - h2;
            return Math.Round(distance, 0);
        }
        #endregion

        #region 获得梁底净高
        //private double GetBeamClearHeight(Document doc, View3D view, FamilyInstance f)
        //{
        //    LocationCurve beamLocationCurve = f.Location as LocationCurve;
        //    Line beamLine = beamLocationCurve.Curve as Line;
        //    XYZ point = beamLine.GetEndPoint(0);
        //    double z1 = point.Z * 304.8;
        //    double h = 0.0;
        //    double h1 = 0.0;
        //    double z2 = 0.0;
        //    foreach (Parameter p in f.Symbol.Parameters)
        //    {
        //        if (p.Definition.Name == "h")
        //        {
        //            h = double.Parse(p.AsValueString());
        //            break;
        //        }
        //    }
        //    foreach (Parameter p in f.Parameters)
        //    {
        //        if (p.Definition.Name == "Z 轴偏移值")
        //        {
        //            h1 = double.Parse(p.AsValueString());
        //            z2 = z1 - h + h1;
        //        }
        //    }
        //    FilteredElementCollector collector = new FilteredElementCollector(doc);
        //    collector.OfCategory(BuiltInCategory.OST_Levels).OfClass(typeof(Instance));
        //    double i = 0.0;
        //    foreach (Level item in collector)
        //    {
        //        if (item.Name == "1F")
        //        {
        //            i = item.Elevation * 304.8;
        //            break;
        //        }
        //    }
        //    double beamClearHeight = 0.0;
        //    beamClearHeight = z2 - i;
        //    return beamClearHeight;
        //}
        #endregion

        #region 获得RGB列表
        private List<Color> GetRGBList(List<double> heightList)
        {
            List<Color> GetRGBList = new List<Color>();

            for (int i = 0; i < heightList.Count; i++)
            {
                int r = 255 / heightList.Count * i;
                Color col = new Color(byte.Parse(r.ToString()), 0, 0);
                GetRGBList.Add(col);
            }

            return GetRGBList;
        }
        #endregion

        #region 获得RGB列表 列举颜色
        //private List<Color> GetRGBList(List<double> heightList)
        //{
        //    Color c1 = new Color(0, 0, 0);
        //    Color c2 = new Color(100, 0, 0);
        //    Color c3 = new Color(0, 50, 0);
        //    Color c4 = new Color(0, 50, 90);
        //    Color c5 = new Color(50, 0, 100);
        //    Color c6 = new Color(150, 0, 150);
        //    Color c7 = new Color(255, 0, 0);
        //    Color c8 = new Color(100, 100, 150);
        //    Color c9 = new Color(255, 150, 255);
        //    Color c10 = new Color(0, 100, 255);
        //    Color c11 = new Color(0, 255, 255);
        //    Color c12 = new Color(0, 100, 100);
        //    Color c13 = new Color(100, 255, 100);
        //    Color c14 = new Color(255, 150, 0);
        //    Color c15 = new Color(255, 255, 100);
        //    Color c16 = new Color(200, 220, 255);
        //    Color c17 = new Color(255, 255, 180);
        //    Color c18 = new Color(180, 255, 220);
        //    Color c19 = new Color(255, 110, 110);
        //    Color c20 = new Color(255, 200, 200);
        //    Color c21 = new Color(200, 240, 255);
        //    Color c22 = new Color(255, 255, 255);

        //    Color[] co = { c1, c2, c3, c4, c5, c6, c7, c8, c9, c10, c11, c12, c13, c14, c15, c16, c17, c18, c19, c20, c21, c22 };
        //    List<Color> myCo = new List<Color>();
        //    int n = heightList.Count;
        //    for (int i = 0; i < n; i++)
        //    {
        //        myCo.Add(co[i]);
        //    }

        //    return myCo;
        //}
        #endregion


        /// <summary>
        /// 分段颜色 //2021-8-23 BY JL
        /// </summary>
        /// <param name="clearHeight"></param>
        /// <returns></returns>
        private Color GetColorByClearHeight(double clearHeight, double errorBeamHigh)
        {
            Color c = null;
            if (clearHeight < errorBeamHigh)
            {
                c = new Color(255, 0, 0);
            }
            else if (errorBeamHigh <= clearHeight && clearHeight < errorBeamHigh + 200)
            {
                c = new Color(255, 140, 140);
            }
            else if (errorBeamHigh + 200 <= clearHeight && clearHeight < errorBeamHigh + 400)
            {
                c = new Color(232, 116, 0);
            }
            else if (errorBeamHigh + 400 <= clearHeight && clearHeight < errorBeamHigh + 600)
            {
                c = new Color(243, 194, 129);
            }
            else
            {
                c = new Color(234, 207, 21);
            }
            return c;
        }

        #region 找到不同盘符的共享盘
        /// <summary>
        /// 找到不同盘符的共享盘
        /// </summary>
        /// <param name="specifiedPath">指定的路径</param>
        /// <returns>大家电脑上可以识别到的路径</returns>
        public static string SharedPath(string path)
        {
            //列出用户共享盘可能的盘符
            List<string> strList = new List<string>()
        {
            "A", "B", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", 
            "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"
        };
            for (int i = 0; i < strList.Count; i++)
            {
                string SharePath = path.Replace("X", strList[i]);
                if (Directory.Exists(SharePath))
                {
                    path = SharePath;
                    break;
                }
            }
            return path;
        }

        #endregion
    }
    public class BeamInfo
    {
        public double B { get; set; }
        public double H { get; set; }
        public ElementId BeamId { get; set; }
        public double BeamHigh { get; set; }
    }
}
