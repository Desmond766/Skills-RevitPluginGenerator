---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetTableCellStyle(System.Int32,System.Int32)
source: html/ba47a22c-f50c-9a53-8a82-0ccc2f86aac5.htm
---
# Autodesk.Revit.DB.TableSectionData.GetTableCellStyle Method

Returns a cell's style and if no style exists for this cell,
 it would come from the column, or the section

## Syntax (C#)
```csharp
public TableCellStyle GetTableCellStyle(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

