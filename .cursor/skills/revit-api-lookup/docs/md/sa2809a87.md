---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarBarType.BarModelDiameter
source: html/f13299fd-9276-9263-a0cf-20e1b2161afb.htm
---
# Autodesk.Revit.DB.Structure.RebarBarType.BarModelDiameter Property

Defines bar model diameter of rebar

## Syntax (C#)
```csharp
public double BarModelDiameter { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: the bar diameter barModelDiam is not positive or bigger than the smallest value of 1.0, and current internal values of standard bend diameter,
 standard hook bend diameter and stirrup/tie bend diameter

