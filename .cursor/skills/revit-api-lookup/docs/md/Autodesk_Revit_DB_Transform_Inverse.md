---
kind: property
id: P:Autodesk.Revit.DB.Transform.Inverse
zh: 变换
source: html/10b30358-917f-31f3-d17e-24f64d157a68.htm
---
# Autodesk.Revit.DB.Transform.Inverse Property

**中文**: 变换

The inverse transformation of this transformation.

## Syntax (C#)
```csharp
public Transform Inverse { get; }
```

## Remarks
The transformation matrix A is invertible if there exists a transformation matrix B 
such that A*B = B*A = I (identity).

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown when this transformation is not conformal or invertible.

