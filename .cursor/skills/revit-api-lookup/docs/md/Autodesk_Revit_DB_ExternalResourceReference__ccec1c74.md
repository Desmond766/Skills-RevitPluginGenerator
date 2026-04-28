---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceReference
source: html/ffad9c15-8fc9-fbfd-f328-101533f4cf74.htm
---
# Autodesk.Revit.DB.ExternalResourceReference

This class identifies an external resource provided by an IExternalResourceServer.

## Syntax (C#)
```csharp
public class ExternalResourceReference : IDisposable
```

## Remarks
The class contains: The id of the IExternalResourceServer from which the resource was obtained. A (String, String) map containing information that is meaningful to the server for accessing the desired data.
 This could be something as simple as "4" to indicate that Revit wants option 4 from a range of several choices, or
 something more detailed, such as a filename or directory path. A String indicating the version of the resource that was most recently loaded in Revit. A (String, String) map containing "in session" information that is meaningful to the server, but
 which does not need to be saved permanently in the document on disk. When calling an IExternalResourceServer, Revit will provide an ExternalResourceReference to
 identify the specific resource that Revit is using from that server. The server can then use the
 relevant information in the (String, String) maps to retrieve the data from the correct source.

