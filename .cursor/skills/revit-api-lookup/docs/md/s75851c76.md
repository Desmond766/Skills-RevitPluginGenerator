---
kind: method
id: M:Autodesk.Revit.DB.WireframeBuilder.AddPoint(Autodesk.Revit.DB.Point)
source: html/5334339f-09ee-5ea2-6f11-29276c6e5cf6.htm
---
# Autodesk.Revit.DB.WireframeBuilder.AddPoint Method

Add a point to the shape representation stored in this WireframeBuilder.

## Syntax (C#)
```csharp
public void AddPoint(
	Point GPoint
)
```

## Parameters
- **GPoint** (`Autodesk.Revit.DB.Point`) - The point to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - GPoint is not acceptable for a wireframe shape representation.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

