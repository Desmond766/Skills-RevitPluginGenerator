---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.MultiServerService.SetServerState(System.Guid,Autodesk.Revit.DB.Document,System.Boolean)
source: html/a5a3d19e-57f1-85f9-a2c3-e095094fcd1a.htm
---
# Autodesk.Revit.DB.ExternalService.MultiServerService.SetServerState Method

This method will simply switch the active state of a server without affecting in any way the other servers.

## Syntax (C#)
```csharp
public bool SetServerState(
	Guid serverId,
	Document document,
	bool bActive
)
```

## Parameters
- **serverId** (`System.Guid`) - Id of the server to switch active state for.
- **document** (`Autodesk.Revit.DB.Document`) - Document for which to activate this server. If null, server will activate globally.
- **bActive** (`System.Boolean`) - True to activate server, false to deactivate.

## Returns
True if operation succeeded (even if the server state was not changed), false otherwise (e.g. when serverId is invalid).

## Remarks
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to false
 calling this method will throw exception.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - For a service that doesn't support activation, the servers can't be activated/deactivated.

