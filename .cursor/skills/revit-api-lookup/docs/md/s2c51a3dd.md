---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.IsValidEdgeId(Autodesk.Revit.DB.BRepBuilderGeometryId)
source: html/3572f388-f282-9c72-fdec-9147b2687638.htm
---
# Autodesk.Revit.DB.BRepBuilder.IsValidEdgeId Method

A validator function that checks whether the edge id corresponds to an edge previously added to this BRepBuilder object.

## Syntax (C#)
```csharp
public bool IsValidEdgeId(
	BRepBuilderGeometryId edgeId
)
```

## Parameters
- **edgeId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Edge id to be validated.

## Returns
True if edgeId corresponds to an edge previously added to this BRepBuilder, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

