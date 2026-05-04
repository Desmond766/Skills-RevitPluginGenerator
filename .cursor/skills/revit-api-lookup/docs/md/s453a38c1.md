---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.ExecuteService(System.Guid,Autodesk.Revit.DB.ExternalService.IExternalData)
source: html/89cfbb29-5f7c-bd05-e216-0befff791ae5.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.ExecuteService Method

Execute a service independently of any document.

## Syntax (C#)
```csharp
public static ExternalServiceResult ExecuteService(
	Guid executionKey,
	IExternalData data
)
```

## Parameters
- **executionKey** (`System.Guid`) - Access key of the service to be executed.
 The key is not the same as the service's Id. It is the value
 that was returned to the caller who registered the service.
- **data** (`Autodesk.Revit.DB.ExternalService.IExternalData`) - The associated data. The type is defined by the service.

## Returns
The result of executing the external service.

## Remarks
Execution of a service should be invoked only by the application
 that registered the service. The execution will use the currently
 active server (or servers in the case of a multi-server service).
This method does not take a document as one of its arguments
 and therefore it is not intended for executions of recordable
 services that may modify documents. If the service (recordable)
 or its server(s) is expected to modify documents, the other ExecuteService
 method -- the one that takes a document as one of its arguments -- is
 supposed to be used.
Non-recordable services are free to modify documents during this
 ExecuteService call, because activities of non-recordable services
 are not recorded; the changes those services made are assumed to be
 independent of the presence of the service and/or its servers.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The execution key is either invalid or of a service that is not registered.
 To execute a service, the key returned by RegisterService method must be used.
 -or-
 The execution key is of a service that is already being executed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

