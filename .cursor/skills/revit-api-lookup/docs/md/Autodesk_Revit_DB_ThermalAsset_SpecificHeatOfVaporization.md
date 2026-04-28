---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.SpecificHeatOfVaporization
source: html/a7e58272-27a8-50b7-515a-7bbd82dbd05c.htm
---
# Autodesk.Revit.DB.ThermalAsset.SpecificHeatOfVaporization Property

The specific heat of vaporization of the asset.

## Syntax (C#)
```csharp
public double SpecificHeatOfVaporization { get; set; }
```

## Remarks
Values are in feet per squared-second (ft/sÂ²) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for specificHeatOfVaporization must be non-negative.

