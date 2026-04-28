---
kind: method
id: M:Autodesk.Revit.DB.TableView.GetCalculatedValueName(Autodesk.Revit.DB.SectionType,System.Int32,System.Int32)
source: html/42fa111f-c7a2-e8b0-7d57-db0e1cf7719b.htm
---
# Autodesk.Revit.DB.TableView.GetCalculatedValueName Method

Gets the calculated value name for a cell from the template view.

## Syntax (C#)
```csharp
public string GetCalculatedValueName(
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
The name of the calculated value.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The sectionType is not a valid type for this view.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - The given row number row is invalid.
 -or-
 The given column number column is invalid.
 -or-
 A value passed for an enumeration argument is not a member of that enumeration

