---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.IndexStreamTriangle.AddTriangles(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.IndexTriangle})
source: html/a0803821-c418-02d0-ec3f-030a77734d9e.htm
---
# Autodesk.Revit.DB.DirectContext3D.IndexStreamTriangle.AddTriangles Method

Inserts multiple IndexTriangle instances into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddTriangles(
	IList<IndexTriangle> triangles
)
```

## Parameters
- **triangles** (`System.Collections.Generic.IList < IndexTriangle >`) - The triangles to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

