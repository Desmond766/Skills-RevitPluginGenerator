---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.RegisterService(Autodesk.Revit.DB.ExternalService.ISingleServerService,Autodesk.Revit.DB.ExternalService.ExternalServiceOptions)
source: html/054c94df-c82d-f8d4-b97f-c7efed5cbb97.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.RegisterService Method

A method to register a single-server service.

## Syntax (C#)
```csharp
public static Guid RegisterService(
	ISingleServerService service,
	ExternalServiceOptions options
)
```

## Parameters
- **service** (`Autodesk.Revit.DB.ExternalService.ISingleServerService`) - An instance of the external service class that implements ISingleServerService interface.
- **options** (`Autodesk.Revit.DB.ExternalService.ExternalServiceOptions`) - Optional settings to control the service's behavior.

## Returns
An access key to the service. The key is needed to execute the service.

## Remarks
Each service can only be registered once. Revit checks the Id of every service
 getting registered and throws an exception upon an attempt to register a service
 with an Id that already exists.
Services need to be registered before Revit ends its initialization.
 For external applications that means they have to register their services
 during OnStartup. This will give servers which need to register to services
 a chance to do so during the ApplicationInitialized event, which is raised
 after a successfully processing OnStartup routines.
A service can be registered as either recordable or non-recordable.
 It is expected that a service that is once registered as recordable
 will always be registered as recordable. Failure to comply with this
 policy may lead to data loss in some documents when they are opened
 in a Revit session with the service currently registered as non-recordable.
A service is supposed to be executed only by the application that registered
 it. To enforce this requirement, the registering method return an execution
 key (a Guid) that is required as an argument to ExecuteService methods.
 If the owner of a service allows executing it by anyone, it needs to register
 it as a public service (via the option argument). Once registered as public,
 The access key of the service can be obtained by any application, thus
 it can also be executed by any application. By default, a service is registered
 as private.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given service is not a valid implementation of ISingleServerService.
 -or-
 The given service does not return valid values from the interface methods.
 At least one of the Name, VendorId, Description, and ServiceId is either empty or invalid.
 -or-
 A service with this Id is either invalid or not unique.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Service cannot be registered because the registry of services has been already closed.
 All external services must be registered before the ApplicationInitialized event is raised.

