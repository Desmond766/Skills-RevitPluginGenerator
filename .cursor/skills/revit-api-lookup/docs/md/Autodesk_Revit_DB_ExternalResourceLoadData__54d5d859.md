---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceLoadData
source: html/e2156349-e735-775f-8cfa-4eaa6bda9f3b.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadData

This class contains the input and output data resulting from invoking an IExternalResourceServer's LoadResource method. After the call to LoadResource, the resulting ExternalResourceLoadData will be passed into
 IExternalResourceServer.HandleLoadResourceResults() so that appropriate UI can be displayed. Server providers can inspect the ExternalResourceLoadData to get an ExternalResourceLoadContent
 object of the subclass appropriate to the external resource. The class also contains a copy of the
 ExternalResourceReference, and information about the context of the load operation.

## Syntax (C#)
```csharp
public class ExternalResourceLoadData : IDisposable
```

