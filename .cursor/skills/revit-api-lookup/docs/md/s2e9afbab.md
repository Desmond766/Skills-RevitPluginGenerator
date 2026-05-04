---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireMaterialType.AddTemperatureRatingType(System.String,Autodesk.Revit.DB.Electrical.TemperatureRatingType)
source: html/e07cf6c5-d374-ff37-4dc3-1ca59577e466.htm
---
# Autodesk.Revit.DB.Electrical.WireMaterialType.AddTemperatureRatingType Method

Add a new temperature rating type into material type.

## Syntax (C#)
```csharp
public TemperatureRatingType AddTemperatureRatingType(
	string name,
	TemperatureRatingType baseOn
)
```

## Parameters
- **name** (`System.String`) - Name of temperature type to be added.
- **baseOn** (`Autodesk.Revit.DB.Electrical.TemperatureRatingType`) - The new temperature rating will be created base on this existing temperature rating type.

## Returns
New constructed temperature rating type.

