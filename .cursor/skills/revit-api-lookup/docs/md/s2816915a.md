---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationConnectedLoad(System.Int32,System.Int32)
source: html/e8810150-cc1f-49b0-b663-85f2b2eabc72.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationConnectedLoad Method

Gets the Total Load for given Load Classification

## Syntax (C#)
```csharp
public string GetLoadClassificationConnectedLoad(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row number of Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The total load for the given Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

