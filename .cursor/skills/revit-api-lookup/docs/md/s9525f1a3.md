---
kind: method
id: M:Autodesk.Revit.DB.StructuralAsset.SetShearModulus(System.Double)
source: html/75f7a413-1b73-a7fc-cef1-75c9972e6652.htm
---
# Autodesk.Revit.DB.StructuralAsset.SetShearModulus Method

Sets the shear modulus of the asset.

## Syntax (C#)
```csharp
public void SetShearModulus(
	double shearModulus
)
```

## Parameters
- **shearModulus** (`System.Double`)

## Remarks
The shear modulus is one-dimensional for wood-based and isotropic materials.
 This method sets the x, y, and z components to the same value.
 The value is in Newtons per foot meter (N/(ft Â· m)).

