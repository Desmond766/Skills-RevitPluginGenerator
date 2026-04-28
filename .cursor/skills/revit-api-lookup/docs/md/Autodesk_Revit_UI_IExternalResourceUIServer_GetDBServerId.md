---
kind: method
id: M:Autodesk.Revit.UI.IExternalResourceUIServer.GetDBServerId
source: html/7a58e7fb-d4ed-cb5b-3b3d-496b6be34bd7.htm
---
# Autodesk.Revit.UI.IExternalResourceUIServer.GetDBServerId Method

Implement this method to return the id of the server which is associated with this UI server.

## Syntax (C#)
```csharp
Guid GetDBServerId()
```

## Returns
The id of the associated DB server.

## Remarks
If there's no DB server associated with this UI server, an empty GUID value will be returned.

