---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationName(System.Int32,System.Int32)
source: html/b7cb0b5c-93d7-b2f5-6052-60944d3d5da0.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationName Method

Gets the name of the Load Classification at the given row/column

## Syntax (C#)
```csharp
public string GetLoadClassificationName(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row Number of the Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The name of the Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

