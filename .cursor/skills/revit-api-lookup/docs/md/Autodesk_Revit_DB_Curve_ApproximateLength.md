---
kind: property
id: P:Autodesk.Revit.DB.Curve.ApproximateLength
zh: 曲线
source: html/202c6c2c-23cf-aee3-fc9e-24b24a46e293.htm
---
# Autodesk.Revit.DB.Curve.ApproximateLength Property

**中文**: 曲线

The approximate length of the curve.

## Syntax (C#)
```csharp
public double ApproximateLength { get; }
```

## Remarks
Quickly estimates the length of the curve, may deviate by a factor of 2 in some cases.
The computation is exact for lines and arcs.

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when the curve is unbound and not periodic.

