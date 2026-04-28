---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementGeometryCalculator.IsValidObject
source: html/36c35ab6-827a-ba22-d17b-d663cb3230b5.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryCalculator.IsValidObject Property

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

