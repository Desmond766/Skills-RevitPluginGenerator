---
kind: property
id: P:Autodesk.Revit.DB.BRepBuilderSurfaceGeometry.IsValidObject
source: html/073f35f9-8a25-b8d7-7e75-a2e3ec8c7e0f.htm
---
# Autodesk.Revit.DB.BRepBuilderSurfaceGeometry.IsValidObject Property

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

