# Sample Snippet: DimensionChecking

Source project: `existingCodes\梁涛插件源代码\10.CEG\DimensionChecking\DimensionChecking`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Autodesk.Revit.DB.SpecTypeId;
using View = Autodesk.Revit.DB.View;

namespace DimensionChecking
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uIDocument = uiapp.ActiveUIDocument;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            if (!(doc.ActiveView is ViewSheet))
            {
                message = "please run in a sheet view";
                return Result.Cancelled;
            }
            string assemblyName = doc.GetElement(doc.ActiveView.AssociatedAssemblyInstanceId).Name;
            List<Autodesk.Revit.DB.View> views = GetAllViewInSheet(doc, doc.ActiveView as ViewSheet);

            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn();
            dc1.ColumnName = "ViewName";
            dt.Columns.Add(dc1);
            DataColumn dc2 = new DataColumn();
            dc2.ColumnName = "Dimension";
            dt.Columns.Add(dc2);
            DataColumn dc3 = new DataColumn();
            dc3.ColumnName = "Warnning";
            dt.Columns.Add(dc3);


            //Dictionary<View,List<ElementId>> idGroup = new Dictionary<View,List<ElementId>>();
            //Dictionary<View, ElementId> idGroup = new Dictionary<View, ElementId>();
            List<DimensionInfo> idGroup = new List<DimensionInfo>();
            foreach (Autodesk.Revit.DB.View v in views)
            {
                List<Element> viewElements = new FilteredElementCollector(doc, v.Id)
                    .ToElements().ToList();
                List<Element> visibleDimensions = new List<Element>();

                // 遍历每个尺寸标注，检查其是否在当前视图中可见
                foreach (var dimension in viewElements)
                {
                    if (IsElementVisibleInView(doc, v, dimension))
                    {
                        visibleDimensions.Add(dimension);
                    }
                }
                //if (v.Name == "SECTION-E")
                //    v.UnhideElements(visibleDimensions.Select(x => x.Id).ToList());
                //List<ElementId> ids = new List<ElementId>();
                foreach (Element e in visibleDimensions)
                {
                    if (e is Dimension)
                    {
                        Dimension dim = (Dimension)e;
                        //if (dim.View.Name == "SECTION-E")
                        //{
                        //    //List<Element> elements1 = visibleDimensions.Where(x => x is Dimension).ToList();
                        //    //TaskDialog.Show("ll", elements1.Count.ToString());
                        //    //TaskDialog.Show("ll", dim.Id.ToString());
                        //    if (dim.CanBeHidden(v) == true)
                        //    {

                        //        if (dim.IsHidden(v) == false)
                        //        {
                        //            TaskDialog.Show("ll", dim.Id.ToString());
                        //        }
                        //    }
                        //}
                        bool flag1 = ValueOverrideCheck(dim);
                        if (!flag1)
                        {
                            DimensionInfo dimensionInfo = new DimensionInfo() { ActiveView = v ,dimId = dim.Id};
// ... truncated ...
```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DimensionChecking
{
    public static class Utils
    {
        public static FamilySymbol GetTitleOnSheet(Document doc, ViewSheet vs)
        {
            //https://forums.autodesk.com/t5/revit-api-forum/how-to-get-a-viewsheet-s-title-block/td-p/5430779

            // 1. to collect all objects in the view
            IList<Element> m_alltitleblocks = new List<Element>();
            IList<Element> m_elementsOnSheet = new List<Element>();
            FamilySymbol myTitleBlock = null;

            foreach (Element e in new FilteredElementCollector(doc).OwnedByView(vs.Id))
            {
                m_elementsOnSheet.Add(e);
            }

            // 2. then Get all the titleblocks in the document

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol));
            collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

            m_alltitleblocks = collector.ToElements();

            // 3. Then I simply went through the elements on view untill i found the title sheet:

            foreach (Element el in m_elementsOnSheet)
            {
                foreach (FamilySymbol fs in m_alltitleblocks)
                {
                    if (el.GetTypeId().IntegerValue == fs.Id.IntegerValue)
                    {
                        myTitleBlock = fs;
                        break;
                    }
                }
            }

            return myTitleBlock;

        }

        public static FamilyInstance GetTitleInstanceOnSheet(Document doc, ViewSheet vs)
        {
            //https://forums.autodesk.com/t5/revit-api-forum/how-to-get-a-viewsheet-s-title-block/td-p/5430779

            // 1. to collect all objects in the view
            IList<Element> m_alltitleblocks = new List<Element>();
            IList<Element> m_elementsOnSheet = new List<Element>();
            FamilyInstance myTitleBlock = null;

            foreach (Element e in new FilteredElementCollector(doc).OwnedByView(vs.Id))
            {
                m_elementsOnSheet.Add(e);
            }

            // 2. then Get all the titleblocks in the document

            FilteredElementCollector collector = new FilteredElementCollector(doc);
            collector.OfClass(typeof(FamilySymbol));
            collector.OfCategory(BuiltInCategory.OST_TitleBlocks);

            m_alltitleblocks = collector.ToElements();

            // 3. Then I simply went through the elements on view untill i found the title sheet:

            foreach (Element el in m_elementsOnSheet)
            {
                foreach (FamilySymbol fs in m_alltitleblocks)
                {
                    if (el.GetTypeId().IntegerValue == fs.Id.IntegerValue)
                    {
                        myTitleBlock = el as FamilyInstance;
                        break;
                    }
                }
            }

            return myTitleBlock;
// ... truncated ...
```

