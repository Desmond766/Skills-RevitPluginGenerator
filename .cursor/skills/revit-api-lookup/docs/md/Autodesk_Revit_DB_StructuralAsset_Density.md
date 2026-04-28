---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.Density
source: html/383be1ee-1349-6f10-350b-3dd19043d183.htm
---
# Autodesk.Revit.DB.StructuralAsset.Density Property

The density of the asset.

## Syntax (C#)
```csharp
public double Density { get; set; }
```

## Remarks
Values are in kilograms per cubed feet (kg/ftÂ³) and must be non-negative.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - When setting this property: The given value for density must be non-negative.

