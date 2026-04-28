---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetMappedHandle
source: html/b817304d-d9e7-6503-31ba-a8b058ac2377.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexBuffer.GetMappedHandle Method

Gets a handle to the buffer's memory that has been mapped. Writing data to the buffer using the handle is an alternative to using stream objects.

## Syntax (C#)
```csharp
public IntPtr GetMappedHandle()
```

## Returns
The handle to the mapped memory or nullptr when the buffer is not mapped.

