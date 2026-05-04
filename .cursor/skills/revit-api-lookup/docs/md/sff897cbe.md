---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetIndexStreamLine
source: html/ebc0cd34-62cd-9eed-0eb5-9b54c0a260b6.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetIndexStreamLine Method

Gets a stream that can be used to write IndexLine segment primitives into the buffer.

## Syntax (C#)
```csharp
public IndexStreamLine GetIndexStreamLine()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

