---
kind: method
id: M:Autodesk.Revit.DB.TriangulatedShellComponent.GetVertex(System.Int32)
source: html/0dcf5d72-c570-9ec0-c374-a4f7b4c3274b.htm
---
# Autodesk.Revit.DB.TriangulatedShellComponent.GetVertex Method

Returns the vertex with a given index.

## Syntax (C#)
```csharp
public XYZ GetVertex(
	int vertexIndex
)
```

## Parameters
- **vertexIndex** (`System.Int32`) - The index of the vertex (between 0 and getVertexCount()-1, inclusive).

## Returns
A copy of the requested vertex.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - vertexIndex is out of range.

