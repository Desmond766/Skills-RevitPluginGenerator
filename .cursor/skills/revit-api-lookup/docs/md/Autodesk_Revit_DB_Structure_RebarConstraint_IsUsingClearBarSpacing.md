---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.IsUsingClearBarSpacing
source: html/13351019-9549-3a83-9d51-7b59d3dbe7bf.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.IsUsingClearBarSpacing Method

Returns true if the RebarConstrainedHandle to target offset is the clear bar distance, false if the offset is measured between bar centers.

## Syntax (C#)
```csharp
public bool IsUsingClearBarSpacing()
```

## Returns
Returns true if the RebarConstrainedHandle to target offset is the clear bar distance, false if the offset is measured between bar centers.

## Remarks
Throw exception if it's used on start/end handle to start/end handle constraint, and on constraints involving bar/hook bend handle.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarConstraint constrain two Rebar ends.
 -or-
 The RebarTargetConstraintType is 'HookBend' or 'BarBend'.

