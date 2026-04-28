---
kind: type
id: T:Autodesk.Revit.DB.Architecture.TopographySurface
source: html/64242f41-69e1-84be-f21b-84783e81364a.htm
---
# Autodesk.Revit.DB.Architecture.TopographySurface

Represents a TopographySurface element.

## Syntax (C#)
```csharp
public class TopographySurface : Element
```

## Remarks
TopographySurface and related classes have been replaced as of Revit 2024 with Toposolid and related classes.
 It is recommended that all newly created elements and modifications operate from the new Toposolid class. The TopographySurface element remains in the API for backwards compatibility and upgrade.
 A TopographySurface element in the Revit API represents:
 An actual topography surface which can have an arbitrary boundary and collection of points. A SiteSubRegion element bounded by a sketch. A topography surface created automatically by the introduction of a BuildingPad element. 
 Identify a subregion with the IsSiteSubRegion property, and access the object that provides interfaces to manipulate the subregion via AsSiteSubRegion().
 Identify a topography surface associated with a building pad with the isAssociatedWithBuildingPad property, and access the associated BuildingPad element via the property AssociatedBuildingPadId.
 If the element does represent a subregion or a topography surface associated with a building pad, some methods of this class are inapplicable.

