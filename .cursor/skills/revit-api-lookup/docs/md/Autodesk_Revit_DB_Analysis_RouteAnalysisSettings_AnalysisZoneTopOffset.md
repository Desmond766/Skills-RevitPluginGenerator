---
kind: property
id: P:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.AnalysisZoneTopOffset
source: html/9fe08a3f-976f-223b-6350-2e2565d9a16e.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.AnalysisZoneTopOffset Property

The top plane offset, in ft, for the zone used in route calculation. Default value is 6'8".

## Syntax (C#)
```csharp
public double AnalysisZoneTopOffset { get; set; }
```

## Remarks
The zone's top plane elevation is different per plan view
 and is determined by adding the top offset to the view's level elevation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for topOffset must be non-negative.

