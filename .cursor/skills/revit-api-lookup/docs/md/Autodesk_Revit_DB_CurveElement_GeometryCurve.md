---
kind: property
id: P:Autodesk.Revit.DB.CurveElement.GeometryCurve
source: html/713ec948-c85c-24fa-0668-c2c2bbdc4c73.htm
---
# Autodesk.Revit.DB.CurveElement.GeometryCurve Property

Geometry curve of the curve element.

## Syntax (C#)
```csharp
public Curve GeometryCurve { get; set; }
```

## Remarks
When setting this property, any curves that this curve is currently joined to will affect the result -
the final geometry of this curve and of the joined curves may change.
To avoid the effect of existing joins, use SetGeometryCurve(Curve, Boolean) with true passed ot overrideJoins.
After the curve geometry is set, other nearby curves may join to the new curve geometry.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input curve is of a type different from the current. -- or --
Thrown if the input curve is bound and the current is not or vice versa. -- or --
Thrown if the input curve is helical. -- or --
Thrown if the input curve lies outside of the SketchPlane of the current curve and the CurveElement is not CurveByPoints.

