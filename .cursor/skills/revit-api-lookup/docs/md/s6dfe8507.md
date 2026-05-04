---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetHostFaceAndTransform(System.Int32,Autodesk.Revit.DB.Transform)
source: html/26bfbda5-6121-a44a-b0fd-04533adda39b.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetHostFaceAndTransform Method

Returns the face to which the RebarConstraint is attached associated to the given target index.
 The RebarConstraintType of the RebarConstraint must be 'FixedDistanceToHostFace' or 'ToCover.'

## Syntax (C#)
```csharp
public Face GetTargetHostFaceAndTransform(
	int targetIndex,
	Transform faceTransform
)
```

## Parameters
- **targetIndex** (`System.Int32`) - The index of the target. Should be between 0 and NumberOfTargets().
- **faceTransform** (`Autodesk.Revit.DB.Transform`) - Returns the transform that is associated to the face's element geometry.

## Returns
Requested Face.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - targetIndex is out of range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace' or 'ToCover.'

