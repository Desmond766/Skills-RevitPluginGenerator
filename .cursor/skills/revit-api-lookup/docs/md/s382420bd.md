---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.SetRuleEnabled(System.Int32,System.Boolean)
source: html/e497cec0-b601-740c-20d7-ccfd4898a2f4.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.SetRuleEnabled Method

Retrieves an enabled/disabled status for the given rule.

## Syntax (C#)
```csharp
public void SetRuleEnabled(
	int index,
	bool enabled
)
```

## Parameters
- **index** (`System.Int32`) - The rule index to set enabled/disabled status for.
- **enabled** (`System.Boolean`) - True enables the rule, false disables.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index is outside of acceptable range.

