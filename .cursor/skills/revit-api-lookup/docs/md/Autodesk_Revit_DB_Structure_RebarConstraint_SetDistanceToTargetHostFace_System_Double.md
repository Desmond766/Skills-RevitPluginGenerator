---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.SetDistanceToTargetHostFace(System.Double)
source: html/87771139-34dd-1135-026b-904e4098bdbc.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.SetDistanceToTargetHostFace Method

Sets the distance from the RebarConstrainedHandle to the target Host Element surface.
 The RebarConstraintType of the RebarConstraint must be 'FixedDistanceToHostFace.'

## Syntax (C#)
```csharp
public void SetDistanceToTargetHostFace(
	double offset
)
```

## Parameters
- **offset** (`System.Double`) - The distance is given as an offset value, the sign of which depends on Host Face direction.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for offset must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'FixedDistanceToHostFace.'

