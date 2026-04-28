---
kind: method
id: M:Autodesk.Revit.DB.MeshFromGeometryOperationResult.GetMesh
source: html/bd2901fe-9510-612a-f383-cb8caaee62ed.htm
---
# Autodesk.Revit.DB.MeshFromGeometryOperationResult.GetMesh Method

This returns a valid mesh only for the first call. Later calls
 will throw an exception as the mesh is no longer valid in this object.

## Syntax (C#)
```csharp
public Mesh GetMesh()
```

## Returns
Mesh which built.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The Mesh has already been accessed by a previous GetMesh() call, and is no longer available for use.

