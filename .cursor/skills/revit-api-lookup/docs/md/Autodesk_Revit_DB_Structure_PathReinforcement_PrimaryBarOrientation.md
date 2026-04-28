---
kind: property
id: P:Autodesk.Revit.DB.Structure.PathReinforcement.PrimaryBarOrientation
source: html/a351b2f4-2f3e-e0e4-7bb1-0fab85004fdc.htm
---
# Autodesk.Revit.DB.Structure.PathReinforcement.PrimaryBarOrientation Property

Orientation of primary bars of Path Reinforcement.

## Syntax (C#)
```csharp
public ReinforcementBarOrientation PrimaryBarOrientation { get; set; }
```

## Remarks
The orientation corresponds to the bars' rotation in the Path Reinforcement element.
 It indicates the postion of the major segment of the primary Rebar Shape relative to the edges of a rectangular region
 which bounds the Path Reinforcement, where the top/exterior and bottom/interior come from the cover boundaries of the host,
 the near side edge is defined by the Path Reinforcement sketch line, and the far side edge is derived from bar length (defaulting to 5').

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: This orientation is not allowed for primary bars.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: A value passed for an enumeration argument is not a member of that enumeration

