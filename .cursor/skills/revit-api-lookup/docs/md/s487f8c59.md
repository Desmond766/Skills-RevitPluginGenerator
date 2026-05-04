---
kind: method
id: M:Autodesk.Revit.DB.Curve.MakeUnbound
zh: 曲线
source: html/31ef6a2e-0e39-a394-b6ee-4e4df56d8380.htm
---
# Autodesk.Revit.DB.Curve.MakeUnbound Method

**中文**: 曲线

Makes this curve unbound.

## Syntax (C#)
```csharp
public void MakeUnbound()
```

## Remarks
If the curve is marked as read-only (because it was extracted directly from
a Revit element or collection/aggregation object), calling this method
causes the object to be changed to carry a disconnected copy of the original curve. The
modification will not affect the original curve or the object that supplied it.

