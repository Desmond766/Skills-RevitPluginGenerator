---
kind: method
id: M:Autodesk.Revit.DB.Element.ArePhasesModifiable
zh: 构件、图元、元素
source: html/329b02eb-5ee4-1715-2fbf-2cbbc0d3ff2a.htm
---
# Autodesk.Revit.DB.Element.ArePhasesModifiable Method

**中文**: 构件、图元、元素

Returns true if the properties CreatedPhaseId and DemolishedPhaseId can be modified for this Element.

## Syntax (C#)
```csharp
public bool ArePhasesModifiable()
```

## Returns
True if the properties CreatedPhaseId and DemolishedPhaseId can be modified for this Element, false otherwise.

## Remarks
Acts as a validator for setting the properties CreatedPhaseId and DemolishedPhaseId.

