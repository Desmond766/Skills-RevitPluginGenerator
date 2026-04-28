---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewCurveByPoints(Autodesk.Revit.DB.ReferencePointArray)
source: html/40741486-ce16-4aed-fa74-257a36ab7428.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewCurveByPoints Method

Create a 3d curve through two or more points in an Autodesk
Revit family document.

## Syntax (C#)
```csharp
public CurveByPoints NewCurveByPoints(
	ReferencePointArray points
)
```

## Parameters
- **points** (`Autodesk.Revit.DB.ReferencePointArray`) - Two or more PointElements. The curve will interpolate
these points.

## Returns
The newly created curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when points is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when points does not contain at least two PointElements.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the family is not a Conceptual Mass Family.

