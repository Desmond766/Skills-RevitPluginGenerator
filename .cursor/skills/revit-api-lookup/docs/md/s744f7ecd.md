---
kind: method
id: M:Autodesk.Revit.DB.Curve.Intersect(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.IntersectionResultArray@)
zh: 曲线
source: html/51961478-fb36-e00b-2d1b-7db27b0a09e6.htm
---
# Autodesk.Revit.DB.Curve.Intersect Method

**中文**: 曲线

Calculates the intersection of this curve with the specified curve and returns the intersection results.

## Syntax (C#)
```csharp
public SetComparisonResult Intersect(
	Curve curve,
	out IntersectionResultArray resultArray
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The specified curve to intersect with this curve.
- **resultArray** (`Autodesk.Revit.DB.IntersectionResultArray %`) - Provides more information about the intersection.

## Returns
SetComparisonResult.Overlap - One or more intersections were encountered. The output argument has the details. SetComparisonResult.Subset - The inputs are parallel lines with only one common intersection point, or 
the curve used to invoke the intersection check is a line entirely within the unbound line passed as argument curve.
If the former, the output argument has the details of the intersection point. SetComparisonResult.Superset - The input curve is entirely within the unbound line used to invoke the intersection check. SetComparisonResult.Disjoint - There is no intersection found between the two curves. SetComparisonResult.Equal - The two curves are identical.

## Remarks
The array of the intersection results contains one entry for each point where curves intersect.
The following is the meaning of IntersectionResult members:
 XYZPoint is the evaluated intersection point UVPoint.U is the unnormalized parameter on this curve (use ComputeNormalizedParameter to compute the normalized value). UVPoint.V is the unnormalized parameter on the specified curve (use ComputeNormalizedParameter to compute the normalized value).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - Thrown when the specified curve is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when failed to calculate the intersection.

