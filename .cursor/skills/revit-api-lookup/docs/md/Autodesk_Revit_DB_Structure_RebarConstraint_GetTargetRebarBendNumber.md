---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarBendNumber
source: html/134322bb-4c04-d211-bcda-905098f4068d.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarBendNumber Method

Returns the number of the bend on the other Rebar Element to which this RebarConstraint is attached.
 The RebarConstraint must be of RebarConstraintType 'ToOtherRebar,' and the TargetRebarConstraintType
 must be 'BarBend.'
 Rebar must be Shape Driven Rebar element.

## Syntax (C#)
```csharp
public int GetTargetRebarBendNumber()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is not 'BarBend'
 -or-
 Constrained rebar is a free form rebar element.

