---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.IExternalService.IsValidServer(Autodesk.Revit.DB.ExternalService.IExternalServer)
source: html/67f80199-6dad-2d0c-118c-85e83afed78a.htm
---
# Autodesk.Revit.DB.ExternalService.IExternalService.IsValidServer Method

Implement this method to check if the given instance represents a valid server of this service.

## Syntax (C#)
```csharp
bool IsValidServer(
	IExternalServer server
)
```

## Parameters
- **server** (`Autodesk.Revit.DB.ExternalService.IExternalServer`) - An instance of a server that is to be validated.

## Returns
True if the server is valid, False otherwise

## Remarks
This method is invoked by the framework upon registration of a server for this service.
 The simplest implementation would be to test whether the type of the object is as expected,
 but a service may have other rules for validating its servers.

