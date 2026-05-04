---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.RegisterService(Autodesk.Revit.DB.ExternalService.IMultiServerService,Autodesk.Revit.DB.ExternalService.ExternalServiceOptions,Autodesk.Revit.DB.ExternalService.ExecutionPolicy)
source: html/79a85e01-c0c0-9efa-0a91-271b57cdc557.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalServiceRegistry.RegisterService Method

A method to register a multi-server service.

## Syntax (C#)
```csharp
public static Guid RegisterService(
	IMultiServerService service,
	ExternalServiceOptions options,
	ExecutionPolicy policy
)
```

## Parameters
- **service** (`Autodesk.Revit.DB.ExternalService.IMultiServerService`) - An instance of the external service class that implements IMultiServerService interface.
- **options** (`Autodesk.Revit.DB.ExternalService.ExternalServiceOptions`) - Optional settings to control the service's behavior.
- **policy** (`Autodesk.Revit.DB.ExternalService.ExecutionPolicy`) - Specifies how the service handles servers during its execution.

## Returns
An execution key to access the service when executing it.

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
An application registering a service must specify a policy to follow when
 executing the service. Once set, the policy remain constant during the
 Revit session, but a different policy may be used next time, if there
 is ever a need for such a change. More about the various execution policies
 can be found in the description of the ExecutionPolicy enumerated type.
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
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Service cannot be registered because the registry of services has been already closed.
 All external services must be registered before the ApplicationInitialized event is raised.

