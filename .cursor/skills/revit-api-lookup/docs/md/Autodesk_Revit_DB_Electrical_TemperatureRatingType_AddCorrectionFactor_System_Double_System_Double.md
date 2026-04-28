---
kind: method
id: M:Autodesk.Revit.DB.Electrical.TemperatureRatingType.AddCorrectionFactor(System.Double,System.Double)
source: html/c8c0c7ac-34af-bc90-e55f-6f1a7baa0572.htm
---
# Autodesk.Revit.DB.Electrical.TemperatureRatingType.AddCorrectionFactor Method

Add a new electrical correction factor type to this temperature rating type. The given temperature
value should be quantified in the document's selected unit of electrical temperature.

## Syntax (C#)
```csharp
public CorrectionFactor AddCorrectionFactor(
	double temperature,
	double factor
)
```

## Parameters
- **temperature** (`System.Double`) - Temperature of correction factor to be added in the document's selected unit of electrical temperature.
- **factor** (`System.Double`) - Factor of correction factor to be added.

## Returns
New constructed correction factor.

