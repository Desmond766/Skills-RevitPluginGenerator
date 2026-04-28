---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.ShearModulus
source: html/5f395818-706a-711b-aa55-bdb11a8ece0f.htm
---
# Autodesk.Revit.DB.StructuralAsset.ShearModulus Property

The shear modulus of the asset.

## Syntax (C#)
```csharp
public XYZ ShearModulus { get; set; }
```

## Remarks
This property cannot be used to set the shear modulus for wood-based and isotropic materials.
 For such assets, use setShearModulus instead.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type is wood.
 -or-
 When setting this property: the behavior is isotropic.

