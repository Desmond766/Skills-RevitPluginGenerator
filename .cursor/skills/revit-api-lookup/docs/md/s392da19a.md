---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.SetDistanceToTargetCover(System.Double)
source: html/5c573cf3-7ff8-49a1-7b8e-f78fe2709ea8.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.SetDistanceToTargetCover Method

Sets the distance from the RebarConstrainedHandle to the target Host Cover Element surface.
 The RebarConstraintType of the RebarConstraint must be 'ToCover.'

## Syntax (C#)
```csharp
public void SetDistanceToTargetCover(
	double distanceToTargetCover
)
```

## Parameters
- **distanceToTargetCover** (`System.Double`) - The distance is given as an offset value, the sign of which depends on Host Cover direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for distanceToTargetCover must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToCover.'

