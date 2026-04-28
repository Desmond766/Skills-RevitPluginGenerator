---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.VaporPressure
source: html/aa844bd8-eb53-f523-0334-be71dcacb9c1.htm
---
# Autodesk.Revit.DB.ThermalAsset.VaporPressure Property

The vapor pressure of the asset.

## Syntax (C#)
```csharp
public double VaporPressure { get; set; }
```

## Remarks
Values are in kilograms per feet, squared-second (kg/(ft Â· sÂ²)) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for vaporPressure must be non-negative.

