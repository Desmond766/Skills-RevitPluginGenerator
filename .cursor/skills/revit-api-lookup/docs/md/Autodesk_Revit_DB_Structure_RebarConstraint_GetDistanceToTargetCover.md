---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetDistanceToTargetCover
source: html/927a9514-0182-1c40-2018-83de25737348.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetDistanceToTargetCover Method

Returns the distance from the RebarConstrainedHandle to the target Host Cover Element surface.
 The RebarConstraintType of the RebarConstraint must be 'ToCover.'

## Syntax (C#)
```csharp
public double GetDistanceToTargetCover()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToCover.'

