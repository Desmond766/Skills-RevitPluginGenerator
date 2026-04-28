---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormalColored.AddVertices(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.VertexPositionNormalColored})
source: html/8c268b67-b8e6-0b4d-2375-63bcd045e4e9.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormalColored.AddVertices Method

Inserts multiple VertexStreamPositionNormalColored instances into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertices(
	IList<VertexPositionNormalColored> vertices
)
```

## Parameters
- **vertices** (`System.Collections.Generic.IList < VertexPositionNormalColored >`) - The vertices to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

