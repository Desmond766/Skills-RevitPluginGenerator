---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.ExecuteService(System.Guid,Autodesk.Revit.DB.Document,Autodesk.Revit.DB.ExternalService.IExternalData)
source: html/e0daaeed-3020-3e32-8cc4-f0dc9f7ce028.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.ExecuteService Method

Execute the service for the given document.

## Syntax (C#)
```csharp
public static ExternalServiceResult ExecuteService(
	Guid executionKey,
	Document document,
	IExternalData data
)
```

## Parameters
- **executionKey** (`System.Guid`) - Access key of the service to be executed.
 The key is not the same as the service's Id. It is the value
 that was returned to the caller who registered the service.
- **document** (`Autodesk.Revit.DB.Document`) - The document for which the service is going to be executed.
- **data** (`Autodesk.Revit.DB.ExternalService.IExternalData`) - The associated data. The type must be of the class defined by the service.

## Returns
The result of executing the external service.

## Remarks
Execution of a service should be invoked only by the application
 that registered the service. The execution will use the active server
 (or servers in the case of a multi-server service) currently set for
 the given document. If there is no server specifically set for the
 document the current application-wide server (or servers) will be applied.
Please note that recordable services may only be executed in a document
 that is currently modifiable. An exception will be thrown if it isn't so.
 This requirement does not apply to non-recordable services.
This method is primarily intended for executing of recordable services,
 for it is assumed that any changes made to the model during the service's
 execution are likely tied with the service's currently active servers.
 If the service was registered as non-recordable, changes to the model may
 still be made, but the framework does not assume any explicit or implicit
 correlations between the document changes and servers that caused them,
 therefore it is not recorded which server did what. This fact is very important,
 particularly in work-sharing environment. If it may happen that different
 local users can have different servers installed and available, it is
 imperative for a non-serialized service that its servers are completely
 compatible with (or indifferent to) document modifications made by other
 servers of the same service. The responsibility for complying with this
 assumption is entirely on the service's provider.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The execution key is either invalid or of a service that is not registered.
 To execute a service, the key returned by RegisterService method must be used.
 -or-
 The execution key is of a service that is already being executed.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Executing a recordable service in a document that is not modifiable.

