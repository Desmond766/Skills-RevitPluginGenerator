---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetMovedBarTransform(System.Int32)
zh: 钢筋、配筋
source: html/8db286b5-f16e-2367-7e1f-de58fe5a84b8.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetMovedBarTransform Method

**中文**: 钢筋、配筋

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

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

