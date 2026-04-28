---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.GetName
source: html/216416ae-c0dc-53f2-f961-d03567fc44fe.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.GetName Method

Implement this method to return the name of the service.

## Syntax (C#)
```csharp
string GetName()
```

## Returns
Name of the service.

## Remarks
Although an external service is uniquely identified by its Id, the Name
 can identify it to the end user in UI when UI is appropriate for the service. Beside the requirement for the name to be a non-empty string,
 there are no other general restrictions imposed by the External Services Framework.

