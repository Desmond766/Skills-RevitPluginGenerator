---
kind: enumMember
id: F:Autodesk.Revit.DB.CurveProjectionType.FollowSurfaceUV
enum: Autodesk.Revit.DB.CurveProjectionType
source: html/5669d7b4-2440-877f-5889-9390af7f8542.htm
---
# Autodesk.Revit.DB.CurveProjectionType.FollowSurfaceUV

The curve is generated on to lie on the surface based on its endpoints/control points on the surface, its curve type, and depending on the surface type,
 either projecting to the surface based on projecting tessellation points of the curve to the target surface,
 or by interpreting the equation produced by the curve type and user defined control points in the surface uv.
 In some ways, this is the most robust way to generate the curve on the surface,
 but for some surface shapes, it can make it difficult to obtain the desired appearance from a particular perspective in the model.

