---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetMergedCell(System.Int32,System.Int32,Autodesk.Revit.DB.TableMergedCell)
source: html/c53502f5-75cb-6f5c-9b5e-1bc05f67fcaf.htm
---
# Autodesk.Revit.DB.TableSectionData.SetMergedCell Method

Sets the merged cell that this cell is a part of.

## Syntax (C#)
```csharp
public void SetMergedCell(
	int nRow,
	int nCol,
	TableMergedCell mergedCell
)
```

## Parameters
- **nRow** (`System.Int32`) - The cell row.
- **nCol** (`System.Int32`) - The cell column.
- **mergedCell** (`Autodesk.Revit.DB.TableMergedCell`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 The given TableMergedCell mergedCell is outside of acceptable range.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

