---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarEdgeNumber
source: html/ba6652ad-cc66-349a-87d6-ee8460572791.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarEdgeNumber Method

Returns the number of the edge on the other Rebar Element to which this RebarConstraint is attached.
 The RebarConstraint must be of RebarConstraintType 'ToOtherRebar,' and the TargetRebarConstraintType
 must be 'Edge.'
 Rebar must be Shape Driven Rebar element.

## Syntax (C#)
```csharp
public int GetTargetRebarEdgeNumber()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarConstraint is not attached to an edge, or bend, or hook bend of another Rebar Element.
 -or-
 Constrained rebar is a free form rebar element.

