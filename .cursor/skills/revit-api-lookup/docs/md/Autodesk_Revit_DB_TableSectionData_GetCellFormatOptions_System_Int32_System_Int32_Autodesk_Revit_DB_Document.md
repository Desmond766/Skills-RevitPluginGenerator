---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.GetCellFormatOptions(System.Int32,System.Int32,Autodesk.Revit.DB.Document)
source: html/2fe87e81-da51-e784-8169-6991a17b4669.htm
---
# Autodesk.Revit.DB.TableSectionData.GetCellFormatOptions Method

Returns a cell's FormatOptions and if no FormatOptions exists for this cell,
 it would come from the column, or the row, or the section.

## Syntax (C#)
```csharp
public FormatOptions GetCellFormatOptions(
	int nRow,
	int nCol,
	Document document
)
```

## Parameters
- **nRow** (`System.Int32`)
- **nCol** (`System.Int32`)
- **document** (`Autodesk.Revit.DB.Document`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given row number nRow is invalid.
 -or-
 The given column number nCol is invalid.
- **Autodesk.Revit.Exceptions.ArgumentNullException** - A non-optional argument was null

