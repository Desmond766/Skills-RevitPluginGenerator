---
kind: type
id: T:Autodesk.Revit.DB.ExternalService.IExternalServer
source: html/91e4af0b-59c0-d640-107a-eebc4d99fa76.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalServer

The base interface for all external servers.

## Syntax (C#)
```csharp
public interface IExternalServer
```

## Remarks
Every external service in Revit declares a specific interface
 for its servers. Each interface must be derived from this IExternalServer.
 Providers of external servers implement the server interfaces
 defined by the respective external services to which the servers
 belong. The whole process of creating a server and registering
 it with Revit as a server of a concrete external service can be
 outlined in the following steps:
 A provider of an external service declares a server interface derived from IExternalServer The provider of the service will make it known that this interface is for the servers of that service An application wanting to have a server will implement the appropriate interface The server's application obtains the service from Revit using the ExternalServiceRegistry.GetService method An instance of the server class can then be registered with Revit by using the ExternalService.AddServer method

