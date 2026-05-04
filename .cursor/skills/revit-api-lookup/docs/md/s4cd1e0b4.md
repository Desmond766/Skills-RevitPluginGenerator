---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodPerpendicularShearStrength
source: html/c5862404-4802-ea0d-9143-ea77eeaf0601.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodPerpendicularShearStrength Property

The perpendicular shear strength of the asset.

## Syntax (C#)
```csharp
public double WoodPerpendicularShearStrength { get; set; }
```

## Remarks
Applies to wood-based structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

