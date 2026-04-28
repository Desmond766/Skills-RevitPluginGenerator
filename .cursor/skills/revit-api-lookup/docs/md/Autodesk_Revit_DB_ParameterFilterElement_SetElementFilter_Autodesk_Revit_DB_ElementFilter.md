---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.SetElementFilter(Autodesk.Revit.DB.ElementFilter)
source: html/42927817-dfe1-2787-b133-af3480ae0921.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.SetElementFilter Method

Sets the rules that must be satisfied for a given element to pass this filter.

## Syntax (C#)
```csharp
public bool SetElementFilter(
	ElementFilter elementFilter
)
```

## Parameters
- **elementFilter** (`Autodesk.Revit.DB.ElementFilter`) - An ElementFilter representing the rules. It may be an ElementParameterFilter
 representing a conjunction of one or more FilterRules, or an ElementLogicalFilter
 (of type LogicalAndFilter or LogicalOrFilter) representing a logical combination
 of FilterRules, using AND/OR operations.

## Returns
Returns true if this ParameterFilterElement was changed, false if not.
 It will not be changed if the input rules are equivalent to the ParameterFilterElement's
 existing rules.

## Remarks
Note that in some situation, calling GetElementFilter after calling SetElementFilter
 may return an ElementFilter that is structurally different from the one passed as input
 to SetElementFilter. For example, if the input ElementFilter contains an ElementParameterFilter
 that contains more than one FilterRule, and if the view filters dialog box is used in between
 the calls to SetElementFilter and GetElementFilter, the output ElementFilter will use a single
 ElementParameterFilter for each of the FilterRules that were bundled in an input ElementParameterFilter.
 The two ElementFilters will be logically and functionally equivalent in the sense that any given
 Element will either be accepted by both ElementFilters or rejected by both ElementFilters.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - One of the given rules refers to a parameter that does not apply to this filter's categories.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentsInconsistentException** - The ElementFilter is not acceptable for use by a ParameterFilterElement.

