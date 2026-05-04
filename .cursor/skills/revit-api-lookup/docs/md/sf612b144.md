---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellType(System.Int32,System.Int32,Autodesk.Revit.DB.CellType)
source: html/f272616d-f9de-d2b5-7055-cedaca81bb43.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellType Method

Sets a cell's Type

## Syntax (C#)
```csharp
public void SetCellType(
	int nRow,
	int nCol,
	CellType type
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)
- **type** (`Autodesk.Revit.DB.CellType`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - A CellType.CustomField can't be set.
 -or-
 The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

