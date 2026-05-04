---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetRebarConstraintTargetHostFaceType
source: html/6446870e-2774-3d2f-cb78-0cb39e7dada4.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetRebarConstraintTargetHostFaceType Method

Returns the RebarConstraintTargetHostFaceType of the host Element face to which
 the RebarConstraint is attached. The RebarConstraintType of the RebarConstraint
 must be 'FixedDistanceToHostFace' or 'ToCover.'
 Will throw exception if it's a multi target constraint.

## Syntax (C#)
```csharp
public RebarConstraintTargetHostFaceType GetRebarConstraintTargetHostFaceType()
```

## Returns
Returns the RebarConstraintTargetHostFaceType of the host Element face to which the RebarConstraint is attached.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace' or 'ToCover.'
 -or-
 Multi target constraint. Consider using the indexed version of the method.

