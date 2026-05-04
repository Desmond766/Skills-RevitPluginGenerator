---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.BarsOnNormalSide
source: html/dc6806bd-c813-1964-b768-2177e718bb5f.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.BarsOnNormalSide Property

Identifies if the bars of the rebar set are on the same side of the rebar plane indicated by the normal.

## Syntax (C#)
```csharp
public bool BarsOnNormalSide { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

