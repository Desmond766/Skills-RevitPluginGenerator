---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.LiquidViscosity
source: html/0a72e0ea-0523-bbc5-493b-771027a346aa.htm
---
# Autodesk.Revit.DB.ThermalAsset.LiquidViscosity Property

The liquid viscosity of the asset.

## Syntax (C#)
```csharp
public double LiquidViscosity { get; set; }
```

## Remarks
Values are in kilograms per feet-second (kg/(ft Â· s)) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for liquidViscosity must be non-negative.
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the asset must be liquid to set this property.

