---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.GetInteriorPoints
source: html/b32902d7-16d8-58ca-ed8f-7229f6734276.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.GetInteriorPoints Method

Gets all of the points that are not boundary points for the topography surface.

## Syntax (C#)
```csharp
public IList<XYZ> GetInteriorPoints()
```

## Returns
The collection of interior points.

## Remarks
This applies to TopographySurface, SiteSubRegion, and the topography surface associated with a BuildingPad element.
 For a SiteSubRegion, this returns the points inherited from the host TopographySurface.
 For the topography surface associated with a BuildingPad element, this returns an empty collection.

