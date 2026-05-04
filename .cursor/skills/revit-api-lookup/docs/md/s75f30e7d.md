---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.RequestSystemsAnalysis(Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions)
source: html/b36cb95e-9857-9028-4587-86fdb6767cbc.htm
---
# Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.RequestSystemsAnalysis Method

Requests a new systems analysis in the background.

## Syntax (C#)
```csharp
public void RequestSystemsAnalysis(
	SystemsAnalysisOptions options
)
```

## Parameters
- **options** (`Autodesk.Revit.DB.Analysis.SystemsAnalysisOptions`) - The additional options to run systems analysis. If empty, use the default value in the view element.
 The request may download the weather file at current site location if not specified in the options.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - No weather station is within 500 nautical miles of this site location.
- **Autodesk.Revit.Exceptions.FileNotFoundException** - Fail to download the weather file.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - A valid energy model is required for systems analysis.
 -or-
 Unable to access the weather service. Try again later.

