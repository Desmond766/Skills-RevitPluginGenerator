---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.#ctor(System.Int32)
source: html/c19f57b3-4b5a-3f01-61d8-91fd23da70b4.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.#ctor Method

Constructs the vertex buffer with the given capacity, measured in floats.

## Syntax (C#)
```csharp
public VertexBuffer(
	int sizeInFloats
)
```

## Parameters
- **sizeInFloats** (`System.Int32`) - The number of floats that the buffer can contain.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This VertexBuffer is not available because Revit is not currently rendering. In general, this VertexBuffer must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

