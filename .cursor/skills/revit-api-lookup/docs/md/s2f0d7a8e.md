---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetAllRevisionCloudIds
zh: 图纸
source: html/dd1487e6-dffa-5c9c-8fcc-ff8f664b494e.htm
---
# Autodesk.Revit.DB.ViewSheet.GetAllRevisionCloudIds Method

**中文**: 图纸

Gets the ids of the revision clouds which appear on the sheet's revision schedules.

## Syntax (C#)
```csharp
public ISet<ElementId> GetAllRevisionCloudIds()
```

## Returns
The ids of the revisions clouds which appear on the sheet's revision schedules.

## Remarks
The sheet's revision schedules include the revisions that are associated with revision clouds that are visible on the sheet.
 Revision schedules may also include revisions that have been additionally added to the sheet via the Revisions On Sheets parameter.
 Use GetAdditionalRevisionIds () () () to get the additionally added revisions.

