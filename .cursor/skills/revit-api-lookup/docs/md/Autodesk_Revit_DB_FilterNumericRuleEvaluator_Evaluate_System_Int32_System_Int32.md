---
kind: method
id: M:Autodesk.Revit.DB.FilterNumericRuleEvaluator.Evaluate(System.Int32,System.Int32)
source: html/65a997f9-7472-acf2-3983-f92e5e833a2b.htm
---
# Autodesk.Revit.DB.FilterNumericRuleEvaluator.Evaluate Method

Derived classes should override this method to implement the desired test.

## Syntax (C#)
```csharp
[ObsoleteAttribute("This method is deprecated in Revit 2024. Override the evalute method taking Int64 instead. It may be removed in a future version.")]
public bool Evaluate(
	int lhs,
	int rhs
)
```

## Parameters
- **lhs** (`System.Int32`) - A value from an element in the document.
- **rhs** (`System.Int32`) - The user-supplied value against which values from the document are tested.

## Returns
True if lhs , rhs satisfy the condition implemented by this evaluator.

