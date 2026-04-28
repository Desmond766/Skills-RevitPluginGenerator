---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.IsRuleEnabled(System.Int32)
source: html/a96e8f1e-ef13-7b00-ce2b-71eed84a67d2.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.IsRuleEnabled Method

Retrieves an enabled/disabled status for the given rule.

## Syntax (C#)
```csharp
public bool IsRuleEnabled(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The rule index to retrieve enabled/disabled status for.

## Returns
True if rule is disabled, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index is outside of acceptable range.

