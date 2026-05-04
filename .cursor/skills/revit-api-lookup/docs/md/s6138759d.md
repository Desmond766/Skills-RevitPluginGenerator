---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.GetMinimum(System.Int32,System.Boolean)
source: html/0e0a6d9e-eb1b-ddc1-3e8a-d62f914f75e8.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.GetMinimum Method

Calculates the minimum value for all primitives

## Syntax (C#)
```csharp
public double GetMinimum(
	int resultIndex,
	bool rawValue
)
```

## Parameters
- **resultIndex** (`System.Int32`) - Index of result schema
- **rawValue** (`System.Boolean`) - If true returned value is NOT multiplied by the current result's units multiplier, otherwise it IS

## Returns
Resulting minimum value

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown when current measurement is >= the number of measurements for at least one primitive

