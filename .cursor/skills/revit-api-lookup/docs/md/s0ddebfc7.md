---
kind: method
id: M:Autodesk.Revit.DB.CurveElement.SetSketchPlaneAndCurve(Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.Curve)
source: html/99c03261-aeb7-032f-d71e-1e03716cbfb3.htm
---
# Autodesk.Revit.DB.CurveElement.SetSketchPlaneAndCurve Method

Sets the sketch plane and the curve for this CurveElement.

## Syntax (C#)
```csharp
public void SetSketchPlaneAndCurve(
	SketchPlane sketchPlane,
	Curve curve
)
```

## Parameters
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The new sketch plane.
- **curve** (`Autodesk.Revit.DB.Curve`) - The new curve.

## Remarks
Unlike the setters of SketchPlane and GeometryCurve , 
this method will reset relationships between the two properties and with other elements.
To set a geometry curve which belongs to a sketch-based elements, use GeometryCurve

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown if the argument is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the CurveElement is CurveByPoints or belongs to a Path3d element. -- or --
Thrown if the sketch plane is set on a DetailCurve. -- or --
Thrown if the sketch plane is not suitable. -- or --
Thrown if the CurveElement belongs to a sketch-based element. -- or --
Thrown if modifying the sketch plane is not allowed. -- or --
Thrown if the CurveElement cannot be moved out of its sketch plane. -- or --
Thrown if the input curve is of a type different from the current. -- or --
Thrown if the input curve is bound and the current is not or vice versa. -- or --
Thrown if the input curve is helical. -- or --
Thrown if the input curve lies outside of the SketchPlane of the current curve.

