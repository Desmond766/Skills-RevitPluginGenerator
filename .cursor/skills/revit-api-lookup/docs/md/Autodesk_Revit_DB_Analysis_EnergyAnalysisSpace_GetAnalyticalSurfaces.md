---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.GetAnalyticalSurfaces
source: html/ed3a5d9b-8fbc-b17f-df57-6fc1033cb491.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSpace.GetAnalyticalSurfaces Method

Provides a way to access the collection of
 analytical surfaces for a space.
 Geometry data defining an analytical space volume.
 Through an analytical surface you can connect a
 source element with each polygon in a space.
 The analytical surfaces defines an enclosed volume
 bounded by the center plane of walls
 and the top plane of roofs and floors.

## Syntax (C#)
```csharp
public IList<EnergyAnalysisSurface> GetAnalyticalSurfaces()
```

## Returns
the collection of analytical surfaces for a space.

