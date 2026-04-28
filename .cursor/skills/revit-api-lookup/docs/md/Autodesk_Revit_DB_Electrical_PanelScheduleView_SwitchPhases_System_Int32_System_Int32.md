---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.SwitchPhases(System.Int32,System.Int32)
source: html/88042b4b-cbe1-95c6-babf-fee553edb451.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.SwitchPhases Method

Switches the circuit phases at the slot.

## Syntax (C#)
```csharp
public void SwitchPhases(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number.
- **nCol** (`System.Int32`) - Column Number.

## Remarks
Only one or two poles circuit on switchboard panel schedule can switch phases.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The circuit at given cell (nRow, nCol) is not one or two poles circuit.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Body.
 -or-
 The given column number nCol is invalid in Body.
 -or-
 There is no circuit at given cell (nRow, nCol).
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This is not a switchboard panel schedule.

