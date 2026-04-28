---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.ConcreteShearStrengthReduction
source: html/579c95fb-dabb-05ba-e5af-2c3997f1b2b7.htm
---
# Autodesk.Revit.DB.StructuralAsset.ConcreteShearStrengthReduction Property

The shear strength reduction of the asset.

## Syntax (C#)
```csharp
public double ConcreteShearStrengthReduction { get; set; }
```

## Remarks
Applies to concrete-based structural assets.

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type must be concrete to set this property.

