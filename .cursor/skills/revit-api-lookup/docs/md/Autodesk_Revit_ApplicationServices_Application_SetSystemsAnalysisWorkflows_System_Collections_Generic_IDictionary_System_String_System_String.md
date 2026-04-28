---
kind: method
id: M:Autodesk.Revit.ApplicationServices.Application.SetSystemsAnalysisWorkflows(System.Collections.Generic.IDictionary{System.String,System.String})
source: html/895a3f70-be83-736a-daec-056e09ee25a7.htm
---
# Autodesk.Revit.ApplicationServices.Application.SetSystemsAnalysisWorkflows Method

Sets name and path information identifying systems analysis workflow files.

## Syntax (C#)
```csharp
public void SetSystemsAnalysisWorkflows(
	IDictionary<string, string> paths
)
```

## Parameters
- **paths** (`System.Collections.Generic.IDictionary < String , String >`) - The map of systems analysis workflows.

## Remarks
The map should be specified as a key that is the name of the systems analysis workflow,
 and a value that is the path to the workflow file.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

