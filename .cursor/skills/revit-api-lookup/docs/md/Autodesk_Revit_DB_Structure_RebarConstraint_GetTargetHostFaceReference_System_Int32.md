---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetHostFaceReference(System.Int32)
source: html/8da5f062-8f8f-3151-e029-6492a3978a50.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetHostFaceReference Method

Returns a reference that corresponds to the face to which the RebarConstraint is attached specified by the targetIndex.
 The RebarConstraintType of the RebarConstraint must be 'FixedDistanceToHostFace' or 'ToCover.'

## Syntax (C#)
```csharp
public Reference GetTargetHostFaceReference(
	int targetIndex
)
```

## Parameters
- **targetIndex** (`System.Int32`) - The index of the target. Should be between 0 and NumberOfTargets().

## Returns
Requested reference.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetIndex is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace' or 'ToCover.'

