---
kind: method
id: M:Autodesk.Revit.DB.CurveUV.As3DCurveInXYPlane
source: html/df4dd3a3-810f-892e-87b6-fbe00ff698c3.htm
---
# Autodesk.Revit.DB.CurveUV.As3DCurveInXYPlane Method

Returns a 3D curve lying in the XY plane in XYZ coordinates, representing the 2D curve with its UV coordinates identified with XY coordinates.

## Syntax (C#)
```csharp
public Curve As3DCurveInXYPlane()
```

## Returns
3D curve lying in the XY plane in XYZ coordinates, representing the 2D curve with its UV coordinates identified with XY coordinates.

## Remarks
Ideally, this function should only be used in cases when the 2D curve needs to be used in a context
 that does not support 2D curves, but can represent them as 3D curves with Z = 0 everywhere (for example,
 converting the 2D curve to another CAD system that does not support 2D curves).

