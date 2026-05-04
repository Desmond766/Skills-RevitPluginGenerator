---
kind: method
id: M:Autodesk.Revit.DB.Curve.Tessellate
zh: 曲线
source: html/f95f3199-3251-c708-c5a3-a0e9ef95ecfa.htm
---
# Autodesk.Revit.DB.Curve.Tessellate Method

**中文**: 曲线

Valid only if the curve is bound. Returns a polyline approximation to the curve.

## Syntax (C#)
```csharp
public IList<XYZ> Tessellate()
```

## Remarks
Tolerance of approximation is defined internally by Revit to be adequate for
display purposes.

