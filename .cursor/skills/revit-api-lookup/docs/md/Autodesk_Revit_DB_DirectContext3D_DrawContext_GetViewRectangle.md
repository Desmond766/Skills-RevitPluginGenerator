---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.DrawContext.GetViewRectangle
source: html/7ea41cc8-bf1c-d9f0-5013-8e73ff0a0bbe.htm
---
# Autodesk.Revit.DB.DirectContext3D.DrawContext.GetViewRectangle Method

Gets the rectangle that represents the extent (in 2D) of the Revit view where rendering takes place.

## Syntax (C#)
```csharp
public static Rectangle GetViewRectangle()
```

## Returns
The view rectangle.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This DrawContext is not available because Revit is not currently rendering. In general, this DrawContext must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

