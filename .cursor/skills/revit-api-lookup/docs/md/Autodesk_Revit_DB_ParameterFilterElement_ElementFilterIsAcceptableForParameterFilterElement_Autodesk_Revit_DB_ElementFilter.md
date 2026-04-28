---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.ElementFilterIsAcceptableForParameterFilterElement(Autodesk.Revit.DB.ElementFilter)
source: html/b04518c6-7501-b41e-e1a0-56970f23f64e.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.ElementFilterIsAcceptableForParameterFilterElement Method

Checks that an ElementFilter is acceptable for use in defining the filtering rules
 for a ParameterFilterElement (i.e., for view filtering).

## Syntax (C#)
```csharp
public bool ElementFilterIsAcceptableForParameterFilterElement(
	ElementFilter elementFilter
)
```

## Parameters
- **elementFilter** (`Autodesk.Revit.DB.ElementFilter`) - The ElementFilter to validate.

## Returns
True if the ElementFilter is acceptable for use by an ParameterFilterElement, false if not.

## Remarks
ElementFilter is either an ElementParameterFilter or an ElementLogicalFilter
 representing a Boolean combination of ElementParameterFilters. In addition, we check that
 each ElementParameterFilter satisfies the following conditions:
 Its array of FilterRules is not empty and contains:
 Any number of FilterRules of type FilterValueRule, FilterInverseRule, and SharedParameterApplicableRule or Exactly one FilterCategoryRule containing only one category from categories stored by this ParameterFilterElement or Exactly two rules: the first one is a FilterCategoryRule containing only one category from categories stored by this ParameterFilterElement and
 the second one is a FilterRule of type FilterValueRule, FilterInverseRule, or SharedParameterApplicableRule. 
 Note that cases in the second and third bullet are currently allowed only if the parent node of ElementParameterFilter is LogicalOrFilter.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

