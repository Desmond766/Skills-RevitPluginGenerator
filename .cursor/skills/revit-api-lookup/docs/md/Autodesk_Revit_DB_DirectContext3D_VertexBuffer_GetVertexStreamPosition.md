---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPosition
source: html/622eea58-8f57-1f8b-f36f-47df37778212.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetVertexStreamPosition Method

Gets a stream that can be used to write vertices of type VertexPosition into the buffer.

## Syntax (C#)
```csharp
public VertexStreamPosition GetVertexStreamPosition()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

