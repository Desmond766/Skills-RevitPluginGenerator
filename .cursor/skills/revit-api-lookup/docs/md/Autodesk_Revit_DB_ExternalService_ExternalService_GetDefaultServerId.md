---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.GetDefaultServerId
source: html/f348cd43-7480-2799-12ed-9d6dbc2b47b7.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.GetDefaultServerId Method

Returns the Id of the default server if one was assigned to the service.

## Syntax (C#)
```csharp
public Guid GetDefaultServerId()
```

## Returns
The GUID of the default server, or an invalid GUID if there is none assigned.

## Remarks
Only mandatory services have default servers assigned.
 Only single-server and built-in multi-server services can currently be mandatory.
 All other services that are optional don't have a default server.

