---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.ExecuteAllRules(Autodesk.Revit.DB.Document)
source: html/39024ba7-f6c7-7bc3-72ee-80da074f1416.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.ExecuteAllRules Method

Executes all rules in the list on a given document.

## Syntax (C#)
```csharp
public IList<FailureMessage> ExecuteAllRules(
	Document document
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document on which the rules will be executed.

## Returns
Failure messages explaining performance problems detected in the document.

## Remarks
Disabled rules are not executed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

