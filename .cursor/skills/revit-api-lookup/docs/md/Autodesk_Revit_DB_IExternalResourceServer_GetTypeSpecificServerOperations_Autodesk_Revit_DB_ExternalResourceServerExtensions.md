---
kind: method
id: M:Autodesk.Revit.DB.IExternalResourceServer.GetTypeSpecificServerOperations(Autodesk.Revit.DB.ExternalResourceServerExtensions)
source: html/cf5b2bd0-9ccd-8961-d568-21319c15d896.htm
---
# Autodesk.Revit.DB.IExternalResourceServer.GetTypeSpecificServerOperations Method

Implement this method to get operations supported by the external server for a particular type of external resource.

## Syntax (C#)
```csharp
void GetTypeSpecificServerOperations(
	ExternalResourceServerExtensions extensions
)
```

## Parameters
- **extensions** (`Autodesk.Revit.DB.ExternalResourceServerExtensions`) - The class which owns sub-interface classes, each of which has methods related to a particular type of external resource.

## Remarks
Through this method, some specific operations for a paritcular type of external resource, such as Open(and Unload)
 and shared coordinates for Revit Link, can be set in a class ExternalResourceServerExtensions.
ExternalResourceServerExtensions is able to own sub-interface classes, each of which has methods
 related to a particular type of external resource.

