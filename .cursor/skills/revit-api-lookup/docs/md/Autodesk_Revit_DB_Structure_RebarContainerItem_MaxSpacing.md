---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarContainerItem.MaxSpacing
source: html/d750a266-d22b-c73e-2622-a32147f0a39c.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.MaxSpacing Property

Identifies the maximum spacing between rebar in rebar set.

## Syntax (C#)
```csharp
public double MaxSpacing { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The maxSpacing isn't bigger than 0.0.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - This rebar element represents a single bar (the layout rule is Single).

