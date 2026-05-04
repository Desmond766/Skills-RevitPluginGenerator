---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.IsValidObject
source: html/192f91bf-34dc-7ca0-bb5d-b4c1b7979503.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.IsValidObject Property

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

