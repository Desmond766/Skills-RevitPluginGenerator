---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalServer.GetServiceId
source: html/1f8da2c8-54d9-2d69-bdcc-e801d990d463.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalServer.GetServiceId Method

Implement this method to return the id of the service.

## Syntax (C#)
```csharp
ExternalServiceId GetServiceId()
```

## Returns
The id of the service to which the server belongs.

## Remarks
An external server belongs to only one external service.
 This method must return an Id that matches the Id of the corresponding service was registered with.

