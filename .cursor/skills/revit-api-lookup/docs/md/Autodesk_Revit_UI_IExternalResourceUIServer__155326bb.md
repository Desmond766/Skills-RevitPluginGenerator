---
kind: type
id: T:Autodesk.Revit.UI.IExternalResourceUIServer
source: html/aee37f3f-98e9-79c6-e02d-1b07e3ffd89c.htm
---
# Autodesk.Revit.UI.IExternalResourceUIServer

The interface used to provide custom handling of UI operations related to external resources.

## Syntax (C#)
```csharp
public interface IExternalResourceUIServer : IExternalServer
```

## Remarks
IExternalResourceUIServer is the UI server associated with IExternalResourceServer.
 IExternalResourceServer provides an interface for loading an external resource (such as a Revit
 link or the keynote data) from a source outside of Revit. IExternalResourceUIServer provides
 an interface for displaying the results of such an operation to the Revit user. IExternalResourceUIServers must be associated with an IExternalResourceServer in order
 to display any UI. Implement GetDBServerId () () () to declare a relationship
 between an IExternalResourceUIServer and an IExternalResourceServer. The primary method in IExternalResourceUIServer is [M:Autodesk.Revit.UI.IExternalResourceUIServer.HandleLoadResourceResults(Autodesk.Revit.DB.Document,System.Collections.Generic.IList`1{Autodesk.Revit.DB.ExternalResourceLoadData})] .
 After an IExternalResourceServer loads an external resource, Revit will call
 HandleLoadResourceResults() on the IExternalResourceUIServer, so that it may display any
 related UI. Revit will provide an ExternalResourceLoadData to the UI server, which will
 contain information about the resource which was loaded, information about the context of
 the load operation, and any Revit-side errors. The ExternalResourceLoadData passed to HandleLoadResourceResults will also contain a GUID
 to uniquely identify the load request. This identifier can help IExternalResourceUIServers
 query their IExternalResourceServers for additional information about errors that occurred
 during specific load operations. Particularly, the IExternalResourceUIServer may wish to
 ask the IExternalResourceServer about errors which Revit is not aware of. For example,
 if the IExternalResourceServer includes a website and the user is not logged in, Revit
 will not have any information about this error.

