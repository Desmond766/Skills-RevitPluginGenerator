---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.SetHookPlaneNormalForBarIdx(System.Int32,System.Int32,Autodesk.Revit.DB.XYZ)
source: html/e639b633-d0c2-3913-dad4-ad9fde83fc32.htm
---
# Autodesk.Revit.DB.Structure.RebarUpdateCurvesData.SetHookPlaneNormalForBarIdx Method

Set the normal of plane in which the hook at end of bar with index barPositionIndex will stay. This information is set to the rebar after the API execution is finished successfully.

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
- **barPositionIndex** (`System.Int32`) - Index of the bar for which it will set hook plane normal.
- **hookNormal** (`Autodesk.Revit.DB.XYZ`) - The normal of plane in which the hook at end of bar with index barPositionIndex will stay.

## Remarks
This information is set to the rebar after the API execution is finished successfully. Before setting the value a validation will be done.
 We consider a hook plane normal valid if it isn't parallel with the bar direction at end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - Invalid end.
 -or-
 hookNormal has zero length.

