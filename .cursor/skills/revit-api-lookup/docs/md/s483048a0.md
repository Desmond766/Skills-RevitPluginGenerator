---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.OnServersDisparity(Autodesk.Revit.DB.Document,System.Collections.Generic.IList{System.Guid})
source: html/6d47d262-499e-75b8-4b8e-40bb0234241f.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.OnServersDisparity Method

Implements this method to get notified that the servers in a just
 opened document differ from those currently set as active for the service.

## Syntax (C#)
```csharp
DisparityResponse OnServersDisparity(
	Document document,
	IList<Guid> oldServers
)
```

## Parameters
- **document** (`Autodesk.Revit.DB.Document`) - The coresponding document
- **oldServers** (`System.Collections.Generic.IList < Guid >`) - Ids of servers previously used in the document. Please note that the Ids may
 belong to servers that are currently not registered with the service.

## Returns
Return DoNothing if the situation has been completely handled by your service;
 If not, reply with either ApplyDefaults (typical case) or LetUserDecide.

## Remarks
This method may only be invoked in a recordable service.
 Services registered as non-recordable never receive this call.
This notification is sent when Revit opens a document which has a record of
 the service used (executed at least once) and the record shows that the server
 (or servers) used differ from those currently set as active for the service.
Unless the situation is explicitly handled in this call (by returning DoNothing),
 the framework will follow up by assigning the formerly used servers as the
 currently active servers of that document. After it will notify the service
 about the change by invoking the OnServersChanged method on the services interface.

