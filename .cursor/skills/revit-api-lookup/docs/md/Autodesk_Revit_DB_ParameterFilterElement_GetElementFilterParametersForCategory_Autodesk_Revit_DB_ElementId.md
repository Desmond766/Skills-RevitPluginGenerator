---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.GetElementFilterParametersForCategory(Autodesk.Revit.DB.ElementId)
source: html/7b1992bb-a55f-f872-b35b-0a2db840bf68.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.GetElementFilterParametersForCategory Method

Retrieves a list of the parameters associated with all rules in the filter
 that are combined (using logical AND) with a FilterCategoryRule corresponding to single %categoryId%.

## Syntax (C#)
```csharp
public ISet<ElementId> GetElementFilterParametersForCategory(
	ElementId categoryId
)
```

## Parameters
- **categoryId** (`Autodesk.Revit.DB.ElementId`) - The category for which parameters should be found.

## Returns
A set of parameter identifiers.

## Remarks
Note that in the case when InvalidElementId specified as input %categoryId% this function returns
 parameters common to all categories used by this ParameterFilterElement,
 i.e. it is equivalent to ParameterFilterElement.GetElementFilterParameters().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

