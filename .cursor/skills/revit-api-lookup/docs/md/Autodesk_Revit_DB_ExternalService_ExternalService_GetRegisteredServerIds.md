---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.GetRegisteredServerIds
source: html/230b50ac-8db7-cf62-2502-3cb0fd217b35.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.GetRegisteredServerIds Method

Returns Ids of all servers registered for the service.

## Syntax (C#)
```csharp
public IList<Guid> GetRegisteredServerIds()
```

## Returns
An array of Ids of all registered servers. The array may be empty.

## Remarks
The list includes all registered servers regardless of whether they are currently active or not.

