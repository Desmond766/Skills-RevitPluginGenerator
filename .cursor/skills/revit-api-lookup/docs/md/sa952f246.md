---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.ResetMovedBarTransform(System.Int32)
source: html/1597340c-e5cc-3aec-4801-19a03b1ba487.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.ResetMovedBarTransform Method

Reset the transformation representing the movement of the bar relative to its default position along the distribution path.
 The moved bar transform will be set to Identity.

## Syntax (C#)
```csharp
public void ResetMovedBarTransform(
	int barPositionIndex
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - The bar index.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].
- **Autodesk.Revit.Exceptions.InapplicableDataException** - For this RebarInSystem element individual bars can't be moved, excluded or included.

