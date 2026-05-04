---
kind: method
id: M:Autodesk.Revit.DB.TableView.GetCalculatedValueText(Autodesk.Revit.DB.SectionType,System.Int32,System.Int32)
source: html/7a18ae01-215e-70a7-ee3b-ebfee6b8e3a8.htm
---
# Autodesk.Revit.DB.TableView.GetCalculatedValueText Method

Gets the calculated value text for a cell from the instance view.

## Syntax (C#)
```csharp
public string GetCalculatedValueText(
	SectionType sectionType,
	int row,
	int column
)
```

## Parameters
- **sectionType** (`Autodesk.Revit.DB.SectionType`) - The section type.
- **row** (`System.Int32`) - The row.
- **column** (`System.Int32`) - The column.

## Returns
The calculated value text.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sectionType is not a valid type for this view.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number row is invalid.
 -or-
 The given column number column is invalid.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

