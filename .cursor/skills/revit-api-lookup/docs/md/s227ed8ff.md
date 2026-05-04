---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.IsBoundaryPoint(Autodesk.Revit.DB.XYZ)
source: html/e9bceb03-79f8-d0e6-0216-39eb0993addf.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.IsBoundaryPoint Method

Identifies whether the given point is an existing boundary point of the current topography surface.

## Syntax (C#)
```csharp
public bool IsBoundaryPoint(
	XYZ point
)
```

## Parameters
- **point** (`Autodesk.Revit.DB.XYZ`) - The point to be checked.

## Returns
Returns true if a given point is an existing boundary point.
 For TopographySurface and SiteSubRegion elements, it returns false if the given point is an existing interior point of current topography surface.
 For the topography surface associated with a BuildingPad element, it always returns true if the point is a part of the element (all points are boundary
 points for the topography surface associated with a BuildingPad element).

## Remarks
This applies to TopographySurface, SiteSubRegion, and the topography surface associated with a BuildingPad element.
 The given point will be evaluated in XYZ. If a point matches the XY location, but not the elevation, an ArgumentException will be thrown
 if this point does not exist in current topography surface.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input point does not exist in the current topography surface.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

