---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.IsBindingHandleWithTarget
source: html/d51defb0-82be-ff30-c3c4-75eb86fa5bd0.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.IsBindingHandleWithTarget Method

Gets the relationship between two RebarConstrainedHandles.

## Syntax (C#)
```csharp
public bool IsBindingHandleWithTarget()
```

## Returns
Returns False if only the constrained RebarConstrainedHandle follows the target. Returns True if the constrained RebarConstrainedHandle and the target bar handle are bound and move together.

## Remarks
Throws exception for any type of constraint other than 'ToOtherRebar' or if the RebarTargetConstraintType of the constraint is 'HookBend' or 'BarBend'.
 Will also throw if the target Rebar has the 'Number with Spacing' layout rule and the RebarTargetConstraintType of the constraint is 'OutOfPlaneExtent'.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is 'HookBend' or 'BarBend'.
 -or-
 The RebarTargetConstraintType is 'OutOfPlaneExtent' and the rebar target layout is 'Number with Spacing'.

