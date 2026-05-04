---
kind: property
id: P:Autodesk.Revit.DB.ScheduleSheetInstance.IsTitleblockRevisionSchedule
source: html/14b7f666-18be-d81f-9f75-86f158600e8c.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance.IsTitleblockRevisionSchedule Property

Identifies if this ScheduleSheetInstance is a revision schedule in a titleblock family.

## Syntax (C#)
```csharp
public bool IsTitleblockRevisionSchedule { get; }
```

## Remarks
These schedule instances should not be modified in the project environment. To modify the revision schedule on a titleblock, edit the titleblock family.

