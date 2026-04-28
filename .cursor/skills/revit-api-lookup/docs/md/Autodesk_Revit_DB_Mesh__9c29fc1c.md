---
kind: type
id: T:Autodesk.Revit.DB.Mesh
source: html/bf9cd59c-03c3-9e7f-1e2b-6aaf5c425b69.htm
---
# Autodesk.Revit.DB.Mesh

A triangular mesh.

## Syntax (C#)
```csharp
public class Mesh : GeometryObject
```

## Remarks
Meshes are generated during triangulation of faces. They can also be encountered directly in Revit geometry (typically imported geometry).
Meshes contain a single array of Vertices , and a corresponding array of triangles. Triangles can be accessed by index from
 Triangle[Int32] , and reference 3 vertices from the Vertices array.

