---
kind: method
id: M:Autodesk.Revit.DB.CurveLoop.GetPlane
source: html/87e64330-90d4-c6bb-944d-d2dbb1529948.htm
---
# Autodesk.Revit.DB.CurveLoop.GetPlane Method

Gets the plane of the curve loop, if it is planar.

## Syntax (C#)
```csharp
public Plane GetPlane()
```

## Returns
The plane of the curve loop.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The curve loop does not lie in a single plane.

