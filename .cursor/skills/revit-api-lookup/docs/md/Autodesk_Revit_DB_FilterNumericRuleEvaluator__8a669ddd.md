---
kind: type
id: T:Autodesk.Revit.DB.FilterNumericRuleEvaluator
source: html/1f1a96bb-5f00-1a24-8c03-6984c88672b9.htm
---
# Autodesk.Revit.DB.FilterNumericRuleEvaluator

Base for all classes that compare numeric values from Revit to a user-supplied filter value.

## Syntax (C#)
```csharp
public class FilterNumericRuleEvaluator : IDisposable
```

## Remarks
A class derived from FilterNumericRuleEvaluator must handle both integer and double-precision types.
 For double-precision comparisons, an epsilon value is given. The evaluator class should use this
 value in a manner appropriate to the comparison being implemented.

