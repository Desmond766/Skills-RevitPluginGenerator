---
kind: property
id: P:Autodesk.Revit.DB.PolymeshTopology.NumberOfNormals
source: html/93f4755d-4792-a9be-6835-e7ac169b87d3.htm
---
# Autodesk.Revit.DB.PolymeshTopology.NumberOfNormals Property

The number of normals associated with the polymesh

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

