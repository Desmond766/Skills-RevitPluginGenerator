---
kind: method
id: M:Autodesk.Revit.DB.Curve.Intersect(Autodesk.Revit.DB.Curve)
zh: 曲线
source: html/90e86110-9bce-6e43-c18a-4d67380008bb.htm
---
# Autodesk.Revit.DB.Curve.Intersect Method

**中文**: 曲线

Calculates the intersection of this curve with the specified curve.

## Syntax (C#)
```csharp
public SetComparisonResult Intersect(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The specified curve to intersect with this curve.

## Returns
SetComparisonResult.Overlap - One or more intersections were encountered. SetComparisonResult.Subset - The inputs are parallel lines with only one common intersection point, or 
the curve used to invoke the intersection check is a line entirely within the unbound line passed as argument curve. SetComparisonResult.Superset - The input curve is entirely within the unbound line used to invoke the intersection check. SetComparisonResult.Disjoint - There is no intersection found between the two curves. SetComparisonResult.Equal - The two curves are identical.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - The specified curve is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Failed to calculate the intersection.

