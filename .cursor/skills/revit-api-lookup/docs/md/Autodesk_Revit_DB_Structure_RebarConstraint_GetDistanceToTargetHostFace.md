---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetDistanceToTargetHostFace
source: html/9859e4a1-a5d4-a1e6-d28b-2e69799f2c10.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetDistanceToTargetHostFace Method

Returns the distance from the RebarConstrainedHandle to the target Host Element surface.
 The RebarConstraintType of the RebarConstraint must be 'FixedDistanceToHostFace.'

## Syntax (C#)
```csharp
public double GetDistanceToTargetHostFace()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace.'

