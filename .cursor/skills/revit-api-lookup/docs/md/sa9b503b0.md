---
kind: method
id: M:Autodesk.Revit.DB.IOnLocalLinkSharedCoordinatesSavedCallback.OnLocalLinkSharedCoordinatesSaved(Autodesk.Revit.DB.ExternalResourceReference)
source: html/73b54d32-6cf5-fe6c-4b7c-9b5367907b96.htm
---
# Autodesk.Revit.DB.IOnLocalLinkSharedCoordinatesSavedCallback.OnLocalLinkSharedCoordinatesSaved Method

Revit will call this method whenever shared coordinates
 changes are saved to a linked document provided by an
 IExternalResourceServer. This call is a notification
 to the server provider that one of their Revit or DWG
 links has changed locally, and they should upload the
 new version back to their server.

## Syntax (C#)
```csharp
void OnLocalLinkSharedCoordinatesSaved(
	ExternalResourceReference changedResource
)
```

## Parameters
- **changedResource** (`Autodesk.Revit.DB.ExternalResourceReference`) - The ExternalResourceReference whose shared coordinates have been saved.

