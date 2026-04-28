---
kind: method
id: M:Autodesk.Revit.DB.TriOrQuadFacet.GetVertexIndex(System.Int32)
source: html/50d7f09d-de53-1998-8af4-d3a41ba6f994.htm
---
# Autodesk.Revit.DB.TriOrQuadFacet.GetVertexIndex Method

Returns the index of the specified vertex of this facet (as an index into the external array
 of vertices in the TriangulationInterface that was used to create the list of TriOrQuadFacets).

## Syntax (C#)
```csharp
public int GetVertexIndex(
	int index
)
```

## Parameters
- **index** (`System.Int32`) - Index of the desired vertex in this TriOrQuadFacet (between 0 and NumberOfVertices-1, inclusive).

## Returns
The index of the specified vertex in the external array of vertices (only valid if NumberOfVertices >= 3).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - index is out of range..

