---
kind: method
id: M:Autodesk.Revit.DB.FilterIntegerRule.#ctor(Autodesk.Revit.DB.FilterableValueProvider,Autodesk.Revit.DB.FilterNumericRuleEvaluator,System.Int32)
source: html/369d2b9c-f841-d4b0-ae4b-260edc9e6308.htm
---
# Autodesk.Revit.DB.FilterIntegerRule.#ctor Method

Constructs an instance of FilterIntegerRule.

## Syntax (C#)
```csharp
public FilterIntegerRule(
	FilterableValueProvider valueProvider,
	FilterNumericRuleEvaluator evaluator,
	int ruleValue
)
```

## Parameters
- **valueProvider** (`Autodesk.Revit.DB.FilterableValueProvider`) - A pointer to a "value provider" object that will extract values from a Revit document.
- **evaluator** (`Autodesk.Revit.DB.FilterNumericRuleEvaluator`) - A pointer to the filter rule evaluator object that implements the desired test.
 The built-in evaluators implement commonly used tests such as less-than, greater-than
 less-than-or-equal-to, equal, etc.
- **ruleValue** (`System.Int32`) - The user-supplied value against which values from a Revit document will be tested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

