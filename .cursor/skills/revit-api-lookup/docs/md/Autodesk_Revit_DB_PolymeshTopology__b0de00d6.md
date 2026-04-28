---
kind: type
id: T:Autodesk.Revit.DB.PolymeshTopology
source: html/fef5982c-3825-eed0-f792-1e0bff5509c2.htm
---
# Autodesk.Revit.DB.PolymeshTopology

A class representing topology of a polymesh.

## Syntax (C#)
```csharp
public class PolymeshTopology : IDisposable
```

## Remarks
Topology of a polymesh consists of a number of points and triangular facets formed
 by the points. Each facet is determined by three indices to the array of points.
 A polymesh may have UV coordinates assigned, and always has at least one normal associated.
 There may be more than one normal available for a non-planar polymesh; there may be as many
 normals as there are either facets or points in the polymesh. The DistributionOfNormals
 property indicates how normals are distributed along the polymesh.

