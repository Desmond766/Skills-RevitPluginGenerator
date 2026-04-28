---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationId(System.Int32)
source: html/0818a43a-e096-8959-b470-21c8acb23f68.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationId Method

Gets the id of the associated Load Classification at the given row

## Syntax (C#)
```csharp
public ElementId GetLoadClassificationId(
	int nRow
)
```

## Parameters
- **nRow** (`System.Int32`) - Row number of Load Summary Section

## Returns
The element id of the Load Classification

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.

