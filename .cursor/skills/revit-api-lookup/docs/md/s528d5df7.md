---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarBarType.BarNominalDiameter
source: html/af82b6df-2053-aa48-ae42-f97349d875af.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.BarNominalDiameter Property

Defines bar nominal diameter of rebar

## Syntax (C#)
```csharp
public double BarNominalDiameter { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: the bar diameter barNominalDiam is not positive or bigger than the smallest value of 1.0, and current internal values of standard bend diameter,
 standard hook bend diameter and stirrup/tie bend diameter

