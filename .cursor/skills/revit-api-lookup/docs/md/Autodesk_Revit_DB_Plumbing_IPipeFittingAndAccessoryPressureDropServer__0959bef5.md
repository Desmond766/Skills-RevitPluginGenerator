---
kind: type
id: T:Autodesk.Revit.DB.Plumbing.IPipeFittingAndAccessoryPressureDropServer
source: html/27a15d91-2dcb-41f3-b818-9c6d3c6e17a3.htm
---
# Autodesk.Revit.DB.Plumbing.IPipeFittingAndAccessoryPressureDropServer

Interface class for external servers implementing pipe fitting and pipe accessory coefficient calculation.

## Syntax (C#)
```csharp
public interface IPipeFittingAndAccessoryPressureDropServer : IExternalServer
```

## Remarks
A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry . Assign server to pipe fitting instance.

