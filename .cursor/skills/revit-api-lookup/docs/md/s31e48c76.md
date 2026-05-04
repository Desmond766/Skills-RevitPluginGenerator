---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalServer.GetDescription
source: html/ab8f162b-c7af-dafc-04f6-8cb3835caa13.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalServer.GetDescription Method

Implement this method to return a description of the server.

## Syntax (C#)
```csharp
string GetDescription()
```

## Returns
Description of the server.

## Remarks
The purpose of this string is to describe the external server
 in more details than just a short name alone could do.
 The intended use is to show the string to the end user in UI
 when UI is appropriate for the corresponding external service. Beside the requirement for it to be a non-empty string,
 there are no other general restrictions imposed by the External Services Framework.
 However, the external service may have some specific rules in place for its servers.

