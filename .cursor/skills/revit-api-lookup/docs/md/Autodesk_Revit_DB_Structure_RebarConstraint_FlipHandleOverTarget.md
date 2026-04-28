---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarConstraint.FlipHandleOverTarget
source: html/0e5101f2-2ece-c720-ee63-13857754c0c6.htm
---
# Autodesk.Revit.DB.Structure.RebarConstraint.FlipHandleOverTarget Method

Flips the RebarConstrainedHandle to the other side of the target bar handle, maintaining the distance in absolute value.

## Syntax (C#)
```csharp
public void FlipHandleOverTarget()
```

## Remarks
Throw exception if constraint type is not 'ToOtherRebar', or for constraints involving bar/hook bend handle.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - RebarConstraint is no longer valid.
 -or-
 The RebarConstraint is not of RebarConstraintType 'ToOtherRebar.'
 -or-
 The RebarTargetConstraintType is 'HookBend' or 'BarBend'.

