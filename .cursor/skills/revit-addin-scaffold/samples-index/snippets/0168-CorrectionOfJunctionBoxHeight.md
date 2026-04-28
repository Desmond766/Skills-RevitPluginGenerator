# Sample Snippet: CorrectionOfJunctionBoxHeight

Source project: `existingCodes\梁涛插件源代码\8.算量插件集合\拆分（旧）\CorrectionOfJunctionBoxHeight\CorrectionOfJunctionBoxHeight`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Interop;
using System.Xml.Linq;
using CheckBox = System.Windows.Controls.CheckBox;
using Floor = Autodesk.Revit.DB.Floor;
using Line = Autodesk.Revit.DB.Line;
using Outline = Autodesk.Revit.DB.Outline;

namespace CorrectionOfJunctionBoxHeight
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            UIApplication uIApp = commandData.Application;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;

            var fec = new FilteredElementCollector(doc).OfClass(typeof(RevitLinkInstance)).First(x => x.Name.Contains("结构"));
            RevitLinkInstance revitLinkInstance = fec as RevitLinkInstance;
            Document linkDoc = revitLinkInstance.GetLinkDocument();
            FilteredElementCollector linkElems = new FilteredElementCollector(linkDoc);
            linkElems.OfClass(typeof(Wall));
            Transform transform = revitLinkInstance.GetTransform();
            
            List<WallInfo> wallInfos = new List<WallInfo>();
            foreach (var linkElem in linkElems)
            {
                Line line = (linkElem.Location as LocationCurve).Curve as Line;
                XYZ p0 = line.GetEndPoint(0);
                XYZ p1 = line.GetEndPoint(1);
                p0 = transform.OfPoint(p0);
                p1 = transform.OfPoint(p1);
                Line newLine = Line.CreateBound(new XYZ(p0.X, p0.Y, 0), new XYZ(p1.X, p1.Y, 0));
                var solids = GetElementSolid(linkElem);
                if (solids.Count == 1)
                {
                    Solid solid = SolidUtils.CreateTransformed(solids.First(), transform);
                    wallInfos.Add(new WallInfo() { Line = newLine, Solid = solid, Width = (linkElem as Wall).Width, Wall = linkElem as Wall });
                }
            }
            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //WallInfo wallInfo = wallInfos.First(w => w.Wall.Id.IntegerValue == 4306132);
            //XYZ p = (element.Location as LocationPoint).Point;
            //XYZ pp = wallInfo.Line.Project(p).XYZPoint;
            //p = new XYZ(p.X, p.Y, 0);
            //TaskDialog.Show("revit", p + "\n" + pp + "\n" + p.DistanceTo(pp) + "\n" + wallInfo.Wall.Id);
            //GetNearestWall(element as FamilyInstance, wallInfos);
            //return Result.Succeeded;

            // 旋转 25.1.22
            //Element element = doc.GetElement(sel.PickObject(ObjectType.Element));
            //using (Transaction t = new Transaction(doc, "旋转"))
            //{
            //    t.Start();
            //    XYZ p = (element.Location as LocationPoint).Point;
            //    ElementTransformUtils.RotateElement(doc, element.Id, Line.CreateBound(p, p + XYZ.BasisZ * 1), 1.57);

            //    t.Commit();
            //}


            // 自动获取引用参照 25.1.22
            //Reference reference = sel.PickObject(ObjectType.Element);
            //Element element = doc.GetElement(reference);
            //Reference reference1 = sel.PickObject(ObjectType.Element);
            //Element element1 = doc.GetElement(reference1);
            //using (Transaction t = new Transaction(doc, "尺寸标注"))
            //{
            //    t.Start();

            //    Reference newRef1 = GetSpecialFamilyReference(doc, element as FamilyInstance, FamilyInstanceReferenceType.CenterFrontBack);
// ... truncated ...
```

## App.cs

```csharp
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace CorrectionOfJunctionBoxHeight
{
    public class App : IExternalApplication
    {
        static string AddInPath = typeof(App).Assembly.Location;
        public Result OnShutdown(UIControlledApplication application)
        {
            return Result.Succeeded;
        }

        public Result OnStartup(UIControlledApplication application)
        {
            return Result.Succeeded;
        }
    }
}

```

