---
kind: method
id: M:Autodesk.Revit.DB.StructuralAsset.SetThermalExpansionCoefficient(System.Double)
source: html/719f5d40-2c08-5cca-f1d5-87793fff5242.htm
---
# Autodesk.Revit.DB.StructuralAsset.SetThermalExpansionCoefficient Method

Sets the thermal expansion coefficient of the asset.

## Syntax (C#)
```csharp
public void SetThermalExpansionCoefficient(
	double thermalExpCoeff
)
```

## Parameters
- **thermalExpCoeff** (`System.Double`)

## Remarks
The thermal expansion coefficient is one-dimensional for wood-based and isotropic materials.
 This method sets the x, y, and z components to the same value.
 The value is in inverse Kelvin (1/K).

