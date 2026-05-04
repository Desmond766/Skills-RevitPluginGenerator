---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionColored.AddVertices(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.VertexPositionColored})
source: html/f277ce8e-23f2-6c02-ce17-c7f006085274.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionColored.AddVertices Method

Inserts multiple VertexStreamPositionColored instances into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertices(
	IList<VertexPositionColored> vertices
)
```

## Parameters
- **vertices** (`System.Collections.Generic.IList < VertexPositionColored >`) - The vertices to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

