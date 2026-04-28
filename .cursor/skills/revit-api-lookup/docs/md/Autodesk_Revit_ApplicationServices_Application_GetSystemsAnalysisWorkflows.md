---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.GetSystemsAnalysisWorkflows
source: html/cee64137-25e5-2ceb-6902-09ece90dd0ec.htm
---
# Autodesk.Revit.ApplicationServices.Application.GetSystemsAnalysisWorkflows Method

Returns name and path information identifying systems analysis workflow files.

## Syntax (C#)
```csharp
public IDictionary<string, string> GetSystemsAnalysisWorkflows()
```

## Returns
The map of systems analysis workflows.

## Remarks
The map that is returned contains a key that is the name of the systems analysis workflow,
 and the value is the path to the workflow file.

