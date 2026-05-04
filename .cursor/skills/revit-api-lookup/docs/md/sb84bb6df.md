---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPositionNormalColored
source: html/b4ee5ac8-8fad-4861-01c4-b249e1d40c0f.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPositionNormalColored Method

Gets a stream that can be used to write vertices of type VertexPositionNormalColored into the buffer.

## Syntax (C#)
```csharp
public VertexStreamPositionNormalColored GetVertexStreamPositionNormalColored()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

