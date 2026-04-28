---
kind: method
id: M:Autodesk.Revit.DB.Architecture.TopographySurface.GetHostedSubRegionIds
source: html/e491ee31-108d-a79a-267e-2fe01a0d5065.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface.GetHostedSubRegionIds Method

Gets the ids of all subregion elements hosted on this topography surface.

## Syntax (C#)
```csharp
public IList<ElementId> GetHostedSubRegionIds()
```

## Returns
The hosted subregion ids.

## Remarks
This applies to a TopographySurface element (not a SiteSubRegion or a topography surface associated with a BuildingPad).
 This applies to TopographySurface and SiteSubRegion elements.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This element is not a TopographySurface.

