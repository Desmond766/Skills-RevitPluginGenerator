---
kind: method
id: M:Autodesk.Revit.DB.Electrical.TemperatureRatingType.RemoveInsulationType(Autodesk.Revit.DB.Electrical.InsulationType)
source: html/1195de62-fe29-f235-70f1-2e78c6e5f849.htm
---
# Autodesk.Revit.DB.Electrical.TemperatureRatingType.RemoveInsulationType Method

Remove an existing insulation type from this temperature rating type.

## Syntax (C#)
```csharp
public void RemoveInsulationType(
	InsulationType insulationType
)
```

## Parameters
- **insulationType** (`Autodesk.Revit.DB.Electrical.InsulationType`) - Insulation type to be removed.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The last one insulation type of project and any one which is in use by a wire type can't be removed.

