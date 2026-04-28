---
kind: method
id: M:Autodesk.Revit.DB.ExternalService.ExternalService.AddServer(Autodesk.Revit.DB.ExternalService.IExternalServer)
source: html/6e60c7f3-83f3-dca5-745c-efd995421369.htm
---
# Autodesk.Revit.DB.ExternalService.ExternalService.AddServer Method

Registers a server with its service.

## Syntax (C#)
```csharp
public void AddServer(
	IExternalServer server
)
```

## Parameters
- **server** (`Autodesk.Revit.DB.ExternalService.IExternalServer`) - The instance of the server. The server must implement the interface provided by the service.

## Remarks
Servers must be registered with their services. There has to be at least one server
 registered for a service in order to be able to execute the service.
A server can be added only once. An attempt to add a server again will lead to an exception.
 A server cannot be removed during the service's execution or when another server is just being
 added or removed (e.g. during OnServersChanged call-back to the service).
When SupportActivation 
 is set to true adding a server to a service does not make the server active yet. It is the developer's
 responsibility to change its activation state.
When SupportActivation 
 is set to false, for a single-server service there can be added only one server, and this will be
 considered active. An attempt to add another one will lead to an exception. For a multi-server service
 there can be added multiple servers and all of them will be considered activated.
Servers can be registered at any time; registering does not need to happen during an application's
 start-up, but it must happen - naturally - after the respective service has been registered.
 Since all built-in services are automatically registered during initialization of Revit, their servers
 can be added as early as during the OnStartup method. Third-party services, on the other hand, get
 registered during the OnStartup method, therefore their servers need to be added later. The next
 earliest opportunity for adding servers to a third-party service is on the ApplicationInitialized event.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The Server object is not valid or its service Id does not match the service.
 -or-
 A server with the same Id has already been registered with the service.
 -or-
 The given server does not return valid values from the interface methods.
 At least one of the Name, VendorId, Description, and ServerId is empty or invalid.
 -or-
 The server does not represent a server of a valid type to be used with the service.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The operation is not allowed because the service is being executed.
 -or-
 The service provider is not valid.
 -or-
 Only one server can be added for a single-server service.

