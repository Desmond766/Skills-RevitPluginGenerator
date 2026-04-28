---
kind: method
id: M:Autodesk.Revit.DB.FabricationConfiguration.GetServiceByGUID(System.Guid)
source: html/bf058c52-e36d-e8fd-f2c7-88a4d30ec3d6.htm
---
# Autodesk.Revit.DB.FabricationConfiguration.GetServiceByGUID Method

Gets the service identifier by its GUID.

## Syntax (C#)
```csharp
public int GetServiceByGUID(
	Guid serviceGUID
)
```

## Parameters
- **serviceGUID** (`System.Guid`) - The service GUID.

## Returns
The service identifier. Returns 0 if not found.

