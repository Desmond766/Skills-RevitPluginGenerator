---
kind: property
id: P:Autodesk.Revit.DB.StructuralAsset.YoungModulus
source: html/89daf55c-217b-4daa-3be5-bc89fe1c4972.htm
---
# Autodesk.Revit.DB.StructuralAsset.YoungModulus Property

The Young's modulus of the asset.

## Syntax (C#)
```csharp
public XYZ YoungModulus { get; set; }
```

## Remarks
This property cannot be used to set the Young's modulus for wood-based and isotropic materials.
 For such assets, use setYoungModulus instead.
 The value is in Newtons per foot meter (N/(ft Â· m)).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - When setting this property: A non-optional argument was null
- **Autodesk.Revit.Exceptions.InapplicableDataException** - When setting this property: the material type is wood.
 -or-
 When setting this property: the behavior is isotropic.

