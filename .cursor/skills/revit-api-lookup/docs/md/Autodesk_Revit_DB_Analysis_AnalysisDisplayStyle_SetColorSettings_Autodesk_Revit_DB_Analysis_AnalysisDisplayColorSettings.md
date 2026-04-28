---
kind: method
id: M:Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.SetColorSettings(Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings)
source: html/0c668426-1570-4bbd-6706-611c1a7903d8.htm
---
# Autodesk.Revit.DB.Analysis.AnalysisDisplayStyle.SetColorSettings Method

Set color settings object for the style.

## Syntax (C#)
```csharp
public void SetColorSettings(
	AnalysisDisplayColorSettings colorSettings
)
```

## Parameters
- **colorSettings** (`Autodesk.Revit.DB.Analysis.AnalysisDisplayColorSettings`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - for Diagram display style, colorSettings must have type SolidColorRanges and exactly one intermediate entry with zero value

