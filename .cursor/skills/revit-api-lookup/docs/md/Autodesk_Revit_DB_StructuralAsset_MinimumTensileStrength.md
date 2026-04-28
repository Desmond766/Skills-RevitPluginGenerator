---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.MinimumTensileStrength
source: html/6ab72995-032f-1648-38e4-727a24e08491.htm
---
# Autodesk.Revit.DB.StructuralAsset.MinimumTensileStrength Property

The minimum tensile strength of the asset.

## Syntax (C#)
```csharp
public double MinimumTensileStrength { get; set; }
```

## Remarks
Applies to Metal-based and generic structural assets.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be Metal or generic to set this property.

