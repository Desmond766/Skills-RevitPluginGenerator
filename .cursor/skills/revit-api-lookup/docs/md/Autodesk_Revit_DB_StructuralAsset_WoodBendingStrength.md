---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodBendingStrength
source: html/d008c4d5-111a-674e-b0fc-48e0f12cc2dd.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodBendingStrength Property

The bending strength of the asset.

## Syntax (C#)
```csharp
public double WoodBendingStrength { get; set; }
```

## Remarks
Applies to wood-based structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

