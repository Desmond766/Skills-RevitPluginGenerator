---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.Map(System.Int32)
source: html/f330f770-6571-abb2-9615-6c5eb0e4f525.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.Map Method

Maps a portion of the index buffer into memory, so that indices can be written into it.
 see IndexStream .

## Syntax (C#)
```csharp
public void Map(
	int sizeInShortInts
)
```

## Parameters
- **sizeInShortInts** (`System.Int32`) - The size of the part of the buffer to be mapped, measured in short integers.
 Must be less than or equal to the size of the IndexBuffer

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This IndexBuffer is not available because Revit is not currently rendering. In general, this IndexBuffer must be used in the scope of the RenderScene() callback of IDirectContext3DServer.
 -or-
 Thrown if the buffer is smaller than sizeInShortInts.

