---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.ElectricalResistivity
source: html/d7c21bb5-5538-8194-d3e8-e4eeccbef117.htm
---
# Autodesk.Revit.DB.ThermalAsset.ElectricalResistivity Property

The electrical resistivity of the asset.

## Syntax (C#)
```csharp
public double ElectricalResistivity { get; set; }
```

## Remarks
Values are in ohm-meters and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for electricalResistivity must be non-negative.

