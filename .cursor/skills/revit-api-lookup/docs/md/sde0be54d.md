---
kind: method
id: M:Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCombinedParamValue(Autodesk.Revit.DB.SectionType,System.Int32,System.Int32)
source: html/84113ab7-3fb6-8d69-a650-e5b77ec82d2e.htm
---
# Autodesk.Revit.DB.Electrical.PanelScheduleView.GetCombinedParamValue Method

Returns the combined parameter text for instance view

## Syntax (C#)
```csharp
public string GetCombinedParamValue(
	SectionType sectionType,
	int nRow,
	int nCol
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - Section type
- **nRow** (`System.Int32`) - Row Number
- **nCol** (`System.Int32`) - Column Number

## Returns
The combined parameter text

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

