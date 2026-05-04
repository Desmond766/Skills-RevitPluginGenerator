---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationConnectedCurrent(System.Int32,System.Int32)
source: html/06f0cab2-01c8-8264-9595-c7797ef57456.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationConnectedCurrent Method

Gets the Total Current for given Load Classification

## Syntax (C#)
```csharp
public string GetLoadClassificationConnectedCurrent(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row number of Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The Connected Current for the given Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

