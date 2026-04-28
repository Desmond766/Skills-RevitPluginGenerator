---
kind: type
id: T:Autodesk.Revit.DB.Architecture.SiteSubRegion
source: html/98cf9a80-873e-3703-5a95-a87672adf383.htm
---
# Autodesk.Revit.DB.Architecture.SiteSubRegion

Represents a proxy class exposing the interfaces needed to access details of a subregion.

## Syntax (C#)
```csharp
public class SiteSubRegion : IDisposable
```

## Remarks
In the Revit database, both TopographySurface elements and subregion elements are represented by the same TopographySurface element subclass.
 In the Revit API, this SiteSubRegion class exists to separate the interfaces for subregions from those of topography surfaces.

