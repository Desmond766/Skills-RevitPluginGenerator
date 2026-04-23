using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Xml.Linq;
using Color = Autodesk.Revit.DB.Color;
using Document = Autodesk.Revit.DB.Document;
using Autodesk.Revit.ApplicationServices;
using Application = Autodesk.Revit.ApplicationServices.Application;
using Autodesk.Revit.UI.Events;
using System.ComponentModel;
using Autodesk.Revit.UI.Selection;
using System.Threading;

//楼板按标高/板厚赋色
namespace ColoringOfStructuralPlates
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        Document doc = null;
        public static List<ColorInfo> ColorInfos = null;
        public static bool IsHigh;
        public static bool IsCeiling;

        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            Selection sel = uIDoc.Selection;
            Application app = commandData.Application.Application;
            doc = uIDoc.Document;

            //var testRef = sel.PickObject(ObjectType.Element);
            //var testElem = doc.GetElement(testRef);
            //TaskDialog.Show("revit", GetElementColorInCurrentView(doc, testElem).Red.ToString());
            //return Result.Succeeded;

            var basePoint = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectBasePoint).WhereElementIsNotElementType().First();
            var elevation = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsValueString();
            int intElevation = Convert.ToInt32(elevation);

            List<Group> allGroup = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_IOSModelGroups).OfClass(typeof(Group)).Cast<Group>().ToList();
            // 获取所有楼板
            List<Element> floors = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Floors).OfClass(typeof(Floor))
                .WhereElementIsNotElementType()/*.Cast<Floor>()*/.ToList();
            // 获取所有组中的楼板
            List<Element> floorInGroup = new List<Element>();
            foreach (var group in allGroup)
            {
                foreach (var id in group.GetMemberIds())
                {
                    Element e = doc.GetElement(id);
                    if (e is Floor) floorInGroup.Add(e);
                }
            }
            //floors.AddRange(floorInGroup); // 不需要通过组添加

            // 获取所有天花板
            List<Element> ceilings = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Ceilings).OfClass(typeof(Ceiling))
                .WhereElementIsNotElementType()/*.Cast<Ceiling>()*/.ToList();
            // 获取所有组中的天花板
            List<Element> ceilingInGroup = new List<Element>();
            foreach (var group in allGroup)
            {
                foreach (var id in group.GetMemberIds())
                {
                    Element e = doc.GetElement(id);
                    if (e is Ceiling) ceilingInGroup.Add(e);
                }
            }
            //ceilings.AddRange(ceilingInGroup);

            var floorOrCeilings = new List<Element>();

            //获取填充方式（实体填充）
            FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
            fillPatternElementFilter.OfClass(typeof(FillPatternElement));
            FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
            .GetFillPattern().IsSolidFill) as FillPatternElement;

            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            if (mainWindow.cancel)
            {
                return Result.Cancelled;
            }
            IsHigh = mainWindow.high;
            IsCeiling = mainWindow.IsCeiling;

            if (mainWindow.IsCeiling) floorOrCeilings = ceilings.Select(x => x).ToList();
            else floorOrCeilings = floors.Select(x => x).ToList();

            string floorOrCeiling = "楼板";
            if (mainWindow.IsCeiling) floorOrCeiling = "天花板";
            Transaction t = new Transaction(doc, $"{floorOrCeiling}前景颜色填充");
            t.Start();
            List<ColorInfo> colorInfos = FloorOrCeilingGrouping(floorOrCeilings, mainWindow.high, mainWindow.IsCeiling, fillPatternElement);
            //ColorInfos = colorInfos.Select(c => c).ToList();
            if (colorInfos == null)
            {
                if (t.HasStarted()) t.RollBack();
                return Result.Failed;
            }
            t.Commit();
            colorInfos = colorInfos.OrderBy(x => x.HighOrTop).ThenBy(y => y.Count).ToList();
            ColorInfos = colorInfos;
            ShowGroup showGroup = new ShowGroup(mainWindow.high, mainWindow.IsCeiling, uIDoc, colorInfos);
            //showGroup.list.ItemsSource = colorInfos;
            showGroup.Show();
            GlobalResources.ShowGroup1 = showGroup;
            app.DocumentChanged += OnDocumentChanged;
            return Result.Succeeded;
        }
        public static void UpdateBasePointData(List<ColorInfo> colorInfos, Document doc)
        {
            var basePoint = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectBasePoint).WhereElementIsNotElementType().First();
            var elevation = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsValueString();
            int intElevation = Convert.ToInt32(elevation);
            foreach (var item in colorInfos)
            {
                item.MeasureOrProject = item.HighOrTop + intElevation;
            }
        }
        public static double UpdateBasePointData(ColorInfo colorInfo, Document doc)
        {
            var basePoint = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_ProjectBasePoint).WhereElementIsNotElementType().First();
            var elevation = basePoint.get_Parameter(BuiltInParameter.BASEPOINT_ELEVATION_PARAM).AsValueString();
            int intElevation = Convert.ToInt32(elevation);
            if (GlobalResources.ShowGroup1.cb_title.SelectedValue.ToString() == "项目基点")
            {
                return colorInfo.HighOrTop;
            }
            return colorInfo.HighOrTop + intElevation;

        }

        public static BuiltInParameter GetBuiltInParameter(Element element)
        {
            BuiltInParameter builtInParameter;
            if (!IsCeiling && element is Floor)
            {
                if (IsHigh) builtInParameter = BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM;
                else builtInParameter = BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP;
            }
            else if (IsCeiling && element is Ceiling)
            {
                builtInParameter = BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM;
            }
            else builtInParameter = BuiltInParameter.INVALID;
            return builtInParameter;
        }

        public static void OnDocumentChanged(object sender, DocumentChangedEventArgs e)
        {
            Document doc = e.GetDocument();

            List<ElementId> elementIds = e.GetModifiedElementIds().ToList();

            ChangeFloorColor changeFloorColor = new ChangeFloorColor();
            ExternalEvent externalEvent = ExternalEvent.Create(changeFloorColor);
            foreach (var item in elementIds)
            {
                Element element = null;
                try
                {
                    element = doc.GetElement(item);
                    //if (element.Category.Name == "楼板" || element.Category.Name == "模型组") TaskDialog.Show("revit", element.Category.Name);
                }
                catch (Exception)
                {
                    continue;
                }

                if (!IsCeiling && !IsHigh && GlobalResources.ShowGroup1.cb_title.SelectedValue.ToString() == "测量点" && element is BasePoint)
                {
                    UpdateBasePointData(ColorInfos, doc);
                    continue;
                }

                BuiltInParameter builtInParameter;
                //if (!IsCeiling && element is Floor floor)
                //{
                //    if (IsHigh) builtInParameter = BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM;
                //    else builtInParameter = BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP;
                //}
                //else if (IsCeiling && element is Ceiling ceiling)
                //{
                //    builtInParameter = BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM;
                //}
                //else continue;

                // FINISH 25.10.15 对组中的楼板判断
                //TaskDialog.Show("revit", element.Category.Name + "\n" + element.Id + "\n" + (element is GroupType) + "\n" + (element.Category.Id.IntegerValue == -2000095) + "\n" /*+ ((Group)element == null)*/);
                if (element is GroupType groupType)
                {
                    List<Group> groups = new List<Group>();
                    using (FilteredElementCollector groupCol = new FilteredElementCollector(doc))
                    {
                        groupCol.OfCategory(BuiltInCategory.OST_IOSModelGroups).WhereElementIsNotElementType();
                        groups = groupCol.Cast<Group>().Where(g => g.GroupType.Id == groupType.Id).ToList();
                    }

                    foreach (var group in groups)
                    {
                        foreach (var id in group.GetMemberIds())
                        {
                            Element subElem;
                            try
                            {
                                subElem = doc.GetElement(id);
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                            builtInParameter = GetBuiltInParameter(subElem);
                            if (builtInParameter == BuiltInParameter.INVALID) continue;

                            ChangeColorInfo(doc, subElem, builtInParameter, ref changeFloorColor);
                        }
                    }

                }

                builtInParameter = GetBuiltInParameter(element);
                if (builtInParameter == BuiltInParameter.INVALID) continue;

                ChangeColorInfo(doc, element, builtInParameter, ref changeFloorColor);


                //if (!IsCeiling && element is Floor floor)
                //{
                //    double floorHighOrTop;
                //    if (IsHigh)
                //    {
                //        floorHighOrTop = floor.get_Parameter(BuiltInParameter.FLOOR_ATTR_THICKNESS_PARAM).AsDouble() * 304.8;
                //        ColorInfo colorInfo = ColorInfos.FirstOrDefault(c => Math.Abs(c.HighOrTop - floorHighOrTop) < 0.0001);
                //        if (colorInfo != null)
                //        {
                //            ChangeFloorColor changeFloorColor = new ChangeFloorColor();
                //            ExternalEvent externalEvent = ExternalEvent.Create(changeFloorColor);
                //            changeFloorColor.Color = colorInfo.Color;
                //            changeFloorColor.FloorOrCeiling = floor;
                //            externalEvent.Raise();
                //            colorInfo.Count++;
                //            var oldInfo = ColorInfos.FirstOrDefault(c => c.ElemIds.Contains(floor.Id));
                //            if (oldInfo != null)
                //            {
                //                oldInfo.Count--;
                //                oldInfo.ElemIds.Remove(floor.Id);
                //            }
                //            colorInfo.ElemIds.Add(floor.Id);

                //        }

                //    }
                //    else
                //    {
                //        floorHighOrTop = floor.get_Parameter(BuiltInParameter.STRUCTURAL_ELEVATION_AT_TOP).AsDouble() * 304.8;
                //        ColorInfo colorInfo = ColorInfos.FirstOrDefault(c => Math.Abs(c.HighOrTop - floorHighOrTop) < 0.0001);
                //        if (colorInfo != null)
                //        {
                //            ChangeFloorColor changeFloorColor = new ChangeFloorColor();
                //            ExternalEvent externalEvent = ExternalEvent.Create(changeFloorColor);
                //            changeFloorColor.Color = colorInfo.Color;
                //            changeFloorColor.FloorOrCeiling = floor;
                //            externalEvent.Raise();
                //            colorInfo.Count++;
                //            var oldInfo = ColorInfos.FirstOrDefault(c => c.ElemIds.Contains(floor.Id));
                //            if (oldInfo != null)
                //            {
                //                oldInfo.Count--;
                //                oldInfo.ElemIds.Remove(floor.Id);
                //            }
                //            colorInfo.ElemIds.Add(floor.Id);
                //        }
                //    }
                //}
                //else if (IsCeiling && element is Ceiling ceiling)
                //{
                //    var levelOffset = ceiling.get_Parameter(BuiltInParameter.CEILING_HEIGHTABOVELEVEL_PARAM).AsDouble() * 304.8;
                //    ColorInfo colorInfo = ColorInfos.FirstOrDefault(c => c.HighOrTop == levelOffset);
                //    if (colorInfo != null)
                //    {
                //        ChangeFloorColor changeFloorColor = new ChangeFloorColor();
                //        ExternalEvent externalEvent = ExternalEvent.Create(changeFloorColor);
                //        changeFloorColor.Color = colorInfo.Color;
                //        changeFloorColor.FloorOrCeiling = ceiling;
                //        externalEvent.Raise();
                //        colorInfo.Count++;
                //        var oldInfo = ColorInfos.FirstOrDefault(c => c.ElemIds.Contains(ceiling.Id));
                //        if (oldInfo != null)
                //        {
                //            oldInfo.Count--;
                //            oldInfo.ElemIds.Remove(ceiling.Id);
                //        }
                //        colorInfo.ElemIds.Add(ceiling.Id);
                //    }
                //}

            }
            //if (changeFloorColor.ElemIds.Count > 0) externalEvent.Raise();
            //TaskDialog.Show("ondoc", (changeFloorColor.ChangeColorInfos.Count).ToString());
            if (changeFloorColor.ChangeColorInfos.Count > 0)
            {
                KeyUtils.SimulateEscapePress();
                Thread.Sleep(50);
                KeyUtils.SimulateEscapePress();
                Thread.Sleep(50);
            }
            if (changeFloorColor.ChangeColorInfos.Count > 0) { externalEvent.Raise(); }
        }

        private static void ChangeColorInfo(Document doc, Element element, BuiltInParameter builtInParameter, ref ChangeFloorColor changeFloorColor)
        {
            double floorHighOrTop = element.get_Parameter(builtInParameter).AsDouble() * 304.8;
            ColorInfo colorInfo = ColorInfos.FirstOrDefault(c => Math.Abs(c.HighOrTop - floorHighOrTop) < 0.001);
            if (colorInfo != null)
            {
                // TODO: 26.1.23修改高程时列表对应的数量不正确(原因，每次对组进行修改时，组内元素的ID都会发生改变)(改变组内元素类型ID不变，改变组偏移元素ID改变)
                //changeFloorColor.Color = colorInfo.Color;
                //changeFloorColor.ElemIds.Add(element.Id);
                changeFloorColor.ChangeColorInfos.Add(new ChangeColorInfo() { Color = colorInfo.Color, ElementId = element.Id });

                colorInfo.Count++;
                var oldInfo = ColorInfos.FirstOrDefault(c => c.ElemIds.Contains(element.Id));
                if (oldInfo == null) oldInfo = ColorInfos.FirstOrDefault(c => c.Color == GetElementColorInCurrentView(doc, element));

                if (oldInfo != null)
                {
                    oldInfo.Count--;
                    oldInfo.ElemIds.Remove(element.Id);
                }
                else
                {
                    foreach (var color in ColorInfos)
                    {
                        var delIds = color.ElemIds.Where(id => doc.GetElement(id) == null).ToList();
                        delIds.ForEach(delId => color.ElemIds.Remove(delId));
                        color.Count -= delIds.Count;
                    }
                }
                colorInfo.ElemIds.Add(element.Id);

            }
            else
            {

                var color = new Command().RandomColorInRevit(DateTime.Now.Second * element.Id.IntegerValue);

                //changeFloorColor.Color = color;
                //changeFloorColor.ElemIds.Add(element.Id);
                changeFloorColor.ChangeColorInfos.Add(new ChangeColorInfo() { Color = color, ElementId = element.Id });


                //changeFloorColor.FloorOrCeiling = element;
                //externalEvent.Raise();
                ColorInfo colorInfo1 = new ColorInfo();
                colorInfo1.Color = color;
                colorInfo1.FloorColor = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(color.Red, color.Green, color.Blue));
                colorInfo1.HighOrTop = Convert.ToDouble(element.get_Parameter(builtInParameter).AsValueString());
                colorInfo1.MeasureOrProject = UpdateBasePointData(colorInfo1, doc);
                colorInfo1.ElemIds = new List<ElementId> { element.Id };
                colorInfo1.Count = 1;

                var oldInfo = ColorInfos.FirstOrDefault(c => c.ElemIds.Contains(element.Id));
                if (oldInfo == null) oldInfo = ColorInfos.FirstOrDefault(c => c.Color == GetElementColorInCurrentView(doc, element));
                if (oldInfo != null)
                {
                    oldInfo.Count--;
                    oldInfo.ElemIds.Remove(element.Id);
                }

                ColorInfos.Add(colorInfo1);
                GlobalResources.ShowGroup1.list.ItemsSource = null;
                GlobalResources.ShowGroup1.list.ItemsSource = ColorInfos;
            }
        }
        private static Color GetElementColorInCurrentView(Document doc, Element element)
        {
            Color result;

            OverrideGraphicSettings ogs = doc.ActiveView.GetElementOverrides(element.Id);
            // 表面前景颜色
            var projectColor = ogs.SurfaceForegroundPatternColor;
            // 截面前景颜色
            var cutColor = ogs.CutForegroundPatternColor;

            result = projectColor != Color.InvalidColorValue ? projectColor : cutColor != Color.InvalidColorValue ? cutColor : null;

            return result;
        }

        public List<ColorInfo> FloorOrCeilingGrouping(List<Element> floorsOrCeilings, bool high, bool isCeiling, FillPatternElement fillPatternElement)
        {
            List<ColorInfo> colorInfos = new List<ColorInfo>();
            string groupBy = "";
            if (isCeiling)
            {
                groupBy = "自标高的高度偏移";
            }
            else if (high)
            {
                groupBy = "厚度";
            }
            else
            {
                //groupBy = "标高";
                groupBy = "顶部高程";
            }
            var floorOrCeilingGroup = floorsOrCeilings.GroupBy(x => x.LookupParameter(groupBy).AsValueString());
            if (high) floorOrCeilingGroup = floorOrCeilingGroup.OrderBy(x => Convert.ToInt32(x.Key));

            //Random random = new Random();
            if (floorOrCeilingGroup.Count() > 15)
            {
                string floorOrCeiling = "楼板";
                if (isCeiling) floorOrCeiling = "天花板";
                //TaskDialog.Show("提示", $"分类后的{floorOrCeiling}种类超过了15种，无法进行赋色");
                var result = TaskDialog.Show("提示", $"分类后的{floorOrCeiling}种类超过了15种，后续{floorOrCeiling}进行随机赋色", TaskDialogCommonButtons.Ok | TaskDialogCommonButtons.Cancel);
                if (result == TaskDialogResult.Cancel) return null;
                //return null;
            }
            int i = 0;
            foreach (var item in floorOrCeilingGroup)
            {
                // 随机获取颜色
                //int red = random.Next(0, 255);
                //int green = random.Next(0, 255);
                //int blue = random.Next(0, 255);
                //if (Math.Abs(red - green) < 40) red = red / 2;

                //List<RGBInfo> rGBInfos = InitRGBInfos();
                //byte red = rGBInfos[i].Red;
                //byte green = rGBInfos[i].Green;
                //byte blue = rGBInfos[i].Blue;
                var colors = InitRGBColors();
                Color rGBColor;
                if (i > 14) rGBColor = RandomColorInRevit(i ^ 2);
                else rGBColor = colors[i];

                foreach (var floor in item)
                {
                    OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(floor.Id);
                    overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);//前景填充图案
                    //overrideGraphicSettings.SetSurfaceForegroundPatternColor(new Color(red, green, blue));//前景填充颜色
                    //overrideGraphicSettings.SetSurfaceForegroundPatternColor(colors[i]);//前景填充颜色
                    overrideGraphicSettings.SetSurfaceForegroundPatternColor(rGBColor);//前景填充颜色
                    overrideGraphicSettings.SetSurfaceTransparency(0);//设置透明度(0：不透明；1：透明)

                    overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
                    overrideGraphicSettings.SetCutForegroundPatternColor(rGBColor);
                    overrideGraphicSettings.SetCutForegroundPatternVisible(true);
                    //将设置应用到视图
                    doc.ActiveView.SetElementOverrides(floor.Id, overrideGraphicSettings);
                }
                //string color = RgbToHex2(red, green, blue);
                //string color = RgbToHex2(colors[i].Red, colors[i].Green, colors[i].Blue);
                string color = System.Drawing.ColorTranslator.ToHtml(System.Drawing.Color.FromArgb(rGBColor.Red, rGBColor.Green, rGBColor.Blue));

                double highOrTop = Convert.ToDouble(item.Key);

                ColorInfo colorInfo = new ColorInfo() { Count = item.Count(), FloorColor = color, HighOrTop = highOrTop, Color = rGBColor, ElemIds = item.ToList().Select(x => x.Id).ToList() };
                colorInfos.Add(colorInfo);
                i++;
            }
            return colorInfos;
        }
        public string RgbToHex(int r, int g, int b)
        {
            // 将RGB值转换为十六进制格式的字符串
            return $"#{r:X2}{g:X2}{b:X2}";
        }
        public string RgbToHex2(int r, int g, int b)
        {
            string r1 = Convert.ToString(r, 16);
            string g1 = Convert.ToString(g, 16);
            string b1 = Convert.ToString(b, 16);
            return $"#{r1}{g1}{b1}";
        }
        public System.Drawing.Color RandomColor()
        {
            long tick = DateTime.Now.Ticks;
            Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));

            int R = ran.Next(255);
            int G = ran.Next(255);
            int B = ran.Next(255);
            B = (R + G > 400) ? R + G - 400 : B;//0 : 380 - R - G;
            B = (B > 255) ? 255 : B;
            return System.Drawing.Color.FromArgb(R, G, B);
        }
        public Color RandomColorInRevit(int seed)
        {

            long tick = DateTime.Now.Ticks;
            //Random ran = new Random((int)(tick & 0xffffffffL) | (int)(tick >> 32));
            Random ran = new Random(seed);

            int R = ran.Next(0, 255);
            int G = ran.Next(0, 255);
            int B = ran.Next(0, 255);
            B = (R + G > 400) ? R + G - 400 : B;
            B = (B > 255) ? 255 : B;
            R = Math.Abs(R - G) < 40 ? R / 2 : R;
            return new Color((byte)R, (byte)G, (byte)B);
        }
        //初始化十五个RGB颜色
        public List<RGBInfo> InitRGBInfos()
        {
            List<RGBInfo> rGBInfos = new List<RGBInfo>()
            {
                new RGBInfo(){ Red = 128 ,Green = 128 ,Blue = 128 },
                new RGBInfo(){ Red = 128 ,Green = 120 ,Blue = 65 },
                new RGBInfo(){ Red = 128 ,Green = 255 ,Blue = 255 },
                new RGBInfo(){ Red = 100 ,Green = 128 ,Blue = 255 },
                new RGBInfo(){ Red = 255 ,Green = 128 ,Blue = 192 },
                new RGBInfo(){ Red = 16 ,Green = 16 ,Blue = 255 },
                new RGBInfo(){ Red = 50 ,Green = 255 ,Blue = 50 },
                new RGBInfo(){ Red = 255 ,Green = 255 ,Blue = 50 },
                new RGBInfo(){ Red = 16 ,Green = 128 ,Blue = 128 },
                new RGBInfo(){ Red = 128 ,Green = 16 ,Blue = 128 },
                new RGBInfo(){ Red = 50 ,Green = 50 ,Blue = 50 },
                new RGBInfo(){ Red = 64 ,Green = 16 ,Blue = 128 },
                new RGBInfo(){ Red = 50 ,Green = 100 ,Blue = 50 },
                new RGBInfo(){ Red = 255 ,Green = 69 ,Blue = 32 },
                new RGBInfo(){ Red = 255 ,Green = 0 ,Blue = 0 },
            };
            return rGBInfos;
        }
        public List<Color> InitRGBColors()
        {
            List<Color> colors = new List<Color>()
            {
                new Color(128,128,128),
                new Color(128,128,65),
                new Color(128,255,255),
                new Color(100,128,255),
                new Color(255,128,192),
                new Color(16,16,255),
                new Color(50,255,50),
                new Color(255,255,50),
                new Color(16,128,128),
                new Color(128,16,128),
                new Color(50,50,50),
                new Color(64,16,128),
                new Color(50,100,50),
                new Color(255,69,32),
                new Color(255,0,0),
            };
            return colors;
        }
    }
    public class ColorInfo : INotifyPropertyChanged
    {
        private int _count;
        public int Count
        {
            get => _count;
            set
            {
                if (_count != value)
                {
                    _count = value;
                    OnPropertyChanged(nameof(Count)); // 通知属性更改
                }
            }
        }
        public List<ElementId> ElemIds { get; set; }
        //public string LevelOrHigh { get; set; }
        private string _floorColor;
        public string FloorColor
        {
            get => _floorColor;
            set
            {
                if (_floorColor != value)
                {
                    _floorColor = value;
                    OnPropertyChanged(nameof(FloorColor));
                }
            }
        }
        public double HighOrTop { get; set; }
        public Color Color { get; set; }

        private double _measureOrProject = double.NaN;
        public double MeasureOrProject
        {
            get { return _measureOrProject; }
            set
            {
                if (_measureOrProject != value)
                {
                    _measureOrProject = value;
                    OnPropertyChanged(nameof(MeasureOrProject));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class RGBInfo
    {
        public byte Red { get; set; }
        public byte Green { get; set; }
        public byte Blue { get; set; }
        //public byte Red { get; set; }
        //public byte Green { get; set; }
        //public byte Blue { get; set; }
    }
    public static class GlobalResources
    {
        public static ShowGroup ShowGroup1 { get; set; }
    }
}
