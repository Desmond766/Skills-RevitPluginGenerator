---
kind: property
id: P:Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.ColorRangeWidth
source: html/a98657a9-8ac9-cfa2-78e3-c75957f61a33.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayLegendSettings.ColorRangeWidth Property

Width of color range (for Colored Surface, Markers and Text, and Vector display). Measured in paperspace units.

## Syntax (C#)
```csharp
public int ColorRangeWidth { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - When setting this property: colorRangeWidth is greater than 10000 or less than 0

