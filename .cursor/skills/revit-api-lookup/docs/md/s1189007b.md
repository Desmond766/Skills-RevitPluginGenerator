---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.GetClipRectangle
source: html/3befe4ef-682b-f101-c6a6-e54aa15adf04.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.GetClipRectangle Method

Gets the clip rectangle for the Revit view where rendering takes place. The clip rectangle
 is the area currently being redrawn, which may be smaller than the view rectangle.

## Syntax (C#)
```csharp
public static Rectangle GetClipRectangle()
```

## Returns
The clip rectangle.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

