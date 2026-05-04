---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricWireType.WireDiameter
source: html/634ed038-5bb2-c7a3-1a70-40d864164a6b.htm
---
# Autodesk.Revit.DB.Structure.FabricWireType.WireDiameter Property

Determines the diameter of the wire.

## Syntax (C#)
```csharp
public double WireDiameter { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for wireDiameter is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The wire diameter wireDiameter is negative or greater than 12 inches/300 mm.

