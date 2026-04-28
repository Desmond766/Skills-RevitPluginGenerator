---
kind: type
id: T:Autodesk.Revit.DB.Mechanical.IDuctPressureDropServer
source: html/a10ca03f-4146-c0c0-7783-86682fa869cd.htm
---
# Autodesk.Revit.DB.Mechanical.IDuctPressureDropServer

Interface for external servers implementing duct pressure drop calculation.

## Syntax (C#)
```csharp
public interface IDuctPressureDropServer : IExternalServer
```

## Remarks
A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry . Assign server for the duct pressure drop calculation in DuctSettings .

