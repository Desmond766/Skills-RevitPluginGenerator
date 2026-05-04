---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.AddSpare(System.Int32,System.Int32)
source: html/ab14ab85-9051-a473-45bf-9c3966b6ef73.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.AddSpare Method

Add a spare at specific cell.

## Syntax (C#)
```csharp
public void AddSpare(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Body.
 -or-
 The given column number nCol is invalid in Body.
 -or-
 There is a circuit at given cell (nRow, nCol) already.

