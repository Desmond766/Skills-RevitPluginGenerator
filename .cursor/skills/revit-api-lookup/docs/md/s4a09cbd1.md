---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.VertexStream
source: html/a7a2d911-e3e4-84a7-a0c2-6aa5a28ae2ed.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStream

The base class for DirectContext3D vertex streams, which are used to write vertex data into buffers.

## Syntax (C#)
```csharp
public class VertexStream : IDisposable
```

## Remarks
This base class cannot be used directly. Instead, a steam that is specific for each type of
 vertex must be used.
 Use VertexStreamPosition to insert VertexPosition instances. Use VertexStreamPositionColored to insert VertexPositionColored instances. Use VertexStreamPositionNormal to insert VertexPositionNormal instances. Use VertexStreamPositionNormalColored to insert VertexPositionNormalColored instances. 
 The process of putting vertex data into a buffer involves using a stream-buffer pair as follows:
 Map the vertex buffer. Get a stream of the appropriate type from the buffer. Add vertices of the same type to the stream. They will be written into the buffer that was used to create the stream. Unmap the buffer. 
 As an alternative to using streams, it is possible to write data into a buffer using a handle to its mapped memory.

