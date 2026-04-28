---
kind: type
id: T:Autodesk.Revit.DB.ScheduleSheetInstance
source: html/68db8e46-90de-6b54-3dae-598957d94201.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance

An element that represents a particular placement of a schedule on a sheet.

## Syntax (C#)
```csharp
public class ScheduleSheetInstance : Element
```

## Remarks
Use ScheduleSheetInstance.OwnerViewId to find the sheet on which a schedule is placed.
When a schedule is set to filter by sheet and placed on a sheet, it will create a new schedule with elements visible
 in the Viewport(s) on that sheet. The instance created belongs to the newly created schedule.

