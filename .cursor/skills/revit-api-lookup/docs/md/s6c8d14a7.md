---
kind: method
id: M:Autodesk.Revit.DB.RevisionCloud.GetSheetIds
source: html/07ff2f25-9201-24aa-e025-502200af0379.htm
---
# Autodesk.Revit.DB.RevisionCloud.GetSheetIds Method

Returns the ids of the ViewSheets where this RevisionCloud may appear and contribute to the sheet's revision schedule.

## Syntax (C#)
```csharp
public ISet<ElementId> GetSheetIds()
```

## Returns
The ids of the ViewSheets where this RevisionCloud may appear.

## Remarks
A RevisionCloud can appear on a ViewSheet because it is drawn directly on the ViewSheet
 or because its owner view is placed on the ViewSheet. If the RevisionCloud is owned by
 a view that is a dependent view or has associated dependent views, then the RevisionCloud can also
 be visible on the sheets where the related dependent or primary views have been placed.
 This RevisionCloud may not be visible in all ViewSheets reported by this method.
 Additional factors, such as the visibility settings or annotation crop of the Views or the visibility settings
 of the associated Revision may still cause this RevisionCloud to not appear on a particular ViewSheet. If this RevisionCloud is owned by a ViewLegend, no sheets will be returned because the RevisionCloud
 will not participate in revision schedules.

