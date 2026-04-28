---
kind: method
id: M:Autodesk.Revit.DB.LinkLoadContent.GetLinkLoadResult
source: html/48116b8a-9858-214c-e85e-337010bb3fae.htm
---
# Autodesk.Revit.DB.LinkLoadContent.GetLinkLoadResult Method

Retrieves the LinkLoadResult of the attempt to load or reload a Revit link.

## Syntax (C#)
```csharp
public LinkLoadResult GetLinkLoadResult()
```

## Returns
A LinkLoadObject containing the status and other information about an attempt by Revit
 to load a Revit link.

## Remarks
A LinkLoadResult object is included in the LinkLoadContent class so that
 IExternalResourceUIServers will have additional information about the status of the
 link to display to the user. The LinkLoadResult is added to the LinkLoadContent object during the load operation,
 after the IExternalResourceServer LoadResource method has been called.
 Consequently, this method will return NULL if called from the LoadResource method
 of an IExternalResourceServer.

