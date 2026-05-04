---
kind: method
id: M:Autodesk.Revit.DB.Lighting.AdvancedLossFactor.#ctor(System.Double,System.Double,System.Double,System.Double,System.Double,System.Double,System.Double)
source: html/cea92f47-d977-d54f-b371-95cadb232f5f.htm
---
# Autodesk.Revit.DB.Lighting.AdvancedLossFactor.#ctor Method

Creates an advanced loss factor object with the given values.

## Syntax (C#)
```csharp
public AdvancedLossFactor(
	double ballastLossFactorIn,
	double lampLumenDepreciationIn,
	double lampTiltLossFactorIn,
	double luminaireDirtDepreciationIn,
	double surfaceDepreciationLossFactorIn,
	double temperatureLossFactorIn,
	double voltageLossFactorIn
)
```

## Parameters
- **ballastLossFactorIn** (`System.Double`) - The ballast loss factor as a numerical value between 0.0 and 1.0.
- **lampLumenDepreciationIn** (`System.Double`) - The lamp lumen depreciation loss factor as a numerical value between 0.0 and 1.0.
- **lampTiltLossFactorIn** (`System.Double`) - The lamp tilt loss factor as a numerical value between 0.0 and 1.0.
- **luminaireDirtDepreciationIn** (`System.Double`) - The luminaire dirt depreciation loss factor as a numerical value between 0.0 and 1.0.
- **surfaceDepreciationLossFactorIn** (`System.Double`) - The surface depreciation loss factor as a numerical value between 0.0 and 1.0.
- **temperatureLossFactorIn** (`System.Double`) - The temperature loss factor as a numerical value between 0.0 and 2.0.
- **voltageLossFactorIn** (`System.Double`) - The voltage loss factor as a numerical value between 0.0 and 2.0.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The loss factor is not valid because it is not between 0.0 and 1.0.
 -or-
 The loss factor is not valid because it is not between 0.0 and 2.0.

