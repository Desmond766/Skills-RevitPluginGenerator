---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.GetDescription
source: html/16d666df-8d5f-74c7-4761-8b8bbeae4397.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.GetDescription Method

Implement this method to return a description of the service.

## Syntax (C#)
```csharp
string GetDescription()
```

## Returns
Description of the service.

## Remarks
The purpose of this string is to describe the external service
 in more details than just a short name alone could do.
 The intended use is to show the string to the end user in UI
 when UI is appropriate for the service. Beside the requirement for it to be a non-empty string,
 there are no other general restrictions imposed by the External Services Framework.

