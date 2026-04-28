---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetCoverType(System.Int32)
source: html/f5ef3d50-d753-2598-7a12-74cc1cb569fa.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetCoverType Method

Returns the RebarCoverType for the face specified by targetIndex. Returns null if no RebarHostData is present for target element.

## Syntax (C#)
```csharp
public RebarCoverType GetTargetCoverType(
	int targetIndex
)
```

## Parameters
- **targetIndex** (`System.Int32`) - The index of the target. Should be between 0 and NumberOfTargets().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetIndex is out of range.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace' or 'ToCover.'

