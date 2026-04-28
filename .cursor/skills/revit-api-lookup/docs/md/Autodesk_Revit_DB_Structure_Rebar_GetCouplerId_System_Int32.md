---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetCouplerId(System.Int32)
zh: 钢筋、配筋
source: html/72b65231-27d4-79b2-1193-136bab814951.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetCouplerId Method

**中文**: 钢筋、配筋

Get the id of the Rebar Coupler that is applied to the rebar at the specified end.

## Syntax (C#)
```csharp
public ElementId GetCouplerId(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - 0 for the start Rebar Coupler, 1 for the end Rebar Coupler.

## Returns
The id of a Rebar Coupler, or invalidElementId if the rebar has
 no Rebar Coupler at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.

