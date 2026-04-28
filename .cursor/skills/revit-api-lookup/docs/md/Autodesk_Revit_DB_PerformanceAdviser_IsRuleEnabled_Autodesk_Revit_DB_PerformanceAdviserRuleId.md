---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.IsRuleEnabled(Autodesk.Revit.DB.PerformanceAdviserRuleId)
source: html/25d3fea3-491d-fe57-a9f3-40c1042c7d7f.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.IsRuleEnabled Method

Retrieves an enabled/disabled status for the given rule.

## Syntax (C#)
```csharp
public bool IsRuleEnabled(
	PerformanceAdviserRuleId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.PerformanceAdviserRuleId`) - The rule id to retrieve enabled/disabled status for.

## Returns
True if rule is disabled, false otherwise.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The id does not correspond to any registered rule.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

