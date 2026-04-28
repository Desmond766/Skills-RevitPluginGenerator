---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings.AreIntermediateColorsValid(System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.AnalysisDisplayColorEntry})
source: html/a721b73d-f41d-82f7-4344-a81a5ecd8f7d.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings.AreIntermediateColorsValid Method

Verify intermediate color entries

## Syntax (C#)
```csharp
public bool AreIntermediateColorsValid(
	IList<AnalysisDisplayColorEntry> map
)
```

## Parameters
- **map** (`System.Collections.Generic.IList < AnalysisDisplayColorEntry >`) - Array of intermediate color entries.

## Returns
True if intermediate colors are valid, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

