# Sample Snippet: HangerClassificationAnnotation

Source project: `existingCodes\饶昌锋插件源代码\258吊架分类编号并标记\HangerClassificationAnnotation`

This is a compact reference excerpt generated from existing plug-ins. It preserves the command structure and key API usage without requiring the full `existingCodes/` tree during normal skill use.

## Command.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HangerClassificationAnnotation
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]
    public class Command : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            bool flag = true;
            HangerFilter hangerFilter = new HangerFilter();
            Reference reference = null;
            try
            {
                reference = uidoc.Selection.PickObject(ObjectType.Element, hangerFilter, "请选择");
            }
            catch (Exception)
            {
                return Result.Cancelled;
            }
            FamilyInstance familyInstance = doc.GetElement(reference) as FamilyInstance;
            FamilySymbol familySymbol = familyInstance.Symbol;
            Family family = familySymbol.Family;
            Document familyDoc = doc.EditFamily(family);
            Element element = doc.GetElement(reference);
            //Parameter parameter = doc.GetElement(reference).LookupParameter("类别编号");
            Parameter isParameter = element.LookupParameter("类别编号");
            //创建新的属性 并重新加载到项目中
            if (isParameter == null)
            {
                using (Transaction tran1 = new Transaction(familyDoc, "添加属性"))
                {
                    tran1.Start();
                    CustomFamilyLoadOptions options = new CustomFamilyLoadOptions();
                    try
                    {
                        FamilyParameter familyParameter = familyDoc.FamilyManager.AddParameter("类别编号", BuiltInParameterGroup.PG_IDENTITY_DATA, ParameterType.Text, true);
                    }
                    catch (Autodesk.Revit.Exceptions.ArgumentException)
                    {
                        familyDoc.LoadFamily(doc, options);
                    }
                    familyDoc.LoadFamily(doc, options);
                    tran1.Commit();
                }
            }

            //获取当前所有的族实例
            ElementFilter filter = new FamilyInstanceFilter(doc, familySymbol.Id);
            FilteredElementCollector collector1 = new FilteredElementCollector(doc);
            ICollection<Element> elementList1 = collector1.WherePasses(filter).ToElements();
            collector1.Dispose();
            string[,] arrayList = new string[elementList1.Count, 4];
            List<int> letters = new List<int>();
            //字母列表 给类型编号用
            for (int i = 1; i <= 2000; i++)
            {
                letters.Add(i);
            }
            //给新创建的类别编号赋值 
            using (Transaction tran = new Transaction(doc, "修改类别编号"))
            {
                //tran.Start();
                ////清空参数
                //foreach (Element elem in elementList1)
                //{
                //    elem.LookupParameter("类别编号").Set("");
                //}
                //tran.Commit();
                tran.Start();
                //获取清空后的所有类型
                FilteredElementCollector collector2 = new FilteredElementCollector(doc);
                ICollection<Element> elementList2 = collector2.WherePasses(filter).ToElements();
                //遍历赋值
                foreach (Element elem in elementList2)
                {
                    string a = "";
// ... truncated ...
```

## DynamicModelUpdate\UpdateCommand.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class UpdateCommand : IExternalCommand
    {
        public static ChangeType ChangeType;
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            Document doc = commandData.Application.ActiveUIDocument.Document;
            MyUpdater myUpdater = new MyUpdater(commandData.Application.ActiveAddInId);
            if (UpdaterRegistry.IsUpdaterRegistered(myUpdater.GetUpdaterId(),doc))
            {
                UpdaterRegistry.RemoveDocumentTriggers(myUpdater.GetUpdaterId(), doc);
                UpdaterRegistry.UnregisterUpdater(myUpdater.GetUpdaterId(), doc);
            }
            UpdaterRegistry.RegisterUpdater(myUpdater, doc,true);
            ElementFilter elementFilter = new ElementClassFilter(typeof(CableTray));
            UpdaterRegistry.AddTrigger(myUpdater.GetUpdaterId(), doc, elementFilter, Element.GetChangeTypeGeometry());
            throw new NotImplementedException();
        }
    }
}

```

## DynamicModelUpdate\UpdaterSwitchCommand.cs

```csharp
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicModelUpdate
{
    [Transaction(TransactionMode.Manual)]
    public class UpdaterSwitchCommand : IExternalCommand
    {
       
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            MyUpdater myUpdater = new MyUpdater(commandData.Application.ActiveAddInId);
            if (UpdaterRegistry.IsUpdaterRegistered(myUpdater.GetUpdaterId()))
            {
                if (UpdaterRegistry.IsUpdaterEnabled(myUpdater.GetUpdaterId()))
                {
                    UpdaterRegistry.DisableUpdater(myUpdater.GetUpdaterId());
                }
                else
                {
                    UpdaterRegistry.EnableUpdater(myUpdater.GetUpdaterId());
                }
            }
            return Result.Succeeded;
        }
    }
}

```

