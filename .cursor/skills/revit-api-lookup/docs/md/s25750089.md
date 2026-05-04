---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.Unmap
source: html/c3d125d9-e95e-5466-8818-1959f87e2889.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.Unmap Method

Unmaps the buffer so that it can be used for rendering.

## Syntax (C#)
```csharp
public void Unmap()
```

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This IndexBuffer is not available because Revit is not currently rendering. In general, this IndexBuffer must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

