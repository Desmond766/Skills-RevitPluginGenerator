---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarContainerItem.SetHookTypeId(System.Int32,Autodesk.Revit.DB.ElementId)
source: html/9aef5675-a0b7-de1c-01e1-19b8566c79b3.htm
---
# Autodesk.Revit.DB.Structure.RebarContainerItem.SetHookTypeId Method

Set the id of the RebarHookType to be applied to the rebar.

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

