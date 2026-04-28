---
kind: method
id: M:Autodesk.Revit.DB.Face.Intersect(Autodesk.Revit.DB.Face,Autodesk.Revit.DB.Curve@)
source: html/9498ae60-43cc-77b3-70e2-9098200b53fc.htm
---
# Autodesk.Revit.DB.Face.Intersect Method

Calculates the intersection of the specified face with this face and returns the intersection results.

## Syntax (C#)
```csharp
public FaceIntersectionFaceResult Intersect(
	Face face,
	out Curve result
)
```

## Parameters
- **face** (`Autodesk.Revit.DB.Face`) - The specified face to intersect with this face.
- **result** (`Autodesk.Revit.DB.Curve %`) - A single Curve representing the intersection.

## Returns
FaceIntersectionFaceResult.Intersecting - One or more intersections were encountered. SetComparisonResult.NonIntersecting - There is no intersection found.

## Remarks
This is not a general-purpose function: it only works properly for simple configurations.
For other configurations, it may return an incorrect result.
Some configurations for which the function might return a correct result are:
 A planar face that fully intersects another face in a single curve, when the other face is planar or cylindrical. A cylindrical face that fully intersects another face in a single curve, when the other face is planar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - The face is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The intersection calculation fails.

