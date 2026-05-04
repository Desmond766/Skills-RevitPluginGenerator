---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.GetEndTreatmentTypeId(System.Int32)
zh: 钢筋、配筋
source: html/3521d0c8-5746-6dde-4839-3e9a14dbd93e.htm
---
# Autodesk.Revit.DB.Structure.Rebar.GetEndTreatmentTypeId Method

**中文**: 钢筋、配筋

Get the id of the EndTreatmentType to be applied to the rebar.

## Syntax (C#)
```csharp
public ElementId GetEndTreatmentTypeId(
	int end
)
```

## Parameters
- **end** (`System.Int32`) - 0 for the start end treatment, 1 for the end end treatment.

## Returns
The id of a EndTreatmentType, or invalidElementId if the rebar has
 no end treatment at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.

