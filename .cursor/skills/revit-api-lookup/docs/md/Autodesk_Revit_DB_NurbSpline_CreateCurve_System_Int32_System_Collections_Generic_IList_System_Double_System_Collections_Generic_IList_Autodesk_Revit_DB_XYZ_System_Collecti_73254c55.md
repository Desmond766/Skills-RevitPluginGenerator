---
kind: method
id: M:Autodesk.Revit.DB.NurbSpline.CreateCurve(System.Int32,System.Collections.Generic.IList{System.Double},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{System.Double})
source: html/a0d68a24-0bda-0322-111c-e9f1011149c9.htm
---
# Autodesk.Revit.DB.NurbSpline.CreateCurve Method

Creates a new geometric Curve object from NURBS curve data, which includes weights.
 The created curve may be a NURBSpline or a simpler curve such as line or arc.

## Syntax (C#)
```csharp
public static Curve CreateCurve(
	int degree,
	IList<double> knots,
	IList<XYZ> controlPoints,
	IList<double> weights
)
```

## Parameters
- **degree** (`System.Int32`) - The degree of the NURBSpline.
- **knots** (`System.Collections.Generic.IList < Double >`) - The knots of the NURBSpline.
- **controlPoints** (`System.Collections.Generic.IList < XYZ >`) - The control points of the NURBSpline.
- **weights** (`System.Collections.Generic.IList < Double >`) - The weights of the NURBSpline.

## Returns
The new Curve object.

## Remarks
Degree must be 1 or greater.
 The number of control points must be greater than degree.
 The number of knots must equal the sum of degree, number of controlPoints and 1.
 The distinct knot values (ignoring multiplicities) must be in increasing order.
 The first degree+1 knots should be identical, as should the last degree+1 knots.
 The multiplicities of other (interior) knots should be less than degree -1.
 The number of weights must be equal to the the number of control points.
 The values of all weights must be positive.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The degree must be at least 1.
 -or-
 The number of control points must be greater than degree.
 -or-
 The number of knots must equal the sum of number of control points, degree and 1.
 -or-
 An interior knot must not repeat itself more than degree times.
 -or-
 The number of weights must be the same as the number of control points and all weights must be positive.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was NULL
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Curve length is too small for Revit's tolerance (as identified by Application.ShortCurveTolerance).

