---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetIndexStreamPoint
source: html/4ec45b4f-4565-7724-bf92-25a723ee315e.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetIndexStreamPoint Method

Gets a stream that can be used to write IndexPoint primitives into the buffer.

## Syntax (C#)
```csharp
public IndexStreamPoint GetIndexStreamPoint()
```

## Returns
The stream that can be used to write into this buffer.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the buffer is not mapped.
 -or-
 Thrown if the buffer has insufficient space.

