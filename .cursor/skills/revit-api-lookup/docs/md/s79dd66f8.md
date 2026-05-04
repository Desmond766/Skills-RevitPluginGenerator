---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetHookOrientation(System.Int32)
zh: 钢筋、配筋
source: html/0aabc992-1723-9f78-aff7-ef9760f8a64b.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetHookOrientation Method

**中文**: 钢筋、配筋

Returns the orientation of the hook plane at the start or at the end of the rebar with respect to the orientation of the first or the last curve and the plane normal.

## Syntax (C#)
```csharp
public RebarHookOrientation GetHookOrientation(
	int iEnd
)
```

## Parameters
- **iEnd** (`System.Int32`) - 0 for the start hook, 1 for the end hook.

## Returns
Value = Right: The hook is on your right as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."
 Value = Left: The hook is on your left as you stand at the end of the bar,
 with the bar behind you, taking the bar's normal as "up."

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - iEnd must be 0 or 1.

