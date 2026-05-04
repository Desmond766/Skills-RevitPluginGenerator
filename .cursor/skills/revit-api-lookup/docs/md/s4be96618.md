---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.SetDistanceToTargetRebar(System.Double)
source: html/e605c253-b628-2db6-48f4-49f9506d4193.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.SetDistanceToTargetRebar Method

Sets the offset distance between the constrained RebarConstrainedHandle and its target Rebar handle surface.

## Syntax (C#)
```csharp
public void SetDistanceToTargetRebar(
	double distanceToTargetRebar
)
```

## Parameters
- **distanceToTargetRebar** (`System.Double`) - The distance is given as an offset value, the sign of which depends on the target bar handle direction.

## Remarks
Throws exception if the constraint is not to other rebar or if the target constraint is to bar bend or hook bend.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given value for distanceToTargetRebar must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is 'HookBend' or 'BarBend'.

