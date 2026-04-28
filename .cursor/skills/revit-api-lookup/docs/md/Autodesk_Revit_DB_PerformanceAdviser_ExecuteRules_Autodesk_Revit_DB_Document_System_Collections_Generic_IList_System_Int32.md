---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.ExecuteRules(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{System.Int32})
source: html/e6833e0f-8d9a-1e2f-9d7f-e3907da15804.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.ExecuteRules Method

Executes selected rules on a given document.

## Syntax (C#)
```csharp
public IList<FailureMessage> ExecuteRules(
	Document document,
	IList<int> rules
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document on which the rules will be executed.
- **rules** (`System.Collections.Generic.IList < Int32 >`) - Indices of rules to be executed.

## Returns
Failure messages explaining performance problems detected in the document.

## Remarks
Disabled rules are not executed.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

