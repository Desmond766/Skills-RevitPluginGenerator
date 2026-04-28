---
kind: method
id: M:Autodesk.Revit.DB.Transform2D.GetInverse
source: html/511bce10-cd5b-963e-4f4f-86e2b4e7ed73.htm
---
# Autodesk.Revit.DB.Transform2D.GetInverse Method

Gets the inverse transformation of this transformation.

## Syntax (C#)
```csharp
public Transform2D GetInverse()
```

## Remarks
The transformation matrix A is invertible if there exists a transformation matrix B such that A*B = B*A = I (identity).

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This transformation is not conformal or invertible.

