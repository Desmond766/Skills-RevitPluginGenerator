---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.GetPolyloops
source: html/21417a57-3811-d7f8-25c5-c50176bcf801.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisSurface.GetPolyloops Method

Gets the collection of planar polygons describing the surface geometry.

## Syntax (C#)
```csharp
public IList<Polyloop> GetPolyloops()
```

## Returns
The collection of polygons describing the surface geometry.

## Remarks
A collection of polyloops (planar polygons) describing the surface geometry as described
 in gbXML. The geometry is currently measured per analytical(center-line).

