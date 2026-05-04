---
kind: method
id: M:Autodesk.Revit.DB.RepeaterBounds.GetLowerBound(System.Int32)
source: html/a7d2526a-92fe-3d1d-9574-0e9bd21c9808.htm
---
# Autodesk.Revit.DB.RepeaterBounds.GetLowerBound Method

Returns the smallest index of the array in the given dimension.

## Syntax (C#)
```csharp
public int GetLowerBound(
	int dimension
)
```

## Parameters
- **dimension** (`System.Int32`) - The dimension.

## Returns
The smallest index of the array in the given dimension.

## Remarks
The dimension begins at 0 and must be in the range [0, number of dimensions in the bounds - 1].
 This method does not apply to zero dimensional bounds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The dimension is invalid for these bounds.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The bounds must have at least one dimension.

