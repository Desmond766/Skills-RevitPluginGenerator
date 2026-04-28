---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceManager.GetMEPPartId(Autodesk.Revit.DB.RoutingPreferenceRuleGroupType,Autodesk.Revit.DB.RoutingConditions)
source: html/b0900fd7-828b-c0f7-0729-24191b0d43a3.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.GetMEPPartId Method

Gets a fitting or segment id of given routing preference group that meets the specified routing conditions.

## Syntax (C#)
```csharp
public ElementId GetMEPPartId(
	RoutingPreferenceRuleGroupType groupType,
	RoutingConditions conditions
)
```

## Parameters
- **groupType** (`Autodesk.Revit.DB.RoutingPreferenceRuleGroupType`) - The routing preference group
- **conditions** (`Autodesk.Revit.DB.RoutingConditions`) - A set of routing conditions

## Returns
The Id of the fitting or segment that met the given routing conditions.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration

