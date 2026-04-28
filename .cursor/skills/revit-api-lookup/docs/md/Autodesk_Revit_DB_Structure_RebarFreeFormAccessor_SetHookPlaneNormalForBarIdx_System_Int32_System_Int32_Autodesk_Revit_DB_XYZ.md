---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetHookPlaneNormalForBarIdx(System.Int32,System.Int32,Autodesk.Revit.DB.XYZ)
source: html/1e594f7a-4db8-1a90-dec7-8787008dc934.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetHookPlaneNormalForBarIdx Method

Set the normal of plane in which the hook at end of bar with index barPositionIndex will stay. Will throw exception if the rebar has valid constraints.

## Syntax (C#)
```csharp
public void SetHookPlaneNormalForBarIdx(
	int end,
	int barPositionIndex,
	XYZ hookNormal
)
```

## Parameters
- **end** (`System.Int32`) - The end of bar. Should be 0 for start or 1 for end.
- **barPositionIndex** (`System.Int32`) - An index between 0 and (NumberOfBarPositions-1).
- **hookNormal** (`Autodesk.Revit.DB.XYZ`) - The normal of plane in which the hook at end of bar with index barPositionIndex will stay.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - Normal hookNormal for end end isn't a valid normal for bar with index barPositionIndex
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - barPositionIndex is not in the range [ 0, NumberOfBarPositions-1 ].
 -or-
 Invalid end.
 -or-
 hookNormal has zero length.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This RebarFreeFormAccessor Rebar is constrained.

