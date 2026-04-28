---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetParamValue(Autodesk.Revit.DB.SectionType,System.Int32,System.Int32)
source: html/8fcec8d8-5d79-9a53-3d03-838efc3e7400.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetParamValue Method

Gets the cell's text based on its type

## Syntax (C#)
```csharp
public string GetParamValue(
	SectionType sectionType,
	int nRow,
	int nCol
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - Section of the desired parameter value
- **nRow** (`System.Int32`) - Row Number of the Section
- **nCol** (`System.Int32`) - Column Number of the Section

## Returns
The cell's text

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 Thrown if there is no parameter at this cell
 -or-
 A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - Thrown if attempt to call on a template

