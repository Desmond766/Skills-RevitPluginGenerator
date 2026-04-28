---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.AddRule(Autodesk.Revit.DB.PerformanceAdviserRuleId,Autodesk.Revit.DB.IPerformanceAdviserRule)
source: html/9742ccd3-6736-6b87-596e-e829b8184db3.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.AddRule Method

Adds a performance adviser rule to the list of rules.

## Syntax (C#)
```csharp
public void AddRule(
	PerformanceAdviserRuleId id,
	IPerformanceAdviserRule rule
)
```

## Parameters
- **id** (`Autodesk.Revit.DB.PerformanceAdviserRuleId`) - An id of the rule to be added to the list of rules.
- **rule** (`Autodesk.Revit.DB.IPerformanceAdviserRule`) - The rule to be added

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

