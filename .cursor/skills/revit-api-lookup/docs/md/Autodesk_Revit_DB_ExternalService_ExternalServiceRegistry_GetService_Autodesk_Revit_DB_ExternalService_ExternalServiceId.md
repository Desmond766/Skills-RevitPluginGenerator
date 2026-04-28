---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.GetService(Autodesk.Revit.DB.ExternalService.ExternalServiceId)
source: html/d12b0501-12a5-0d65-ac98-215c35dd0c0b.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.GetService Method

Returns an instance of an object that represents the external service with the given Id.

## Syntax (C#)
```csharp
public static ExternalService GetService(
	ExternalServiceId serviceId
)
```

## Parameters
- **serviceId** (`Autodesk.Revit.DB.ExternalService.ExternalServiceId`) - Id of the service.

## Returns
The instance of the service or NULL if it cannot be found.

## Remarks
The returned instance is either of type SingleServerService or MultiServerService.
 Users should cast the returned object to one of the classes if they need access to active servers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

