---
kind: type
id: T:Autodesk.Revit.UI.Mechanical.IDuctFittingAndAccessoryPressureDropUIServer
source: html/502b969b-0b78-4b9b-b396-ae4e6a31a091.htm
---
# Autodesk.Revit.UI.Mechanical.IDuctFittingAndAccessoryPressureDropUIServer

Interface for external servers providing optional UI for duct fitting and duct accessory coefficient calculation.

## Syntax (C#)
```csharp
public interface IDuctFittingAndAccessoryPressureDropUIServer : IExternalServer
```

## Remarks
This service works with duct fitting and accessory pressure drop service. It provides the settings for the duct fitting and accessory pressure drop server if needed;
 and it also provides UI for user to input the settings in Revit.
 A typical way to use the external server can be:
 Implement a server class that derives from this interface Create a new server object and register it with the service.

