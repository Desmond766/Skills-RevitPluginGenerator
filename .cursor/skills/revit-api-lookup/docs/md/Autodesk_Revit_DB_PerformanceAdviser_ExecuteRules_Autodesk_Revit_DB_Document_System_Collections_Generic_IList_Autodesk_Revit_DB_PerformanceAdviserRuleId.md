---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.ExecuteRules(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{Autodesk.Revit.DB.PerformanceAdviserRuleId})
source: html/cda35c7f-33e8-f648-a522-8e90a4853f06.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.ExecuteRules Method

Executes selected rules on a given document.

## Syntax (C#)
```csharp
public IList<FailureMessage> ExecuteRules(
	Document document,
	IList<PerformanceAdviserRuleId> rules
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - Document on which the rules will be executed.
- **rules** (`System.Collections.Generic.IList < PerformanceAdviserRuleId >`) - Ids of rules to be executed.

## Returns
Failure messages explaining performance problems detected in the document.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

