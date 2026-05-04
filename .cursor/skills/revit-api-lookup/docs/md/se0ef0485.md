---
kind: method
id: M:Autodesk.Revit.DB.FilterStringRule.#ctor(Autodesk.Revit.DB.FilterableValueProvider,Autodesk.Revit.DB.FilterStringRuleEvaluator,System.String)
source: html/5bd5286a-612f-e12f-e200-6a8763bb2aee.htm
---
# Autodesk.Revit.DB.FilterStringRule.#ctor Method

Constructs an instance of FilterStringRule.

## Syntax (C#)
```csharp
public FilterStringRule(
	FilterableValueProvider valueProvider,
	FilterStringRuleEvaluator evaluator,
	string ruleString
)
```

## Parameters
- **valueProvider** (`Autodesk.Revit.DB.FilterableValueProvider`) - A pointer to a "value provider" object that will extract values from a Revit document.
- **evaluator** (`Autodesk.Revit.DB.FilterStringRuleEvaluator`) - A pointer to the filter rule evaluator object that implements the desired test.
 The built-in evaluators implement commonly used tests for strings such as begins-with,
 ends-with, contains, equal, etc.
- **ruleString** (`System.String`) - The user-supplied string against which strings from a Revit document will be tested.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

