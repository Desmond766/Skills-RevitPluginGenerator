---
kind: method
id: M:Autodesk.Revit.DB.Analysis.SpatialFieldManager.GetMaximum(System.Int32,System.Boolean)
source: html/adba27cb-ed96-1593-efeb-2466c23dee26.htm
---
# Autodesk.Revit.DB.Analysis.SpatialFieldManager.GetMaximum Method

Calculates the maximum value for all primitives

## Syntax (C#)
```csharp
public double GetMaximum(
	int resultIndex,
	bool rawValue
)
```

## Parameters
- **resultIndex** (`System.Int32`) - Index of result schema
- **rawValue** (`System.Boolean`) - If true returned value is NOT multiplied by the current result's units multiplier, otherwise it IS

## Returns
Resulting maximum value

## Exceptions
- **Autodesk.Revit.Exceptions.InapplicableDataException** - Thrown when current measurement is >= the number of measurements for at least one primitive

