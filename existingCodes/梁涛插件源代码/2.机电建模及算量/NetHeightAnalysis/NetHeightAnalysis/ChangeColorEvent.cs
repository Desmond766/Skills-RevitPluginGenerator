using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NetHeightAnalysis
{
    public class ChangeColorEvent : IExternalEventHandler
    {
        public List<ClearHeightInfo> ClearHeightInfos = new List<ClearHeightInfo>();
        public void Execute(UIApplication app)
        {
            UIDocument uidoc = app.ActiveUIDocument;
            Document doc = uidoc.Document;

            //获取填充方式（实体填充）
            FilteredElementCollector fillPatternElementFilter = new FilteredElementCollector(doc);
            fillPatternElementFilter.OfClass(typeof(FillPatternElement));
            FillPatternElement fillPatternElement = fillPatternElementFilter.First(f => (f as FillPatternElement)
            .GetFillPattern().IsSolidFill) as FillPatternElement;

            var textNoteType = GetTextNoteType(doc);

            Transaction t = new Transaction(doc, "填充色块颜色");
            t.Start();
            foreach (var chInfo in ClearHeightInfos)
            {
                ElementId id = chInfo.FloorId;
                Color color = GetParkingSpaceColor(chInfo.ClearHeight);
                if (color == null) continue;

                string text = "净高=" + Math.Round(chInfo.ClearHeight / 1000.0, 2) + "m";
                if (textNoteType != null)
                {
                    try
                    {
                        var textNote = TextNote.Create(doc, doc.ActiveView.Id, chInfo.FloorPos, text, textNoteType.Id);
                        textNote.Location.Move(XYZ.BasisX.Negate() * (600 / 304.8));
                        textNote.Location.Move(XYZ.BasisY * (200 / 304.8));

                        //var noteBox = textNote.get_BoundingBox(null);
                        //var noteMin = noteBox.Min;
                        //var noteMax = noteBox.Max;
                        //textNote.Location.Move(XYZ.BasisX.Negate() * ((noteMax.X - noteMin.X) / 2.0));
                        //textNote.Location.Move(XYZ.BasisY * ((noteMax.Y - noteMin.Y) / 2.0));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        throw;
                    }
                    
                }

                OverrideGraphicSettings overrideGraphicSettings = doc.ActiveView.GetElementOverrides(id);
                overrideGraphicSettings.SetSurfaceForegroundPatternId(fillPatternElement.Id);//前景填充图案
                overrideGraphicSettings.SetSurfaceForegroundPatternColor(color);//前景填充颜色
                overrideGraphicSettings.SetSurfaceTransparency(0);//设置透明度(0：不透明；1：透明)

                overrideGraphicSettings.SetCutForegroundPatternId(fillPatternElement.Id);
                overrideGraphicSettings.SetCutForegroundPatternColor(color);
                overrideGraphicSettings.SetCutForegroundPatternVisible(true);
                //将设置应用到视图
                doc.ActiveView.SetElementOverrides(id, overrideGraphicSettings);

            }
            t.Commit();
            MessageBox.Show("完成");
        }

        private Color GetParkingSpaceColor(double clearHeight)
        {
            Color color = null;

            if (clearHeight < 0) return null;
            else if (clearHeight < 2000)
            {
                color = new Color(255, 0, 0);
            }
            else if (clearHeight < 3000)
            {
                color = new Color(255, 128, 192);
            }
            else if (clearHeight < 4000)
            {
                color = new Color(255, 128, 64);
            }
            else if (clearHeight < 5000)
            {
                color = new Color(128, 255, 0);
            }
            else if (clearHeight < 6000)
            {
                color = new Color(0, 255, 255);
            }
            else if (clearHeight < 7000)
            {
                color = new Color(128, 128, 255);
            }
            else
            {
                color = new Color(0, 128, 255);
            }


            return color;
        }
        private TextNoteType GetTextNoteType(Document doc)
        {
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> textNoteTypes = collector1.OfClass(typeof(TextNoteType)).ToElements();
            TextNoteType textNoteType = null;
            foreach (TextNoteType textType in textNoteTypes)
            {
                if (textType?.FamilyName == "文字" && textType?.Name == "支吊架信息标记")
                {
                    textNoteType = textType;
                    break;
                }
            }
            if (textNoteType == null) textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").FirstOrDefault(x => x.Name.Contains("2.5"));
            if (textNoteType == null) textNoteType = textNoteTypes.Cast<TextNoteType>().ToList().Where(x => x.FamilyName == "文字").FirstOrDefault();
            return textNoteType;
        }

        public string GetName()
        {
            return "ChangeColor";
        }
    }
}
