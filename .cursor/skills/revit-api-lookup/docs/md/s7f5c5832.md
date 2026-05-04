---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.NotchThickness
source: html/f3c7d0c9-f3e2-5e4d-4e01-20ca3b1d51da.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.NotchThickness Property

The vertical length of the notch profile from the top.

## Syntax (C#)
```csharp
public double NotchThickness { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for notchThickness must be between 0 and 30000 feet.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The construction method of the stairs type is not "Precast" or the StairsEndConnectionType of the stairs type is not "Notch", so this related data cannot be set.

