---
kind: method
id: M:Autodesk.Revit.DB.RepeaterBounds.AdjustForCyclicalBounds(Autodesk.Revit.DB.RepeaterCoordinates)
source: html/9cbf97b3-28f6-3479-044f-a7ec0419192b.htm
---
# Autodesk.Revit.DB.RepeaterBounds.AdjustForCyclicalBounds Method

Shifts the input coordinates in the cyclical dimensions so that they fall in the [lower bounds, upper bounds] range.

## Syntax (C#)
```csharp
public RepeaterCoordinates AdjustForCyclicalBounds(
	RepeaterCoordinates coordinates
)
```

## Parameters
- **coordinates** (`Autodesk.Revit.DB.RepeaterCoordinates`) - The coordinates.

## Returns
The adjusted coordinates.

## Remarks
The coordinates must have the same number of dimensions as the bounds.
 This method does not apply to zero dimensional bounds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The coordinates coordinates have incompatible number of dimensions.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The bounds must have at least one dimension.

