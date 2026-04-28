# Sample Snippet: CEGShopTicketHelper

Source project: `existingCodes\梁涛插件源代码\10.CEG\CEGShopTicketHelper\CEGShopTicketHelper`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## AutoTicketingHelperCmd.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;

//根据板块类型自动出图

namespace CEGShopTicketHelper
{
    [Transaction(TransactionMode.Manual)]
    public class AutoTicketingHelperCmd : IExternalCommand
    {
        public string settingFileName = "CEGTicketHelperSetting.txt";
        public string settingFileDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//桌面
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            //if (!CEGToolsHelper.Utils.CheckReg())
            //{
            //    return Result.Cancelled;
            //}

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;

            Reference reference = sel.PickObject(ObjectType.Element);
            AssemblyInstance assembly = doc.GetElement(reference) as AssemblyInstance;

            //AutoTicketingHelper.PrecastCategory cegCategory = Utils.CheckCEGCategory(assembly.);
            AutoTicketingHelper.PCaTicketingHelper helper = null;

            helper = new AutoTicketingHelper.DtTicketingHelper(assembly);
            //helper = new AutoTicketingHelper.SpandrelTicketingHelper(assembly);
            helper.CreateAssemblyView();
            helper.TicketingView();


            return Result.Succeeded;
        }
    }
}

```

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CEGShopTicketHelper
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
// ... truncated ...
```

## AutoTicketingHelper\DtTicketingHelper.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CEGShopTicketHelper.AutoTicketingHelper
{
    public class DtTicketingHelper : PCaTicketingHelper
    {
        public string topViewName = "TOP VIEW IN FORM";
        //public string topViewTemplateName = "TICKET-3/16(DT TOP)";
        public string topViewTemplateName = "TICKET- DT-3/16\" TOP";
        public XYZ topViewLocation = new XYZ(0.5, 0.6, 0);

        public string elevationViewName = "ELEVATION VIEW";
        //public string elevationViewTemplateName = "TICKET-3/16(DT TOP)";
        public string elevationViewTemplateName = "TICKET- DT-3/16\" ELE";
        public XYZ elevationViewLocation = new XYZ(0.5, 0.4, 0);  
        
        public DtTicketingHelper(AssemblyInstance assembly) : base(assembly)
        {
            
        }

        public override void CreateAssemblyView()
        {
            using (Transaction trans = new Transaction(Doc, "CEG.CreateAssemblyView"))
            {
                trans.Start();
                CreateAssemblySheet();
                Create3DView();
                TopView = CreateAssemblyView(
                    AssemblyDetailViewOrientation.ElevationTop,
                    topViewName,
                    topViewTemplateName,
                    topViewLocation);
                FrontView = CreateAssemblyView(
                    AssemblyDetailViewOrientation.ElevationFront,
                    elevationViewName,
                    elevationViewTemplateName,
                    elevationViewLocation);
                trans.Commit();
            }
        }

        public override void TicketingView()
        {
            //TOP VIEW
            ViewAnnotatingHelper helper = new ViewAnnotatingHelper(Assembly, TopView);
            using (Transaction trans = new Transaction(Doc, "CEG.TopViewAnnotating"))
            {
                ////失败处理
                //FailureHandlingOptions failureHandlingOptions = trans.GetFailureHandlingOptions();
                //FailureHandler failureHandler = new FailureHandler();
                //failureHandlingOptions.SetFailuresPreprocessor(failureHandler);
                //// 这句话是关键
                //failureHandlingOptions.SetClearAfterRollback(true);
                //trans.SetFailureHandlingOptions(failureHandlingOptions);

                trans.Start();
                helper.AddSideEndText();
                helper.OverallSideDim();
                helper.OverallEndDim();
                helper.EndDim();
                helper.SideDim();
                //Utils.CreateModelLine(Doc, helper.PtLeftUpCorner, helper.PtRightDownCorner);
                //Utils.CreateModelLine(Doc, helper.PtLeftDownCorner, helper.PtRightUpCorner);
                trans.Commit();
            }
        }

    }
}

```

