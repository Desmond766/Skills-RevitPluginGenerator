---
kind: enumMember
id: F:Autodesk.Revit.DB.CurveProjectionType.ParallelToLevel
enum: Autodesk.Revit.DB.CurveProjectionType
source: html/5669d7b4-2440-877f-5889-9390af7f8542.htm
---
# Autodesk.Revit.DB.CurveProjectionType.ParallelToLevel

The curves are projected to their target surface in a projection direction that is parallel to level.
 The exact vector of projection also considers the endpoints of the curve being projected or endpoints in a loop of curves it belongs to (if any).
 But the vector is always parallel to the level.
 This is used to create curves on the building that retain a particular sketched shape based on elevation perspective,
 regardless of target surface contours.
 Sketching windows is an example where this is useful.

