---
kind: type
id: T:Autodesk.Revit.DB.ExternalService.ExternalService
source: html/0408e6d9-12d3-20e4-911e-6d299fe31b81.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService

This base class represents an external service inside Revit application.

## Syntax (C#)
```csharp
public class ExternalService : IDisposable
```

## Remarks
This is a base class from which SingleServerService and MultiServerService
 classes are inherited. It implements all basic methods, but the two inherited
 classes add more methods specific for that kind of service the class
 represents. Use this base class to get information about a service and its
 servers. Use the specific inherited classes to set or get active servers.
Summary of common methods:
 Adding and removing a server to and from a service Getting information about a service Querying a number of servers registered for a service Accessing servers currently registered for a service 
 Summary of the service-specific methods:
 Getting and setting active server (or servers) for a service

