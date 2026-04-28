---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.GetInverse
source: html/823f8360-6333-6449-a748-ad5c58aa4149.htm
---
# Autodesk.Revit.DB.Transform1D.GetInverse Method

Gets the inverse transformation of this transformation.

## Syntax (C#)
```csharp
public Transform1D GetInverse()
```

## Remarks
The transformation matrix A is invertible if there exists a transformation matrix B such that A*B = B*A = I (identity).

## Exceptions
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This transformation is singular.

