---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.WoodParallelCompressionStrength
source: html/8f7a5f8b-e222-5e5b-66a7-a9e5c9dde17e.htm
---
# Autodesk.Revit.DB.StructuralAsset.WoodParallelCompressionStrength Property

The parallel compression strength of the asset.

## Syntax (C#)
```csharp
public double WoodParallelCompressionStrength { get; set; }
```

## Remarks
Applies to wood-based structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be wood to set this property.

