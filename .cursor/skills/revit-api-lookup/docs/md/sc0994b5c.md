---
kind: method
id: M:Autodesk.Revit.DB.FilterDoubleRule.#ctor(Autodesk.Revit.DB.FilterableValueProvider,Autodesk.Revit.DB.FilterNumericRuleEvaluator,System.Double,System.Double)
source: html/70a53592-01d0-7d35-afbc-fb59825b4124.htm
---
# Autodesk.Revit.DB.FilterDoubleRule.#ctor Method

Constructs an instance of FilterDoubleRule.

## Syntax (C#)
```csharp
public FilterDoubleRule(
	FilterableValueProvider valueProvider,
	FilterNumericRuleEvaluator evaluator,
	double ruleValue,
	double epsilon
)
```

## Parameters
- **valueProvider** (`Autodesk.Revit.DB.FilterableValueProvider`) - A pointer to a "value provider" object that will extract values from a Revit document.
- **evaluator** (`Autodesk.Revit.DB.FilterNumericRuleEvaluator`) - A pointer to the filter rule evaluator object that implements the desired test.
 The built-in evaluators implement commonly used tests such as less-than, greater-than
 less-than-or-equal-to, equal, etc.
- **ruleValue** (`System.Double`) - The user-supplied value against which values from a Revit document will be tested.
- **epsilon** (`System.Double`) - The tolerance within which two floating-point values may be considered equal.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for ruleValue is not finite
 -or-
 The given value for ruleValue is not a number
 -or-
 The given value for epsilon is not finite
 -or-
 The given value for epsilon is not a number
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

