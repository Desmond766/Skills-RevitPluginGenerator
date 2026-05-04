---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceLoadContent
source: html/1747ac99-aaa5-70b9-5d1f-89e72539f497.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContent

This class contains the actual content data and other results of an external resource load operation that are
 returned by an IExternalResourceServer to Revit.

## Syntax (C#)
```csharp
public class ExternalResourceLoadContent : IDisposable
```

## Remarks
When Revit calls the LoadResource method for an IExternalResourceServer, Revit will provide an object that is a
 sub-class of ExternalResourceLoadContent. The IExternalResourceServer will use this object to return the content
 Revit should use for the external resource. The server can also add information about any errors that occurred
 during the load operation. This error information will be stored by Revit and later passed to the
 associated IExternalResourceUIServer (if any) that designates the IExternalResourceServer as its "DBServer"
 (see the IExternalResourceUIServer.GetDBServerId() method). The IExternalResourceUIServer can then generate
 any UI that is required for handling the errors that occurred. Note that since different kinds of external resources are expected to return different kinds of data to Revit,
 a number of ExternalResourceLoadContent sub-classes have been created to handle the data for specific ExternalResourceTypes.
 This base class contains only a string to indicate the version of the resource data that is being supplied
 by the server and a status variable to indicate the outcome of a load operation. Revit will always
 provide the server with an instance of the appropriate sub-class of ExternalResourceLoadContent, with internal
 data that are relevant to the particular ExternalResourceType that is being loaded.

