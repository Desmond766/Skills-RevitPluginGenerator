---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.AddPartCustomData(System.Int32)
source: html/30ec16b0-8480-7777-144d-b76a99b74e6f.htm
---
# Autodesk.Revit.DB.FabricationPart.AddPartCustomData Method

Add custom data type to the fabrication part. The new data gets the default value defined by the fabrication configuration.

## Syntax (C#)
```csharp
public bool AddPartCustomData(
	int customId
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to add.

## Returns
Returns true if the type was not already present.

## Remarks
The custom id must be positive.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data identifier does not exist.

