---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.SingleServerService.SetActiveServer(System.Guid,Autodesk.Revit.DB.Document)
source: html/cd04f63b-9c63-2ea2-d69e-c9fc4bb13dd0.htm
---
# Autodesk.Revit.DB.ExternalService.SingleServerService.SetActiveServer Method

Change the active server for a specific document.

## Syntax (C#)
```csharp
public void SetActiveServer(
	Guid serverId,
	Document document
)
```

## Parameters
- **serverId** (`System.Guid`) - Id of the server.
- **document** (`Autodesk.Revit.DB.Document`) - The document for which the server is being set as active.

## Remarks
Only one server per document can be set as active at any given time
 in a single-server service. A document does not have to have an explicitly
 set active server though - the application-wide active server would be
 normally used when the service is executed for such a document.
Having an active server for a document overrules the active server
 set for the application. That means if the service gets executed in
 this particular document, the document-specific server will be used
 instead of the application-wide one.
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to true
 it is possible to set a server as active when another server is already active
 for that service in this document. Making a server active will automatically
 deactivate the server that was active before this call.
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to false
 calling this method will throw exception. For this kind of service only one server can be added,
 and it will be marked by default as an application-wide active server.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given Id is not of a server registered with the service.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation is not allowed because the service is being executed.
 -or-
 For a service that doesn't support activation, the servers can't be activated/deactivated.

