---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceManager.AddRule(Autodesk.Revit.DB.RoutingPreferenceRuleGroupType,Autodesk.Revit.DB.RoutingPreferenceRule,System.Int32)
source: html/c4bdfaf6-c21b-a19e-4b16-4ab1ba3bc67d.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.AddRule Method

Adds a new routing preference rule to the specified position in the rule group.

## Syntax (C#)
```csharp
public void AddRule(
	RoutingPreferenceRuleGroupType groupType,
	RoutingPreferenceRule rule,
	int index
)
```

## Parameters
- **groupType** (`Autodesk.Revit.DB.RoutingPreferenceRuleGroupType`) - The routing preference group type in which the rule should be added.
- **rule** (`Autodesk.Revit.DB.RoutingPreferenceRule`) - The new rule to be added.
- **index** (`System.Int32`) - The zero-based index position where the new rule will be added.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is not a valid zero-based index within groupType.
 -or-
 The rule cannot be added to the groupType.
 -or-
 Thrown if the index is out of bounds, or the rule is not valid for this group (e.g. an elbow may not be added to the junction group).
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

