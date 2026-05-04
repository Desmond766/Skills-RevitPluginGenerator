---
kind: type
id: T:Autodesk.Revit.DB.ExternalService.ExternalServiceId
source: html/2bab66fa-f55d-4419-46d1-f33b9540e727.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceId

Unique identifier of an external service.

## Syntax (C#)
```csharp
public class ExternalServiceId : GuidEnum
```

## Remarks
Each external service must have a unique ExternalServiceId.
 The Id can be registered with Revit for servers to easily find it.
 Unique ExternalServiceId should be created using GUID generation tool.
 ExternalServiceId can later be used to access registered external services.

