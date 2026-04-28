---
kind: type
id: T:Autodesk.Revit.DB.DirectContext3D.IndexStream
source: html/9c300586-7f1f-41db-270b-797d6ad967d8.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStream

The base class for DirectContext3D index streams, which are used to write vertex indices into buffers.

## Syntax (C#)
```csharp
public class IndexStream : IDisposable
```

## Remarks
This base class cannot be used directly. Instead, a steam that is specific for each type of
 primitive (point, line, or triangle) must be used.
 Use IndexStreamPoint to insert IndexPoint instances. Use IndexStreamLine to insert IndexLine instances. Use IndexStreamTriangle to insert IndexTriangle instances. 
The process of putting vertex indices into a buffer involves using a stream-buffer pair as follows:
 Map the index buffer (see IndexBuffer ). Get a stream for the appropriate primitive type from the buffer. Add sequences of indices corresponding to primitives of the same type to the stream. The indices will be written into the buffer that was used to create the stream. Unmap the buffer. 
 As an alternative to using streams, it is possible to write data into a buffer using a handle to its mapped memory.

