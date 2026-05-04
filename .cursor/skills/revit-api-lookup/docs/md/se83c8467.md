---
kind: method
id: M:Autodesk.Revit.DB.Electrical.WireMaterialType.RemoveTemperatureRatingType(Autodesk.Revit.DB.Electrical.TemperatureRatingType)
source: html/84c4992a-c355-2a2b-23de-606791e00e03.htm
---
# Autodesk.Revit.DB.Electrical.WireMaterialType.RemoveTemperatureRatingType Method

Remove an existing temperature rating type from this material type.

## Syntax (C#)
```csharp
public void RemoveTemperatureRatingType(
	TemperatureRatingType temperatureRating
)
```

## Parameters
- **temperatureRating** (`Autodesk.Revit.DB.Electrical.TemperatureRatingType`) - The temperature rating type to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The last temperature rating type of project and any one used by a wire type can't be removed.

