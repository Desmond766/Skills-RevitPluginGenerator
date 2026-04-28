---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetHookOrientation(System.Int32,Autodesk.Revit.DB.Structure.RebarHookOrientation)
zh: 钢筋、配筋
source: html/d2bb944f-32dd-d6d0-142c-cba3dfd01e5f.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetHookOrientation Method

**中文**: 钢筋、配筋

Defines the orientation of the hook plane at the start or at the end of the rebar with respect to the orientation of the first or the last curve and the plane normal.

## Syntax (C#)
```csharp
public void SetHookOrientation(
	int iEnd,
	RebarHookOrientation hookOrientation
)
```

## Parameters
- **iEnd** (`System.Int32`) - 0 for the start hook, 1 for the end hook.
- **hookOrientation** (`Autodesk.Revit.DB.Structure.RebarHookOrientation`) - Only two values are permitted:
 Value = Right: The hook is on your right as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
 Value = Left: The hook is on your left as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."

## Remarks
If RebarShapeDefinesHooks property of ReinforcementSettings is true (non-European shapes), setHookOrientation method does nothing.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - iEnd must be 0 or 1.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

