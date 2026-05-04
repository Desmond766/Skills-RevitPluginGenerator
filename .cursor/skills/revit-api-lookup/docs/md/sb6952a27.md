---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationDemandFactor(System.Int32,System.Int32)
source: html/18a83aa5-3266-0095-e778-29ea78f602d1.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationDemandFactor Method

Gets the Demand Factor for given Load Classification

## Syntax (C#)
```csharp
public string GetLoadClassificationDemandFactor(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - Row number of Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The Demand Factor for the given Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

