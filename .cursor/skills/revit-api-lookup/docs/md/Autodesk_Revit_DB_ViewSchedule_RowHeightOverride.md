---
kind: property
id: P:Autodesk.Revit.DB.ViewSchedule.RowHeightOverride
zh: 明细表
source: html/92cfddb5-13af-dc32-0b27-2f0fc35dbae2.htm
---
# Autodesk.Revit.DB.ViewSchedule.RowHeightOverride Property

**中文**: 明细表

Defines the override that is applied to the row height.

## Syntax (C#)
```csharp
public RowHeightOverrideOptions RowHeightOverride { get; set; }
```

## Remarks
Setting this property to anything but None will allow setting the RowHeight property.
 This is taken into account when the schedule is viewed as a ScheduleSheetInstance on a ViewSheet.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

