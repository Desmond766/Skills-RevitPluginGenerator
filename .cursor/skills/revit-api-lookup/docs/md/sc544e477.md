---
kind: method
id: M:Autodesk.Revit.DB.FacetingUtils.ConvertTrianglesToQuads(Autodesk.Revit.DB.TriangulationInterface)
source: html/c5f0e1f7-bf56-5634-b6a2-9989f7677448.htm
---
# Autodesk.Revit.DB.FacetingUtils.ConvertTrianglesToQuads Method

Replaces pairs of adjacent, coplanar triangles by quadrilaterals.

## Syntax (C#)
```csharp
public static IList<TriOrQuadFacet> ConvertTrianglesToQuads(
	TriangulationInterface triangulation
)
```

## Parameters
- **triangulation** (`Autodesk.Revit.DB.TriangulationInterface`) - A triangulated face, shell, or solid.

## Returns
A collection of triangles and quadrilaterals representing the original triangulated object.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation failed.

