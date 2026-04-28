---
kind: method
id: M:Autodesk.Revit.DB.StructuralAsset.SetPoissonRatio(System.Double)
source: html/6347df48-2f78-a33c-316c-bc27c64b538a.htm
---
# Autodesk.Revit.DB.StructuralAsset.SetPoissonRatio Method

Sets the Poisson ratio of the asset.

## Syntax (C#)
```csharp
public void SetPoissonRatio(
	double poissonRatio
)
```

## Parameters
- **poissonRatio** (`System.Double`)

## Remarks
The Poisson ratio is one-dimensional for wood-based and isotropic materials.
 This method sets the x, y, and z components to the same value.

