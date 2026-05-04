---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.ExecuteService(System.Guid,System.Guid,Autodesk.Revit.DB.ExternalService.IExternalData)
source: html/2dbd5fdf-7ba7-a15f-8883-21b1e8d4e063.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.ExecuteService Method

Execute the service by the given server.

## Syntax (C#)
```csharp
public static ExternalServiceResult ExecuteService(
	Guid executionKey,
	Guid serverId,
	IExternalData data
)
```

## Parameters
- **executionKey** (`System.Guid`) - Access key of the service to be executed.
 The key is not the same as the service's Id. It is the value
 that was returned to the caller who registered the service.
- **serverId** (`System.Guid`) - the specific server to execute
- **data** (`Autodesk.Revit.DB.ExternalService.IExternalData`) - The associated data. The type must be of the class defined by the service.

## Returns
The result of executing the external service.

## Remarks
Execution of a service should be invoked only by the application
 that registered the service. The execution will use the given server.
The serverId must be of a valid server that is currently registered for the service, ArgumentException
 be thrown if it is not available.
Because this method executes an explicitly specified server regardless of what other servers are
 currently active, it can only be invoked for a service that is not set as being recordable.
Plese also note that this method does not have any effect on active servers currently set for the service.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

