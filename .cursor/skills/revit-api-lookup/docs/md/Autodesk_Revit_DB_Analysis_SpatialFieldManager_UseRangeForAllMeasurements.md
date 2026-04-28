---
kind: property
id: P:Autodesk.Revit.DB.Analysis.SpatialFieldManager.UseRangeForAllMeasurements
source: html/41b134ca-63e1-6ecf-d93f-05be6946f712.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.UseRangeForAllMeasurements Property

Governs how minimum and maximum values (the data range) are calculated.

## Syntax (C#)
```csharp
public bool UseRangeForAllMeasurements { get; set; }
```

## Remarks
If true the data range is calculated from all measurements.
 Otherwise the data range is calculated from the current measurement only.

