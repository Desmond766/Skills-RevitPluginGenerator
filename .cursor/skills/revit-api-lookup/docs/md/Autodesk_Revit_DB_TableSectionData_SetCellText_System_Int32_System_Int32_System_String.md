---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellText(System.Int32,System.Int32,System.String)
source: html/1c7a694b-73c0-8d15-7817-5620b6e83098.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellText Method

Sets a cell's to display the specified text.

## Syntax (C#)
```csharp
public void SetCellText(
	int nRow,
	int nCol,
	string text
)
```

## Parameters
- **nRow** (`System.Int32`) - The cell row.
- **nCol** (`System.Int32`) - The cell column.
- **text** (`System.String`) - The text to show in the cell.

## Remarks
If this cell's type is not CellType.Text, and the operation is permitted on this cell, the cell type
 will be changed to type CellType.Text as a result of this call.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

