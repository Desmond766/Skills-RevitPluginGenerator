---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.GasViscosity
source: html/af311bec-60a7-f7ea-08af-9389349355d4.htm
---
# Autodesk.Revit.DB.ThermalAsset.GasViscosity Property

The gas viscosity of the asset.

## Syntax (C#)
```csharp
public double GasViscosity { get; set; }
```

## Remarks
Values are in kilograms per feet-second (kg/(ft Â· s)) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for gasViscosity must be non-negative.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the asset must be gas to set this property.

