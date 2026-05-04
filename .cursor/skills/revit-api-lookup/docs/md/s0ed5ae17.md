---
kind: other
id: AllMembers.T:Autodesk.Revit.DB.BRepBuilderEdgeGeometry
source: html/21f2f2d1-2ece-a234-bec4-68486a8f845b.htm
---
# BRepBuilderEdgeGeometry Members

Construct BRepBuilderEdgeGeometry based on any GCurve, including GLine and GArc.
 The curve will be simplified if possible, and the concrete type of the returned value will reflect
 that simplification: BRepBuilderLinearEdgeGeometry if the curve could be simplified to a line,
 BRepBuilderArcEdgeGeometry if it could be simplified to an arc, BRepBuilderGenericCurveEdgeGeometry
 otherwise.

