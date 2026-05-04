---
kind: type
id: T:Autodesk.Revit.DB.Mechanical.IDuctFittingAndAccessoryPressureDropServer
source: html/de29d659-b390-4855-425b-72cb918a3b7a.htm
---
# Autodesk.Revit.DB.Mechanical.IDuctFittingAndAccessoryPressureDropServer

Interface class for external servers implementing duct fitting and duct accessory coefficient calculation.

## Syntax (C#)
```csharp
public interface IDuctFittingAndAccessoryPressureDropServer : IExternalServer
```

## Remarks
A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service, see ExternalServiceRegistry . Assign server to duct fitting instance.

