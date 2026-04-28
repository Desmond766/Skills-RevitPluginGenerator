---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.AddEdge(Autodesk.Revit.DB.BRepBuilderEdgeGeometry)
source: html/75963b10-7aec-dd68-e160-4a198161dadc.htm
---
# Autodesk.Revit.DB.BRepBuilder.AddEdge Method

Add a new edge to the geometry being built. The BRepBuilder uses edges only to store edge geometry and to track
 pairs of co-edges that share an edge.

## Syntax (C#)
```csharp
public BRepBuilderGeometryId AddEdge(
	BRepBuilderEdgeGeometry edgeGeom
)
```

## Parameters
- **edgeGeom** (`Autodesk.Revit.DB.BRepBuilderEdgeGeometry`) - Information specifying the edge's geometry.

## Returns
Id of the edge, to be used in calls to other BRepBuilder methods such as AddCoEdge().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The input edge geometry was invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object isn't accepting new data, either because it has already been used to build geometry, or because of an error.
 Consult the State property of the BRepBuilder object for more details.

