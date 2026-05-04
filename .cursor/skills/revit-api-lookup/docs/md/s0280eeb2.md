---
kind: type
id: T:Autodesk.Revit.DB.ExternalResourceLoadContext
source: html/225225cb-6161-4681-34f9-1da4a6d50856.htm
---
# Autodesk.Revit.DB.ExternalResourceLoadContext

This class contains data describing the context related
 to an external resource load operation.

## Syntax (C#)
```csharp
public class ExternalResourceLoadContext : IDisposable
```

## Remarks
Note that automatic loads can occur in the context of other operations such as opening a file.
 During automatic loads, it is therefore recommended that the server only display UI that is critical
 for the user to see (such as error message). The loading operation type is Explicit when the user is specifically trying to reload the resource.
 During explicit loads, it may be desirable to provide more feedback to the user, such as specific feedback
 that the load operation succeeded.

