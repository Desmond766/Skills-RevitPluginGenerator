---
kind: method
id: M:Autodesk.Revit.DB.ViewSheet.GetAdditionalRevisionIds
zh: 图纸
source: html/6d852f22-cf1b-3bcb-c255-184998d1334c.htm
---
# Autodesk.Revit.DB.ViewSheet.GetAdditionalRevisionIds Method

**中文**: 图纸

Gets the Revisions that are additionally included in the sheet's revision schedules.

## Syntax (C#)
```csharp
public ICollection<ElementId> GetAdditionalRevisionIds()
```

## Returns
The additionally included Revisions for the sheet's revision schedules.

## Remarks
Revisions in the sheet's additional project revisions set will appear in revisions schedules
 even if no RevisionCloud belonging to that Revision is visible on the sheet.
 These ids correspond to the Revisions that are explicitly included on the sheet via the
 Revisions On Sheet parameter.

