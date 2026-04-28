---
kind: property
id: P:Autodesk.Revit.DB.ThermalAsset.Permeability
source: html/35629ac4-79a0-3be4-b575-be3a05b3c946.htm
---
# Autodesk.Revit.DB.ThermalAsset.Permeability Property

The permeability of the asset.

## Syntax (C#)
```csharp
public double Permeability { get; set; }
```

## Remarks
Values are in seconds per foot (s/ft) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for permeability must be non-negative.

