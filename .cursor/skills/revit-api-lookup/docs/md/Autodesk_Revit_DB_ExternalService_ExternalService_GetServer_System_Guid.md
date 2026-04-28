---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.GetServer(System.Guid)
source: html/839e6c3d-1f70-4668-781f-823baf005ff5.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.GetServer Method

Returns the instance that provides implementation for a registered server.

## Syntax (C#)
```csharp
public IExternalServer GetServer(
	Guid serverId
)
```

## Parameters
- **serverId** (`System.Guid`) - Id of a registered server

## Returns
An instance of the server interface. NULL is returned if the server is invalid (e.g. destroyed)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id is not a valid GUID value.

