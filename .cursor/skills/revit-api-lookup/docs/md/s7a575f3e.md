---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.GetElementFilter
source: html/9b14bfc0-597d-36ab-77d6-d801c3053873.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.GetElementFilter Method

Returns an ElementFilter representing the combination of rules used by this filter.

## Syntax (C#)
```csharp
public ElementFilter GetElementFilter()
```

## Returns
An ElementFilter representing the rules. It may be an ElementParameterFilter
 representing a conjunction of one or more FilterRules, or an ElementLogicalFilter
 (of type LogicalAndFilter or LogicalOrFilter) representing a logical combination
 of FilterRules, using AND/OR operations.

## Remarks
May return Nothing nullptr a null reference ( Nothing in Visual Basic) when no rules are sprcified in ParameterFilterElement, only categories.
 Note that in some situation, calling GetElementFilter after calling SetElementFilter
 may return an ElementFilter that is structurally different from the one passed as input
 to SetElementFilter. For example, if the input ElementFilter contains an ElementParameterFilter
 that contains more than one FilterRule, and if the view filters dialog box is used in between
 the calls to SetElementFilter and GetElementFilter, the output ElementFilter will use a single
 ElementParameterFilter for each of the FilterRules that were bundled in an input ElementParameterFilter.
 The two ElementFilters will be logically and functionally equivalent in the sense that any given
 Element will either be accepted by both ElementFilters or rejected by both ElementFilters.

