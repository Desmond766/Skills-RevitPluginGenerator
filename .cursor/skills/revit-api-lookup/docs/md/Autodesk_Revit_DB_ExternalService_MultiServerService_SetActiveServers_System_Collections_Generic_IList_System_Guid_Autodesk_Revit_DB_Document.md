---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.MultiServerService.SetActiveServers(System.Collections.Generic.IList{System.Guid},Autodesk.Revit.DB.Document)
source: html/2b1cfcab-7354-010c-b40d-8ca063ac8b8f.htm
---
# Autodesk.Revit.DB.ExternalService.MultiServerService.SetActiveServers Method

Changes the active servers and/or their order for the given document.

## Syntax (C#)
```csharp
public void SetActiveServers(
	IList<Guid> serverIds,
	Document document
)
```

## Parameters
- **serverIds** (`System.Collections.Generic.IList < Guid >`) - A set of Ids of servers that are to be set as active for this service in this
 document or an empty set if no server should currently be set as active in this
 particular document.
- **document** (`Autodesk.Revit.DB.Document`) - The document for which the servers are set as active.

## Remarks
More than one server per document can be set as active at any given time
 in a multi-server service. A document does not have to have an explicitly
 set active servers though - the application-wide active servers would be
 normally used when the service is executed for such a document.
Having active servers for a document overrules the active servers
 set for the application. That means if the service gets executed in
 this particular document, the document-specific servers will be used
 instead of the application-wide ones.
It is possible to set servers as active when other servers already are active
 for that service in this document. Setting a new set or the same set
 but with a different order will automatically replace the previously active
 servers in that document
All the servers must be valid (registered with the service) and must be unique
 in the set. The set may be empty though which allows to unset active servers
 from a document, which means that the document will be executed with the currently
 active servers set application-wide
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to false
 calling this method will throw exception.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Some of the given Ids do not represent valid servers of the service.
 -or-
 The list of servers contains duplicates. The SetActiveServers method expects a set of unique servers.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation is not allowed because the service is being executed.
 -or-
 For a service that doesn't support activation, the servers can't be activated/deactivated.

