---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.MultiServerService.GetActiveServerIds
source: html/d3e87992-9ae7-7ad0-3e0b-0931d015b2d7.htm
---
# Autodesk.Revit.DB.ExternalService.MultiServerService.GetActiveServerIds Method

Returns Ids of the currently active application-level servers registered for the service.

## Syntax (C#)
```csharp
public IList<Guid> GetActiveServerIds()
```

## Returns
A set of GUIDs of the application-wide active servers; the list may be empty.

## Remarks
More than one application-level server can be active at a given time in a multi-server service,
 but it is possible that no server is active (unless the service is mandatory).

