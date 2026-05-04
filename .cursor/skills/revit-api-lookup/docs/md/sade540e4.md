---
kind: type
id: T:Autodesk.Revit.UI.Plumbing.IPipeFittingAndAccessoryPressureDropUIServer
source: html/727a30e8-f519-3192-0e4b-0d86bc537c0c.htm
---
# Autodesk.Revit.UI.Plumbing.IPipeFittingAndAccessoryPressureDropUIServer

Interface for external servers providing optional UI for pipe fitting and pipe accessory coefficient calculation.

## Syntax (C#)
```csharp
public interface IPipeFittingAndAccessoryPressureDropUIServer : IExternalServer
```

## Remarks
This service works with pipe fitting and accessory pressure drop service. It provides the settings for the pipe fitting and accessory pressure drop server if needed;
 and it also provides UI for user to input the settings in Revit.
 A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service.

