---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.NotchVerticalGap
source: html/cb89c3c8-19e9-4c46-7e3b-e8a0fbd4bb86.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.NotchVerticalGap Property

The width of the vertical gap in the stairs notch.

## Syntax (C#)
```csharp
public double NotchVerticalGap { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for notchVerticalGap must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The construction method of the stairs type is not "Precast" or the StairsEndConnectionType of the stairs type is not "Notch", so this related data cannot be set.

