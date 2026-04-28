---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.AddSpace(System.Int32,System.Int32)
source: html/6402484c-2986-c20e-722c-5d95edcbd316.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.AddSpace Method

Add a space at specific cell.

## Syntax (C#)
```csharp
public void AddSpace(
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

