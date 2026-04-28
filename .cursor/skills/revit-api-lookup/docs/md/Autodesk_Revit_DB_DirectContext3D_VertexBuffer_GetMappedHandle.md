---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetMappedHandle
source: html/5c72f0d1-a411-a0dc-9254-45aac63a2a2a.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexBuffer.GetMappedHandle Method

Gets a handle to the buffer's memory that has been mapped. Writing data to the buffer using the handle is an alternative to using stream objects.

## Syntax (C#)
```csharp
public IntPtr GetMappedHandle()
```

## Returns
The handle to the mapped memory or nullptr when the buffer is not mapped.

