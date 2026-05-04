---
kind: type
id: T:Autodesk.Revit.DB.CADLinkOperations
source: html/cc56c56f-5ba7-f922-c003-61d58bdf5387.htm
---
# Autodesk.Revit.DB.CADLinkOperations

This class is used to extend the IExternalResourceServer interface with methods to support operations
 specifically related to DWG links.

## Syntax (C#)
```csharp
public class CADLinkOperations : LinkOperations
```

## Remarks
The class owns single-method interfaces which are used as callbacks to perform specific operations
 on DWG link external resources. An empty CADLinkOperations instance is passed to an IExternalResourceServer (inside an
 ExternalResourceServerExtensions object) via the GetTypeSpecificServerOperations method. The server
 provider can then add their own implemented interface objects to the CADLinkOperations, thus
 making them available to Revit to use as callbacks. Supporting these additional, type-specific operations is not absolutely required, but is strongly
 recommended in order for users to be able to perform all the same operations they would with
 locally-accessed links.

