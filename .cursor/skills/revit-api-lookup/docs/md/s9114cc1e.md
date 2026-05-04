---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalServer.GetName
source: html/df64b529-27e1-3a6a-7876-2145bb8a37b4.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalServer.GetName Method

Implement this method to return the name of the server.

## Syntax (C#)
```csharp
string GetName()
```

## Returns
Name of the server.

## Remarks
Although a server is uniquely identified by its Id,
 the Name can identify it to the end user in UI when UI
 is appropriate for the corresponding external service. Beside the requirement for the name to be a non-empty string,
 there are no other general restrictions imposed by the External Services Framework.
 However, the external service may have some specific rules in place for its servers.

