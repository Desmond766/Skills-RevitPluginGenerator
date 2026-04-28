---
kind: type
id: T:Autodesk.Revit.DB.CurveByPoints
source: html/2df7ab39-1ac0-5803-79fa-b23a959bf8f2.htm
---
# Autodesk.Revit.DB.CurveByPoints

A curve interpolating two or more points.

## Syntax (C#)
```csharp
public class CurveByPoints : CurveElement
```

## Remarks
The points to be interpolated are represented as
ReferencePoints, which must already exist in the
document. In terms of appearance and graphics control,
CurveByPoints behaves similarly to ModelCurve. The main
difference being that a ModelCurve refers to a SketchPlane,
while a CurveByPoints does not.
For more methods capable of accessing data from CurveByPoints elements, 
see the static class CurveByPointsUtils.

