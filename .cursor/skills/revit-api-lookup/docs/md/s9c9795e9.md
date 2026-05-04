---
kind: method
id: M:Autodesk.Revit.DB.RepeaterCoordinates.GetCoordinate(System.Int32)
source: html/2ba9cdf1-8315-bbf5-9670-13dfe9ddea35.htm
---
# Autodesk.Revit.DB.RepeaterCoordinates.GetCoordinate Method

Returns the coordinate in the given dimension.

## Syntax (C#)
```csharp
public int GetCoordinate(
	int dimension
)
```

## Parameters
- **dimension** (`System.Int32`) - The dimension.

## Returns
The coordinate.

## Remarks
The dimension begins at 0 and must be in the range [0, number of dimensions in the bounds - 1].
 This method does not apply to zero dimensional coordinates.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The dimension is invalid for these coordinates.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The coordinates must have at least one dimension.

