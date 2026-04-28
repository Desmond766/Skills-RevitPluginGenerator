---
kind: method
id: M:Autodesk.Revit.DB.TriangulatedShellComponent.GetTriangle(System.Int32)
source: html/dfc40de3-d27b-45b8-1539-0ca682316592.htm
---
# Autodesk.Revit.DB.TriangulatedShellComponent.GetTriangle Method

Returns the triangle corresponding to the given index.

## Syntax (C#)
```csharp
public TriangleInShellComponent GetTriangle(
	int triangleIndex
)
```

## Parameters
- **triangleIndex** (`System.Int32`) - The index of the triangle (between 0 and TriangleCount-1, inclusive).

## Returns
The triangle.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - triangleIndex is out of range.

