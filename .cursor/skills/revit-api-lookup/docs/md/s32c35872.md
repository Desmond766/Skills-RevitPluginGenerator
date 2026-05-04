---
kind: property
id: P:Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.AnalysisZoneBottomOffset
source: html/81229c75-be84-5d5e-7d90-cb61e6d08018.htm
---
# Autodesk.Revit.DB.Analysis.RouteAnalysisSettings.AnalysisZoneBottomOffset Property

The bottom plane offset, in ft, of the zone used in route calculation. Default value is 8".

## Syntax (C#)
```csharp
public double AnalysisZoneBottomOffset { get; set; }
```

## Remarks
The zone's bottom plane elevation is different per plan view
 and is determined by adding the bottom offset to the view's level elevation.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for bottomOffset must be non-negative.

