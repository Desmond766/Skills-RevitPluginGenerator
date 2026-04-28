---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormal.AddVertex(Autodesk.Revit.DB.DirectContext3D.VertexPositionNormal)
source: html/0b04b60d-dabb-c584-0503-9bba7ee921c1.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormal.AddVertex Method

Inserts a VertexStreamPositionNormal into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertex(
	VertexPositionNormal vertex
)
```

## Parameters
- **vertex** (`Autodesk.Revit.DB.DirectContext3D.VertexPositionNormal`) - The vertex to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

