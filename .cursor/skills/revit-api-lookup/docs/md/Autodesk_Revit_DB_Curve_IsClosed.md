---
kind: property
id: P:Autodesk.Revit.DB.Curve.IsClosed
zh: 曲线
source: html/a8297234-87a1-111c-fb24-ba1a9bd1d8a3.htm
---
# Autodesk.Revit.DB.Curve.IsClosed Property

**中文**: 曲线

Describes whether the curve is closed.

## Syntax (C#)
```csharp
public bool IsClosed { get; }
```

## Remarks
A curve is "closed" if it is bounded and its start and end points coincide (to within Revit's 3D tolerance),
or if it is unbounded and periodic.

