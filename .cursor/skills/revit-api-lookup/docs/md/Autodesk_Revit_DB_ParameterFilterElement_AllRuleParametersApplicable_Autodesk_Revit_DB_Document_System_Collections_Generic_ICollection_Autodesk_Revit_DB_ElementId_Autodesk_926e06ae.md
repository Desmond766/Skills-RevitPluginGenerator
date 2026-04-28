---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.AllRuleParametersApplicable(Autodesk.Revit.DB.Document,System.Collections.Generic.ICollection{Autodesk.Revit.DB.ElementId},Autodesk.Revit.DB.ElementFilter)
source: html/93e1ec59-4604-19cc-a010-246b918ddd8a.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.AllRuleParametersApplicable Method

Checks that the parameters of the given ElementFilter (representing a combination of rules)
 are valid for the given set of categories.

## Syntax (C#)
```csharp
public static bool AllRuleParametersApplicable(
	Document aDocument,
	ICollection<ElementId> categories,
	ElementFilter elementFilter
)
```

## Parameters
- **aDocument** (`Autodesk.Revit.DB.Document`) - The document containing the filter, categories, and parameters involved in this validation.
- **categories** (`System.Collections.Generic.ICollection < ElementId >`) - The set of categories against which to check the rule parameters.
- **elementFilter** (`Autodesk.Revit.DB.ElementFilter`) - The ElementFilter representing the combination of rules to check.

## Returns
True if all the parameters of the given rules are valid for this filter, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

