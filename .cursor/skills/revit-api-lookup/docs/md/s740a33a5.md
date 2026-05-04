---
kind: method
id: M:Autodesk.Revit.DB.FilterNumericRuleEvaluator.Evaluate(System.Int64,System.Int64)
source: html/97c35e52-48cd-2581-aff3-c13556ea1af2.htm
---
# Autodesk.Revit.DB.FilterNumericRuleEvaluator.Evaluate Method

Derived classes should override this method to implement the desired test.

## Syntax (C#)
```csharp
public bool Evaluate(
	long lhs,
	long rhs
)
```

## Parameters
- **lhs** (`System.Int64`) - A value from an element in the document.
- **rhs** (`System.Int64`) - The user-supplied value against which values from the document are tested.

## Returns
True if lhs , rhs satisfy the condition implemented by this evaluator.

