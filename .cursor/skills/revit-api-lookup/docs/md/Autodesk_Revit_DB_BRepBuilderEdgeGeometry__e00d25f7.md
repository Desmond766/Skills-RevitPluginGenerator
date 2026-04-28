---
kind: other
id: Methods.T:Autodesk.Revit.DB.BRepBuilderEdgeGeometry
source: html/13253dbd-0234-6848-ae5c-adf8c5574337.htm
---
# BRepBuilderEdgeGeometry Methods

Construct BRepBuilderEdgeGeometry based on any GCurve, including GLine and GArc.
 The curve will be simplified if possible, and the concrete type of the returned value will reflect
 that simplification: BRepBuilderLinearEdgeGeometry if the curve could be simplified to a line,
 BRepBuilderArcEdgeGeometry if it could be simplified to an arc, BRepBuilderGenericCurveEdgeGeometry
 otherwise.

