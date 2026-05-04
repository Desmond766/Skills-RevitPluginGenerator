---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceManager.AddRule(Autodesk.Revit.DB.RoutingPreferenceRuleGroupType,Autodesk.Revit.DB.RoutingPreferenceRule)
source: html/3af59293-3253-c0b5-b491-48fd4d5afae3.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.AddRule Method

Adds a new routing preference rule to the rule group.

## Syntax (C#)
```csharp
public void AddRule(
	RoutingPreferenceRuleGroupType groupType,
	RoutingPreferenceRule rule
)
```

## Parameters
- **groupType** (`Autodesk.Revit.DB.RoutingPreferenceRuleGroupType`) - The routing preference group in which the rule should be added.
- **rule** (`Autodesk.Revit.DB.RoutingPreferenceRule`) - The new rule to be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The rule cannot be added to the groupType.
 -or-
 Thrown if the index is out of bounds, or the rule is not valid for this group (e.g. an elbow may not be added to the junction group).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

