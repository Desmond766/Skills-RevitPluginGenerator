---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.AllowOverrideCellStyle(System.Int32,System.Int32)
source: html/3de51365-3c24-586c-0d0e-2431448ad4c8.htm
---
# Autodesk.Revit.DB.TableSectionData.AllowOverrideCellStyle Method

Identifies if the style can be overridden in the given cell.

## Syntax (C#)
```csharp
public bool AllowOverrideCellStyle(
	int nRow,
	int nCol
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)

## Returns
True if allow to override cell style.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.

