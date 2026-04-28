---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetHookTypeId(System.Int32,Autodesk.Revit.DB.ElementId)
zh: 钢筋、配筋
source: html/31ce9472-9bf7-3567-eaad-b8b45d587438.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetHookTypeId Method

**中文**: 钢筋、配筋

Set the id of the RebarHookType to be applied to the rebar.
 If an EndTreatmentType is present at the rebar end, it will automatically set to invalidElementId.

## Syntax (C#)
```csharp
public void SetHookTypeId(
	int end,
	ElementId hookTypeId
)
```

## Parameters
- **end** (`System.Int32`) - 0 for the start hook, 1 for the end hook.
- **hookTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of a RebarHookType element, or invalidElementId if
 the rebar should have no hook at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the rebar hook type id hookTypeId is not valid
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.

