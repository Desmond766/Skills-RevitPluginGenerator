---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.SetToBindHandleWithTarget(System.Boolean)
source: html/11d87c14-8f42-3f33-98d5-a03058eec1f4.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.SetToBindHandleWithTarget Method

Sets the relationship between two RebarConstrainedHandles.

## Syntax (C#)
```csharp
public void SetToBindHandleWithTarget(
	bool bindsHandleWithTarget
)
```

## Parameters
- **bindsHandleWithTarget** (`System.Boolean`) - False if only the constrained RebarConstrainedHandle follows the target. True if the constrained RebarConstrainedHandle and the target bar handle will be bound and move together.

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

