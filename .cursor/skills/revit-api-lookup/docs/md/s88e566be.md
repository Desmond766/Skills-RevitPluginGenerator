---
kind: method
id: M:Autodesk.Revit.DB.Structure.Rebar.SetEndTreatmentTypeId(System.Int32,Autodesk.Revit.DB.ElementId)
zh: 钢筋、配筋
source: html/ceb68db2-2053-5911-3318-da05ec742dac.htm
---
# Autodesk.Revit.DB.Structure.Rebar.SetEndTreatmentTypeId Method

**中文**: 钢筋、配筋

Sets the id of the EndTreatmentType to be applied to the rebar.
 This can be done if and only if the end of the bar on which the end treatment is applied has no RebarCoupler on it, otherwise will throw an exception.
 If a RebarHookType is present at the rebar end, it will automatically set to invalidElementId.

## Syntax (C#)
```csharp
public void SetEndTreatmentTypeId(
	int end,
	ElementId endTreatmentTypeId
)
```

## Parameters
- **end** (`System.Int32`) - 0 for the start end treatment, 1 for the end end treatment.
- **endTreatmentTypeId** (`Autodesk.Revit.DB.ElementId`) - The id of a EndTreatmentType element, or invalidElementId if
 the rebar should have no end treatment at the specified end.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - the parameter endTreatmentTypeId is not an EndTreatmentType element.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - end must be 0 or 1.
- **Autodesk.Revit.Exceptions.InvalidOperationException** - the Rebar end end has a RebarCoupler on it.

