---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.IsRegisteredServerId(System.Guid)
source: html/24077646-e04a-cd18-c9e9-0bc1f7cfbcba.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.IsRegisteredServerId Method

Checks if the Id represents a valid server that has been registered for the service.

## Syntax (C#)
```csharp
public bool IsRegisteredServerId(
	Guid serverId
)
```

## Parameters
- **serverId** (`System.Guid`) - An Id of a server

## Returns
True if the specified server is currently registed for this service, false otherwise.

