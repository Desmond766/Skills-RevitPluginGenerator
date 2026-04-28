---
kind: property
id: P:Autodesk.Revit.DB.Structure.FabricWireItem.Distance
source: html/b1195afc-c148-3c59-23f4-e6c70cc4c95b.htm
---
# Autodesk.Revit.DB.Structure.FabricWireItem.Distance Property

Distance to the next fabric wire item
 Can be 0 to be used with offset along wire.

## Syntax (C#)
```csharp
public double Distance { get; set; }
```

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - When setting this property: The given value for distance is not a number
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for distance must be between 0 and 30000 feet.

