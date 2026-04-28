---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetApparentPhaseValue(Autodesk.Revit.DB.ElementId,Autodesk.Revit.DB.ElementId)
source: html/dcc2ccdd-f1c6-1eec-aed2-4824c5355280.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetApparentPhaseValue Method

Gets the apparent load for the given phase for the given slotted circuit

## Syntax (C#)
```csharp
public double GetApparentPhaseValue(
	ElementId circuitId,
	ElementId apparentLoadParam
)
```

## Parameters
- **circuitId** (`Autodesk.Revit.DB.ElementId`) - Circuit id for the apparent phase value
- **apparentLoadParam** (`Autodesk.Revit.DB.ElementId`) - The requested apparent load phase parameter

## Returns
The value of the apparent phase

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

