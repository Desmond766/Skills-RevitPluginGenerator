---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.ElementFilterIsAcceptableForParameterFilterElement(Autodesk.Revit.DB.Document,System.Collections.Generic.ISet{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementFilter)
source: html/7439c67a-bd5b-d15f-28cc-b9cffe8ec8e8.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.ElementFilterIsAcceptableForParameterFilterElement Method

Checks that an ElementFilter is acceptable for use in defining the filtering rules
 for a given list of categories (i.e., for view filtering).

## Syntax (C#)
```csharp
public static bool ElementFilterIsAcceptableForParameterFilterElement(
	Document aDocument,
	ISet<ElementId> categories,
	ElementFilter elementFilter
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document in which to create the ParameterFilterElement.
- **categories** (`System.Collections.Generic.ISet < ElementId >`) - The categories for the new ParameterFilterElement.
- **elementFilter** (`Autodesk.Revit.DB.ElementFilter`) - The ElementFilter to validate.

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

