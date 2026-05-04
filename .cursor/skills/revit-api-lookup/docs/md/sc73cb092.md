---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPositionColored
source: html/a383c1a4-df45-0a71-4b03-fca1194dcd36.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPositionColored Method

Gets a stream that can be used to write vertices of type VertexPositionColored into the buffer.

## Syntax (C#)
```csharp
public VertexStreamPositionColored GetVertexStreamPositionColored()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

