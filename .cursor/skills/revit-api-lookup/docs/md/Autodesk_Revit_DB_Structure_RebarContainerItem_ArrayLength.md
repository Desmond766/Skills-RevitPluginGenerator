---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.ArrayLength
source: html/65bd5b22-0211-e66c-18e9-72798ce675d5.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.ArrayLength Property

Identifies the distribution path length of rebar set.

## Syntax (C#)
```csharp
public double ArrayLength { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: the set length arrayLength isn't acceptable.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

