---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.GetMovedBarTransform(System.Int32)
source: html/2566be75-c675-6b5d-ed4b-3ff30a2ad7c4.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.GetMovedBarTransform Method

Returns a transform representing the movement of the bar relative to its default position along the distribution path.

## Syntax (C#)
```csharp
public Transform GetMovedBarTransform(
	int barPositionIndex
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - The bar index.

## Returns
The transform representing the movement of the bar relative to its default position along the distribution path.

## Remarks
For a RebarInSystem for which individual bars can't be edited (the ones owned by AreaReinforcement) the identity transform is returned.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

