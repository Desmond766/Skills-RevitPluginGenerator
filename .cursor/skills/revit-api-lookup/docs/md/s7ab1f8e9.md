---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.ColorRangeHeight
source: html/636fafe6-f687-0bfc-f832-f14422303d90.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.ColorRangeHeight Property

Height of color range (for Colored Surface, Markers and Text, and Vector display). Measured in paperspace units.

## Syntax (C#)
```csharp
public int ColorRangeHeight { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - When setting this property: colorRangeHeight is greater than 10000 or less than 0

