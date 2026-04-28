---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.GetPartCustomDataText(System.Int32)
source: html/55d3d3e8-6f38-b858-e988-e0940c1b8023.htm
---
# Autodesk.Revit.DB.FabricationPart.GetPartCustomDataText Method

Get custom data text for the specified custom data.

## Syntax (C#)
```csharp
public string GetPartCustomDataText(
	int customId
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to get.

## Returns
Returns the text of the custom data. If the data is a number it will be formatted according to the fabrication configuration's rules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.

