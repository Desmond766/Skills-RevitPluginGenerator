---
kind: method
id: M:Autodesk.Revit.DB.FillGrid.GetPointLineZone(Autodesk.Revit.DB.UV,Autodesk.Revit.DB.UV@)
source: html/f91284a4-7e4a-8c8d-bda2-85d378e0f3c1.htm
---
# Autodesk.Revit.DB.FillGrid.GetPointLineZone Method

Gets the index of fill grid line and the point on the grid line nearest to the input point.

## Syntax (C#)
```csharp
public int GetPointLineZone(
	UV point,
	out UV nearestPoint
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.UV`) - Input point.
- **nearestPoint** (`Autodesk.Revit.DB.UV %`) - The point on the grid line nearest to the input point.

## Returns
The index of fill grid line.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

