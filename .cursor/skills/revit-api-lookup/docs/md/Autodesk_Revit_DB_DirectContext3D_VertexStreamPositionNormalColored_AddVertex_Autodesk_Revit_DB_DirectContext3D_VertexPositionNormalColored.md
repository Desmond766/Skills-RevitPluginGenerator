---
kind: method
id: M:Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormalColored.AddVertex(Autodesk.Revit.DB.DirectContext3D.VertexPositionNormalColored)
source: html/5c578e87-b296-0676-2e52-12862fd1ad0d.htm
---
# Autodesk.Revit.DB.DirectContext3D.VertexStreamPositionNormalColored.AddVertex Method

Inserts a VertexStreamPositionNormalColored into the stream and associated buffer.

## Syntax (C#)
```csharp
public void AddVertex(
	VertexPositionNormalColored vertex
)
```

## Parameters
- **vertex** (`Autodesk.Revit.DB.DirectContext3D.VertexPositionNormalColored`) - The vertex to be inserted.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if the associated buffer is not mapped.
 -or-
 Thrown if the associated buffer has insufficient space.

