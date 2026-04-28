---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetHookTypeId(System.Int32)
zh: 钢筋、配筋
source: html/016d53d9-0ef5-99d1-b12f-089f04df3952.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetHookTypeId Method

**中文**: 钢筋、配筋

Get the id of the RebarHookType to be applied to the rebar.

## Syntax (C#)
```csharp
public ElementId GetHookTypeId(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - 0 for the start hook, 1 for the end hook.

## Returns
The id of a RebarHookType, or invalidElementId if the rebar has
 no hook at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.

