---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarHookBarEnd
source: html/14d3ea55-2756-05de-b5f7-4a2793817099.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.GetTargetRebarHookBarEnd Method

Returns 0 or 1 to indicate which end hook on the other Rebar Element to which this RebarConstraint is attached.
 The RebarConstraint must be of RebarConstraintType 'ToOtherRebar,' and the TargetRebarConstraintType
 must be 'HookBend.'
 Rebar must be Shape Driven Rebar element.

## Syntax (C#)
```csharp
public int GetTargetRebarHookBarEnd()
```

## Remarks
0 means start of the bar, and 1 indicates end of the bar.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is not 'HookBend'
 -or-
 Constrained rebar is a free form rebar element.

