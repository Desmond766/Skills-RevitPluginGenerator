---
kind: method
id: M:Autodesk.Revit.DB.FabricationPart.RemovePartCustomData(System.Int32)
source: html/ee48c297-18a0-bc55-066f-e7bbad9fd12e.htm
---
# Autodesk.Revit.DB.FabricationPart.RemovePartCustomData Method

Remove custom data from the fabrication part.

## Syntax (C#)
```csharp
public bool RemovePartCustomData(
	int customId
)
```

## Parameters
- **customId** (`System.Int32`) - The identifier of the custom data field to remove.

## Returns
Returns true if the type was found and removed. The type will not be removed if it is not an optional type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist on the part.

