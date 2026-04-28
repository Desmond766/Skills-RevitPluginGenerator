---
kind: type
id: T:Autodesk.Revit.DB.TriangleInShellComponent
source: html/ff9ef159-5435-7874-842e-7a681735bcc8.htm
---
# Autodesk.Revit.DB.TriangleInShellComponent

This class represents a triangle in a TriangulatedShellComponent object. The triangle is
 defined by its vertices, which are specified by their indices in the
 TriangulatedShellComponent's array of vertices.

## Syntax (C#)
```csharp
public class TriangleInShellComponent : IDisposable
```

## Remarks
A TriangulatedShellComponent stores an array of TriangleInShellComponent objects
 representing the triangles of the triangulation. An external class is used
 because the API does not allow the use of a triple of integers. Note that a
 TriangleInShellComponent must only be used in the context of a single, fixed
 TriangulatedShellComponent.

