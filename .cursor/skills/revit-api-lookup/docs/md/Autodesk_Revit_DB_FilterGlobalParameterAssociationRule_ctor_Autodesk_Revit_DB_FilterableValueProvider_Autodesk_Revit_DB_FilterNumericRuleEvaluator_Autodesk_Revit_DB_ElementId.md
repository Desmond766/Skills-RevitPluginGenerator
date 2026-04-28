---
kind: method
id: M:Autodesk.Revit.DB.FilterGlobalParameterAssociationRule.#ctor(Autodesk.Revit.DB.FilterableValueProvider,Autodesk.Revit.DB.FilterNumericRuleEvaluator,Autodesk.Revit.DB.ElementId)
source: html/e87f2a24-1616-4980-3474-573758df1055.htm
---
# Autodesk.Revit.DB.FilterGlobalParameterAssociationRule.#ctor Method

Constructs an instance of FilterGlobalParameterAssociationRule.

## Syntax (C#)
```csharp
public FilterGlobalParameterAssociationRule(
	FilterableValueProvider valueProvider,
	FilterNumericRuleEvaluator evaluator,
	ElementId ruleValue
)
```

## Parameters
- **valueProvider** (`Autodesk.Revit.DB.FilterableValueProvider`) - A pointer to a "value provider" object that will extract values from a Revit document.
- **evaluator** (`Autodesk.Revit.DB.FilterNumericRuleEvaluator`) - A pointer to the filter rule evaluator object that implements the desired test.
 The built-in evaluators implement commonly used tests such as less-than, greater-than
 less-than-or-equal-to, equal, etc.
- **ruleValue** (`Autodesk.Revit.DB.ElementId`) - The user-supplied global parameter value against which values from a Revit document will be tested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

