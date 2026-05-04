---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetPartCustomDataName(System.Int32)
source: html/46f73ae4-794e-e195-4d52-47a7df0346c9.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetPartCustomDataName Method

Gets the custom data name from its identifier.

## Syntax (C#)
```csharp
public string GetPartCustomDataName(
	int customDataId
)
```

## Parameters
- **customDataId** (`System.Int32`) - The custom data identifier.

## Returns
The custom data name.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist.

