---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.OnServersChanged(Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalService.ServerChangeCause,System.Collections.Generic.IList{System.Guid})
source: html/792efefb-aa2e-d934-2a68-3a9199d5c96d.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.OnServersChanged Method

Implement this method to handle situations when servers for the service have changed.

## Syntax (C#)
```csharp
void OnServersChanged(
	Document document,
	ServerChangeCause cause,
	IList<Guid> oldServers
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The corresponding document
- **cause** (`Autodesk.Revit.DB.ExternalService.ServerChangeCause`) - Indicates in what situation the servers are changed. Currently available values indicate
 whether the change is a result of an explicit user request, or by an implicit change of
 situation within the service - for example when a document is updated upon opening.
- **oldServers** (`System.Collections.Generic.IList < Guid >`) - Ids of servers previously used in the document. Please note that the Ids may
 belong to servers that are not registered with service anymore.

## Remarks
This method may only be invoked in a recordable service.
 Services registered as non-recordable never receive this call.
It is imperative to understand this method is not called just when an active server (or servers)
 is (are) changed for a service. It is invoked only when the active server is changed so it is
 different from those previously used (i.e. actually executed) in a document. Because of that,
 this notification is never sent when active server is set or reset in a document in which the
 service was never executed before.
If a document has explicitly set active server (or servers), OnServersChanged is never called
 for that document when the application-wide active server (servers) gets changed. The document
 would still be executed with its own active servers applied.
 A similar case is when the active server (servers) is unset for a document but the currently
 active application-wide server happens to be the same as the one that was set in the document.
It is up to the service provider to decide what should be the appropriate action. In some cases,
 if not all, the service will probably want to execute again, now with the new active server(s),
 but that it is not necessary - the service invoker may as well decide to wait for the end-user
 to trigger execution if the service (e.g. by clicking a corresponding command in the menu.)

