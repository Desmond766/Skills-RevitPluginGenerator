---
kind: type
id: T:Autodesk.Revit.DB.CameraInfo
source: html/facf52cc-bc82-0008-9e4c-60e6a335ef40.htm
---
# Autodesk.Revit.DB.CameraInfo

An object holding information about the projection mapping of a 3D view.

## Syntax (C#)
```csharp
public class CameraInfo : IDisposable
```

## Remarks
CameraInfo can be obtained directly from a ViewNode 
 If camera info is not available, an orthographic view should be assumed.
See also: OnViewBegin(ViewNode) .

