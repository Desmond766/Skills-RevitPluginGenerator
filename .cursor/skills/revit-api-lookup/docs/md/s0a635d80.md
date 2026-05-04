---
kind: property
id: P:Autodesk.Revit.DB.BRepBuilderEdgeGeometry.IsValidObject
source: html/b5e6346c-5061-37ad-677b-f5db3ccaa6cf.htm
---
# Autodesk.Revit.DB.BRepBuilderEdgeGeometry.IsValidObject Property

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

