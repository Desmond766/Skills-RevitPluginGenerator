---
kind: property
id: P:Autodesk.Revit.DB.ScheduleSheetInstance.Rotation
source: html/bf164c57-a523-252c-1ba6-bd15c7049eeb.htm
---
# Autodesk.Revit.DB.ScheduleSheetInstance.Rotation Property

Rotation of the ScheduleInstance.

## Syntax (C#)
```csharp
public ViewportRotation Rotation { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: This operation is prohibited for ScheduleInstances associated with revision schedules in titleblocks.
 -or-
 When setting this property: This operation is prohibited for ScheduleInstances that are pinned.

