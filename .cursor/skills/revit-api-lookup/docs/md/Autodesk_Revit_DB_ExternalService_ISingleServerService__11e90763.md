---
kind: type
id: T:Autodesk.Revit.DB.ExternalService.ISingleServerService
source: html/ae967a42-6490-07ed-7976-71d324d250c4.htm
---
# Autodesk.Revit.DB.ExternalService.ISingleServerService

The base interface class for all single-server services.

## Syntax (C#)
```csharp
public interface ISingleServerService : IExternalService
```

## Remarks
Both single-server and multi-server services may have more than one server
 registered for them. The difference between these two kinds is while there can
 only be one active server at any given time for a single-sever service, there
 may be a set of active servers assigned for a multi-server service.
ISingleServerService does not have any specific methods (currently)
 added to those inherited from the common IExternalService interface.

