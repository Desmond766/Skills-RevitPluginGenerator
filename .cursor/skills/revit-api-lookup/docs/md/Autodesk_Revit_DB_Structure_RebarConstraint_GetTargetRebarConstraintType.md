---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarConstraintType
source: html/282c6cbe-06c7-8f56-e38c-6f8550655cf4.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarConstraintType Method

Returns the TargetRebarConstraintType of the handle on the other Rebar Element
 to which this RebarConstraint is attached. The RebarConstraintType of the
 RebarConstraint must be 'ToOtherRebar.'
 Rebar must be Shape Driven Rebar element.

## Syntax (C#)
```csharp
public TargetRebarConstraintType GetTargetRebarConstraintType()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 Constrained rebar is a free form rebar element.

