---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPosition.AddVertices(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.VertexPosition})
source: html/3392007c-c686-485e-d9a3-a5ee7a920814.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPosition.AddVertices Method

Inserts multiple VertexStreamPosition instances into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertices(
	IList<VertexPosition> vertices
)
```

## Parameters
- **vertices** (`System.Collections.Generic.IList < VertexPosition >`) - The vertices to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

