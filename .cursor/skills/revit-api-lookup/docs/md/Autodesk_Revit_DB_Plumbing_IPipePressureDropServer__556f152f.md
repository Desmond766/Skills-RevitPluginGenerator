---
kind: type
id: T:Autodesk.Revit.DB.Plumbing.IPipePressureDropServer
source: html/5f6479aa-4e07-560d-f505-16d44cdd795c.htm
---
# Autodesk.Revit.DB.Plumbing.IPipePressureDropServer

Interface for external servers implementing pipe pressure drop calculation.

## Syntax (C#)
```csharp
public interface IPipePressureDropServer : IExternalServer
```

## Remarks
A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry . Assign server for the pipe pressure drop calculation in PipeSettings .

