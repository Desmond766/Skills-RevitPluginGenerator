---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.Map(System.Int32)
source: html/25906237-dd27-22a6-96cf-c480869fe02b.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.Map Method

Maps a portion of the buffer into memory, so that vertex data can be written into it.
 (see VertexStream ).

## Syntax (C#)
```csharp
public void Map(
	int sizeInFloats
)
```

## Parameters
- **sizeInFloats** (`System.Int32`) - The size of the part of the buffer to be mapped, measured in floats.
 Must be less than or equal to the size of the VertexBuffer

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This VertexBuffer is not available because Revit is not currently rendering. In general, this VertexBuffer must be used in the scope of the RenderScene() callback of IDirectContext3DServer.
 -or-
 Thrown if the buffer is smaller than sizeInFloats.

