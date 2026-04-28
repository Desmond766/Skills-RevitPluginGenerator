---
kind: method
id: M:Autodesk.Revit.Creation.FamilyItemFactory.NewRevolution(System.Boolean,Autodesk.Revit.DB.CurveArrArray,Autodesk.Revit.DB.SketchPlane,Autodesk.Revit.DB.Line,System.Double,System.Double)
source: html/efde572e-b5fa-14c8-6a1a-a46e36927374.htm
---
# Autodesk.Revit.Creation.FamilyItemFactory.NewRevolution Method

Add a new Revolution instance into the Autodesk Revit family document.

## Syntax (C#)
```csharp
public Revolution NewRevolution(
	bool isSolid,
	CurveArrArray profile,
	SketchPlane sketchPlane,
	Line axis,
	double startAngle,
	double endAngle
)
```

## Parameters
- **isSolid** (`System.Boolean`) - Indicates if the Revolution is Solid or Void.
- **profile** (`Autodesk.Revit.DB.CurveArrArray`) - The profile of the newly created revolution. This may contain
more than one curve loop. Each loop must be a fully closed curve loop and the loops 
must not intersect. All loops must lie in the same plane.
The loop can be a unbound circle or ellipse, but its geometry will be split in two in 
order to satisfy requirements for sketches used in extrusions.
- **sketchPlane** (`Autodesk.Revit.DB.SketchPlane`) - The sketch plane for the revolution. The direction of revolution
is determined by the normal for the sketch plane.
- **axis** (`Autodesk.Revit.DB.Line`) - The axis of revolution. This axis must lie in the same plane as the curve loops.
- **startAngle** (`System.Double`) - The start angle of Revolution in radians.
- **endAngle** (`System.Double`) - The end angle of Revolution in radians.

## Returns
If creation was successful the new revolution is returned, 
otherwise an exception with failure information will be thrown.

## Remarks
This method creates an Revolution in a family document. The Revolution will be 
rotated the plane of the Revolution profile about the Axis.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-profile-is Nothing nullptr a null reference ( Nothing in Visual Basic) or empty array.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-sketchPlane-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.ArgumentException** - Thrown when the input argument-sketchPlane-is an invalid sketch plane.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the input argument-axis-is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when creation is attempted in Conceptual Mass, 2D, or other family where revolutions cannot be created.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the creation failed.

