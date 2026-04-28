---
kind: method
id: M:Autodesk.Revit.DB.RepeaterBounds.GetUpperBound(System.Int32)
source: html/ed36936e-ea19-b021-04f1-32921cd17313.htm
---
# Autodesk.Revit.DB.RepeaterBounds.GetUpperBound Method

Returns the highest index of the array in the given dimension.

## Syntax (C#)
```csharp
public int GetUpperBound(
	int dimension
)
```

## Parameters
- **dimension** (`System.Int32`) - The dimension.

## Returns
The highest index of the array in the given dimension.

## Remarks
The dimension begins at 0 and must be in the range [0, number of dimensions in the bounds - 1].
 This method does not apply to zero dimensional bounds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The dimension is invalid for these bounds.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The bounds must have at least one dimension.

