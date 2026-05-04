---
kind: type
id: T:Autodesk.Revit.DB.RevitLinkOperations
source: html/29f57c72-dfdf-4d24-5bb9-92740c9f7beb.htm
---
# Autodesk.Revit.DB.RevitLinkOperations

This class is used to extend the IExternalResourceServer interface with methods to support operations
 specifically related to Revit links.

## Syntax (C#)
```csharp
public class RevitLinkOperations : LinkOperations
```

## Remarks
The class owns single-method interfaces which are used as callbacks to perform specific operations
 on Revit link external resources. An empty RevitLinkOperations instance is passed to an IExternalResourceServer (inside an
 ExternalResourceServerExtensions object) via the GetTypeSpecificServerOperations method. The server
 provider can then add their own implemented interface objects to the RevitLinkOperations, thus
 making them available to Revit to use as callbacks. Supporting these additional, type-specific operations is not absolutely required, but is strongly
 recommended in order for users to be able to perform all the same operations they would with
 locally-accessed Revit links.

