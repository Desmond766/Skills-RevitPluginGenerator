---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.SetToUseClearBarSpacing(System.Boolean)
source: html/2e8fd543-a754-0c53-6812-e11b4c27f438.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.SetToUseClearBarSpacing Method

Sets whether the RebarConstrainedHandle to target offset is the clear bar distance, or is measured between bar centers.

## Syntax (C#)
```csharp
public void SetToUseClearBarSpacing(
	bool useClearBarSpacing
)
```

## Parameters
- **useClearBarSpacing** (`System.Boolean`) - True if the RebarConstrainedHandle to target offset is the clear bar distance, false if the offset is measured between bar centers.

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

