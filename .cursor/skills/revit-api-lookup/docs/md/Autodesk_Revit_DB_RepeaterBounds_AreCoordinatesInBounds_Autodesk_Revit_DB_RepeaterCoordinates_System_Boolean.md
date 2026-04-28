---
kind: method
id: M:Autodesk.Revit.DB.RepeaterBounds.AreCoordinatesInBounds(Autodesk.Revit.DB.RepeaterCoordinates,System.Boolean)
source: html/66edda4f-79f3-30d7-f485-3e8a1ec33da4.htm
---
# Autodesk.Revit.DB.RepeaterBounds.AreCoordinatesInBounds Method

Determines whether given coordinates are within the bounds.

## Syntax (C#)
```csharp
public bool AreCoordinatesInBounds(
	RepeaterCoordinates coordinates,
	bool treatCyclicalBoundsAsInfinite
)
```

## Parameters
- **coordinates** (`Autodesk.Revit.DB.RepeaterCoordinates`) - The coordinates.
- **treatCyclicalBoundsAsInfinite** (`System.Boolean`) - True if cyclical directions should be treated as unbounded.

## Returns
True if the coordinates are within the bounds.

## Remarks
The coordinates must have the same number of dimensions as the bounds.
 This method does not apply to zero dimensional bounds.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The coordinates coordinates have incompatible number of dimensions.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - The bounds must have at least one dimension.

