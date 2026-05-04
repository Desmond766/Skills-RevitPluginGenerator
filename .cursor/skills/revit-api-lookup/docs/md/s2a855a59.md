---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.IsSlotLocked(System.Int32,System.Int32)
source: html/8efe6f9b-7648-ebae-a328-9139bfaec2dd.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.IsSlotLocked Method

Check if the circuit slot in this cell is locked.

## Syntax (C#)
```csharp
public bool IsSlotLocked(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Returns
True if the circuit slot in this cell is locked, false otherwise
 False if the circuit slot not found.

