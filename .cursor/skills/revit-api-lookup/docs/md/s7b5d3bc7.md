---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetHookPlaneNormalForBarIdx(System.Int32,System.Int32)
source: html/ff212171-e964-2045-42f8-1519762cff43.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.GetHookPlaneNormalForBarIdx Method

Returns the normal of plane in which the hook at end of bar with index barPositionIndex that is currently in Rebar.

## Syntax (C#)
```csharp
public XYZ GetHookPlaneNormalForBarIdx(
	int end,
	int barPositionIndex
)
```

## Parameters
- **end** (`System.Int32`) - The end of bar. Should be 0 for start or 1 for end.
- **barPositionIndex** (`System.Int32`) - An index between 0 and (GetNumberOfBars()-1).

## Returns
The normal of plane in which the hook at end of bar with index barPositionIndex that is currently in Rebar.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, GetNumberOfBars()-1 ].
 -or-
 Invalid end.

