---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.ThermalConductivity
source: html/395a496b-41aa-5378-b8c0-7e95f9d222d7.htm
---
# Autodesk.Revit.DB.ThermalAsset.ThermalConductivity Property

The thermal conductivity of the asset.

## Syntax (C#)
```csharp
public double ThermalConductivity { get; set; }
```

## Remarks
Values are in feet-kilograms per Kelvin-cubed-second ((ft Â· kg)/(K Â· sÂ³)) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for thermalConductivity must be non-negative.

