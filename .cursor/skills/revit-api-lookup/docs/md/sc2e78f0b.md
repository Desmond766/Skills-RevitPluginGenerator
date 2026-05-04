---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.SingleServerService.SetActiveServer(System.Guid)
source: html/8d559fcf-ab8b-8104-97a9-460897113bba.htm
---
# Autodesk.Revit.DB.ExternalService.SingleServerService.SetActiveServer Method

Set an active server applicable application-wide for the service.

## Syntax (C#)
```csharp
public void SetActiveServer(
	Guid serverId
)
```

## Parameters
- **serverId** (`System.Guid`) - Id of the application server.

## Remarks
Only one server can be active at any given time in a single-server service,
 but it is possible that no server is active (unless the service is mandatory).
An application-wide active server gets executed when the service is invoked
 in the scope of the entire application (i.e. without a specific document),
 or if the service is executed in a document but the document does not have
 an active server explicitly set.
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to true
 it is possible to set a server as active when another server is already active
 for that service. Making a server active will automatically deactivate the server
 that was active before this call.
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to false
 calling this method will throw exception. For this kind of service only one server can be added,
 and it will be marked by default as active.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id is not of a server registered with the service.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation is not allowed because the service is being executed.
 -or-
 For a service that doesn't support activation, the servers can't be activated/deactivated.

