---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.GetPartCustomDataInteger(System.Int32)
source: html/20ee7ee5-dabe-16ad-c4a7-78b673117642.htm
---
# Autodesk.Revit.DB.FabricationPart.GetPartCustomDataInteger Method

Get custom data integer value for the specified custom data.

## Syntax (C#)
```csharp
public int GetPartCustomDataInteger(
	int customId
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to get.

## Returns
Returns the integer of the custom data. If the data is not a number it will return 0.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.

