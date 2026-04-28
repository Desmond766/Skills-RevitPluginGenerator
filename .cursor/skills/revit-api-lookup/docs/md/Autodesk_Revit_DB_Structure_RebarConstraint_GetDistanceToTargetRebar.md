---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetDistanceToTargetRebar
source: html/759f89cb-e28e-cb61-d667-8153e5c432d3.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetDistanceToTargetRebar Method

Gets the distance from the RebarConstrainedHandle to the target Rebar handle surface.
 The RebarConstraintType of the RebarConstraint must be 'ToOtherRebar.'

## Syntax (C#)
```csharp
public double GetDistanceToTargetRebar()
```

## Returns
Returns the distance from the RebarConstrainedHandle to the target Rebar handle surface.

## Remarks
Throws exception if the constraint is not to other rebar or if the target constraint is to bar bend or hook bend.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is 'HookBend' or 'BarBend'.

