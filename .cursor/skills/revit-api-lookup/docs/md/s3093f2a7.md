---
kind: type
id: T:Autodesk.Revit.DB.IOnLocalLinkSharedCoordinatesSavedCallback
source: html/b6b41945-2aa8-0089-c05b-87aaf3d6fd42.htm
---
# Autodesk.Revit.DB.IOnLocalLinkSharedCoordinatesSavedCallback

A callback for notifying an IExternalResourceServer that
 shared coordinates changes have been saved back to one
 of the Revit or DWG links provided by that server.

## Syntax (C#)
```csharp
public interface IOnLocalLinkSharedCoordinatesSavedCallback
```

## Remarks
Revit will call OnLocalLinkSharedCoordinatesSaved whenever
 shared coordinates changes are saved to a linked document
 which is provided by an external server. This is a notification
 to the server provider so they can copy the updated link
 back up to their server.

