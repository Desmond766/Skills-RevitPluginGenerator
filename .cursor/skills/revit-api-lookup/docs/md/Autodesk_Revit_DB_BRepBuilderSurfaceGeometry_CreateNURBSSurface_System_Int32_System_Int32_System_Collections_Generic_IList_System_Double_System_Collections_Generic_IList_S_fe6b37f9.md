---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilderSurfaceGeometry.CreateNURBSSurface(System.Int32,System.Int32,System.Collections.Generic.IList{System.Double},System.Collections.Generic.IList{System.Double},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{System.Double},System.Boolean,Autodesk.Revit.DB.BoundingBoxUV)
source: html/04ce47fc-117b-8e48-c388-7f2de2bbaa96.htm
---
# Autodesk.Revit.DB.BRepBuilderSurfaceGeometry.CreateNURBSSurface Method

Construct BRepBuilderSurfaceGeometry based on NURBS surface data, where the weights are supplied.
 In this case, the NURBS surface will be a piecewise rational polynomial surface.

## Syntax (C#)
```csharp
public static BRepBuilderSurfaceGeometry CreateNURBSSurface(
	int degreeU,
	int degreeV,
	IList<double> knotsU,
	IList<double> knotsV,
	IList<XYZ> controlPoints,
	IList<double> weights,
	bool bReverseOrientation,
	BoundingBoxUV surfaceEnvelope
)
```

## Parameters
- **degreeU** (`System.Int32`) - The degree of the spline in the u-direction; must be positive.
- **degreeV** (`System.Int32`) - The degree of the spline in the v-direction; must be positive.
- **knotsU** (`System.Collections.Generic.IList < Double >`) - Knot values in the u-direction.
 The number of knots in the u-direction must be at least 2 * (degreeU + 1).
- **knotsV** (`System.Collections.Generic.IList < Double >`) - Knot values in the v-direction.
 The number of knots in the v-direction must be at least 2 * (degreeV + 1).
- **controlPoints** (`System.Collections.Generic.IList < XYZ >`) - One dimensional array of points representing the two dimensional net of control points
 of the NURBS surface in u and v directions.
The total number of control points must equal numControlPtsU times numControlPtsV,
 where numControlPtsU and numControlPtsV are the numbers of control points in u and v directions,
 and they must satisfy the following conditions:
 numControlPtsU = number of knots in u - degreeU - 1. numControlPtsV = number of knots in v - degreeV - 1. 
 The convention for 2d (idxU, idxV) to 1d (idx) conversion of array indexes: idxV first.
 That is, idxU is outer loop and idxV is inner loop. In other words,
 idx = idxU * numControlPtsV + idxV.
- **weights** (`System.Collections.Generic.IList < Double >`) - Array of weights assigned to the control points.
 The number of weights must equal the number of control points.
 All weights should be greater than zero.
- **bReverseOrientation** (`System.Boolean`) - If true, the surface's orientation is opposite to the canonical parametric orientation, otherwise it is the same.
 The canonical parametric orientation is a counter-clockwise sense of rotation in the uv-parameter plane.
 Extrinsically, the oriented normal vector for the canonical parametric orientation points in the direction of
 the cross product dS/du x dS/dv, which S(u, v) is the parameterized surface.
- **surfaceEnvelope** (`Autodesk.Revit.DB.BoundingBoxUV`) - Envelope of the surface in the uv parametric domain. Defines the domain of interest for the created surface.
 This is typically used to identify the domain of the face that references the surface in question.
 Expected to either be null or define a valid domain.

## Remarks
A rational polynomial is a quotient of two polynomials; this includes a polynomial,
 which can be thought of as a quotient with denominator equal to 1.
 If all the weights are equal, then the NURBS surface will be a piecewise polynomial surface.This class does not handle periodic Nurbs surfaces.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The U-degree value must be at least 1.
 -or-
 The V-degree value must be at least 1.
 -or-
 The number of knots in the U direction must be at least 2 times the U-degree plus 1.
 -or-
 The number of knots in the V direction must be at least 2 times the V-degree plus 1.
 -or-
 The number of control points must equal (number of U-knots - U-degree - 1) * (number of V-knots - V-degree - 1).
 -or-
 The number of weights must be the same as the number of control points and all weights must be positive or all zero.
 -or-
 The input data does not define a valid Nurbs surface.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Nurbs surface could not be converted for use in Revit. It may have C2-discontinuities or be too large.

