---
kind: type
id: T:Autodesk.Revit.DB.ExternalService.IMultiServerService
source: html/9704c8c0-2095-37e7-f17c-56d27ff44ed6.htm
---
# Autodesk.Revit.DB.ExternalService.IMultiServerService

The base interface class for all multi-server services.

## Syntax (C#)
```csharp
public interface IMultiServerService : IExternalService
```

## Remarks
Both a single-server and multi-server service may have more than one server
 registered for them. The difference between these two kinds is while there can
 only be one active server at any given time for a single-sever service, there
 may be a whole set of active servers assigned for a multi-server service.
When a multi-server service gets executed, the framework iterates through the set
 of currently active servers (application-wide or document-specific depending on
 the situation) and invokes the service's interface with a CanExecute call. If the
 service replies the current server cannot be executed, the framework skips it and
 continues with the next one in the queue. When a server is found it can be executed,
 the framework calls the service's interface again, this time with the Execute
 method. Whether the execution loop ends after the first executed server or not
 is controlled by execution policy, which is supplied for the service upon its
 registration.

