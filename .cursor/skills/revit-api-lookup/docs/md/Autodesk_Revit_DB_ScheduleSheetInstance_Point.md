---
kind: property
id: P:Autodesk.Revit.DB.ScheduleSheetInstance.Point
zh: 点
source: html/7bce07cc-eb07-d399-ed18-af09947cc32d.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance.Point Property

**中文**: 点

Location on the sheet where the ScheduleInstance is placed (in sheet coordinates).

## Syntax (C#)
```csharp
public XYZ Point { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation is prohibited for ScheduleInstances associated with revision schedules in titleblocks.

