---
kind: property
id: P:Autodesk.Revit.DB.Structure.RebarHookType.StraightLineMultiplier
source: html/28ab6bf6-6aef-39d7-c9b7-98e16cdc02d2.htm
---
# Autodesk.Revit.DB.Structure.RebarHookType.StraightLineMultiplier Property

Multiplier of bar diameter. Used to compute a default hook length.
 The default hook length can be overridden by the RebarBarType class.

## Syntax (C#)
```csharp
public double StraightLineMultiplier { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for straightLineMultiplier is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: straightLineMultiplier must be greater than 0 and no more than 99.

