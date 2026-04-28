---
kind: method
id: M:Autodesk.Revit.DB.Face.Intersect(Autodesk.Revit.DB.Curve)
source: html/9a487e3d-bbb4-34b9-307d-2e4f63fddab6.htm
---
# Autodesk.Revit.DB.Face.Intersect Method

Calculates the intersection of the specified curve with this face.

## Syntax (C#)
```csharp
public SetComparisonResult Intersect(
	Curve curve
)
```

## Parameters
- **curve** (`Autodesk.Revit.DB.Curve`) - The specified curve to intersect with this face.

## Returns
SetComparisonResult.Overlap - One or more intersections were encountered. SetComparisonResult.Subset - The curve is coincident with the surface. SetComparisonResult.Disjoint - There is no intersection found.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - The curve is Nothing nullptr a null reference ( Nothing in Visual Basic) .
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The intersection calculation fails.

