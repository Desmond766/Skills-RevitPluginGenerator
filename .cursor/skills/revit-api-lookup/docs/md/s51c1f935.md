---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodPerpendicularCompressionStrength
source: html/16afb0a2-49fe-c791-2081-f91b75e4d5b5.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodPerpendicularCompressionStrength Property

The perpendicular compression strength of the asset.

## Syntax (C#)
```csharp
public double WoodPerpendicularCompressionStrength { get; set; }
```

## Remarks
Applies to wood-based structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

