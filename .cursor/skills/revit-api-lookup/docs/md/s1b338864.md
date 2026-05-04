---
kind: method
id: M:Autodesk.Revit.DB.IGetLocalPathForOpenCallback.GetLocalPathForOpen(Autodesk.Revit.DB.ExternalResourceReference)
source: html/9fb95df5-9a28-7f07-e1c9-1e984f9cca19.htm
---
# Autodesk.Revit.DB.IGetLocalPathForOpenCallback.GetLocalPathForOpen Method

Implement this method to specify the local path from where a copy of a Revit link external resource can be opened
 for modification without interfering with its use as a link in other open documents.

## Syntax (C#)
```csharp
string GetLocalPathForOpen(
	ExternalResourceReference desiredResource
)
```

## Parameters
- **desiredResource** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference that needs to be opened for modification by Revit.

## Returns
The local path from where Revit can open the linked file as its own top-level document.

