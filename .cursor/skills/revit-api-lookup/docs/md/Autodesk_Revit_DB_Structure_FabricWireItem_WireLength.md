---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricWireItem.WireLength
source: html/ac07b3da-db1d-8cd6-5064-29cad99dc9f9.htm
---
# Autodesk.Revit.DB.Structure.FabricWireItem.WireLength Property

Wire length for this wire item

## Syntax (C#)
```csharp
public double WireLength { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for length is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for length must be greater than 0 and no more than 30000 feet.

