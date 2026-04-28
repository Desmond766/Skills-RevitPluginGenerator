---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.ResetCellOverride(System.Int32,System.Int32)
source: html/9130456a-7982-116d-a48c-0e2ecb1045d1.htm
---
# Autodesk.Revit.DB.TableSectionData.ResetCellOverride Method

Resets the override of the cell.

## Syntax (C#)
```csharp
public void ResetCellOverride(
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
 -or-
 Only allow to override cell style for header section or column header in body section.

