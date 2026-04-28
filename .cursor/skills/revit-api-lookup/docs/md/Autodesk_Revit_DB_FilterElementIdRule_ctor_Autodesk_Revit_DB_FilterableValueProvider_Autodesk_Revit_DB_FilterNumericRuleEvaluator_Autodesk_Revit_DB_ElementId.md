---
kind: method
id: M:Autodesk.Revit.DB.FilterElementIdRule.#ctor(Autodesk.Revit.DB.FilterableValueProvider,Autodesk.Revit.DB.FilterNumericRuleEvaluator,Autodesk.Revit.DB.ElementId)
source: html/495875f9-2873-ca71-48e8-3b994a598f14.htm
---
# Autodesk.Revit.DB.FilterElementIdRule.#ctor Method

Constructs an instance of FilterElementIdRule.

## Syntax (C#)
```csharp
public FilterElementIdRule(
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
- **ruleValue** (`Autodesk.Revit.DB.ElementId`) - The user-supplied value against which values from a Revit document will be tested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

