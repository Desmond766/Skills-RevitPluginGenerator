---
kind: method
id: M:Autodesk.Revit.DB.Curve.ComputeClosestPoints(Autodesk.Revit.DB.Curve,System.Boolean,System.Boolean,System.Boolean,System.Collections.Generic.IList{Autodesk.Revit.DB.ClosestPointsPairBetweenTwoCurves}@)
zh: 曲线
source: html/04ab73d1-bc85-9b87-aace-4272a0c7c3e4.htm
---
# Autodesk.Revit.DB.Curve.ComputeClosestPoints Method

**中文**: 曲线

Find the closest points between two curves. 
 Closest points mean closest pairs of points, each pair consisting of a point on this, say P1, and a point on other curve, say P2. 
 P1 and P2 are closest locally.
 Each pairs of closest points will be represented by the corresponding parameter values with respect to the two curves and the 3d points.
 A closest pair is also known as a pair of critical points of the distance function between points of the two curves.
 If the input parameter returnAllCriticalPoints is set to false, then the function will return only pairs with minimum distance.

## Syntax (C#)
```csharp
public void ComputeClosestPoints(
	Curve otherCurve,
	bool withinThisCurveBounds,
	bool withinOtherCurveBounds,
	bool returnAllCriticalPnts,
	out IList<ClosestPointsPairBetweenTwoCurves> resultList
)
```

## Parameters
- **otherCurve** (`Autodesk.Revit.DB.Curve`) - The specified curve used to compute closest points to this curve.
- **withinThisCurveBounds** (`System.Boolean`) - If this parameter is true only the solutions that are between this curve bounds will be returned.
 This curve must be bound if this parameter is true.
- **withinOtherCurveBounds** (`System.Boolean`) - If this parameter is true only the solutions that are between other curve bounds will be returned.
 The other curve must be bound if this parameter is true.
- **returnAllCriticalPnts** (`System.Boolean`) - The input parameter returnAllCriticalPnts is used to tell if all the critical points of the
 distance function are to be returned.
- **resultList** (`System.Collections.Generic.IList < ClosestPointsPairBetweenTwoCurves > %`) - Output parameter that will contain the results collection.

## Remarks
The output list of closest points contains one entry for each pair of closest points.
The following is the meaning of every ClosestPointsPairBetweenTwoCurves's members:
 XYZPointOnFirstCurve is the closest point on the first curve; XYZPointOnSecondCurve is the closest point on the second curve; ParameterOnFirstCurve is the raw (not normalized) parameter on the first curve ParameterOnSecondCurve is the raw (not normalized) parameter on the second curve Distance is the distance from the closest point on the first curve to the closest point on the second curve.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when otherCurve argument is null.
 Thrown when resultArray is null.
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - Thrown when withinThisCurveBounds is true and this curve is unbounded.
 Thrown when withinOtherCurveBounds is true and other curve is unbounded.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the method failed. For example the problem has infinitely many solutions
 such as two parallel lines or two concentric circles, or in other singular cases that the method currently cannot handle, 
 such as evaluating the closest points between a spline and a line, and the spline contains
 a flat segment (all points on the segment have zero curvature), and the closest points 
 lie within that flat segment.

