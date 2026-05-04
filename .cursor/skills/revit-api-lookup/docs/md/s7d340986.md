---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.GetBoundaryPoints
source: html/f34dbefb-94de-43e8-967d-8662f6593dac.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.GetBoundaryPoints Method

Gets the points which are on the boundary of the topography surface.

## Syntax (C#)
```csharp
public IList<XYZ> GetBoundaryPoints()
```

## Returns
The collection of boundary points.

## Remarks
This applies to TopographySurface, SiteSubRegion, and the topography surface associated with a BuildingPad element.
 For a SiteSubRegion, this returns the points from a representation of the region's boundary.
 For the topography surface associated with a BuildingPad element, this returns the points from the sketch of this topography surface.

