---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.GetPoints
source: html/f2fbdda9-c064-4167-7b4a-3a7e3086cf69.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.GetPoints Method

Gets the points that define this topography surface.

## Syntax (C#)
```csharp
public IList<XYZ> GetPoints()
```

## Returns
The collection of points.

## Remarks
This applies to TopographySurface, SiteSubRegion, and the topography surface associated with a BuildingPad element.
 For a SiteSubRegion, this returns the points from a representation of the region's boundary as well as the points inherited from the host TopographySurface.
 For the topography surface associated with a BuildingPad element, this returns the points from the sketch of this topography surface(there are no interior points for this topography surface).

