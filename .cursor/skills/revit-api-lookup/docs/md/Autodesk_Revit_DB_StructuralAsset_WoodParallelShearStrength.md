---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodParallelShearStrength
source: html/663cb76c-58e1-3507-19d1-814e4a78292b.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodParallelShearStrength Property

The parallel shear strength of the asset.

## Syntax (C#)
```csharp
public double WoodParallelShearStrength { get; set; }
```

## Remarks
Applies to wood-based structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

