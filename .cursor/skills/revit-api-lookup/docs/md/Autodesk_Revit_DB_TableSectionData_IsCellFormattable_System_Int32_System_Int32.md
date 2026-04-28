---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.IsCellFormattable(System.Int32,System.Int32)
source: html/21f339ad-df02-6548-92d5-189ee22c8669.htm
---
# Autodesk.Revit.DB.TableSectionData.IsCellFormattable Method

Determines whether the cell is formattable or not

## Syntax (C#)
```csharp
public bool IsCellFormattable(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - The row index of the cell
- **nCol** (`System.Int32`) - The column index of the cell

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

