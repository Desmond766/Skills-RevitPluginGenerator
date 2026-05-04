---
kind: method
id: M:Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetReportedShape(Autodesk.Revit.DB.ElementId)
source: html/3f015caf-7844-ab56-c962-9020b141e0d2.htm
---
# Autodesk.Revit.DB.Structure.RebarFreeFormAccessor.SetReportedShape Method

This method changes the RebarShape of a Free Form Rebar that is using RebarWorkInstructions.Straight property to the provided RebarShape.

## Syntax (C#)
```csharp
public void SetReportedShape(
	ElementId rebarShapeId
)
```

## Parameters
- **rebarShapeId** (`Autodesk.Revit.DB.ElementId`)

## Remarks
The Rebar element RebarWorkInstructions property should be Straight.
 The rebarShapeId parameter should be the id of a straight RebarShape (single straight segment, no RebarHookType, no EndTreatmentType).
 Moreover the straight RebarShape RebarStyle should match ( if the current RebarShape RebarStyle is Standard then the RebarShape cannot be changed to a straigh RebarShape using the RebarStyle Stirrup/Tie ).
 If current RebarShape and the provided rebarShapeId has Stirrup/Tie RebarStyle then also the StirrupTieAttachmentType should match ( both InteriorFace or ExteriorFace ).

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - rebarShapeId cannot be set as a reporting RebarShape for this Rebar element.

