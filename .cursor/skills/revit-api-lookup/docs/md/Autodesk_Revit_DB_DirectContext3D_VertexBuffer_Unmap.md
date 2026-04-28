---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.Unmap
source: html/763dedd5-6fdc-84b8-e3ec-18694d5d3382.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.Unmap Method

Unmaps the buffer, so that it can be used for rendering.

## Syntax (C#)
```csharp
public void Unmap()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This VertexBuffer is not available because Revit is not currently rendering. In general, this VertexBuffer must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

