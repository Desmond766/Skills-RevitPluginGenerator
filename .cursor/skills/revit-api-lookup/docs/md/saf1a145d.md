---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceManager.GetRule(Autodesk.Revit.DB.RoutingPreferenceRuleGroupType,System.Int32)
source: html/85f2dafa-381e-60fd-2596-8ebb383f149b.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.GetRule Method

Gets the specified rule.

## Syntax (C#)
```csharp
public RoutingPreferenceRule GetRule(
	RoutingPreferenceRuleGroupType groupType,
	int index
)
```

## Parameters
- **groupType** (`Autodesk.Revit.DB.RoutingPreferenceRuleGroupType`) - The routing preference group type from which the rule should be returned.
- **index** (`System.Int32`) - The zero-based index where the rule should be returned.

## Returns
The rule at the specified group and zero-based index position.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is not a valid zero-based index within groupType.
 -or-
 Thrown if the index is out of bounds
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

