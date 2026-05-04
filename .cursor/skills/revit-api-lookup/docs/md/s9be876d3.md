---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetHookPlaneNormalForBarIdx(System.Int32,System.Int32)
source: html/b6111921-8664-832f-a7c4-e647e7db296e.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.GetHookPlaneNormalForBarIdx Method

Returns the normal of plane in which the hook at end of bar with index barPositionIndex will stay.

## Syntax (C#)
```csharp
public XYZ GetHookPlaneNormalForBarIdx(
	int end,
	int barPositionIndex
)
```

## Parameters
- **end** (`System.Int32`) - The end of bar. Should be 0 for start or 1 for end.
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).

## Returns
The normal of plane in which the hook at end of bar with index barPositionIndex will stay.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].
 -or-
 Invalid end.

