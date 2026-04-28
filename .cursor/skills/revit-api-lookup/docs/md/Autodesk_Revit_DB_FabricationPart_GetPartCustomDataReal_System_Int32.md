---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.GetPartCustomDataReal(System.Int32)
source: html/085c3760-17d9-b595-8bd2-b3659902fd01.htm
---
# Autodesk.Revit.DB.FabricationPart.GetPartCustomDataReal Method

Get custom data real value for the specified custom data.

## Syntax (C#)
```csharp
public double GetPartCustomDataReal(
	int customId
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to get.

## Returns
Returns the real number of the custom data. If the data is not a number it will return 0.0.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.

