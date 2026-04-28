---
kind: method
id: M:Autodesk.Revit.DB.NurbSpline.CreateCurve(System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{System.Double})
source: html/0ef02fb4-1ef1-6adb-dfb6-680eba6fed62.htm
---
# Autodesk.Revit.DB.NurbSpline.CreateCurve Method

Creates a new geometric Curve object from NURBS curve data containing just control points and weights.
 The created curve may be a NURBSpline or a simpler curve such as line or arc.

## Syntax (C#)
```csharp
public static Curve CreateCurve(
	IList<XYZ> controlPoints,
	IList<double> weights
)
```

## Parameters
- **controlPoints** (`System.Collections.Generic.IList < XYZ >`) - The control points of the NURBSpline.
- **weights** (`System.Collections.Generic.IList < Double >`) - The weights of the NURBSpline.

## Returns
The new Curve object.

## Remarks
There must be at least 2 control points.
 The number of weights must be equal to the the number of control points.
 The values of all weights must be positive.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The number of control points must be at least 2.
 -or-
 The number of weights must be the same as the number of control points and all weights must be positive.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

