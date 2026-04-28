---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.GetCamera
source: html/048d5376-17c1-8581-9e2a-376a0bc20215.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.GetCamera Method

Gets the camera corresponding to the Revit view where rendering takes place.

## Syntax (C#)
```csharp
public static Camera GetCamera()
```

## Returns
The camera.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

