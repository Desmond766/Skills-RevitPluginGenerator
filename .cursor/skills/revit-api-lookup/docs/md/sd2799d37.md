---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.SetGeometryCurve(Autodesk.Revit.DB.Curve,System.Boolean)
source: html/9deec90c-4efc-9aa6-245d-061669022aa2.htm
---
# Autodesk.Revit.DB.CurveElement.SetGeometryCurve Method

Sets the geometry of the curve element.
After the curve geometry is set, other nearby curves may join to the new curve geometry.

## Syntax (C#)
```csharp
public void SetGeometryCurve(
	Curve curve,
	bool overrideJoins
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The new curve.
- **overrideJoins** (`System.Boolean`) - An option to specify whether or not existing joins will affect setting the geometry of the CurveElement.
Setting this parameter to false is essentially the same as directly setting the GeometryCurve property.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown if the input curve is of a type different from the current. -- or --
Thrown if the input curve is bound and the current is not or vice versa. -- or --
Thrown if the input curve is helical. -- or --
Thrown if the input curve lies outside of the SketchPlane of the current curve and the CurveElement is not CurveByPoints.

