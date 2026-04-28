---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetMergedCell(System.Int32,System.Int32)
source: html/178b4731-d49d-9315-b9fc-cb2b6334a408.htm
---
# Autodesk.Revit.DB.TableSectionData.GetMergedCell Method

Gets the whole merged cell that this cell is a part of.

## Syntax (C#)
```csharp
public TableMergedCell GetMergedCell(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`) - The cell row.
- **nCol** (`System.Int32`) - The cell column.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

