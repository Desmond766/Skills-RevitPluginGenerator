---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.SetRuleEnabled(Autodesk.Revit.DB.PerformanceAdviserRuleId,System.Boolean)
source: html/22b40d86-7758-63fe-bd60-543ae7a30b84.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.SetRuleEnabled Method

Retrieves an enabled/disabled status for the given rule.

## Syntax (C#)
```csharp
public void SetRuleEnabled(
	PerformanceAdviserRuleId id,
	bool enabled
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.PerformanceAdviserRuleId`) - The rule id to set enabled/disabled status for.
- **enabled** (`System.Boolean`) - True enables the rule, false disables.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id does not correspond to any registered rule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

