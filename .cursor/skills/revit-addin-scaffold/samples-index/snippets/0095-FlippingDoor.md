# Sample Snippet: FlippingDoor

Source project: `existingCodes\梁涛插件源代码\1.土建\FlippingDoor\FlippingDoor`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## ChangeLowHighCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlippingDoor
{
    public class ChangeLowHighCommand : IExternalEventHandler
    {
        public FamilyInstance Door { get; set; }
        public double LowHigh { get; set; }
        public void Execute(UIApplication app)
        {
            Document doc = app.ActiveUIDocument.Document;
            Transaction t = new Transaction(doc, "修改底高度");
            t.Start();
            Door.get_Parameter(BuiltInParameter.INSTANCE_SILL_HEIGHT_PARAM).Set(LowHigh);
            t.Commit();
        }

        public string GetName()
        {
            return "ChangeLowHighCommand";
        }
    }
}

```

## ChangeSymbolCommand.cs

```csharp
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FlippingDoor
{
    public class ChangeSymbolCommand : IExternalEventHandler
    {
        public FamilySymbol NewDoorSymbol { get; set; }
        public FamilyInstance Door { get; set; }
        public DataGrid List { get; set; }
        public void Execute(UIApplication app)
        {
            UIDocument uIDoc = app.ActiveUIDocument;
            Document doc = uIDoc.Document;
            try
            {
                Transaction t = new Transaction(doc, "更改族类型");
                t.Start();
                if (!NewDoorSymbol.IsActive)
                {
                    NewDoorSymbol.Activate();
                    //doc.Regenerate();
                    //uIDoc.RefreshActiveView();
                }
                //Door.ChangeTypeId(NewDoorSymbol.Id);
                foreach (var item in List.SelectedItems)
                {
                    DoorInfo doorInfo = item as DoorInfo;

                    List<ElementId> ids = new FilteredElementCollector(doc).OfCategory(BuiltInCategory.OST_Doors).OfClass(typeof(FamilyInstance)).Cast<FamilyInstance>().Select(x => x.Id).ToList();
                    if (!ids.Contains(doorInfo.DoorId)) continue;
                    FamilyInstance familyInstance = doc.GetElement(doorInfo.DoorId) as FamilyInstance;
                    familyInstance.ChangeTypeId(NewDoorSymbol.Id);

                    doorInfo.DoorFamilyName = NewDoorSymbol.FamilyName;
                    doorInfo.DoorSymbolName = NewDoorSymbol.Name;
                }
                t.Commit();
            }
            catch (Exception)
            {
                
            }
            
            //uIDoc.ShowElements(Door);
            //uIDoc.Selection.SetElementIds(new ElementId[] {Door.Id});

            //DoorInfo doorInfo = GlobalResources.mainWindow1.list.SelectedItem as DoorInfo;
            
            //刷新datagrid数据
            GlobalResources.mainWindow1.list.Items.Refresh();
            //datagrid控件重新获得焦点
            GlobalResources.mainWindow1.list.Focus();
            //滚动到当前行
            GlobalResources.mainWindow1.list.ScrollIntoView(GlobalResources.mainWindow1.list.SelectedItem);
        }

        public string GetName()
        {
            return "ChangeSymbolCommand";
        }
    }
}

```

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.Creation;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Documents.DocumentStructures;
using System.Windows.Shapes;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using Document = Autodesk.Revit.DB.Document;
using Line = Autodesk.Revit.DB.Line;

namespace FlippingDoor
{
    [Transaction(TransactionMode.Manual)]
    public class Command : IExternalCommand
    {
        List<WallInfo> WallInfos = new List<WallInfo>();
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uIDoc = commandData.Application.ActiveUIDocument;
            UIApplication uiapp = commandData.Application;
            Document doc = uIDoc.Document;
            Selection sel = uIDoc.Selection;
            int createCount = 0;


            using (var wallCol = new FilteredElementCollector(doc, doc.ActiveView.Id).OfCategory(BuiltInCategory.OST_Walls).WhereElementIsNotElementType())
            {
                foreach (var wall in wallCol.Where(c => !(c is DirectShape)).Cast<Wall>())
                {
                    var wallLines = new List<Curve>();
                    foreach (var wallLine in GetWallLines(wall))
                    {
                        Curve curve = wallLine.GetCurveZero();
                        if (curve != null) wallLines.Add(curve);

                    }
                    wallLines.Distinct();
                    WallInfos.Add(new WallInfo(wall, wallLines));
                }
            }


            List<ElementId> hideIds = new List<ElementId>();
            var CADNames = new List<string>();
            TransactionGroup TG = new TransactionGroup(doc, "门翻模");
            TG.Start();
            Reference reference;
        Next:
            try
            {
                reference = sel.PickObject(ObjectType.PointOnElement, new CADFilter(doc), "选择一个门图层");
                using (Transaction tran = new Transaction(doc, "隐藏CAD图层"))
                {
                    tran.Start();

                    Category hideCategory = GetLayerCategory(doc, reference);
                    hideIds.Add(hideCategory.Id);
                    doc.ActiveView.SetCategoryHidden(hideCategory.Id, true);

                    tran.Commit();
                }
                CADNames.Add(GetLayerName(doc, reference));
            }
            catch (Exception)
            {
                if (CADNames.Count > 0) goto Finish;
                else
                {
                    TaskDialog.Show("提示", "已取消操作");
                    TG.RollBack();
                    return Result.Cancelled;
                }

            }
            goto Next;
        Finish: using (Transaction tran = new Transaction(doc, "显示CAD图层"))
            {
                tran.Start();
// ... truncated ...
```

