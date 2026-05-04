---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetHookOrientationAtIndex(System.Int32,System.Int32)
source: html/c2292cbe-0b87-0105-6937-5caaae22955d.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetHookOrientationAtIndex Method

Gets the hook orientation that is applied to this Rebar at the bar with index barPositionIndex at the specified end.

## Syntax (C#)
```csharp
public RebarHookOrientation GetHookOrientationAtIndex(
	int barPositionIndex,
	int end
)
```

## Parameters
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).
- **end** (`System.Int32`) - 0 for the start hook, 1 for the end hook.

## Returns
Returns the hook orientation at the specified end.

## Remarks
If this Rebar has Workshop Instructions set to Straight will return the same value for all barPositionIndex between 0 and (NumberOfBarPositions-1). This value will be the same as Rebar.GetHookOrientation(int end). If this Rebar has Workshop Instructions set to Bent there are different cases:
 All bars are matched exactly with a shape. In this case will return the same value for all barPositionIndex between 0 and (NumberOfBarPositions-1). This value will be the same as Rebar.GetHookOrientation(int end). All bars are matched in reversed order with a shape. In this case will return the same value for all barPositionIndex between 0 and (NumberOfBarPositions-1). This value will be the same as Rebar.GetHookOrientation(int end). Some bars are matched in reversed order and the others are matched exactly with a shape. In this case for bars that are matched reversed will return the hook orientation at the opposite end. For the others bars will return the same as Rebar.GetHookOrientation(int end).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
 -or-
 barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].

