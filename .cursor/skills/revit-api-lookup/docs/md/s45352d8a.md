---
kind: property
id: P:Autodesk.Revit.DB.Mesh.NumberOfNormals
source: html/65beb16f-59ae-07fb-44c3-04b5b37752ec.htm
---
# Autodesk.Revit.DB.Mesh.NumberOfNormals Property

The number of normals associated with the mesh.

## Syntax (C#)
```csharp
public int NumberOfNormals { get; }
```

## Remarks
The number is always equal either to '1', or the number of facets,
 or the number of points. The DistributionOfNormals property indicates
 how normals are distributed along the polymesh. If there is only one normal available,
 it applies to the entire mesh. Curved surfaces have normal vectors associated
 with either every facet or every point/vertex of the tessellated polymesh.

