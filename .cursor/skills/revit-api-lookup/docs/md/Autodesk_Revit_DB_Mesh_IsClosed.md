---
kind: property
id: P:Autodesk.Revit.DB.Mesh.IsClosed
source: html/e33dfae6-348a-1d62-fb87-c4ff2a8b3972.htm
---
# Autodesk.Revit.DB.Mesh.IsClosed Property

Indicates whether the mesh is closed.

## Syntax (C#)
```csharp
public bool IsClosed { get; }
```

## Remarks
Every time this property is accessed, it is computed from scratch, 
 so accessing it multiple times will come at a performance cost.
 A mesh is closed when each of its edges has two (or more) faces.
 If an edge has more than two faces (meaning that it's a non-manifold edge), 
 the mesh still may be closed.

