---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.Density
source: html/01ffb388-9936-9186-90f2-ddc7facb9ff9.htm
---
# Autodesk.Revit.DB.ThermalAsset.Density Property

The density of the asset.

## Syntax (C#)
```csharp
public double Density { get; set; }
```

## Remarks
Values are in kilograms per cubed feet (kg/ftÂ³) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for density must be non-negative.

