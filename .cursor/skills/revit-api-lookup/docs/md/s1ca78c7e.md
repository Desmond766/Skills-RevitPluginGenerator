---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetShapeIdAtIndex(System.Int32)
source: html/79172a28-c9c1-3659-681f-f365ba834f03.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetShapeIdAtIndex Method

Gets the Rebar Shape id for the bar with index barPositionIndex.

## Syntax (C#)
```csharp
public ElementId GetShapeIdAtIndex(
	int barPositionIndex
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).

## Returns
Gets the ElementId of the Rebar Shape for the bar with index barPositionIndex.

## Remarks
If this function is called for a bar that isn't included, this function will throw exception.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].
 -or-
 The bar at barPositionIndex index is excluded.

