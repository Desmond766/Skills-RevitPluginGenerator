---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.IsBarMatchedWithShapeInReverseOrder(System.Int32)
source: html/4e8d66b4-8a27-200a-e7d5-8cd8bec7c34b.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.IsBarMatchedWithShapeInReverseOrder Method

Checks if the bar at index barPositionIndex it's matched in reversed order with its shape.

## Syntax (C#)
```csharp
public bool IsBarMatchedWithShapeInReverseOrder(
	int barPositionIndex
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).

## Returns
Returns true if the bar is matched in reversed order with its shape, false otherwise.

## Remarks
If this Rebar has Workshop Instructions set to Straight will return false for all barPositionIndex between 0 and (NumberOfBarPositions-1). If this Rebar has Workshop Instructions set to Bent there are different cases:
 All bars are matched exactly with a shape. In this case will return false for all barPositionIndex between 0 and (NumberOfBarPositions-1). All bars are matched in reversed order with a shape. In this case the Rebar will be reversed and will return false for all barPositionIndex between 0 and (NumberOfBarPositions-1). Some bars are matched in reversed order and the others are matched exactly with a shape. For the bars matched in reversed order will return true and for the others will return false

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

