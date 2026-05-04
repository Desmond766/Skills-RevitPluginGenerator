---
kind: method
id: M:Autodesk.Revit.DB.Face.Intersect(Autodesk.Revit.DB.Curve,Autodesk.Revit.DB.IntersectionResultArray@)
source: html/3513f5e2-a274-4f60-4d8f-78145930a9e3.htm
---
# Autodesk.Revit.DB.Face.Intersect Method

Calculates the intersection of the specified curve with this face and returns the intersection results.

## Syntax (C#)
```csharp
public SetComparisonResult Intersect(
	Curve curve,
	out IntersectionResultArray results
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The specified curve to intersect with this face.
- **results** (`Autodesk.Revit.DB.IntersectionResultArray %`) - Provides more information about the intersection.

## Returns
SetComparisonResult.Overlap - One or more intersections were encountered. The output argument has the results. SetComparisonResult.Subset - The curve is coincident with the surface. SetComparisonResult.Disjoint - There is no intersection found.

## Remarks
The array of the intersection results contains one entry for each point where this face and the curve intersect.
The following is the meaning of IntersectionResult's members:
 XYZPoint is the evaluated intersection point. UVPoint is the intersection parameters on the face. Parameter is the raw intersection parameter on the curve. EdgeObject is the edge if the intersection happens to be near an edge of the face. EdgeParameter is the parameter of the nearest point on the edge.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - The curve is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The intersection calculation fails.

