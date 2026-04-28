---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarAngleOnBarOrHookBend
source: html/737fce1f-9ce0-620a-702b-6c01505985c9.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarAngleOnBarOrHookBend Method

Returns the angular increment along a bar or hook bend to which the RebarConstraint is attached.

## Syntax (C#)
```csharp
public int GetTargetRebarAngleOnBarOrHookBend()
```

## Returns
The angular increment relative to the reference bar edge.

## Remarks
Only applies to RebarConstraints with TargetRebarConstraintType BarBend or HookBend.
 For HookBends, values can be 0, 1, 2, 3 or 4, representing angular locations of 0, 45, 90, 135,
 and 180 degrees around the hook, starting at the 'base' of the hook (or end of the bar without hook).
 For interior BarBends, values can 0 or 1, where 0 means at the intersection of the bar bend and the edge
 specified by getTargetRebarEdgeNumber, and 1 means the mid-point of the bend arc.
 Rebar must be Shape Driven Rebar element.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is not 'HookBend' or 'BarBend'.
 -or-
 Constrained rebar is a free form rebar element.

