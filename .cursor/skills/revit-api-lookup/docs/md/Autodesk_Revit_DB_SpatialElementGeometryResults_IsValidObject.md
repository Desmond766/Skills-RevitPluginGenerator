---
kind: property
id: P:Autodesk.Revit.DB.SpatialElementGeometryResults.IsValidObject
source: html/df7a6b72-d8d2-90e6-21f1-b5be1387288c.htm
---
# Autodesk.Revit.DB.SpatialElementGeometryResults.IsValidObject Property

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

