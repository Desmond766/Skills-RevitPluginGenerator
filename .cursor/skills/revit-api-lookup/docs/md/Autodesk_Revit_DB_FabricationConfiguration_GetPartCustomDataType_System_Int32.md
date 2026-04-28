---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetPartCustomDataType(System.Int32)
source: html/46ec095d-1c5a-54e9-3229-4aa6172a274f.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetPartCustomDataType Method

Gets the custom data type from its identifier. See FabricationCustomDataType enumerator.

## Syntax (C#)
```csharp
public FabricationCustomDataType GetPartCustomDataType(
	int customDataId
)
```

## Parameters
- **customDataId** (`System.Int32`) - The custom data identifier.

## Returns
The custom data type.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The custom data does not exist.

