---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCircuitByCell(System.Int32,System.Int32)
source: html/cb09df9c-a670-ac4d-d9b6-111641a99c03.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCircuitByCell Method

Gets the circuit element for the given slot number

## Syntax (C#)
```csharp
public ElectricalSystem GetCircuitByCell(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number of the Body Section
- **nCol** (`System.Int32`) - Column Number of the Body Section

## Returns
The circuit found at the given row and column

