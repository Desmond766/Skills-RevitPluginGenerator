---
kind: method
id: M:Autodesk.Revit.DB.RoutingPreferenceManager.RemoveRule(Autodesk.Revit.DB.RoutingPreferenceRuleGroupType,System.Int32)
source: html/85817d0c-adff-dc7a-67e6-d7689b9431af.htm
---
# Autodesk.Revit.DB.RoutingPreferenceManager.RemoveRule Method

Removes an existing routing preference rule.
 Thrown if the index is out of bounds.

## Syntax (C#)
```csharp
public void RemoveRule(
	RoutingPreferenceRuleGroupType groupType,
	int index
)
```

## Parameters
- **groupType** (`Autodesk.Revit.DB.RoutingPreferenceRuleGroupType`) - The routing preference group type in which the rule should be removed.
- **index** (`System.Int32`) - The index position of removed routing preference rule in the group.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is not a valid zero-based index within groupType.
 -or-
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.DisabledDisciplineException** - None of the following disciplines is enabled: Mechanical Electrical Piping.

