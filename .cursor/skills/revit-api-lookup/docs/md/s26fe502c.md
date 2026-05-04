---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetHostFaceReference
source: html/df4e4eca-c29a-faea-9bb8-26fd1ed12586.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetHostFaceReference Method

Returns a reference to the host Element face to which the RebarConstraint is attached.
 The RebarConstraintType of the RebarConstraint must be 'FixedDistanceToHostFace' or 'ToCover.'
 Will throw exception if it's a multi target constraint.

## Syntax (C#)
```csharp
public Reference GetTargetHostFaceReference()
```

## Returns
Requested reference.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace' or 'ToCover.'
 -or-
 Multi target constraint. Consider using the indexed version of the method.

