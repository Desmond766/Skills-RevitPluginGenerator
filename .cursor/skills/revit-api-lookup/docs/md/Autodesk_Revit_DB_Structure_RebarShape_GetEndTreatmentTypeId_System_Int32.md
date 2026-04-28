---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.GetEndTreatmentTypeId(System.Int32)
source: html/d78defed-af7e-8feb-6e71-2c067fcc3397.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.GetEndTreatmentTypeId Method

Gets the id of the EndTreatmentType at the specified rebar shape end.

## Syntax (C#)
```csharp
public ElementId GetEndTreatmentTypeId(
	int iEnd
)
```

## Parameters
- **iEnd** (`System.Int32`) - 0 for the start end treatment, 1 for the end end treatment.

## Returns
Returns the id of an EndTreatmentType, or invalidElementId if the rebar shape has no end treatment at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iEnd not a valid shape end

