---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.GetClipPlanes
source: html/be439140-6dd8-f08e-de56-484f576de94f.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.GetClipPlanes Method

Gets the clipping planes for the Revit view where rendering takes place.
 Clipping planes control the 3D extent of a view and can be set using Section Box in Revit.

## Syntax (C#)
```csharp
public static IList<ClipPlane> GetClipPlanes()
```

## Returns
The array of clipping planes, which is empty if none are set.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

