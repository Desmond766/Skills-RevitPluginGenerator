---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellType(System.Int32,System.Int32)
source: html/bb3d6a96-14c3-6442-51cd-a086e6f0f90d.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellType Method

Returns a cell's Type and if no Type exists for this cell,
 it would come from the column, or the row, or the section

## Syntax (C#)
```csharp
public CellType GetCellType(
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

