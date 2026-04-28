---
kind: other
id: Methods.T:Autodesk.Revit.DB.BRepBuilder
source: html/54c17794-cc3b-7c54-837c-0e0cf92dceff.htm
---
# BRepBuilder Methods

Add a co-edge associated to a previously added edge. A co-edge represents the use of an edge on one
 of the edge's faces. BrepBuilder allows at most two faces per edge, hence at most two co-edges per edge,
 and the co-edges must have opposite bCoEdgeIsReversed flags. The co-edges in a loop must be added in the
 order in which they occur in loop (i.e., in their topological order).

