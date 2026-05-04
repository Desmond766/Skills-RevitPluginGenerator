---
kind: method
id: M:Autodesk.Revit.DB.Transform1D.Multiply(Autodesk.Revit.DB.Transform1D)
source: html/c4be593d-c2b2-0c86-90e3-a92b8d600552.htm
---
# Autodesk.Revit.DB.Transform1D.Multiply Method

Multiplies this transformation by the specified transformation and returns the result.

## Syntax (C#)
```csharp
public Transform1D Multiply(
	Transform1D right
)
```

## Parameters
- **right** (`Autodesk.Revit.DB.Transform1D`) - The input transformation.

## Returns
The transformation equal to the composition of the two transformations.

## Remarks
The combined transformation has the same effect as applying the input transformation first, and this transformation, second. So, (T1(T2(p)) = (T1 * T2) (p).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

