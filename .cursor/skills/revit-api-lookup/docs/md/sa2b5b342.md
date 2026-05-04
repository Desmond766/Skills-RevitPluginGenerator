---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.ResetMovedBarTransform(System.Int32)
zh: 钢筋、配筋
source: html/5e2e7166-d294-88a3-5b03-1d38ce930546.htm
---
# Autodesk.Revit.DB.Structure.Rebar.ResetMovedBarTransform Method

**中文**: 钢筋、配筋

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

