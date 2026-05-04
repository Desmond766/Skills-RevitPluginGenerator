---
kind: method
id: M:Autodesk.Revit.DB.Outline.Contains(Autodesk.Revit.DB.XYZ,System.Double)
source: html/3e10329e-4114-73f7-65a6-17bf40056be9.htm
---
# Autodesk.Revit.DB.Outline.Contains Method

Determine if this Outline contains the specified point to within a tolerance.

## Syntax (C#)
```csharp
public bool Contains(
	XYZ point,
	double tolerance
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to test for containment.
- **tolerance** (`System.Double`) - The tolerance to use when determining whether the point is contained. Defaults to zero.

## Returns
True if this outline contains the given point, or false otherwise.

## Remarks
If the tolerance is positive, the point may lie up to the tolerance amount outside the outline in each coordinate.
 If the tolerance is negative, the point must lie at least the tolerance amount inside the outline in each coordinate.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

