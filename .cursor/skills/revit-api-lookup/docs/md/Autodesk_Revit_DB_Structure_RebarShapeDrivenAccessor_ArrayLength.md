---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ArrayLength
source: html/b9d15e52-d912-a5ad-9fb8-4ff22849ec1f.htm
---
# Autodesk.Revit.DB.Structure.RebarShapeDrivenAccessor.ArrayLength Property

Identifies the distribution path length of rebar set.

## Syntax (C#)
```csharp
public double ArrayLength { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: the set length arrayLength isn't acceptable.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarShapeDrivenAccessor doesn't contain a valid rebar reference.

