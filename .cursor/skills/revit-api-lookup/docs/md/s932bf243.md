---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.ScaleHeight
source: html/6b248871-befe-3b7b-68b9-1bdb65ae98e0.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.ScaleHeight Property

Height of scale (for Diagram display). Measured in paperspace units.

## Syntax (C#)
```csharp
public int ScaleHeight { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - When setting this property: scaleHeight is greater than 10000 or less than 0

