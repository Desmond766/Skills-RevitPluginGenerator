---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetRebarConstraintTargetHostFaceType(System.Int32)
source: html/f58fe52a-639f-8101-8c9d-fe2354a755d0.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetRebarConstraintTargetHostFaceType Method

Returns the RebarConstraintTargetHostFaceType of the host Element face to which
 the RebarConstraint is attached. The RebarConstraintType of the RebarConstraint
 must be 'FixedDistanceToHostFace' or 'ToCover.'

## Syntax (C#)
```csharp
public RebarConstraintTargetHostFaceType GetRebarConstraintTargetHostFaceType(
	int targetIndex
)
```

## Parameters
- **targetIndex** (`System.Int32`) - The index of the target. Should be between 0 and NumberOfTargets().

## Returns
Returns the RebarConstraintTargetHostFaceType of the host Element face to which the RebarConstraint is attached.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetIndex is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace' or 'ToCover.'

