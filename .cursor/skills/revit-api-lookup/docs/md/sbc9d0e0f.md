---
kind: method
id: M:Autodesk.Revit.DB.FilterStringRuleEvaluator.Evaluate(System.String,System.String,System.Boolean)
source: html/fcbe6f51-9a2e-10bc-36bb-7705f554bd14.htm
---
# Autodesk.Revit.DB.FilterStringRuleEvaluator.Evaluate Method

Derived classes override this method to implement the test that determines
 whether the two given string values satisfy the desired condition or not.

## Syntax (C#)
```csharp
public bool Evaluate(
	string lhs,
	string rhs,
	bool caseSensitive
)
```

## Parameters
- **lhs** (`System.String`) - A value from an element in the document.
- **rhs** (`System.String`) - The user-supplied value against which values from the document are tested.
- **caseSensitive** (`System.Boolean`) - If true, string comparisons are done case-sensitively.

## Returns
True if the given arguments satisfy the condition, otherwise false.

## Remarks
The arguments may be thought of as the left and right operands of a
 binary expression; for example, "a < b", "x >= 100", etc. The left
 operand comes from an element in the Revit document (e.g., the value
 of a parameter.) The right operand is supplied by the user when
 creating the filter that contains the rule that uses this evaluator.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

