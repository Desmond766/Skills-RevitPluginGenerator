---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.SetPartCustomDataInteger(System.Int32,System.Int32)
source: html/20983846-bfc8-2844-80e3-09c587bc6a9d.htm
---
# Autodesk.Revit.DB.FabricationPart.SetPartCustomDataInteger Method

Set the custom data integer value for the specified custom data.

## Syntax (C#)
```csharp
public void SetPartCustomDataInteger(
	int customId,
	int value
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to set.
- **value** (`System.Int32`) - The integer value of the custom data. If the data is not an integer type the value will be parsed according to the fabrication confifuration rules.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.

