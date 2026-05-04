---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormal.AddVertices(System.Collections.Generic.IList{Autodesk.Revit.DB.DirectContext3D.VertexPositionNormal})
source: html/7ed2b326-210d-1b56-1788-9b59086605ec.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormal.AddVertices Method

Inserts multiple VertexStreamPositionNormal instances into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertices(
	IList<VertexPositionNormal> vertices
)
```

## Parameters
- **vertices** (`System.Collections.Generic.IList < VertexPositionNormal >`) - The vertices to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

