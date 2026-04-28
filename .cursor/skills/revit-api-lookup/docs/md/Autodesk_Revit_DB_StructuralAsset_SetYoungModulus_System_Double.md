---
kind: method
id: M:Autodesk.Revit.DB.StructuralAsset.SetYoungModulus(System.Double)
source: html/a2ec0ac0-2783-d074-9d13-36306959c0b8.htm
---
# Autodesk.Revit.DB.StructuralAsset.SetYoungModulus Method

Sets the Young's modulus of the asset.

## Syntax (C#)
```csharp
public void SetYoungModulus(
	double youngModulus
)
```

## Parameters
- **youngModulus** (`System.Double`)

## Remarks
The Young's modulus is one-dimensional for wood-based and isotropic materials.
 This method sets the x, y, and z components to the same value.
 The value is in Newtons per foot meter (N/(ft Â· m)).

