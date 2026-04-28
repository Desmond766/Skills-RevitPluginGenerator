---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.SpecificHeat
source: html/05daf899-905c-8e87-972b-3b4ab44d61a1.htm
---
# Autodesk.Revit.DB.ThermalAsset.SpecificHeat Property

The specific heat of the asset.

## Syntax (C#)
```csharp
public double SpecificHeat { get; set; }
```

## Remarks
Values are in squared-feet per Kelvin, squared-second (ftÂ²/(K Â· sÂ²)) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for specificHeat must be non-negative.

