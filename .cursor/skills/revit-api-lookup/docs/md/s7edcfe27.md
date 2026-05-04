---
kind: method
id: M:Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.GetPolyloops
source: html/e4c184ff-c645-2ddb-fd85-834e415efd14.htm
---
# Autodesk.Revit.DB.Analysis.EnergyAnalysisOpening.GetPolyloops Method

Gets the collection of planar polygons describing the opening geometry.

## Syntax (C#)
```csharp
public IList<Polyloop> GetPolyloops()
```

## Returns
The collection of polygons describing the opening geometry.

## Remarks
A collection of polyloops (planar polygons) describing the opening geometry as described
 in gbXML. The geometry is currently measured per analytical(center-line).

