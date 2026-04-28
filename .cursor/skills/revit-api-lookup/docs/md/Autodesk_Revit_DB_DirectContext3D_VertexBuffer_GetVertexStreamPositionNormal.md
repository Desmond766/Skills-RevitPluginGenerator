---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPositionNormal
source: html/75da6967-bc49-85f8-5630-7a13dc679609.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPositionNormal Method

Gets a stream that can be used to write vertices of type VertexPositionNormal into the buffer.

## Syntax (C#)
```csharp
public VertexStreamPositionNormal GetVertexStreamPositionNormal()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

