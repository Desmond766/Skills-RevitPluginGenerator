using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Color = Autodesk.Revit.DB.Color;

namespace ColoringOfStructuralPlates
{
    public class ChangeFloorColor : IExternalEventHandler
    {
        public List<ElementId> ElemIds { get; set; } = new List<ElementId>();
        public Element FloorOrCeiling { get; set; }
        public Color Color { get; set; }
        public List<ChangeColorInfo> ChangeColorInfos { get; set; } = new List<ChangeColorInfo>();
        public void Execute(UIApplication app)
        {
            if (ElemIds.Count == 0) goto Next;
            try
            {
                Document doc = app.ActiveUIDocument.Document;

                //获取填充方式（实体填充）
                FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
                fillPatternElementFilter.OfClass(typeof(FillPatternElement));
                FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
                .GetFillPattern().IsSolidFill) as FillPatternElement;

                if (FloorOrCeiling != null) ElemIds.Add(FloorOrCeiling.Id);
                Transaction t = new Transaction(doc, "更改楼板颜色");
                t.Start();
                foreach (var id in ElemIds)
                {
                    //OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(FloorOrCeiling.Id);
                    OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(id);
                    overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);//前景填充图案
                    overrideGraphicSettings.SetSurfaceForegroundPatternColor(Color);//前景填充颜色
                    overrideGraphicSettings.SetSurfaceTransparency(0);//设置透明度(0：不透明；1：透明)

                    overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
                    overrideGraphicSettings.SetCutForegroundPatternColor(Color);
                    overrideGraphicSettings.SetCutForegroundPatternVisible(true);
                    //将设置应用到视图
                    doc.ActiveView.SetElementOverrides(id, overrideGraphicSettings);
                }
                t.Commit();
            }
            catch (Exception e)
            {
                //TaskDialog.Show("revit", e.ToString());
            }
        Next:
            if (ChangeColorInfos.Count == 0) return;
            try
            {
                Document doc = app.ActiveUIDocument.Document;

                //获取填充方式（实体填充）
                FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
                fillPatternElementFilter.OfClass(typeof(FillPatternElement));
                FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
                .GetFillPattern().IsSolidFill) as FillPatternElement;

                Transaction t = new Transaction(doc, "更改楼板颜色");
                t.Start();
                foreach (var info in ChangeColorInfos)
                {
                    //OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(FloorOrCeiling.Id);
                    OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(info.ElementId);
                    overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);//前景填充图案
                    overrideGraphicSettings.SetSurfaceForegroundPatternColor(info.Color);//前景填充颜色
                    overrideGraphicSettings.SetSurfaceTransparency(0);//设置透明度(0：不透明；1：透明)

                    overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
                    overrideGraphicSettings.SetCutForegroundPatternColor(info.Color);
                    overrideGraphicSettings.SetCutForegroundPatternVisible(true);
                    //将设置应用到视图
                    doc.ActiveView.SetElementOverrides(info.ElementId, overrideGraphicSettings);
                    //TaskDialog.Show("rvi", info.Color.Red + "," + info.Color.Green + "," + info.Color.Blue);
                }
                t.Commit();
            }
            catch (Exception)
            {
                
            }
            
        }

        public string GetName()
        {
            return "ChangeFloorColor";
        }
    }
    public class ChangeColorInfo
    {
        public Color Color { get; set; }
        public ElementId ElementId { get; set; }
    }
}
