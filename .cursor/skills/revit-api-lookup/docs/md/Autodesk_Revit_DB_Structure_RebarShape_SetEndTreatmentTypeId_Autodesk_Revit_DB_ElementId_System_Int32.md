---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarShape.SetEndTreatmentTypeId(Autodesk.Revit.DB.ElementId,System.Int32)
source: html/f7c875ee-c66f-e08b-78e2-ad40b0d83ea4.htm
---
# Autodesk.Revit.DB.Structure.RebarShape.SetEndTreatmentTypeId Method

Sets the EndTreatmentType id at the specified rebar shape end.

## Syntax (C#)
```csharp
public void SetEndTreatmentTypeId(
	ElementId endTreatmentId,
	int iEnd
)
```

## Parameters
- **endTreatmentId** (`Autodesk.Revit.DB.ElementId`) - The id of an EndTreatmentType element, or invalidElementId if the rebar shape should have no end treatment at the specified end.
- **iEnd** (`System.Int32`) - 0 for the start end treatment, 1 for the end end treatment.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - iEnd not a valid shape end
 -or-
 the parameter endTreatmentId is not an EndTreatmentType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

