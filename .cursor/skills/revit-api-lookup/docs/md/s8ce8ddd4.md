---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarInSystem.GetHookTypeId(System.Int32)
source: html/3365b4f5-7a75-d891-8a3b-6ecb922d3ff2.htm
---
# Autodesk.Revit.DB.Structure.RebarInSystem.GetHookTypeId Method

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

