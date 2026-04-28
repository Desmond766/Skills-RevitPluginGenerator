---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.IsValid
source: html/82448bdd-a0a4-61f2-fbbd-91a4988f6ce6.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.IsValid Method

Tests whether the buffer is valid for rendering.

## Syntax (C#)
```csharp
public bool IsValid()
```

## Returns
True if the buffer is valid for rendering, false otherwise.

## Remarks
The buffers are internally associated with low-level graphics state and may become invalidated when
 the state changes. Therefore, an application should test each buffer for validity before submitting its
 contents for rendering. If the buffer becomes invalid, the application should re-create its contents and
 write them to a new buffer.

