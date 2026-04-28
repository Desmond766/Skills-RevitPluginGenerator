---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellCategoryId(System.Int32,System.Int32)
source: html/9b101143-5563-663e-8720-6ece0b5c60c0.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellCategoryId Method

Returns a cell's CategoryId and if no CategoryId exists for this cell,
 it would come from the column.
 Associated with the paramId to find the correct element.

## Syntax (C#)
```csharp
public ElementId GetCellCategoryId(
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

