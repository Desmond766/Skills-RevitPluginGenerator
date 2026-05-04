---
kind: method
id: M:Autodesk.Revit.UI.Plumbing.IPipeFittingAndAccessoryPressureDropUIServer.GetDBServerId
source: html/30c17f93-7cf2-fbaf-d880-35f0bff7f88c.htm
---
# Autodesk.Revit.UI.Plumbing.IPipeFittingAndAccessoryPressureDropUIServer.GetDBServerId Method

Returns the Id of the corresponding DB server for which this server provides an optional UI.

## Syntax (C#)
```csharp
Guid GetDBServerId()
```

## Returns
The Id of the DB server.

## Remarks
Note that there may be only one UI server assigned to a DB calculation server.

