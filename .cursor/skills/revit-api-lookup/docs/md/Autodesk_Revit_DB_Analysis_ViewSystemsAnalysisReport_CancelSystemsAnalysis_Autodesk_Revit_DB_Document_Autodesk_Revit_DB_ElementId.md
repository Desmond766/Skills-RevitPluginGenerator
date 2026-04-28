---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.CancelSystemsAnalysis(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ElementId)
source: html/71520a3b-a4f6-fbd7-904d-ddd520465a5b.htm
---
# Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.CancelSystemsAnalysis Method

Cancels the systems analysis based on the report element id.

## Syntax (C#)
```csharp
public static void CancelSystemsAnalysis(
	Document document,
	ElementId reportElement
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The document where the report element existed.
- **reportElement** (`Autodesk.Revit.DB.ElementId`) - The report element that identifies the analysis.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

