---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellType(System.Int32,Autodesk.Revit.DB.CellType)
source: html/96ec7822-f1c0-4406-7958-58cd5ced1d13.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellType Method

Sets a column's cell type

## Syntax (C#)
```csharp
public void SetCellType(
	int nCol,
	CellType type
)
```

## Parameters
- **nCol** (`System.Int32`)
- **type** (`Autodesk.Revit.DB.CellType`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - A CellType.CustomField can't be set.
 -or-
 The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentOutOfRangeException** - A value passed for an enumeration argument is not a member of that enumeration
- **Autodesk.Revit.Exceptions.InvalidOperationException** - This operation is forbidden for cells in standard schedule body sections.

