---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.MinimumYieldStress
source: html/4ff63ecb-cb94-00af-30f0-ab033e755361.htm
---
# Autodesk.Revit.DB.StructuralAsset.MinimumYieldStress Property

The minimum yield stress of the asset.

## Syntax (C#)
```csharp
public double MinimumYieldStress { get; set; }
```

## Remarks
Applies to Metal-based and generic structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be Metal or generic to set this property.

