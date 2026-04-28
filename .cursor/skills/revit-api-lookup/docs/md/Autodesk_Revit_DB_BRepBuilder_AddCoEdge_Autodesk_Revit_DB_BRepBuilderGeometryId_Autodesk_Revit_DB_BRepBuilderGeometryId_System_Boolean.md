---
kind: method
id: M:Autodesk.Revit.DB.BRepBuilder.AddCoEdge(Autodesk.Revit.DB.BRepBuilderGeometryId,Autodesk.Revit.DB.BRepBuilderGeometryId,System.Boolean)
source: html/c4713a48-712b-e293-6745-a266af97e195.htm
---
# Autodesk.Revit.DB.BRepBuilder.AddCoEdge Method

Add a co-edge associated to a previously added edge. A co-edge represents the use of an edge on one
 of the edge's faces. BrepBuilder allows at most two faces per edge, hence at most two co-edges per edge,
 and the co-edges must have opposite bCoEdgeIsReversed flags. The co-edges in a loop must be added in the
 order in which they occur in loop (i.e., in their topological order).

## Syntax (C#)
```csharp
public BRepBuilderGeometryId AddCoEdge(
	BRepBuilderGeometryId loopId,
	BRepBuilderGeometryId edgeId,
	bool bCoEdgeIsReversed
)
```

## Parameters
- **loopId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Id of the loop containing the new co-edge.
- **edgeId** (`Autodesk.Revit.DB.BRepBuilderGeometryId`) - Id of the co-edge's edge, previously created by a call to addEdge().
- **bCoEdgeIsReversed** (`System.Boolean`) - True if the co-edge's topological direction in its face is opposite to the edge's parametric direction, false otherwise.
 The topological directions of the co-edges in a loop must be consistent with the direction in which the loop co-edges
 appear in the loop, and the loop orientations so defined must follow the convention that outer loops are oriented
 counter-clockwise and inner loops are oriented clockwise, with respect to the face's orientation.

## Returns
Id of the edge, to be used in calls to other BRepBuilder methods such as AddCoEdge().

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The supplied loop id doesn't correspond to a loop stored in this BRepBuilder object.
 -or-
 The supplied edge id doesn't correspond to an edge stored in this BRepBuilder object.
 -or-
 FinishLoop() has already been called on loopId.
 -or-
 The edge already has two coedges associated to it.
 -or-
 Inconsistent use of the edge by co-edges is detected: both co-edges have the same bCoedgeIsReversed parameter.
 -or-
 The edge has already been added to this face.
 -or-
 There is a gap between this co-edge and the previous co-edge in the loop.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This BRepBuilder object isn't accepting new data, either because it has already been used to build geometry, or because of an error.
 Consult the State property of the BRepBuilder object for more details.

