---
kind: method
id: M:Autodesk.Revit.DB.FilterNumericRuleEvaluator.Evaluate(System.Double,System.Double,System.Double)
source: html/4779f820-cb81-33f2-5dbf-91f257e76b3a.htm
---
# Autodesk.Revit.DB.FilterNumericRuleEvaluator.Evaluate Method

Derived classes override this method to implement the test that determines
 whether the two given double-precision values satisfy the desired condition or not.

## Syntax (C#)
```csharp
public bool Evaluate(
	double lhs,
	double rhs,
	double epsilon
)
```

## Parameters
- **lhs** (`System.Double`) - A value from an element in the document.
- **rhs** (`System.Double`) - The user-supplied value against which values from the document are tested.
- **epsilon** (`System.Double`) - Defines the tolerance within which two values may be considered equal.

## Returns
True if the given arguments satisfy the condition, otherwise false.

## Remarks
The arguments may be thought of as the left and right operands of a
 binary expression; for example, "a < b", "x >= 100", etc. The left
 operand comes from an element in the Revit document (e.g., the value
 of a parameter.) The right operand is supplied by the user when
 creating the filter that contains the rule that uses this evaluator.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given value for lhs is not finite
 -or-
 The given value for lhs is not a number
 -or-
 The given value for rhs is not finite
 -or-
 The given value for rhs is not a number
 -or-
 The given value for epsilon is not finite
 -or-
 The given value for epsilon is not a number

