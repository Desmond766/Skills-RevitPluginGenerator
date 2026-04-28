---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricWireItem.OffsetAlongWire
source: html/54814023-9b67-b3e2-5daa-91e9cf6b1fea.htm
---
# Autodesk.Revit.DB.Structure.FabricWireItem.OffsetAlongWire Property

Offset along wire direction
 Wire distance should be 0 if we want to be along the same wire

## Syntax (C#)
```csharp
public double OffsetAlongWire { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for offset is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for offset must be between 0 and 30000 feet.

