---
kind: method
id: M:Autodesk.Revit.DB.PerformanceAdviser.GetRuleId(System.Int32)
source: html/b9c94fdb-f4ed-ab9b-ea36-ff52c7725199.htm
---
# Autodesk.Revit.DB.PerformanceAdviser.GetRuleId Method

Retrieves an id of a rule for a given index in the list.

## Syntax (C#)
```csharp
public PerformanceAdviserRuleId GetRuleId(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - The index to retrieve the rule id for.

## Returns
The rule id.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The index is outside of acceptable range.

