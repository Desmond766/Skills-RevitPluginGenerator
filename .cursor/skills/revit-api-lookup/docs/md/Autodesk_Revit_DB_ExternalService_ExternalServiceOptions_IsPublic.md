---
kind: property
id: P:Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsPublic
source: html/e3bb9469-5d13-d3d3-853d-238588852243.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceOptions.IsPublic Property

This property denotes a service as either public or private.

## Syntax (C#)
```csharp
public bool IsPublic { get; set; }
```

## Remarks
A public service can be executed by anyone, while a private
 service can be execute only by the caller who registered it
 (the owner of the service, typically), or by someone who has
 access to the service's execution key. Unless specified otherwise, all services are created
 as private by default.

