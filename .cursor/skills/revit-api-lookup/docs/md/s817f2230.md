---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.MultiServerService.SetActiveServers(System.Collections.Generic.IList{System.Guid})
source: html/d96a3559-859d-6429-6dba-4525a4d587ea.htm
---
# Autodesk.Revit.DB.ExternalService.MultiServerService.SetActiveServers Method

Changes the active servers and/or their order.

## Syntax (C#)
```csharp
public void SetActiveServers(
	IList<Guid> serverIds
)
```

## Parameters
- **serverIds** (`System.Collections.Generic.IList < Guid >`) - A set of Ids of servers that are to be set as active for this service
 or an empty set if no server should currently be set as active.

## Remarks
More than one server can be active at any given time in a multi-server service,
 but it is possible that no server is active (unless the service is mandatory).
An application-wide active servers get executed when the service is invoked
 in the scope of the entire application (i.e. without a specific document),
 or if the service is executed in a document but the document does not have
 active servers explicitly set.
For a service which has cref="Autodesk::Revit::DB::ExternalService::SupportActivation" set to true
 setting active servers replaces previously active servers. Both the number
 of servers and their orders is significant. Servers do always get executed
 in the order in which they were set as active. If it is desired the order
 of execution is different, the same set of active servers must be set again,
 but in the modified, desired order.
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

