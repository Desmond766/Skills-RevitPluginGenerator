---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.LoadResource(System.Guid,Autodesk.Revit.DB.ExternalResourceType,Autodesk.Revit.DB.ExternalResourceReference,Autodesk.Revit.DB.ExternalResourceLoadContext,Autodesk.Revit.DB.ExternalResourceLoadContent)
source: html/f9e67f37-93dc-24a1-70f2-ea603a7719ab.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.LoadResource Method

Implement this method to load the requested resource.

## Syntax (C#)
```csharp
void LoadResource(
	Guid loadRequestId,
	ExternalResourceType resourceType,
	ExternalResourceReference desiredResource,
	ExternalResourceLoadContext loadContext,
	ExternalResourceLoadContent loadResults
)
```

## Parameters
- **loadRequestId** (`System.Guid`) - The id uniquely identifying the load request.
- **resourceType** (`Autodesk.Revit.DB.ExternalResourceType`) - The type of resource requested.
- **desiredResource** (`Autodesk.Revit.DB.ExternalResourceReference`) - The specific resource that should be loaded.
- **loadContext** (`Autodesk.Revit.DB.ExternalResourceLoadContext`) - A class containing info about the context of the load request.
- **loadResults** (`Autodesk.Revit.DB.ExternalResourceLoadContent`) - The data returned by the server as a result of this load operation.
 Revit will ensure that this argument is the appropriate subclass of ExternalResourceLoadContent for the type of data.

## Remarks
This method will be invoked when Revit needs to load a resource supplied by this server. Revit provides four key pieces of information to the server: A GUID identifying the load request. The type of external resource that Revit is requesting, such as keynote data, linked Revit/CAD files, etc. An ExternalResourceReference object, which contains information, such as a filename, the version, or other data,
 that identifies the specific resource that Revit needs from the server. An ExternalResourceLoadContext object, which contains information about the context of the load request. For
 example, the ExternalResourceLoadContext contains information describing whether the load came about as a result of
 a user action or an automatic action. The server returns the results of the load request back to Revit via the loadResults argument, which will be a
 sub-class of ExternalResourceLoadContent. This object will contain appropriate data structures to hold the actual resource
 data (content) required by Revit for the specified ExternalResourceType. Server authors may also wish to display UI related to the resource load operation, particularly when errors occur while
 loading or creating the content. The UI should not be created by the IExternalResourceServer. Instead, the server
 author should implement an IExternalResourcesUIServer which will handle all UI-related tasks. The external services framework
 supports data sharing between, and coordinates the actions of, the two types of servers as follows: Each ExternalResourceLoadContent sub-class is designed to hold data related to errors that may have occurred while
 loading or creating the content the specified ExternalResourceType. The IExternalResourceServer should set this data as
 needed in the LoadResource(Guid, ExternalResourceType, ExternalResourceReference, ExternalResourceLoadContext, ExternalResourceLoadContent) method. The error data, along with ExternalResourceReference and other information associated with the attempt to load the external
 resource, is stored internally by Revit until a time when it is appropriate to display UI. When appropriate, the framework will invoke the HandleLoadResourceResults method of any IExternalResourceUIServer
 that is associated with the IExternalResourceServer, and will pass the error data and other information to the UIServer
 for possible display in the Revit UI. Note that instead of using the ExternalResourceLoadContent object, the IExternalResourceServer can store its own error
 information. Subsequently, when the external services framework invokes the IExternalResourceUIServer's HandleLoadResourceResults
 method, the IExternalResourceUIServer can communicate directly with its associated IExternalResourceServer - using whatever interface
 the server developer has implemented - to retrieve the required messages and error data for display in the UI. Revit provides
 a GUID to LoadResource(Guid, ExternalResourceType, ExternalResourceReference, ExternalResourceLoadContext, ExternalResourceLoadContent) , to facilitate identification of individual load requests.

