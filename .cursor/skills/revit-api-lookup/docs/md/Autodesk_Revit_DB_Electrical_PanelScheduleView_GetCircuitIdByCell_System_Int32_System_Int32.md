---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCircuitIdByCell(System.Int32,System.Int32)
source: html/a71fd35c-6945-fadd-40b8-1db70844b440.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCircuitIdByCell Method

Gets the circuit id for the given slot number

## Syntax (C#)
```csharp
public ElementId GetCircuitIdByCell(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Returns
ElementId of the circuit found at the given row and column

