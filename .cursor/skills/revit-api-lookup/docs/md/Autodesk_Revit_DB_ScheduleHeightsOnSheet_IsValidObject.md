---
kind: property
id: P:Autodesk.Revit.DB.ScheduleHeightsOnSheet.IsValidObject
source: html/fc2efcc1-ad5f-1b7e-387e-2bec362b99dc.htm
---
# Autodesk.Revit.DB.ScheduleHeightsOnSheet.IsValidObject Property

Specifies whether the .NET object represents a valid Revit entity.

## Syntax (C#)
```csharp
public bool IsValidObject { get; }
```

## Returns
True if the API object holds a valid Revit native object, false otherwise.

## Remarks
If the corresponding Revit native object is destroyed, or creation of the corresponding object is undone,
 a managed API object containing it is no longer valid. API methods cannot be called on invalidated wrapper objects.

