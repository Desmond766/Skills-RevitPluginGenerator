---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationDemandCurrent(System.Int32,System.Int32)
source: html/fd72877e-c266-4081-b03b-f68be0e0ef87.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationDemandCurrent Method

Gets the Demand Current for given Load Classification

## Syntax (C#)
```csharp
public string GetLoadClassificationDemandCurrent(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row number of Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The Demand Current for the given Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

