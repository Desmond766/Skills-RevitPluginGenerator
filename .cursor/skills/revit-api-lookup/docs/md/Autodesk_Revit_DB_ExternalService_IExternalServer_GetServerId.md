---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalServer.GetServerId
source: html/49b1955b-a729-b610-0138-592784d20171.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalServer.GetServerId Method

Implement this method to return the id of the server.

## Syntax (C#)
```csharp
Guid GetServerId()
```

## Returns
The id of the server.

## Remarks
The Id must uniquely identify the external server
 to the corresponding external service. It will be
 an error when two servers with identical Ids try
 to register for one external service.

