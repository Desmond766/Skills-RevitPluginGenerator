---
kind: type
id: T:Autodesk.Revit.DB.Structure.TargetRebarConstraintType
source: html/b5eb20bf-e887-41b4-f15c-0c1860799a8b.htm
---
# Autodesk.Revit.DB.Structure.TargetRebarConstraintType

A type used to identify the particular part of a Stirrup style rebar to which
 a Standard style rebar's handle is constrained.

## Syntax (C#)
```csharp
public enum TargetRebarConstraintType
```

## Remarks
Most of the range of values for this type are the same as those of RebarHandleType,
 since it is usually the handles on the Stirrup which constrain the Standard bar.
 However, two additional values - BarBend and HookBend - are used to identify the
 special case of a Standard style, straight bar, running perpendicular to the plane
 of the Stirrup, and constrained to a bend (or hook) arc on the Stirrup.

