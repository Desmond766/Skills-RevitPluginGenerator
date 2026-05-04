---
kind: method
id: M:Autodesk.Revit.DB.TableSectionData.SetColumnWidthInPixels(System.Int32,System.Int32)
source: html/42680b41-24b7-2cc1-0280-49878858b049.htm
---
# Autodesk.Revit.DB.TableSectionData.SetColumnWidthInPixels Method

This sets a column's width in logical pixels

## Syntax (C#)
```csharp
public void SetColumnWidthInPixels(
	int nCol,
	int width
)
```

## Parameters
- **nCol** (`System.Int32`)
- **width** (`System.Int32`)

## Exceptions
- **Autodesk.Revit.Exceptions.ArgumentException** - The given column number nCol is invalid.
 -or-
 The column width is outside of acceptable range.

