# Sample Snippet: NetHeightAnalysis

Source project: `existingCodes\梁涛插件源代码\2.机电建模及算量\NetHeightAnalysis\NetHeightAnalysis`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Mechanical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using Color = System.Drawing.Color;
using Transform = Autodesk.Revit.DB.Transform;

// 车位族净高分析
namespace NetHeightAnalysis
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            //Reference linkRefer = sel.PickObject(ObjectType.LinkedElement);
            //RevitLinkInstance linkInstance = doc.GetElement(linkRefer) as RevitLinkInstance;
            //Document linkDoc = linkInstance.GetLinkDocument();
            //Floor floor = (Floor)linkDoc.GetElement(linkRefer.LinkedElementId);
            //var face = HostObjectUtils.GetTopFaces(floor);
            //TaskDialog.Show("revit", (face.Count).ToString());

            //return Result.Succeeded;

            
            //Reference reference = sel.PickObject(ObjectType.Element);
            //XYZ po = (doc.GetElement(reference).Location as LocationPoint).Point;
            //Transaction ttt = new Transaction(doc, "创建标注");
            //ttt.Start();
            //IndependentTag independentTag = IndependentTag.Create(doc, doc.ActiveView.Id, reference, false, TagMode.TM_ADDBY_CATEGORY, TagOrientation.Horizontal, po);
            //ttt.Commit();
            //return Result.Succeeded;

            //Reference linkRefer = sel.PickObject(ObjectType.LinkedElement, "选择车道边界线所在链接模型");
            //RevitLinkInstance revitLinkInstance = doc.GetElement(linkRefer) as RevitLinkInstance;
            //Document linkDoc = revitLinkInstance.GetLinkDocument();
            //Floor linkFloor = linkDoc.GetElement(linkRefer.LinkedElementId) as Floor;

            //var faceRef = HostObjectUtils.GetTopFaces(linkFloor);
            //Face face = linkFloor.GetGeometryObjectFromReference(faceRef.First()) as Face;
            //IList<CurveLoop> loopss = face.GetEdgesAsCurveLoops();
            //List<CurveLoop> newLoops = new List<CurveLoop>();
            //foreach (var loop in loopss)
            //{
            //    CurveLoop curves = new CurveLoop();
            //    foreach (var curve in loop)
            //    {
            //        curves.Append(curve.CreateTransformed(revitLinkInstance.GetTransform()));
            //    }
            //    newLoops.Add(curves);
            //}

            //FilledRegionType frTypess = null;
            //using (FilteredElementCollector fillTypeCol = new FilteredElementCollector(doc))
            //{
            //    fillTypeCol.OfCategory(BuiltInCategory.OST_DetailComponents).OfClass(typeof(FilledRegionType));
            //    var types = fillTypeCol.Cast<FilledRegionType>().ToList();
            //    frTypess = types.First();
            //}
            //Transaction tt = new Transaction(doc, "楼板色块");
            //tt.Start();
            //FilledRegion.Create(doc, frTypess.Id, doc.ActiveView.Id, newLoops);
            //tt.Commit();


            //return Result.Succeeded;

            SelWindow selWindow = new SelWindow(doc);
            IntPtr intPtr = commandData.Application.MainWindowHandle;
            WindowInteropHelper windowInteropHelper = new WindowInteropHelper(selWindow);
            windowInteropHelper.Owner = intPtr;
            selWindow.ShowDialog();
            if (selWindow.DialogResult == false)
            {
                return Result.Cancelled;
            }

// ... truncated ...
```

## ChangeColorEvent.cs

```csharp
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
// ... truncated ...
```

## ClearHeightInfo.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetHeightAnalysis
{
    public class ClearHeightInfo
    {
        public ElementId ElementId { get; set; }
        public ElementId FloorId { get; set; }
        public XYZ FloorPos { get; set; }
        public string ElementType { get; set; }
        public double ClearHeight { get; set; }
        public IList<CurveLoop> Loops { get; set; }
        public string Color { get; set; }
        public ClearHeightInfo(ElementId elementId, ElementId floorId, XYZ floorPos, string elementType, double clearHeight, IList<CurveLoop> loops)
        {
            ElementId = elementId;
            FloorId = floorId;
            FloorPos = floorPos;
            ElementType = elementType;
            ClearHeight = clearHeight;
            Loops = loops;
        }
    }
}

```

