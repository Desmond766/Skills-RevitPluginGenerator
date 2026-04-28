---
kind: method
id: M:Autodesk.Revit.DB.CurveByPoints.SetPoints(Autodesk.Revit.DB.ReferencePointArray)
source: html/706e73cb-eca6-9ffd-8582-611ef390d6b5.htm
---
# Autodesk.Revit.DB.CurveByPoints.SetPoints Method

Change the sequence of points interpolated by this curve.

## Syntax (C#)
```csharp
public void SetPoints(
	ReferencePointArray points
)
```

## Parameters
- **points** (`Autodesk.Revit.DB.ReferencePointArray`) - An array of 2 or more ReferencePoints.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when
the array contains fewer than 2 points, when the array
contains duplicates, or when adjacent points are
located too close together.

