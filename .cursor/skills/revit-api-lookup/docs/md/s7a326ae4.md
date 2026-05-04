---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.GetServiceId
source: html/1923a4d7-cf6e-ac24-570f-d48291777f57.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.GetServiceId Method

Implement this method to return the unique Id of the service.

## Syntax (C#)
```csharp
ExternalServiceId GetServiceId()
```

## Returns
The extensible enum value representing the Id of the service.

## Remarks
For all built-in external services, their Ids are all items
 of the enumerated type ExternalServices.BuiltInExternalServices. Third-party services will have their respective Ids based on GUIDs.
 It is important to note that a service Id must be unique. It will
 be an error if two external services try to register with the same Id.

