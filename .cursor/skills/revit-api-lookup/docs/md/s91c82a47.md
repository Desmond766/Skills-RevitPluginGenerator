---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.#ctor(System.Int32)
source: html/79dad9e7-85e8-34ac-6255-12ef9116afa2.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.#ctor Method

Constructs the index buffer with the given capacity, measured in short integers.

## Syntax (C#)
```csharp
public IndexBuffer(
	int sizeInShortInts
)
```

## Parameters
- **sizeInShortInts** (`System.Int32`) - The number of short integers that the buffer can contain.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This IndexBuffer is not available because Revit is not currently rendering. In general, this IndexBuffer must be used in the scope of the RenderScene() callback of IDirectContext3DServer.

