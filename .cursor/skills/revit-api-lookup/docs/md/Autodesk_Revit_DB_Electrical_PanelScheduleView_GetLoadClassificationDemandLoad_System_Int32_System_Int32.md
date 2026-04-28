---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationDemandLoad(System.Int32,System.Int32)
source: html/107453a8-fb72-1bdc-e4e5-857bfa41e4ab.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationDemandLoad Method

Gets the Demand Load for given Load Classification

## Syntax (C#)
```csharp
public string GetLoadClassificationDemandLoad(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row number of Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The Demand Load for the Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

