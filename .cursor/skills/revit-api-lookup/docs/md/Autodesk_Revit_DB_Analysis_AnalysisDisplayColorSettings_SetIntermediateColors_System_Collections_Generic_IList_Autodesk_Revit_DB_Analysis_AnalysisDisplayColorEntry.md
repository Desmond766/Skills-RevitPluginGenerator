---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings.SetIntermediateColors(System.Collections.Generic.IList{Autodesk.Revit.DB.Analysis.AnalysisDisplayColorEntry})
source: html/70198f9c-5356-7a8b-a83f-d99b7878f7c7.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings.SetIntermediateColors Method

Set intermediate color entries (other than the minimum and maximum settings).

## Syntax (C#)
```csharp
public void SetIntermediateColors(
	IList<AnalysisDisplayColorEntry> map
)
```

## Parameters
- **map** (`System.Collections.Generic.IList < AnalysisDisplayColorEntry >`) - Array of intermediate color entries.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - intermediate color entries with specific values are not ordered by value (min to max) or too many intermediate colors (>100).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

