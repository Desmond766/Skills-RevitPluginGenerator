# Sample Snippet: RampArrowParallelFloor

Source project: `existingCodes\梁涛插件源代码\1.土建\RampArrowParallelFloor\RampArrowParallelFloor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using System.Xml.Linq;
using FileNotFoundException = System.IO.FileNotFoundException;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Point = Autodesk.Revit.DB.Point;

namespace RampArrowParallelFloor
{
    // 阵列坡道箭头平行于楼板
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;

            FamilySymbol familySymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_GenericModel).Where(f => f is FamilySymbol).Cast<FamilySymbol>()
                .FirstOrDefault(f => f.Name.Contains("坡道箭头"));
            if (familySymbol == null)
            {
                try
                {
                    LoadFamily(doc, Resource1.坡道箭头, "坡道箭头");
                }
                catch (Exception)
                {

                }
                familySymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_GenericModel).Where(f => f is FamilySymbol).Cast<FamilySymbol>()
                .FirstOrDefault(f => f.Name.Contains("坡道箭头"));
                if (familySymbol == null)
                {
                    //TaskDialog.Show("提示", " 未找到族类型: '坡道箭头'");
                    MessageBox.Show("未找到族类型: '坡道箭头'");
                    return Result.Cancelled;
                }
            }

            //return Result.Succeeded;

            TipWindow tipWindow = new TipWindow("选择模型线或元素边线");
            SetWindowPos(tipWindow, uidoc);

            Reference lineRefer;
            try
            {
                lineRefer = sel.PickObject(ObjectType.PointOnElement, new LineFilter(doc), "选择模型线或元素边线");
            }
            catch (Exception)
            {
                MessageBox.Show("已取消操作");
                tipWindow.Close();
                return Result.Cancelled;
            }

            Line line = null;
            Element lineElem = doc.GetElement(lineRefer);
            if (lineElem is ModelLine)
            {
                line = (lineElem.Location as LocationCurve).Curve as Line;
            }
            else if (lineElem is RevitLinkInstance linkInstance)
            {
                Document linkDoc = linkInstance.GetLinkDocument();
                Element linkElem = linkDoc.GetElement(lineRefer.LinkedElementId);
                Reference linkRefer = lineRefer.CreateReferenceInLink();
                GeometryObject linkGeo = linkElem.GetGeometryObjectFromReference(linkRefer);
                if (linkGeo is Edge edge)
                {
// ... truncated ...
```

## Command3.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.Exceptions;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interop;
using OperationCanceledException = Autodesk.Revit.Exceptions.OperationCanceledException;
using Point = Autodesk.Revit.DB.Point;

namespace RampArrowParallelFloor
{
    // 阵列坡道箭头平行于楼板
    [Transaction(TransactionMode.Manual)]
    public class Command3 : IExternalCommand
    {
        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndlnsertAfter, int X, int Y, int cx, int cy, uint Flags);

        [System.Runtime.InteropServices.DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;
            Selection sel = uidoc.Selection;


            FamilySymbol familySymbol = new FilteredElementCollector(doc).WhereElementIsElementType().OfCategory(BuiltInCategory.OST_GenericModel).Where(f => f is FamilySymbol).Cast<FamilySymbol>()
                .FirstOrDefault(f => f.Name.Contains("坡道箭头"));
            if (familySymbol == null)
            {
                return Result.Cancelled;
            }

            var lineRefer = sel.PickObject(ObjectType.Element);
            Line line1 = null;
            Element lineElem = doc.GetElement(lineRefer);
            line1 = (lineElem.Location as LocationCurve).Curve as Line;

            var refer2 = sel.PickObject(ObjectType.Face);
            Element element = doc.GetElement(refer2);
            Face face1 = element.GetGeometryObjectFromReference(refer2) as Face;
            Face finalFace = null;

            // 创建几何选项，并开启引用计算
            Options geomOptions = new Options
            {
                ComputeReferences = true, // 这是解决此问题的关键！
                DetailLevel = ViewDetailLevel.Fine, // 建议设置所需的详细程度
                IncludeNonVisibleObjects = false // 根据需求决定是否包含不可见对象
            };

            // 获取元素的几何图形
            GeometryElement geometryElement = element.get_Geometry(geomOptions);

            // 遍历几何图形以找到所需的面 (Face)
            foreach (GeometryObject geomObj in geometryElement)
            {
                Solid solid = geomObj as Solid;
                if (solid != null && solid.Volume > 0)
                {
                    foreach (Face face2 in solid.Faces)
                    {
                        // 现在，face.Reference 不再是 null
                        Reference faceRef = face2.Reference;
                        if (faceRef.ConvertToStableRepresentation(doc) == refer2.ConvertToStableRepresentation(doc))
                        {
                            finalFace = face2;
                            break;
                        }
                    }
                }
            }

            List<ElementId> ids = new List<ElementId>();
            using (Transaction t = new Transaction(doc, "生成坡道箭头"))
            {
                t.Start();

                if (!familySymbol.IsActive)
                {
                    familySymbol.Activate();
                }
// ... truncated ...
```

