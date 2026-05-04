---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarInSystem.BarsOnNormalSide
source: html/65453ee2-9437-9dd1-893e-2c2c576eb581.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.BarsOnNormalSide Property

Identifies if the bars of the rebar set are on the same side of the rebar plane indicated by the normal.
 For the current implementation of RebarInSystem, this property will always return true,
 but it is included in the RebarInSystem interface for consistency with the Rebar class.

## Syntax (C#)
```csharp
public bool BarsOnNormalSide { get; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

