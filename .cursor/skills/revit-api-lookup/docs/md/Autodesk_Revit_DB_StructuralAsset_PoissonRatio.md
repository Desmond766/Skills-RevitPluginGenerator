---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.PoissonRatio
source: html/a9c7d7a2-7419-8daa-119b-432c80e461a1.htm
---
# Autodesk.Revit.DB.StructuralAsset.PoissonRatio Property

The Poisson ratio of the asset.

## Syntax (C#)
```csharp
public XYZ PoissonRatio { get; set; }
```

## Remarks
This property cannot be used to set the Poisson ratio for wood-based and isotropic materials.
 For such assets, use setPoissonRatio instead.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type is wood.
 -or-
 When setting this property: the behavior is isotropic.

