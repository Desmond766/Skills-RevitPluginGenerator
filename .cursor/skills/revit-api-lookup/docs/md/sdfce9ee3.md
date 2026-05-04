---
kind: method
id: M:Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.GetReportContent
source: html/cdfa90f1-c57a-6a0d-3da9-ae6396525658.htm
---
# Autodesk.Revit.DB.Analysis.ViewSystemsAnalysisReport.GetReportContent Method

Gets the report content in this view.

## Syntax (C#)
```csharp
public string GetReportContent()
```

## Returns
The content of the report as displayed in the view, or the referenced file name.

## Remarks
The report shows "Calculating..." if the background calculation is still going on.
 You may call isAnalysisCompleted() to check if the calculation is completed.

