---
kind: method
id: M:Autodesk.Revit.DB.RepeaterBounds.IsCyclical(System.Int32)
source: html/d5d3a8b0-62bc-6783-3d96-b11564f6ebb6.htm
---
# Autodesk.Revit.DB.RepeaterBounds.IsCyclical Method

True if the array doesn't have finite bounds in the given dimension. Cyclical bounds indicate that the array forms a closed loop in the given dimension.

## Syntax (C#)
```csharp
public bool IsCyclical(
	int dimension
)
```

## Parameters
- **dimension** (`System.Int32`) - The dimension.

## Returns
True if the bounds are cyclical in the given dimension.

## Remarks
The dimension begins at 0 and must be in the range [0, number of dimensions in the bounds - 1].
 This method does not apply to zero dimensional bounds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The dimension is invalid for these bounds.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The bounds must have at least one dimension.

