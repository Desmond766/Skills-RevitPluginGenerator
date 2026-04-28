---
kind: method
id: M:Autodesk.Revit.DB.TableView.GetCellText(Autodesk.Revit.DB.SectionType,System.Int32,System.Int32)
source: html/fb43e302-3ba7-a5cd-0ca2-428ec9e6a422.htm
---
# Autodesk.Revit.DB.TableView.GetCellText Method

Gets the cell's text based on its type

## Syntax (C#)
```csharp
public string GetCellText(
	SectionType sectionType,
	int row,
	int column
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The requested section type
- **row** (`System.Int32`) - Row Number in the Section
- **column** (`System.Int32`) - Column Number in the Section

## Returns
The text for the given cell

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sectionType is not a valid type for this view.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number row is invalid.
 -or-
 The given column number column is invalid.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

