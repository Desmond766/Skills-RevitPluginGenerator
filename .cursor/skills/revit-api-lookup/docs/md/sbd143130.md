---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.IsValid
source: html/e1c07c2d-42f4-f2d8-0a10-219ad78a1fd6.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.IsValid Method

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

