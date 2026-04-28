---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.NotchHorizontalGap
source: html/6b88f8cc-2637-305c-49bd-de410ab901f2.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.NotchHorizontalGap Property

The width of the horizontal gap in the stairs notch.

## Syntax (C#)
```csharp
public double NotchHorizontalGap { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for notchHorizontalGap must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The construction method of the stairs type is not "Precast" or the StairsEndConnectionType of the stairs type is not "Notch", so this related data cannot be set.

