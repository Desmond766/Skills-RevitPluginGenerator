---
kind: method
id: M:Autodesk.Revit.DB.NurbsSurfaceData.Create(System.Int32,System.Int32,System.Collections.Generic.IList{System.Double},System.Collections.Generic.IList{System.Double},System.Collections.Generic.IList{Autodesk.Revit.DB.XYZ},System.Collections.Generic.IList{System.Double},System.Boolean)
zh: 创建、新建、生成、建立、新增
source: html/94b4c433-5458-d1ab-d5c9-f526f288d1ff.htm
---
# Autodesk.Revit.DB.NurbsSurfaceData.Create Method

**中文**: 创建、新建、生成、建立、新增

Construct NurbsSurfaceData based on NURBS surface data, where the weights are supplied.
 The NURBS surface will be (piecewise) polynomial if all the weights are equal, rational if not.
 Note: A rational polynomial is a quotient of two polynomials; this includes a polynomial,
 which can be thought of as a quotient with denominator equal to 1.

## Syntax (C#)
```csharp
public static NurbsSurfaceData Create(
	int degreeU,
	int degreeV,
	IList<double> knotsU,
	IList<double> knotsV,
	IList<XYZ> controlPoints,
	IList<double> weights,
	bool bReverseOrientation
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
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

