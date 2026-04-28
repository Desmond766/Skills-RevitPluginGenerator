---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetIndexStreamTriangle
source: html/02ba04da-3f69-65e9-1070-5ba51467c13a.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetIndexStreamTriangle Method

Gets a stream that can be used to write IndexTriangle primitives into the buffer.

## Syntax (C#)
```csharp
public IndexStreamTriangle GetIndexStreamTriangle()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

