---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationParamValue(Autodesk.Revit.DB.ElementId,System.Int32,System.Int32)
source: html/8ab3592a-8866-cee7-435e-4751e5e69d58.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetLoadClassificationParamValue Method

Gets the load classification parameter value.

## Syntax (C#)
```csharp
public string GetLoadClassificationParamValue(
	ElementId parameterId,
	int nRow,
	int nCol
)
```

## Parameters
- **parameterId** (`Autodesk.Revit.DB.ElementId`) - Parameter Id of the Load Classification
- **nRow** (`System.Int32`) - Row Number of the Load Summary Section
- **nCol** (`System.Int32`) - Column number of Load Summary Section

## Returns
The value of the Load Classification parameter

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid in Summary.
 -or-
 The given column number nCol is invalid in Summary.

