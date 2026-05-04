---
kind: method
id: M:Autodesk.Revit.DB.ParameterFilterElement.AllRuleParametersApplicable(Autodesk.Revit.DB.ElementFilter)
source: html/31407a8e-893f-4b89-bc25-1346ef387db4.htm
---
# Autodesk.Revit.DB.ParameterFilterElement.AllRuleParametersApplicable Method

Checks that the parameters of the rules used by the given ElementFilter are valid for this filter's categories.

## Syntax (C#)
```csharp
public bool AllRuleParametersApplicable(
	ElementFilter elementFilter
)
```

## Parameters
- **elementFilter** (`Autodesk.Revit.DB.ElementFilter`) - The ElementFilter containing the rules to check.

## Returns
True if all the parameters of the given rules are valid for this filter, otherwise false.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

