---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetCellStyle(System.Int32,System.Int32,Autodesk.Revit.DB.TableCellStyle)
source: html/b737baa4-a7a8-0c71-9d3f-b246431743dd.htm
---
# Autodesk.Revit.DB.TableSectionData.SetCellStyle Method

Sets a cell's style

## Syntax (C#)
```csharp
public void SetCellStyle(
	int nRow,
	int nCol,
	TableCellStyle Style
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)
- **Style** (`Autodesk.Revit.DB.TableCellStyle`)

## Remarks
For standard schedule, must set the TableCellStyleOverrideOptions in the TableCellStyle to override this cell.
 The global base format controls any non-overridden characteristics of this cell.

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
 -or-
 Only allow to override cell style for header section or column header in body section.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

