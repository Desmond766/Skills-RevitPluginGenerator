---
kind: property
id: P:Autodesk.Revit.DB.Architecture.StairsType.NotchExtension
source: html/25d40422-b0c8-e6d4-9f57-f60ad6aabff5.htm
---
# Autodesk.Revit.DB.Architecture.StairsType.NotchExtension Property

The horizontal length of the notch profile.

## Syntax (C#)
```csharp
public double NotchExtension { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for notchExtension must be no more than 30000 feet in absolute value.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - When setting this property: The construction method of the stairs type is not "Precast" or the StairsEndConnectionType of the stairs type is not "Notch", so this related data cannot be set.

