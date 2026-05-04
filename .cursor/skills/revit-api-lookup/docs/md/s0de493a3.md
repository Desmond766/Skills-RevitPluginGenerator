---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.RemoveServer(System.Guid)
source: html/8659a6ce-c473-987a-beea-388f64c5f0f3.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.RemoveServer Method

Removes/unregisters a server from the service.

## Syntax (C#)
```csharp
public void RemoveServer(
	Guid serverId
)
```

## Parameters
- **serverId** (`System.Guid`) - Id of the server to be unregistered.

## Remarks
Only servers that have not been used yet (executed) in any still open document are allowed
 to be removed. This applies to servers used in the current session or previous sessions.
It is possible to remove servers that are currently set as active, because it is possible
 for a service to have no active server assigned. This does not apply to mandatory services, which
 will always have at least one server registered - the default server - and at least one server
 set as active at all times.
A server cannot be removed during the service's execution or when another server is just being
 added or removed (e.g. during OnServersChanged call-back to the service).
Default server may not be removed. An attempt to do so will lead to an exception.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - A server with this Id has not been registered for this service.
 -or-
 A server with this Id has already been used in a currently open document
 -or-
 The given serverId belongs to the default server of the service. Default servers may not be removed.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation is not allowed because the service is being executed.
 -or-
 The service provider is not valid.

