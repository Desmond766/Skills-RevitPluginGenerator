---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellText(System.Int32,System.Int32)
source: html/c3459397-26e5-0784-e247-6b5d27503bb7.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellText Method

Returns the text shown by this cell, if the cell's type is CellType.Text or CellType.ParameterText or CellType.CustomField.

## Syntax (C#)
```csharp
public string GetCellText(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - The cell row.
- **nCol** (`System.Int32`) - The cell column.

## Returns
The text in the cell, or an empty string if the type if not CellType.Text or CellType.ParameterText or CellType.CustomField.

## Remarks
For standard view schedules, to read the formatted text of the cell regardless of cell type,
 use [!:Autodesk::Revit::DB::ViewSchedule::GetCellText()] .

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

