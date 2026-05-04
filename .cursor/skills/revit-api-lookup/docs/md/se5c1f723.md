---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.WillRuleCheckElements(Autodesk.Revit.DB.PerformanceAdviserRuleId)
source: html/4913652b-82be-e593-c0d4-eb93d86efe36.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.WillRuleCheckElements Method

Reports if rule needs to be executed on individual elements.

## Syntax (C#)
```csharp
public bool WillRuleCheckElements(
	PerformanceAdviserRuleId id
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.PerformanceAdviserRuleId`) - The rule id to get information for.

## Returns
True if rule needs to be executed on individual elements.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

