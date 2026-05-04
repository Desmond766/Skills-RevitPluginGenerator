# Sample Snippet: ARC_ColumnConnect

Source project: `existingCodes\品成插件源代码\土建\ARC_ColumnConnect\ARC_ColumnConnect`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Utils.cs

```csharp
using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ARC_ColumnConnect
{
    class Utils
    {
        #region 根据族名称找族下某类型名称ID

        public static ElementId FindTypeIdByFamilyName(Document doc, string familyName)
        {
            Family family = FindFamilyByName(doc, familyName);
            ISet<ElementId> iSetFamily = family.GetFamilySymbolIds();
            List<ElementId> listFamily = new List<ElementId>();
            foreach (var item in iSetFamily)
            {
                listFamily.Add(item);
            }
            ElementId elementId = listFamily[0];
            return elementId;

        }

        #endregion

        #region 根据族名称找族
        /// <summary>
        /// 根据族名称找族
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="familyName"></param>
        /// <returns></returns>
        public static Family FindFamilyByName(Document doc, string familyName)
        {
            var collector = new FilteredElementCollector(doc);
            var ids = collector.OfClass(typeof(Family)).ToElementIds();
            foreach (var id in ids)
            {
                if (doc.GetElement(id).Name == familyName)
                {
                    return doc.GetElement(id) as Family;
                }
            }
            return null;
        }
        #endregion
    }
}

```

## Commnad.cs

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using Autodesk.Revit.UI;
using Autodesk.Revit.DB;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.UI.Selection;
using Autodesk.Revit.DB.Plumbing;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.DB.Mechanical;

namespace ARC_ColumnConnect
{
    [Transaction(TransactionMode.Manual)]
    public class Commnad : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, Autodesk.Revit.DB.ElementSet elements)
        {

            UIApplication uiapp = commandData.Application;
            Document doc = uiapp.ActiveUIDocument.Document;
            Selection sel = uiapp.ActiveUIDocument.Selection;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            View view = doc.ActiveView;
            //选择两个面
            Reference r0 = sel.PickObject(ObjectType.Element, "选择较大的面的柱子");
            Reference r1 = sel.PickObject(ObjectType.Face, "选择较大的面");
            Reference r2 = sel.PickObject(ObjectType.Face, "选择较小的面");

            FamilyInstance familyinstance = doc.GetElement(r0) as FamilyInstance;
            Location location = familyinstance.Location;
            LocationPoint locationPoint = location as LocationPoint;

            TaskDialog.Show("a", locationPoint.Point.ToString());

            //获得底面的中心
            //根据名称找族
            var aFamilyName = "族3";
            FamilySymbol aSymbol = null;
            try
            {
                aSymbol = doc.GetElement(Utils.FindTypeIdByFamilyName(doc, aFamilyName)) as FamilySymbol;
            }
            catch (Exception)
            {
                TaskDialog.Show("提示", "检查是否载入品成标记点,\r\n位置：" + @"\\192.168.0.254\pc_2017\品成项目_2017\品成插件工作\0PC_标注族");
                return Result.Cancelled;
            }
            FamilyInstance a = doc.Create.NewFamilyInstance(locationPoint.Point, aSymbol, view);
            return Result.Succeeded;
        }
    }
}

```

